
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Inntopia.Mobile.Data
{
    [XmlRoot("SupplierDetails")]
    public class SupplierResponse
    {
        [XmlArray("TrackingCode")]
        [XmlArrayItem("Account")]
        public TrackingCode[] TrackingCodes { get; set; }    

        [XmlElement ("Supplier")]
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

    public class TrackingCode
    {
        [XmlAttribute] public string Type { get; set; }
        [XmlAttribute] public string Code { get; set; }
        [XmlAttribute] public string Server { get; set; }
    }
}