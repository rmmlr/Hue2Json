using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Rca.Hue2Json.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Rca.Hue2Json.Api
{
    public class ApiCaller
    {
        #region Member


        #endregion Member

        #region Properties
        public static string Host { get; set; }

        public static string AppKey { get; set; }

        #endregion Properties

        #region Constructor
        /// <summary>
        /// Empty constructor for ApiCaller
        /// </summary>
        public ApiCaller()
        {

        }

        #endregion Constructor

        #region Services
        public string HttpGet(string uri)
        {
            Logger.WriteToLog("HttpGet URI=" + uri);

            WebClient client = new WebClient();

            // Add a user agent header in case the 
            // requested URI contains a query.

            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");

            Stream data = client.OpenRead(getUrl(uri));
            StreamReader reader = new StreamReader(data);
            string s = reader.ReadToEnd();
            data.Close();
            reader.Close();

            return s;
        }

        public JObject HttpGetJson(string uri)
        {
            string jsonResult = HttpGet(uri);

            JObject res = JObject.Parse(jsonResult);

            return res;
        }

        public string HttpPut(string uri, string body)
        {
            Logger.WriteToLog("HttpPut URI=" + uri);

            byte[] sentData = Encoding.UTF8.GetBytes(body);

            using (var client = new System.Net.WebClient())
            {
                var result = client.UploadData(getUrl(uri), "PUT", sentData);
            }

            return null;
        }

        #endregion Services

        #region Internal services
        string getUrl(string uri)
        {
            var url = new StringBuilder("http://");
            url.Append(Host);
            url.Append("/api/");
            url.Append(AppKey);
            url.Append("/");
            url.Append(uri);

            return url.ToString();

        }

        #endregion Internal services

        #region Events


        #endregion Events
    }
}
