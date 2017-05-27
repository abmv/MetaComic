using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;

namespace DevWilson
{
    public class ImageOrientationThreaded
    {
        private int imagesRemaining;
        public List<string> Landscapes { get; private set; }

        public void GetLandscapeThreaded(List<string> paths)
        {
            Landscapes = new List<string>();
            imagesRemaining = paths.Count;
            foreach (string path in paths)
            {
                // add each path as a task in the thread pool
                ThreadPool.QueueUserWorkItem(ThreadCallback, path);
            }
            // wait until all images have been loaded
            lock (Landscapes)
            {
                Monitor.Wait(Landscapes);
            }
        }

        public bool IsLandscape(string path)
        {
            using (var b = new Bitmap(path))
            {
                return b.Width > b.Height;
            }
        }

        private void ThreadCallback(object stateInfo)
        {
            var path = (string) stateInfo;
            bool isLandscape = IsLandscape(path);
            lock (Landscapes)
            {
                if (isLandscape)
                {
                    Landscapes.Add(path);
                }
                imagesRemaining--;
                if (imagesRemaining == 0)
                {
                    // all images loaded, signal the main thread
                    Monitor.Pulse(Landscapes);
                }
            }
        }

        public void ResizeImage(string OriginalFile, string NewFile, int NewWidth, int MaxHeight, bool OnlyResizeIfWider)
        {
            Image FullsizeImage = Image.FromFile(OriginalFile);
            // Prevent using images internal thumbnail
            FullsizeImage.RotateFlip(RotateFlipType.Rotate180FlipNone);
            FullsizeImage.RotateFlip(RotateFlipType.Rotate180FlipNone);
            if (OnlyResizeIfWider)
            {
                if (FullsizeImage.Width <= NewWidth)
                {
                    NewWidth = FullsizeImage.Width;
                }
            }
            int NewHeight = FullsizeImage.Height*NewWidth/FullsizeImage.Width;
            if (NewHeight > MaxHeight)
            {
                // Resize with height instead
                NewWidth = FullsizeImage.Width*MaxHeight/FullsizeImage.Height;
                NewHeight = MaxHeight;
            }
            Image NewImage = FullsizeImage.GetThumbnailImage(NewWidth, NewHeight, null, IntPtr.Zero);
            // Clear handle to original file so that we can overwrite it if necessary
            FullsizeImage.Dispose();
            // Save resized picture
            NewImage.Save(NewFile);
        }
    }
}