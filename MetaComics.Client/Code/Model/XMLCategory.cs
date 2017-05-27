using System.Data;

namespace MetaComics.Client.Code
{
    public sealed class XMLCategory
    {
        private static readonly DataSet ds = new DataSet();
        private static DataView dv = new DataView();

        private XMLCategory()
        {
        }

        /// <summary>
        /// Inserts a record into the Category table.
        /// </summary>
        /// 
        public static void save(string path)
        {
            ds.WriteXml(path, XmlWriteMode.WriteSchema);
        }

        public static void Insert(string categoryID, string CategoryName, string path)
        {
            DataRow dr = dv.Table.NewRow();
            dr[0] = categoryID;
            dr[1] = CategoryName;
            dv.Table.Rows.Add(dr);
            save(path);
        }

        /// <summary>
        /// Updates a record in the Category table.
        /// </summary>
        public static void Update(string categoryID, string CategoryName, string path)
        {
            DataRow dr = Select(categoryID);
            dr[1] = CategoryName;
            save(path);
        }

        /// <summary>
        /// Deletes a record from the Category table by a composite primary key.
        /// </summary>
        public static void Delete(string categoryID, string path)
        {
            dv.RowFilter = "categoryID='" + categoryID + "'";
            dv.Sort = "categoryID";
            dv.Delete(0);
            dv.RowFilter = "";
            save(path);
        }

        public static void DeleteBasedOnCategoryName(string categoryName, string path)
        {
            dv.RowFilter = "categoryName='" + categoryName + "'";
            dv.Sort = "categoryName";
            dv.Delete(0);
            dv.RowFilter = "";
            save(path);
        }

        /// <summary>
        /// Selects a single record from the Category table.
        /// </summary>
        public static DataRow Select(string categoryID)
        {
            dv.RowFilter = "categoryID='" + categoryID + "'";
            dv.Sort = "categoryID";
            DataRow dr = null;
            if (dv.Count > 0)
            {
                dr = dv[0].Row;
            }
            dv.RowFilter = "";
            return dr;
        }

        /// <summary>
        /// Selects all records from the Category table.
        /// </summary>
        public static DataView SelectAll(string xmldpath)
        {
            ds.Clear();
            //  ds.ReadXml(Application.StartupPath + "\\XML\\Category.xml", XmlReadMode.ReadSchema);
            ds.ReadXml(xmldpath, XmlReadMode.ReadSchema);
            dv = ds.Tables[0].DefaultView;
            return dv;
        }
    }
}