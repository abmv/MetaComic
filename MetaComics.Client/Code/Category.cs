using System;
using System.Collections;
using System.Data;

namespace MetaComics.Client.Code
{
    /// <summary>
    /// Summary description for Category.
    /// </summary>
    public class Category
    {
        public string CategoryID { get; set; }

        public string CategoryName { get; set; }

        public override string ToString()
        {
            //return String.Format("{0} - {1}", Code, Name);
            return CategoryName;
        }
    }

    public class CategoryList
    {
        public static Category GetCategory(string categoryID)
        {
            DataRow iDr = null;
            iDr = XMLCategory.Select(categoryID);
            Category cat = null;
            if (iDr != null)
            {
                cat = new Category();
                cat.CategoryID = iDr[0] != DBNull.Value ? iDr[0].ToString() : string.Empty;
                ;
                cat.CategoryName = iDr[1] != DBNull.Value ? iDr[1].ToString() : string.Empty;
            }
            return cat;
        }

        public static IList GetCategoryList(string xmldbpath)
        {
            return XMLCategory.SelectAll(xmldbpath);
        }

        public static void UpdateCategory(Category cat, string path)
        {
            XMLCategory.Update(cat.CategoryID, cat.CategoryName, path);
        }

        public static void InsertCategory(Category cat, string path)
        {
            XMLCategory.Insert(cat.CategoryID, cat.CategoryName, path);
        }

        public static void DeleteCategory(string categoryID, string path)
        {
            XMLCategory.Delete(categoryID, path);
        }

        public static void DeleteBasedOnCategoryName(string categoryID, string path)
        {
            XMLCategory.DeleteBasedOnCategoryName(categoryID, path);
        }
    }
}