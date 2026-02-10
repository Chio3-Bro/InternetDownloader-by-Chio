using Downloader.Models;
using System.ComponentModel;
using System.Text.Json;
using System.Xml.Serialization;

namespace Downloader
{
    public partial class MainForm : Form
    {
        private BindingList<DownloadItem> _downloads = new();
        private int _idCounter = 1;
        private readonly string _saveFile = "downloads.json";

        public MainForm()
        {
            InitializeComponent();
            dgV_Downloads.AutoGenerateColumns = false;
            dgV_Downloads.AllowUserToAddRows = false;
            dgV_Downloads.DataSource = _downloads;
            dgV_Downloads.ContextMenuStrip = contextMenuStrip1;

            Id.DataPropertyName = nameof(DownloadItem.Id);
            Url.DataPropertyName = nameof(DownloadItem.Url);
            FileName.DataPropertyName = nameof(DownloadItem.FileName);
            Status.DataPropertyName = nameof(DownloadItem.Status);
            Progress.DataPropertyName = nameof(DownloadItem.Progress);
            ThreadCount.DataPropertyName = nameof(DownloadItem.ThreadCount);
            Tags.DataPropertyName = nameof(DownloadItem.Tags);
            BytesTotal.DataPropertyName = nameof(DownloadItem.BytesTotal);
            BytesDownloaded.DataPropertyName = nameof(DownloadItem.BytesDownloaded);

            LoadDownloads();
        }
        private void btn_Browse_Path_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txt_Final_Path.Text = folderBrowserDialog1.SelectedPath;
            }
        }
        private async void btn_Start_New_Click(object sender, EventArgs e)
        {
            if (!Uri.IsWellFormedUriString(txt_URL.Text, UriKind.Absolute))
            {
                MessageBox.Show("Invalid URL");
                return;
            }

            var item = new DownloadItem
            {
                Id = _idCounter++,
                Url = txt_URL.Text,
                ThreadCount = (int)numericUpDown1.Value,
                SavePath = txt_Final_Path.Text,
                FileName = Path.GetFileName(txt_URL.Text),
                Status = DownloadStatus.Pending
            };

            _downloads.Add(item);

            _ = Task.Run(() => StartDownloadAsync(item));
        }
        private async Task StartDownloadAsync(DownloadItem item)
        {
            try
            {
                item.Status = DownloadStatus.Active;

                using var client = new HttpClient();
                using var response = await client.GetAsync(
                    item.Url,
                    HttpCompletionOption.ResponseHeadersRead,
                    item.TokenSource.Token);

                response.EnsureSuccessStatusCode();
                item.BytesTotal = response.Content.Headers.ContentLength ?? 0;

                string fullPath = Path.Combine(item.SavePath, item.FileName);

                using var stream = await response.Content.ReadAsStreamAsync();
                using var fs = new FileStream(
                    fullPath,
                    FileMode.Create,
                    FileAccess.Write,
                    FileShare.None,
                    8192,
                    useAsync: true);

                byte[] buffer = new byte[8192];
                int read;
                var lastUpdate = DateTime.MinValue;

                while ((read = await stream.ReadAsync(buffer)) > 0)
                {
                    if (item.IsPaused)
                        await item.PauseSemaphore.WaitAsync(item.TokenSource.Token);

                    item.TokenSource.Token.ThrowIfCancellationRequested();

                    await fs.WriteAsync(buffer, 0, read);
                    item.BytesDownloaded += read;

                    if (item.BytesTotal > 0)
                        item.Progress = Math.Round(
                            (double)item.BytesDownloaded / item.BytesTotal * 100, 2);

                    if ((DateTime.Now - lastUpdate).TotalMilliseconds > 100)
                    {
                        if (dgV_Downloads.IsHandleCreated)
                            dgV_Downloads.BeginInvoke(() => dgV_Downloads.Refresh());
                        lastUpdate = DateTime.Now;
                    }
                }

                item.Status = DownloadStatus.Completed;
            }
            catch (OperationCanceledException)
            {
                item.Status = DownloadStatus.Canceled;
            }
            catch (Exception ex)
            {
                item.Status = DownloadStatus.Failed;
                MessageBox.Show($"Error: {ex}");
            }
            finally
            {
                if (dgV_Downloads.IsHandleCreated)
                    dgV_Downloads.BeginInvoke(() => dgV_Downloads.Refresh());

                SaveDownloads();
            }
        }
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            if (dgV_Downloads.CurrentRow?.DataBoundItem is DownloadItem item)
            {
                item.TokenSource.Cancel();
                item.Status = DownloadStatus.Canceled;
                dgV_Downloads.Refresh();
                SaveDownloads();
            }
        }
        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgV_Downloads.CurrentRow?.DataBoundItem is DownloadItem item)
            {
                string newName = Microsoft.VisualBasic.Interaction.InputBox(
                    "Enter new file name:", "Rename", item.FileName);
                if (string.IsNullOrWhiteSpace(newName)) return;

                string oldPath = Path.Combine(item.SavePath, item.FileName);
                string newPath = Path.Combine(item.SavePath, newName);

                File.Move(oldPath, newPath);
                item.FileName = newName;

                dgV_Downloads.Refresh();
            }
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgV_Downloads.CurrentRow?.DataBoundItem is DownloadItem item)
            {
                string fullPath = Path.Combine(item.SavePath, item.FileName);
                if (File.Exists(fullPath))
                {
                    File.Delete(fullPath);
                }
                _downloads.Remove(item);

                dgV_Downloads.Refresh();
            }
        }
        private void dgV_Downloads_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hit = dgV_Downloads.HitTest(e.X, e.Y);
                if (hit.RowIndex >= 0)
                {
                    dgV_Downloads.ClearSelection();
                    dgV_Downloads.Rows[hit.RowIndex].Selected = true;
                }
            }
        }
        private void btn_Pause_Click(object sender, EventArgs e)
        {
            if (dgV_Downloads.CurrentRow?.DataBoundItem is DownloadItem item &&
                !item.IsPaused)
            {
                item.IsPaused = true;
                item.Status = DownloadStatus.Paused;
                dgV_Downloads.Refresh();
                SaveDownloads();
            }
        }
        private void btn_Resume_Click(object sender, EventArgs e)
        {
            if (dgV_Downloads.CurrentRow?.DataBoundItem is DownloadItem item &&
                item.IsPaused)
            {
                item.IsPaused = false;
                if (item.PauseSemaphore.CurrentCount == 0)
                    item.PauseSemaphore.Release();
                item.Status = DownloadStatus.Active;
                dgV_Downloads.Refresh();
                SaveDownloads();
            }
        }
        private void SaveDownloads()
        {
            var json = JsonSerializer.Serialize(_downloads.ToList(),
                new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText(_saveFile, json);
        }
        private void LoadDownloads()
        {
            if (!File.Exists(_saveFile)) return;

            var json = File.ReadAllText(_saveFile);
            var items = JsonSerializer.Deserialize<List<DownloadItem>>(json);

            if (items == null) return;

            _downloads.Clear();

            foreach (var item in items)
            {
                item.TokenSource = new CancellationTokenSource();
                item.PauseSemaphore = new SemaphoreSlim(1, 1);
                item.IsPaused = item.Status == DownloadStatus.Paused;

                if (item.IsPaused)
                    item.PauseSemaphore.Wait();

                _downloads.Add(item);
            }
        }
    }
}