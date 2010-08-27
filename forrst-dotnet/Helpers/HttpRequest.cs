using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using forrst_dotnet.Helpers.Enums;

namespace forrst_dotnet.Helpers {
    public class HttpRequest {
        public static string GetContent(string contentType, HttpMethod method, string urlPath) {
            Uri url = new Uri(urlPath);
            string content = null;
            string statusCode = string.Empty;

            try {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
                request.Accept = contentType;
                request.Method = method.ToString();

                WebResponse webResponse = request.GetResponse();
                StreamReader sr = new StreamReader(webResponse.GetResponseStream());
                if (webResponse.ContentLength > 0) {
                    switch (contentType) {
                        case "text/javascript":
                            content = sr.ReadToEnd();
                            break;

                        case "application/xml":
                             break;
                    }
                }
                else {
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    if (response.StatusCode != HttpStatusCode.NoContent) {
                       
                    }
                }
            }
            catch (WebException we) {
                throw we;
            }
            return content;
        }

    }
}
