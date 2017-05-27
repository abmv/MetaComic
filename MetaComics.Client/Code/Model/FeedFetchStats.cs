using System;
using System.Xml.Serialization;

namespace MetaComics.Client.Code
{
    [Serializable]
    public class FeedFetchStatsList
    {
        // XmlElementAttribute-> public property
        //will be serialized as an //element in the xml node.
        [XmlElement("FeedFetchStats")] public FeedFetchStat[] FeedFetchStats;

        #region Nested type: FeedFetchStat

        [Serializable]
        public class FeedFetchStat
        {
            private string _feedFetchRunDate;
            private bool _feedFetchRunDateHadCurrentDateItem;
            private string _feedFetchRunMonth;
            private string _feedFetchRunTime;
            private string _feedFetchRunYear;
            private string _feedName;
            private DateTime _feedPublishEndDate;
            private string _feedPublishStartDate;
            private bool _feedRunFrequencyWeight;
            private int _feedTotalItemCount;

            [XmlElement("FeedName")]
            public string FeedName
            {
                get { return _feedName; } // get accessor 
                set { _feedName = value; } // set accessor
            }

            [XmlElement("FeedFetchRunDate")]
            public string FeedFetchRunDate
            {
                get { return _feedFetchRunDate; } // get accessor 
                set { _feedFetchRunDate = value; } // set accessor
            }

            [XmlElement("FeedFetchRunTime")]
            public string FeedFetchRunTime
            {
                get { return _feedFetchRunTime; } // get accessor 
                set { _feedFetchRunTime = value; } // set accessor
            }

            [XmlElement("FeedFetchRunMonth")]
            public string FeedFetchRunMonth
            {
                get { return _feedFetchRunMonth; } // get accessor 
                set { _feedFetchRunMonth = value; } // set accessor
            }

            [XmlElement("FeedFetchRunYear")]
            public string FeedFetchRunYear
            {
                get { return _feedFetchRunYear; } // get accessor 
                set { _feedFetchRunYear = value; } // set accessor
            }

            [XmlElement("FeedPublishStartDate")]
            public string FeedPublishStartDate
            {
                get { return _feedPublishStartDate; } // get accessor 
                set { _feedPublishStartDate = value; } // set accessor
            }

            [XmlElement("FeedPublishEndDate")]
            public DateTime _FeedPublishEndDate
            {
                get { return _feedPublishEndDate; } // get accessor 
                set { _feedPublishEndDate = value; } // set accessor
            }

            [XmlElement("FeedTotalItemCount")]
            public int FeedTotalItemCount
            {
                get { return _feedTotalItemCount; } // get accessor 
                set { _feedTotalItemCount = value; } // set accessor
            }

            [XmlElement("FeedFetchRunDateHadCurrentDateItem")]
            public bool FeedFetchRunDateHadCurrentDateItem
            {
                get { return _feedFetchRunDateHadCurrentDateItem; } // get accessor 
                set { _feedFetchRunDateHadCurrentDateItem = value; } // set accessor
            }

            [XmlElement("FeedRunFrequencyWeight")]
            public bool FeedRunFrequencyWeight
            {
                get { return _feedRunFrequencyWeight; } // get accessor 
                set { _feedRunFrequencyWeight = value; } // set accessor
            }
        }

        #endregion
    }
}