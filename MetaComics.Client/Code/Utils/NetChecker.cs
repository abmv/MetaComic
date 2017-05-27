using System;
using System.Net;

namespace MetaComics.Client.Code.Utils
{
    public class NetChecker
    {
        public static bool CheckIfNetConnectionAvailable()
        {
            HttpWebRequest req;
            HttpWebResponse resp;
            try
            {
                req = (HttpWebRequest) WebRequest.Create("http://www.google.com");
                resp = (HttpWebResponse) req.GetResponse();
                if (resp.StatusCode.ToString().Equals("OK"))
                {
                    //Console.WriteLine("its connected.");
                    return true;
                }
                else
                {
                    //Console.WriteLine("its not connected.");
                    return false;
                }
            }
            catch (Exception exc)
            {
                //Console.WriteLine("its not connected.");
                return false;
            }
        }
    }
}