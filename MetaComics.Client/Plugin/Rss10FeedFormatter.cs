﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ServiceModel.Syndication;
using System.Xml;

namespace MetaComics.Client.Plugin
{
    public class Rss10FeedFormatter : SyndicationFeedFormatter
    {
        public Rss10FeedFormatter()
        {
        }

        public Rss10FeedFormatter(SyndicationFeed feed) : base(feed)
        {
        }

        public override string Version
        {
            get { return "Rss10"; }
        }

        public virtual string RdfNamespaceUri
        {
            get { return "http://www.w3.org/1999/02/22-rdf-syntax-ns#"; }
        }

        public virtual string NamespaceUri
        {
            get { return "http://purl.org/rss/1.0/"; }
        }

        public override bool CanRead(XmlReader reader)
        {
            if (reader == null)
                throw new ArgumentNullException("reader");
            return reader.IsStartElement("RDF", RdfNamespaceUri);
        }

        protected override SyndicationFeed CreateFeedInstance()
        {
            return new SyndicationFeed();
        }

        public override void ReadFrom(XmlReader reader)
        {
            if (!CanRead(reader))
                throw new XmlException("Unknown RSS 1.0 feed format.");
            ReadFeed(reader);
        }

        private void ReadFeed(XmlReader reader)
        {
            SetFeed(CreateFeedInstance());
            ReadXml(reader, base.Feed);
        }

        protected virtual void ReadXml(XmlReader reader, SyndicationFeed result)
        {
            if (result == null)
                throw new ArgumentNullException("result");
            else if (reader == null)
                throw new ArgumentNullException("reader");
            reader.ReadStartElement(); // Read in <RDF>
            reader.ReadStartElement("channel"); // Read in <channel>
            while (reader.IsStartElement()) // Process <channel> children
            {
                if (reader.IsStartElement("title"))
                    result.Title = new TextSyndicationContent(reader.ReadElementString());
                else if (reader.IsStartElement("link"))
                    result.Links.Add(new SyndicationLink(new Uri(reader.ReadElementString())));
                else if (reader.IsStartElement("description"))
                    result.Description = new TextSyndicationContent(reader.ReadElementString());
                else
                    reader.Skip();
            }
            reader.ReadEndElement(); // Read in </channel>
            while (reader.IsStartElement())
            {
                if (reader.IsStartElement("item"))
                {
                    result.Items = ReadItems(reader, result);
                    break;
                }
                else
                    reader.Skip();
            }
        }

        protected virtual IEnumerable<SyndicationItem> ReadItems(XmlReader reader, SyndicationFeed feed)
        {
            if (feed == null)
                throw new ArgumentNullException("feed");
            else if (reader == null)
                throw new ArgumentNullException("reader");
            var items = new Collection<SyndicationItem>();
            while (reader.IsStartElement("item"))
            {
                items.Add(ReadItem(reader, feed));
            }
            return items;
        }

        protected virtual SyndicationItem ReadItem(XmlReader reader, SyndicationFeed feed)
        {
            if (feed == null)
                throw new ArgumentNullException("feed");
            else if (reader == null)
                throw new ArgumentNullException("reader");
            var result = new SyndicationItem();
            ReadItemFrom(reader, result);
            return result;
        }

        protected virtual void ReadItemFrom(XmlReader reader, SyndicationItem result)
        {
            if (result == null)
                throw new ArgumentNullException("result");
            else if (reader == null)
                throw new ArgumentNullException("reader");
            reader.ReadStartElement();
            while (reader.IsStartElement())
            {
                if (reader.IsStartElement("title"))
                    result.Title = new TextSyndicationContent(reader.ReadElementString());
                else if (reader.IsStartElement("link"))
                    result.Links.Add(new SyndicationLink(new Uri(reader.ReadElementString())));
                else if (reader.IsStartElement("description"))
                    result.Summary = new TextSyndicationContent(reader.ReadElementString());
                else
                    reader.Skip();
            }
            reader.ReadEndElement();
        }

        public override void WriteTo(XmlWriter writer)
        {
            if (writer == null)
                throw new ArgumentNullException("writer");
            writer.WriteStartElement("rdf", "RDF", RdfNamespaceUri); // Write <RDF>
            writer.WriteAttributeString("xmlns", NamespaceUri);
            WriteFeed(writer);
            writer.WriteEndElement();
        }

