using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.IO;
using Inntopia.Mobile.Data;

using System.Xml.Serialization;
using Inntopia.Mobile.Web.Models;

namespace Inntopia.Mobile.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Selector()
        {
            // Create a request using a URL that can receive a post. 
            WebRequest request = WebRequest.Create("http://www.inntopia.travel/aspnet/09/selector.aspx?salesid=80002&advancedsearch=1&returnxml=1");
            request.Method = "GET";
            request.ContentType = "application/xml";
            WebResponse response = request.GetResponse();

            // Serialize the object
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Selector));
            StreamReader reader = new StreamReader(response.GetResponseStream());
            Selector selector = xmlSerializer.Deserialize(reader) as Selector;

            Assert.IsNotNull(selector);

            reader.Close();
        }
    }
}
