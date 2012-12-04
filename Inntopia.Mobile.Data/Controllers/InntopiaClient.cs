using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Inntopia.Mobile.Data
{
    public enum InntopiaServer
    {
        Development,
        Stage,
        Production
    }

    public enum InntopiaApplication
    {
        IBE,
        RMS,
        Photos,
        Reports
    }

    public class InntopiaClient
    {
        private InntopiaServer _Server = InntopiaServer.Development;
        private InntopiaApplication _Application = InntopiaApplication.IBE;

        public InntopiaClient() : this(InntopiaServer.Production, InntopiaApplication.IBE) { }

        public InntopiaClient(InntopiaServer server, InntopiaApplication app)
        {
            _Server = server;
            _Application = app;
        }

        private string Domain
        {
            get
            {
                string domain = "";
                switch (_Server)
                {
                    case InntopiaServer.Development: domain = "https://dev.inntopia.com/"; break;
                    case InntopiaServer.Stage: domain = "https://stage.inntopia.net/"; break;
                    case InntopiaServer.Production: domain = "https://www.inntopia.travel/"; break;
                    default: break;
                }

                return domain;
            }
        }

        private string VirtualDirectory
        {
            get
            {
                switch (_Application)
                {
                    case InntopiaApplication.IBE: return "aspnet/09/";
                    default: return "";
                }
            }
        }

        private string BuildURL<T>(Dictionary<string, object> parameters)
        {
            return Domain + VirtualDirectory +
                typeof(T).Name.Replace("Response", "").ToLower() + ".aspx" +
                "?" + String.Join("&", parameters.Select(x => x.Key + "=" + x.Value));
        }

        //public string GetData<T>(Dictionary<string, object> parameters)
        //{
        //    // Create a request using a URL that can receive a post. 
        //    WebRequest request = WebRequest.Create(BuildURL(parameters));
        //    request.Method = "GET";
        //    request.ContentType = "application/xml";
        //    WebResponse response = request.GetResponse();
        //
        //    return response.ToString();
        //}

        public T GetData<T>(Dictionary<string, object> parameters)
        {
            // Create a request using a URL that can receive a post. 
            WebRequest request = WebRequest.Create(BuildURL<T>(parameters));
            request.Method = "GET";
            request.ContentType = "application/xml";
            WebResponse response = request.GetResponse();

            // Serialize the object
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            StreamReader reader = new StreamReader(response.GetResponseStream());
            var obj = xmlSerializer.Deserialize(reader);
            reader.Close();

            return (T)obj;
        }
    }
}