        protected virtual void WriteFeed(XmlWriter writer)
        {
            if (writer == null)
                throw new ArgumentNullException("writer");
            if (base.Feed == null)
                throw new InvalidOperationException("Feed formatter does not have a feed.");
            string alternateLink = string.Empty, selfLink = string.Empty;
            foreach (SyndicationLink lnk in base.Feed.Links)
            {
                if (alternateLink.Length == 0 && lnk.RelationshipType == "alternate")
                    alternateLink = lnk.Uri.IsAbsoluteUri ? lnk.Uri.AbsoluteUri : lnk.Uri.ToString();
                else if (selfLink.Length == 0 && lnk.RelationshipType == "self")
                    selfLink = lnk.Uri.IsAbsoluteUri ? lnk.Uri.AbsoluteUri : lnk.Uri.ToString();
            }
            if (selfLink.Length == 0 && alternateLink.Length > 0)
                selfLink = alternateLink;
            else if (alternateLink.Length == 0 && selfLink.Length > 0)
                alternateLink = selfLink;
            writer.WriteStartElement("channel"); // Write <channel>
            writer.WriteAttributeString("about", RdfNamespaceUri, selfLink);
            if (base.Feed.Title == null || string.IsNullOrEmpty(base.Feed.Title.Text))
                throw new ArgumentException("Feed title required for RSS 1.0 feeds.");
            writer.WriteElementString("title", base.Feed.Title.Text); // Write <title>
            if (alternateLink.Length == 0)
                throw new ArgumentException("Feed link required for RSS 1.0 feeds.");
            writer.WriteElementString("link", alternateLink); // Write <link>
            if (base.Feed.Description == null || string.IsNullOrEmpty(base.Feed.Description.Text))
                throw new ArgumentException("Feed title required for RSS 1.0 feeds.");
            writer.WriteElementString("description", base.Feed.Description.Text); // Write <description>
            writer.WriteStartElement("items"); // Write <items>
            writer.WriteStartElement("Seq", RdfNamespaceUri);
            foreach (SyndicationItem item in base.Feed.Items)
            {
                string itemAlternateLink = GetAlternateLinkForItem(item);
                writer.WriteStartElement("li", RdfNamespaceUri);
                writer.WriteAttributeString("resource", RdfNamespaceUri, itemAlternateLink);
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndElement(); // Write </channel>
            // Write the <item> elements
            WriteItems(writer, base.Feed.Items);
        }

        protected virtual void WriteItems(XmlWriter writer, IEnumerable<SyndicationItem> items)
        {
            if (writer == null)
                throw new ArgumentNullException("writer");
            if (items != null)
                foreach (SyndicationItem item in items)
                    WriteItem(writer, item);
        }

        protected virtual void WriteItem(XmlWriter writer, SyndicationItem item)
        {
            if (writer == null)
                throw new ArgumentNullException("writer");
            string alternateLink = GetAlternateLinkForItem(item);
            writer.WriteStartElement("item"); // Write <item>
            writer.WriteAttributeString("about", RdfNamespaceUri, alternateLink);
            WriteItemContents(writer, item);
            writer.WriteEndElement();
        }

        protected virtual void WriteItemContents(XmlWriter writer, SyndicationItem item)
        {
            if (writer == null)
                throw new ArgumentNullException("writer");
            if (item.Title == null || string.IsNullOrEmpty(item.Title.Text))
                throw new ArgumentException("Feed title required for RSS 1.0 feeds.");
            writer.WriteElementString("title", item.Title.Text); // Write <title>
            string alternateLink = GetAlternateLinkForItem(item);
            if (string.IsNullOrEmpty(alternateLink))
                throw new ArgumentException("Feed link required for RSS 1.0 feeds.");
            writer.WriteElementString("link", alternateLink); // Write <link>
            if (base.Feed.Description != null && string.IsNullOrEmpty(item.Summary.Text) == false)
                writer.WriteElementString("description", item.Summary.Text); // Write the optional <description>
        }

        private string GetAlternateLinkForItem(SyndicationItem item)
        {
            foreach (SyndicationLink lnk in item.Links)
                if (lnk.RelationshipType == "alternate")
                    return lnk.Uri.IsAbsoluteUri ? lnk.Uri.AbsoluteUri : lnk.Uri.ToString();
            // If we reach here, return an empty string
            return string.Empty;
        }
    }
}