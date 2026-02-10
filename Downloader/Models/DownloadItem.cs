using Downloader.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Downloader.Models
{
    public enum DownloadStatus
    {
        Pending,
        Active,
        Paused,
        Completed,
        Failed,
        Canceled
    }

    public class DownloadItem
    {
        public int Id { get; set; }
        public string Url { get; set; } = string.Empty;
        public string FileName { get; set; } = string.Empty;
        public string SavePath { get; set; } = string.Empty;
        public DownloadStatus Status { get; set; } = DownloadStatus.Pending;
        public double Progress { get; set; }
        public int ThreadCount { get; set; }
        public List<string> Tags { get; set; } = new List<string>();
        public long BytesTotal { get; set; }
        public long BytesDownloaded { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public CancellationTokenSource TokenSource { get; set; } = new();

        [System.Text.Json.Serialization.JsonIgnore]
        public SemaphoreSlim PauseSemaphore { get; set; } = new(1, 1);

        [System.Text.Json.Serialization.JsonIgnore]
        public bool IsPaused { get; set; } = false;
    }
}