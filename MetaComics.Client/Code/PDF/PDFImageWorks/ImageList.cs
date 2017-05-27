using System.Collections.Generic;
using System.IO;
using System.Timers;

namespace DevWilson
{
    internal class ImageList : List<ImageFileAttributes>
    {
        private readonly string filePath;
        private readonly object syncRoot = new object();
        private Timer saveTimer;

        public ImageList(string filePath)
        {
            this.filePath = filePath;
        }

        public void Load()
        {
            if (File.Exists(filePath))
            {
                lock (syncRoot)
                {
                    if (saveTimer != null)
                    {
                        saveTimer.Stop();
                        saveTimer = null;
                    }
                    ImageListToXml.LoadFromXml(filePath, this);
                }
            }
        }

        public void Save()
        {
            lock (syncRoot)
            {
                if (saveTimer == null || !saveTimer.Enabled)
                {
                    saveTimer = new Timer(5000);
                    saveTimer.Elapsed += saveTimer_Elapsed;
                    saveTimer.AutoReset = false;
                    saveTimer.Start();
                }
            }
        }

        public List<ImageFileAttributes> Clone()
        {
            lock (syncRoot)
            {
                return new List<ImageFileAttributes>(this);
            }
        }

        private void saveTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            string folderPath = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            lock (syncRoot)
            {
                ImageListToXml.SaveAsXml(filePath, this);
            }
        }
    }
}