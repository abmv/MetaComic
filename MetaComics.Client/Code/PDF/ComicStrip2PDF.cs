using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DevWilson;
using iTextSharp.text;
using iTextSharp.text.pdf;
using NLog;
using Image = iTextSharp.text.Image;
using Rectangle = iTextSharp.text.Rectangle;

namespace MetaComics.Client.Code.PDF
{
    internal class ComicStrip2PDF
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        //private void GetImageSize(Image imagex)
        //{
        //    Console.WriteLine(string.Format("Height: {0}", imagex.Height));
        //    Console.WriteLine(string.Format("Width: {0}", imagex.Width));
        //}
        public static void CreatePdfFile(string processingpath, string comicname)
        {
            var threaded = new ImageOrientationThreaded();
            try
            {
                //Create a new document
                var Doc = new Document(PageSize.A4_LANDSCAPE, 20, 20, 20, 20);
                //Store the document on the desktop
                string pdfOutput = Path.Combine(Application.StartupPath, comicname + ".pdf");
                PdfWriter writer = PdfWriter.GetInstance(Doc,
                                                         new FileStream(pdfOutput, FileMode.Create, FileAccess.Write,
                                                                        FileShare.Read));
                //Open the PDF for writing
                Doc.Open();
                string folderpath = processingpath;
                string[] folders = Directory.GetDirectories(folderpath, "*", SearchOption.AllDirectories);
                foreach (string folder in folders)
                {
                    foreach (string F in Directory.GetFiles(folder, "*.gif"))
                    {
                        if (threaded.IsLandscape(F))
                        {
                            //Doc.SetPageSize(new Rectangle(600, 800));
                            Rectangle x = PageSize.A4.Rotate();
                            //Color xy = ColorTranslator.FromOle(AppSettings.PDFPageColor);
                            x.BackgroundColor = new BaseColor(AppSettings.PDFPageColor);
                            //x.BackgroundColor = new BaseColor(191, 64, 124);
                            Doc.SetPageSize(x);
                        }
                        //Insert a page
                        Doc.NewPage();
                        Rectangle x1 = PageSize.A4.Rotate();
                        x1.BackgroundColor = new BaseColor(AppSettings.PDFPageColor);
                        Doc.SetPageSize(x1);
                        //Add image
                        Image gif = Image.GetInstance(F);
                        Doc.Add(gif);
                        //Doc.Add(new iTextSharp.text.Jpeg(new Uri(new FileInfo(F).FullName)));
                    }
                    foreach (string F in Directory.GetFiles(folder, "*.jpg"))
                    {
                        if (threaded.IsLandscape(F))
                        {
                            //Doc.SetPageSize(new Rectangle(600, 800));
                            //Doc.SetPageSize(PageSize.A4.Rotate());
                            //Doc.SetPageSize(new Rectangle(600, 800));
                            Rectangle x = PageSize.A4.Rotate();
                            Color xy = ColorTranslator.FromOle(AppSettings.PDFPageColor);
                            x.BackgroundColor = new BaseColor(AppSettings.PDFPageColor);
                            //x.BackgroundColor = new BaseColor(191, 64, 124);
                        }
                        //Insert a page
                        Doc.NewPage();
                        //Add image
                        Image gif = Image.GetInstance(F);
                        Doc.Add(gif);
                    }
                    foreach (string F in Directory.GetFiles(folder, "*.png"))
                    {
                        if (threaded.IsLandscape(F))
                        {
                            //Doc.SetPageSize(new Rectangle(600, 800));
                            //Doc.SetPageSize(PageSize.A4.Rotate());
                            //Doc.SetPageSize(new Rectangle(600, 800));
                            Rectangle x = PageSize.A4.Rotate();
                            Color xy = ColorTranslator.FromOle(AppSettings.PDFPageColor);
                            x.BackgroundColor = new BaseColor(AppSettings.PDFPageColor);
                            //x.BackgroundColor = new BaseColor(191, 64, 124);
                        }
                        //Insert a page
                        Doc.NewPage();
                        //Add image
                        Image gif = Image.GetInstance(F);
                        Doc.Add(gif);
                    }
                }
                Doc.Close();
                var prc = new Process {StartInfo = {FileName = pdfOutput}};
                prc.Start();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
        }
    }
}