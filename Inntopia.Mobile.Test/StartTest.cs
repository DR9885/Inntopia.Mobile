using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Inntopia.Mobile.Web.Models;
using System.Net;
using System.Xml.Serialization;
using System.IO;

namespace Inntopia.Mobile.Test
{
    [TestClass]
    public class StartTest
    {
        public readonly int SupplierID = 80002;
        public Selector Selector { get; set; }

        [TestInitialize]
        public void Init()
        {
            // Create a request using a URL that can receive a post. 
            WebRequest request = WebRequest.Create("http://dev.inntopia.com/aspnet/09/selector.aspx?salesid=" + SupplierID + "&advancedsearch=1&returnxml=1");
            request.Method = "GET";
            request.ContentType = "application/xml";
            WebResponse response = request.GetResponse();

            // Serialize the object
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Selector));
            StreamReader reader = new StreamReader(response.GetResponseStream());
            Selector = xmlSerializer.Deserialize(reader) as Selector;
            reader.Close();
        }


        [TestMethod]
        public void InntopiaData()
        {
            // Create a request using a URL that can receive a post. 
            WebRequest request = WebRequest.Create("http://dev.inntopia.com/aspnet/09/start.aspx?salesid=80000&returnxml=1");
            request.Method = "GET";
            request.ContentType = "application/xml";
            WebResponse response = request.GetResponse();

            // Serialize the object
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(InntopiaStart));
            StreamReader reader = new StreamReader(response.GetResponseStream());
            var inntopiaStart = xmlSerializer.Deserialize(reader) as InntopiaStart;
            reader.Close();

            Assert.IsNotNull(inntopiaStart);

            Assert.IsNotNull(inntopiaStart.PreferedResellers);

        }
    }
}
