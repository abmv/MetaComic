using System;
using System.Drawing;

namespace DevWilson
{
    public class ImageFileAttributes
    {
        public ImageFileAttributes(string path, Size size)
            : this(path, size, DateTime.MinValue)
        {
        }

        public ImageFileAttributes(string path, Size size, DateTime lastModified)
        {
            Path = path;
            Size = size;
            if (lastModified != DateTime.MinValue)
            {
                LastModified = lastModified;
            }
        }

        public string Path { get; private set; }
        public Size Size { get; private set; }
        public DateTime? LastModified { get; private set; }

        public string DirectoryName
        {
            get { return System.IO.Path.GetDirectoryName(Path); }
        }

        public ImageOrientation Orientation
        {
            get { return Size.Height > Size.Width ? ImageOrientation.Portrait : ImageOrientation.Landscape; }
        }

        public bool IsModified(DateTime lastModified)
        {
            return LastModified == null || LastModified != lastModified;
        }
    }
}