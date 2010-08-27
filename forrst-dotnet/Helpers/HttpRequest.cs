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
        public static string GetResponse(string contentType, HttpMethod method, string urlPath) {
            string statusCode = string.Empty;
            System.Uri currentUri = new Uri(urlPath);

            try {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(currentUri);
                request.Accept = contentType;
                request.Method = method.ToString();

                HttpWebResponse webResponse = (HttpWebResponse)request.GetResponse();
                if ((int)webResponse.StatusCode >= 400) {

                    // An error occured for some reason, need to send the error up to the server
                    var ex = new WebException(webResponse.StatusDescription, null, WebExceptionStatus.UnknownError, webResponse);
                    throw ex;
                }
                else {

                    // Decompress the response
                    StreamReader sr = new StreamReader(webResponse.GetResponseStream());
                    if (webResponse.ContentLength > 0) {
                        string returnValue = sr.ReadToEnd();
                        sr.Close();
                        return returnValue;
                    }
                    else {
                        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                        if (response.StatusCode != HttpStatusCode.NoContent) {

                        }
                    }
                }

            }

            catch (WebException e) {
                throw e;
            }
            return null;
        }
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
