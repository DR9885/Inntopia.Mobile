using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Inntopia.Mobile.Data
{
    public class Address
    {
        [XmlAttribute("Type")]
        public int Type { get; set; }

        [XmlAttribute("CountryCode")]
        public string CountryCode { get; set; }

        [XmlAttribute("Region")]
        public string Region { get; set; }

        [XmlAttribute("PostalCode")]
        public int PostalCode { get; set; }

        [XmlAttribute("StreetAddress")]
        public string Street { get; set; }
    }
}
