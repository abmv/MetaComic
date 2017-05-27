using System;
using System.Drawing;

namespace MetaComics.Client.Plugin
{
    //http://www.bizarrocomics.com/?feed=rss2
    internal class BizarroComicPlugin : IComicPlugin
    {
        #region IComicPlugin Members

        public string Name
        {
            get { throw new NotImplementedException(); }
        }

        public event AnnounceOutput WriteOutput;

        public string Description()
        {
            return null;
        }

        public void ReadComicStripFeed()
        {
        }

        public void DownloadImageFromFeed(string datepublished, string feeditem)
        {
        }

        public Image ComicOfTheDay()
        {
            throw new NotImplementedException();
        }

        public Image ComicOfTheDay(string comicStrip)
        {
            return null;
        }

        public string ComicName()
        {
            return null;
        }

        public string ComicFeedURL
        {
            get { throw new NotImplementedException(); }
        }

        #endregion
    }
}