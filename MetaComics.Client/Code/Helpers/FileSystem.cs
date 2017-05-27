using System;
using System.Collections;
using System.IO;
using System.Threading;

namespace MetaComics.Client
{
    /// <summary>
    /// Project:	Code Project Sample - CoolFileSYstem
    /// Author:		Vahe Karamian
    /// Date:		08/12/2005
    /// Version:	1.0
    /// </summary>
    public class FileSystem
    {
        private static int copyNumofFiles;
        private readonly Thread copyThread;
        private readonly string destinationPath;

        /// <summary>
        /// Used to store directories found under the rootPath. It contains objects of type
        /// DirectoryStructure which hold the Directory Information with a list of files
        /// under the current directory.
        /// </summary>
        private readonly ArrayList directoryList = new ArrayList(500);

        /// <summary>
        /// File list is used internally. It is a list of all files found given the search
        /// criteria. Automatically adjust itself. Default size 500.
        /// </summary>
        private readonly ArrayList fileList = new ArrayList(500);

        /// <summary>
        /// Used for navigation thru the directory structure.
        /// </summary>
        private readonly Thread mainThread;

        private readonly string sourcePath;

        /// <summary>
        /// Used to filter filename when doing the search. By default it is set to "*.xls".
        /// Can be changed using the FILE_FILTER property.
        /// </summary>
        private string fileFilter = "*.*";

        /// <summary>
        /// Used to hold root directory. Start point for the search.
        /// </summary>
        private string rootPath;

        public FileSystem(string source, string destination)
        {
            sourcePath = source;
            destinationPath = destination;
            copyThread = new Thread(startCopyThread);
            copyThread.Start();
        }

        public FileSystem(string path)
        {
            rootPath = path;
            mainThread = new Thread(startThread);
            mainThread.Start();
        }

        /// <summary>
        /// Get/Set property for rootPath.
        /// </summary>
        public string ROOT_PATH
        {
            get { return rootPath; }
            set { rootPath = value; }
        }

        /// <summary>
        /// Get/Set property for fileFilter.
        /// </summary>
        public string FILE_FILTER
        {
            get { return fileFilter; }
            set { fileFilter = value; }
        }

        /// <summary>
        /// Get property. Number of files in fileList.
        /// </summary>
        public int NUMBER_OF_FILES
        {
            get { return fileList.Count; }
        }

        /// <summary>
        /// Get property. Number of directories in directoryList.
        /// </summary>
        public int NUMBER_OF_DIRECTORIES
        {
            get { return directoryList.Count; }
        }

        /// <summary>
        /// Get property. Return mainThread status.
        /// </summary>
        public string STATUS
        {
            get { return mainThread.ThreadState.ToString(); }
        }

        /// <summary>
        /// Get property. Return copyThread status.
        /// </summary>
        public string COPY_STATUS
        {
            get { return copyThread.ThreadState.ToString(); }
        }

        private void startThread()
        {
            var di = new DirectoryInfo(rootPath);
            RecursiveDirectoryNavigation(di);
        }

        private void startCopyThread()
        {
            try
            {
                copyDirectory(@sourcePath, @destinationPath);
            }
            catch (Exception Ex)
            {
                Console.Error.WriteLine(Ex.Message);
            }
        }

        /// <summary>
        /// Vahe Karamian - 08/08/2005 - Copy Directories and Files from Source to Destination
        /// </summary>
        /// <param name="Src"></param>
        /// <param name="Dst"></param>
        public string GetNumOfFilesCopied()
        {
            return copyNumofFiles.ToString();
        }

        public static void copyDirectory(string Src, string Dst)
        {
            String[] Files;
            if (Dst[Dst.Length - 1] != Path.DirectorySeparatorChar)
                Dst += Path.DirectorySeparatorChar;
            if (!Directory.Exists(Dst))
                Directory.CreateDirectory(Dst);
            Files = Directory.GetFileSystemEntries(Src);
            copyNumofFiles += Files.Length;
            foreach (string Element in Files)
            {
                // Sub directories
                if (Directory.Exists(Element))
                {
                    copyDirectory(Element, Dst + Path.GetFileName(Element));
                    // Files in directory
                }
                else
                {
                    File.Copy(Element, Dst + Path.GetFileName(Element), true);
                    Console.WriteLine("Copying file: " + Element);
                }
            }
        }

        //[STAThread]
        private void RecursiveDirectoryNavigation(DirectoryInfo di)
        {
            try
            {
                // Add the current directory to the directory list
                var ds = new DirectoryStructure();
                ds.di = di;
                int insertionIndex = 0;
                // Let's get files in directory
                foreach (FileInfo fi in di.GetFiles(fileFilter))
                {
                    fileList.Insert(insertionIndex, fi);
                    ds.fileList.Insert(insertionIndex, fi);
                }
                directoryList.Add(ds);
                foreach (DirectoryInfo d in di.GetDirectories())
                {
                    RecursiveDirectoryNavigation(d);
                }
            }
            catch
            {
            }
            finally
            {
            }
        }

        public ArrayList GetFiles()
        {
            return fileList;
        }

        public ArrayList GetDirectories()
        {
            return directoryList;
        }
    }

    internal class DirectoryStructure
    {
        public DirectoryInfo di;
        public ArrayList fileList = new ArrayList(500);
    }
}