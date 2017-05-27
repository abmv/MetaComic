using System;
using System.Drawing;

[assembly : CLSCompliant(true)]

namespace MetaComics.Client.Plugin
{
    /// <summary>
    /// This delegate is used to announce something to the outside of the plugin
    /// </summary>
    public delegate void AnnounceOutput(object sender, string Message);

    /// <summary>
    /// The interface implemented by all plugins. 
    /// Remeber: Override the ToString() with the name of the plugin
    /// </summary>
    public interface IComicPlugin
    {
        string Name { get; }
        string ComicFeedURL { get; }

        /// <summary>
        /// This event is used to signal to the out world that something happend
        /// </summary>
        event AnnounceOutput WriteOutput;

        /// <summary>
        /// This function briefly describes the purpose of the plugin
        /// </summary>
        /// <returns>The string containing the description</returns>
        string Description();

        void ReadComicStripFeed();
        void DownloadImageFromFeed(string datepublished, string feeditem);
        Image ComicOfTheDay();
        Image ComicOfTheDay(string comicStrip);
        string ComicName();
    }
}