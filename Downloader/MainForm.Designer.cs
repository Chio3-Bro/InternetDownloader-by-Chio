namespace Downloader
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            folderBrowserDialog1 = new FolderBrowserDialog();
            groupBox1 = new GroupBox();
            btn_Start_New = new Button();
            label3 = new Label();
            numericUpDown1 = new NumericUpDown();
            btn_Browse_Path = new Button();
            label2 = new Label();
            txt_Final_Path = new TextBox();
            label1 = new Label();
            txt_URL = new TextBox();
            groupBox2 = new GroupBox();
            btn_Resume = new Button();
            btn_Cancel = new Button();
            btn_Pause = new Button();
            groupBox3 = new GroupBox();
            dgV_Downloads = new DataGridView();
            Id = new DataGridViewTextBoxColumn();
            Url = new DataGridViewTextBoxColumn();
            FileName = new DataGridViewTextBoxColumn();
            Status = new DataGridViewTextBoxColumn();
            Progress = new DataGridViewTextBoxColumn();
            ThreadCount = new DataGridViewTextBoxColumn();
            Tags = new DataGridViewTextBoxColumn();
            BytesTotal = new DataGridViewTextBoxColumn();
            BytesDownloaded = new DataGridViewTextBoxColumn();
            contextMenuStrip1 = new ContextMenuStrip(components);
            renameToolStripMenuItem = new ToolStripMenuItem();
            deleteToolStripMenuItem = new ToolStripMenuItem();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgV_Downloads).BeginInit();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btn_Start_New);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(numericUpDown1);
            groupBox1.Controls.Add(btn_Browse_Path);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txt_Final_Path);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txt_URL);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(445, 238);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Download options";
            // 
            // btn_Start_New
            // 
            btn_Start_New.Location = new Point(261, 194);
            btn_Start_New.Name = "btn_Start_New";
            btn_Start_New.Size = new Size(178, 31);
            btn_Start_New.TabIndex = 7;
            btn_Start_New.Text = "Start new download";
            btn_Start_New.UseVisualStyleBackColor = true;
            btn_Start_New.Click += btn_Start_New_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 173);
            label3.Name = "label3";
            label3.Size = new Size(145, 21);
            label3.TabIndex = 6;
            label3.Text = "Number of threads:";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(6, 197);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(145, 29);
            numericUpDown1.TabIndex = 5;
            // 
            // btn_Browse_Path
            // 
            btn_Browse_Path.Location = new Point(343, 125);
            btn_Browse_Path.Name = "btn_Browse_Path";
            btn_Browse_Path.Size = new Size(96, 29);
            btn_Browse_Path.TabIndex = 4;
            btn_Browse_Path.Text = "Browse...";
            btn_Browse_Path.UseVisualStyleBackColor = true;
            btn_Browse_Path.Click += btn_Browse_Path_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 101);
            label2.Name = "label2";
            label2.Size = new Size(162, 21);
            label2.TabIndex = 3;
            label2.Text = "Final destination path:";
            // 
            // txt_Final_Path
            // 
            txt_Final_Path.Location = new Point(6, 125);
            txt_Final_Path.Name = "txt_Final_Path";
            txt_Final_Path.Size = new Size(331, 29);
            txt_Final_Path.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 36);
            label1.Name = "label1";
            label1.Size = new Size(117, 21);
            label1.TabIndex = 1;
            label1.Text = "Download URL:";
            // 
            // txt_URL
            // 
            txt_URL.Location = new Point(6, 60);
            txt_URL.Name = "txt_URL";
            txt_URL.Size = new Size(433, 29);
            txt_URL.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btn_Resume);
            groupBox2.Controls.Add(btn_Cancel);
            groupBox2.Controls.Add(btn_Pause);
            groupBox2.Location = new Point(12, 256);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(445, 362);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Downlooad controls";
            // 
            // btn_Resume
            // 
            btn_Resume.Location = new Point(152, 28);
            btn_Resume.Name = "btn_Resume";
            btn_Resume.Size = new Size(145, 35);
            btn_Resume.TabIndex = 2;
            btn_Resume.Text = "Resume";
            btn_Resume.UseVisualStyleBackColor = true;
            btn_Resume.Click += btn_Resume_Click;
            // 
            // btn_Cancel
            // 
            btn_Cancel.Location = new Point(308, 28);
            btn_Cancel.Name = "btn_Cancel";
            btn_Cancel.Size = new Size(131, 35);
            btn_Cancel.TabIndex = 1;
            btn_Cancel.Text = "Cancel";
            btn_Cancel.UseVisualStyleBackColor = true;
            btn_Cancel.Click += btn_Cancel_Click;
            // 
            // btn_Pause
            // 
            btn_Pause.Location = new Point(6, 28);
            btn_Pause.Name = "btn_Pause";
            btn_Pause.Size = new Size(135, 35);
            btn_Pause.TabIndex = 0;
            btn_Pause.Text = "Pause";
            btn_Pause.UseVisualStyleBackColor = true;
            btn_Pause.Click += btn_Pause_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(dgV_Downloads);
            groupBox3.Location = new Point(463, 12);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(1092, 606);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Downloads";
            // 
            // dgV_Downloads
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgV_Downloads.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgV_Downloads.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgV_Downloads.BackgroundColor = SystemColors.Control;
            dgV_Downloads.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgV_Downloads.Columns.AddRange(new DataGridViewColumn[] { Id, Url, FileName, Status, Progress, ThreadCount, Tags, BytesTotal, BytesDownloaded });
            dgV_Downloads.Dock = DockStyle.Fill;
            dgV_Downloads.Location = new Point(3, 25);
            dgV_Downloads.Name = "dgV_Downloads";
            dgV_Downloads.Size = new Size(1086, 578);
            dgV_Downloads.TabIndex = 0;
            dgV_Downloads.MouseDown += dgV_Downloads_MouseDown;
            // 
            // Id
            // 
            Id.HeaderText = "Id";
            Id.Name = "Id";
            // 
            // Url
            // 
            Url.HeaderText = "Url";
            Url.Name = "Url";
            // 
            // FileName
            // 
            FileName.HeaderText = "FileName";
            FileName.Name = "FileName";
            // 
            // Status
            // 
            Status.HeaderText = "Status";
            Status.Name = "Status";
            // 
            // Progress
            // 
            Progress.HeaderText = "Progress";
            Progress.Name = "Progress";
            // 
            // ThreadCount
            // 
            ThreadCount.HeaderText = "ThreadCount";
            ThreadCount.Name = "ThreadCount";
            // 
            // Tags
            // 
            Tags.HeaderText = "Tags";
            Tags.Name = "Tags";
            // 
            // BytesTotal
            // 
            BytesTotal.HeaderText = "BytesTotal";
            BytesTotal.Name = "BytesTotal";
            // 
            // BytesDownloaded
            // 
            BytesDownloaded.HeaderText = "BytesDownloaded";
            BytesDownloaded.Name = "BytesDownloaded";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { renameToolStripMenuItem, deleteToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.RenderMode = ToolStripRenderMode.Professional;
            contextMenuStrip1.Size = new Size(118, 48);
            // 
            // renameToolStripMenuItem
            // 
            renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            renameToolStripMenuItem.Size = new Size(117, 22);
            renameToolStripMenuItem.Text = "Rename";
            renameToolStripMenuItem.Click += renameToolStripMenuItem_Click;
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new Size(117, 22);
            deleteToolStripMenuItem.Text = "Delete";
            deleteToolStripMenuItem.Click += deleteToolStripMenuItem_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1567, 630);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "MainForm";
            Text = "App Downloader";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgV_Downloads).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private FolderBrowserDialog folderBrowserDialog1;
        private GroupBox groupBox1;
        private Button btn_Start_New;
        private Label label3;
        private NumericUpDown numericUpDown1;
        private Button btn_Browse_Path;
        private Label label2;
        private TextBox txt_Final_Path;
        private Label label1;
        private TextBox txt_URL;
        private GroupBox groupBox2;
        private Button btn_Resume;
        private Button btn_Cancel;
        private Button btn_Pause;
        private GroupBox groupBox3;
        private DataGridView dgV_Downloads;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn Url;
        private DataGridViewTextBoxColumn FileName;
        private DataGridViewTextBoxColumn Status;
        private DataGridViewTextBoxColumn Progress;
        private DataGridViewTextBoxColumn ThreadCount;
        private DataGridViewTextBoxColumn Tags;
        private DataGridViewTextBoxColumn BytesTotal;
        private DataGridViewTextBoxColumn BytesDownloaded;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem renameToolStripMenuItem;
        private ToolStripMenuItem deleteToolStripMenuItem;
    }
}
