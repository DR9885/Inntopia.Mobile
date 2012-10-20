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
    public class SelectorTest
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
        public void SelectorData()
        {
            // Ensure Data isn't NULL
            Assert.IsNotNull(Selector);
            Assert.IsNotNull(Selector.SuperCategories);
            Assert.IsNotNull(Selector.DefaultValues);

            Assert.IsNotNull(Selector.DefaultValues.CanSearchDateless);
            Assert.IsNotNull(Selector.DefaultValues.NeedsChildAges);
            Assert.IsNotNull(Selector.DefaultValues.HasTeeTimes);
            Assert.IsNotNull(Selector.DefaultValues.Language);


            foreach (var superCategory in Selector.SuperCategories)
            {
                Assert.IsNotNull(superCategory.Categories);
                foreach (var category in superCategory.Categories)
                {
                    Assert.IsNotNull(category);
                    Assert.IsNotNull(category.ID);
                    Assert.IsNotNull(category.Name);
                    Assert.IsNotNull(category.ShortName);
                }
            }
        }

    }
}
