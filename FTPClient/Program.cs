using System;
using System.IO;
using System.Net;

namespace FTPClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var request = WebRequest.Create(new Uri("ftp://127.0.0.1/file.txt")) as FtpWebRequest;
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            // request.Credentials = new NetworkCredential("admin", "123456");
            // request.EnableSsl = true; // используют SSL или ftps://
            // request.UseBinary = false;

            var responce = request.GetResponse() as FtpWebResponse;
            using (var responseStream = responce.GetResponseStream())
            using (var fileStream = File.OpenWrite("file.txt"))
            {
                responseStream.CopyTo(fileStream);
            }
        }
    }
}
