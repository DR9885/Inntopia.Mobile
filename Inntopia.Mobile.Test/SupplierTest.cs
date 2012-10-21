using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Xml.Serialization;
using System.IO;
using Inntopia.Mobile.Web.Models;

namespace Inntopia.Mobile.Test
{
    [TestClass]
    public class SupplierTest
    {
        public readonly int SupplierID = 80002;
        public SupplierDetails SupplierDetails { get; set; }

        [TestInitialize]
        public void Init()
        {
            // Create a request using a URL that can receive a post. 
            WebRequest request = WebRequest.Create("http://dev.inntopia.com/aspnet/09/supplier.aspx?supplierid=" + SupplierID + "&returnxml=1");
            request.Method = "GET";
            request.ContentType = "application/xml";
            WebResponse response = request.GetResponse();

            // Serialize the object
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(SupplierDetails));
            StreamReader reader = new StreamReader(response.GetResponseStream());
            SupplierDetails = xmlSerializer.Deserialize(reader) as SupplierDetails;
        }

        [TestMethod]
        public void SupplierData()
        {
            Assert.IsNotNull(SupplierDetails);
            Assert.IsNotNull(SupplierDetails.CodeSets);
            Assert.IsNotNull(SupplierDetails.Supplier);

            var supplier = SupplierDetails.Supplier;
            Assert.IsNotNull(supplier.Name);
            Assert.IsNotNull(supplier.Reservations);
            Assert.IsNotNull(supplier.CategoryID);
            Assert.IsNotNull(supplier.CategoryName);
            Assert.IsNotNull(supplier.PricingCurrency);

            Assert.IsNotNull(supplier.Website);
            Assert.IsNotNull(SupplierDetails.Products);
            foreach (var product in SupplierDetails.Products)
            {
                Assert.IsNotNull(product.ProductId);
            }

            int i = 0;
//            Assert.IsNotNull(supplier.Directions);
//            Assert.IsNotNull(supplier.Description);



        }
    }
}
