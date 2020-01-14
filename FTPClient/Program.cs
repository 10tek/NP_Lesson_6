using System;
using System.IO;
using System.Net;

namespace FTPClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var request = (FtpWebRequest)WebRequest.Create(new Uri("ftp://127.0.0.1"));
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            //request.Credentials = new NetworkCredential("admin", "123123");
            //request.EnableSsl = true; //- используется ssl(ftps://)
            request.UseBinary = false;

            var response = (FtpWebResponse)request.GetResponse();

            using (var responseStream = response.GetResponseStream())
            using (var fileStream = File.OpenWrite("1.txt"))
            {
                responseStream.CopyTo(fileStream);
            }
        }
    }
}
