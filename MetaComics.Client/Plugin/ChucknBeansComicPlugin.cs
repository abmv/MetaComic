using System;
using System.Drawing;

namespace MetaComics.Client.Plugin
{
    //http://www.shoeboxblog.com/?feed=rdf
    internal class ChucknBeansComicPlugin : IComicPlugin
    {
        #region IComicPlugin Members

        public string Name
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public event AnnounceOutput WriteOutput;

        public string Description()
        {
            throw new NotImplementedException();
        }

        public void ReadComicStripFeed()
        {
            throw new NotImplementedException();
        }

        public void DownloadImageFromFeed(string datepublished, string feeditem)
        {
            throw new NotImplementedException();
        }

        public Image ComicOfTheDay()
        {
            throw new NotImplementedException();
        }

        public Image ComicOfTheDay(string comicStrip)
        {
            throw new NotImplementedException();
        }

        public string ComicName()
        {
            throw new NotImplementedException();
        }

        public string ComicFeedURL
        {
            get { throw new NotImplementedException(); }
        }

        #endregion
    }
}