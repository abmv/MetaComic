using System;
using System.Drawing;
using System.Linq;
using System.Xml.Linq;

namespace DevWilson
{
    internal class ImageListToXml
    {
        private const string XmlRoot = "Cache";
        private const string XmlImagePath = "ImagePath";
        private const string XmlWidth = "Width";
        private const string XmlHeight = "Height";
        private const string XmlImageCached = "ImageCached";
        private const string XmlLastModified = "LastModified";

        public static void LoadFromXml(string filePath, ImageList list)
        {
            list.Clear();
            XDocument xdoc = XDocument.Load(filePath);
            list.AddRange(
                from d in xdoc.Root.Elements()
                select new ImageFileAttributes(
                    (string) d.Attribute(XmlImagePath),
                    new Size(
                        (int) d.Attribute(XmlWidth),
                        (int) d.Attribute(XmlHeight)),
                    (DateTime) d.Attribute(XmlLastModified)));
        }

        public static void SaveAsXml(string filePath, ImageList list)
        {
            var xml = new XElement(XmlRoot,
                                   from d in list
                                   select new XElement(XmlRoot,
                                                       new XAttribute(XmlImagePath, d.Path),
                                                       new XAttribute(XmlWidth, d.Size.Width),
                                                       new XAttribute(XmlHeight, d.Size.Height),
                                                       new XAttribute(XmlLastModified,
                                                                      d.LastModified ?? DateTime.MinValue)));
            xml.Save(filePath);
        }
    }
}