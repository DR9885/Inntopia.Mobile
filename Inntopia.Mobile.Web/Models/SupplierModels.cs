using Inntopia.Mobile.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Inntopia.Mobile.Web.Models
{

    [XmlRoot("SupplierDetails")]
    public class SupplierDetails
    {
        [XmlElement("Supplier")]
        public Supplier Supplier { get; set; }

        [XmlArray("Slides")]
        [XmlArrayItem("Product")]
        public Product[] Products { get; set; }

        [XmlArray("SupplierAttributes")]
        [XmlArrayItem("AttributeType")]
        public AttributeType[] AttributeTypes { get; set; } 

        [XmlArray("CodeSets")]
        [XmlArrayItem("CodeSet")]
        public CodeSet[] CodeSets { get; set; }

        [XmlArray("CardsAccepted")]
        [XmlArrayItem("Card")]
        public Card[] Cards { get; set; }

        /*[XmlArray("Policies/Supplier")]
        //[XmlArray("Supplier")]
        [XmlArrayItem("Policy")]
        public SupplierPolicy Policies { get; set;}
         */
    }
}