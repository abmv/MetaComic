using System;
using System.IO;

namespace MetaComics.Client
{
    public class Utlity
    {
        private const int HowDeepToScan = 4;

        public void GetDirectoryList()
        {
        }


        public static string FormatFileSize(long bytes)
        {
            if (bytes > 8589934592)
            {
                return (bytes/(float) 8589934592).ToString("0.00 TB");
            }
            else if (bytes > 1073741824)
            {
                return (bytes/(float) 1073741824).ToString("0.00 GB");
            }
            else if (bytes > 1048576)
            {
                return ((bytes/(float) 1048576)).ToString("0.00 MB");
            }
            else if (bytes > 1024)
            {
                return (bytes/(float) 1024).ToString("0.00 KB");
            }
            else return bytes + " Bytes";
        }

        public static void ProcessDir(string sourceDir, int recursionLvl)
        {
            if (recursionLvl <= HowDeepToScan)
            {
                // Process the list of files found in the directory.
                string[] fileEntries = Directory.GetFiles(sourceDir);
                foreach (string fileName in fileEntries)
                {
                    // do something with fileName
                    Console.WriteLine(fileName);
                }

                // Recurse into subdirectories of this directory.
                string[] subdirEntries = Directory.GetDirectories(sourceDir);
                foreach (string subdir in subdirEntries)
                    // Do not iterate through reparse points
                    if ((File.GetAttributes(subdir) &
                         FileAttributes.ReparsePoint) !=
                        FileAttributes.ReparsePoint)

                        ProcessDir(subdir, recursionLvl + 1);
            }
        }


        public static void ConvertDirToDate(string Dir)
        {
            string year = Dir.Remove(Dir.IndexOf("_"), 5);
            //string month = Dir.Remove()
            //string day = 
            //Remove(0, Dir.IndexOf("_"));
        }

        public static DateTime ParseStringToDate(string DateString)
        {
            var dtReturn = new DateTime();
            bool bSeperators = false;
            int iTemp;
            int iMonth;
            int iDay;
            int iYear;

            //First check that it is at least 6 characters or more.
            if (!(DateString.Length > 5))
                throw new Exception("Date string not in correct format.");

            // Next, see if the framework can parse it.
            try
            {
                dtReturn = DateTime.Parse(DateString);
                return dtReturn;
            }
            catch
            {
            }

            //Check to see if it has any seperators.  If not, it should parse to a int.
            try
            {
                iTemp = int.Parse(DateString);
                bSeperators = false;
            }
            catch
            {
                bSeperators = true;
            }

            if (!bSeperators)
            {
                if (DateString.Length == 6)
                {
                    iMonth = int.Parse(DateString.Substring(0, 2));
                    iDay = int.Parse(DateString.Substring(2, 2));
                    iYear = int.Parse(DateString.Substring(4, 2));
                    iTemp = DateTime.Now.Year;
                    iTemp = iTemp/100;
                    iTemp = iTemp*100;
                    iYear += iTemp;
                    try
                    {
                        return new DateTime(iYear, iMonth, iDay);
                    }
                    catch
                    {
                        throw new Exception("Date string not in correct format.");
                    }
                }
                else
                {
                    if (DateString.Length == 8)
                    {
                        iMonth = int.Parse(DateString.Substring(0, 2));
                        iDay = int.Parse(DateString.Substring(2, 2));
                        iYear = int.Parse(DateString.Substring(4, 4));
                        try
                        {
                            return new DateTime(iYear, iMonth, iDay);
                        }
                        catch
                        {
                            throw new Exception("Date string not in correct format.");
                        }
                    }
                    else
                    {
                        // Not a 6 or 8 digit number that was passed in.  Any other
                        // combination would have ambiguity, therefor it is an error.
                        throw new Exception("Date string not in correct format.");
                    }
                }
            }
            else
            {
                // Looks like it is seperated by characters the framework doesn't support.
                // Next version will take this and parse it, but for now it is an error.
                throw new Exception("Date string not in correct format.");
            }
        }
    }
}