using System.Collections;

namespace MetaComics.Client.Code
{
    public class FeedFetchStatCollection : CollectionBase
    {
        // Get Parent Element during serialization
        public FeedFetchStatsList.FeedFetchStat this[int index]
        {
            get
            {
                return
                    (FeedFetchStatsList.FeedFetchStat) base.InnerList[index];
            }
        }

        //Adding n number of FeedFetchStat's 
        public void Add(FeedFetchStatsList.FeedFetchStat inst)
        {
            base.InnerList.Add(inst);
            //Add
        }

        //Updating selected FeedFetchStat's 
        public void Update(int index, FeedFetchStatsList.FeedFetchStat inst)
        {
            base.InnerList.Insert(index, inst); //Insert
        }

        //Deleting selected FeedFetchStat's 
        public void Delete(FeedFetchStatsList.FeedFetchStat inst)
        {
            base.InnerList.Remove(inst);
            // Remove
        }
    }
}