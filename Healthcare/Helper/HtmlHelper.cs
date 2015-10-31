using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare.Helper
{
  public  class HtmlHelper
    {
        public static Uri StrToHTML(string input)
        {
            using (IsolatedStorageFile file = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (!file.DirectoryExists("temp"))
                    file.CreateDirectory("temp");
                using (IsolatedStorageFileStream fs = new IsolatedStorageFileStream("temp\\review.html", System.IO.FileMode.Create, file))
                {
                    string html = "<!DOCTYPE html><html lang='zh-CN'><head><meta http-equiv='Content-Type' content='text/html; charset=utf-8'><meta name='viewport' content='width=device-width, initial-scale=1.0, user-scalable=no, minimum-scale=1.0, maximum-scale=1.0' /></head><body>";
                    html += input;
                    html += "</body></html>";
                    byte[] bytes = Encoding.UTF8.GetBytes(html);
                    fs.Write(bytes, 0, bytes.Length);
                }
            }
            return new Uri("temp\\review.html", UriKind.Relative);
        }

    }
}
