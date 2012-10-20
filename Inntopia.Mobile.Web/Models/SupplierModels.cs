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

        [XmlArray("CodeSets")]
        [XmlArrayItem("CodeSet")]
        public CodeSet[] CodeSets { get; set; }
    }
}