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
        [XmlAttribute] public int Type { get; set; }

        #region Street

        [XmlAttribute("StreetAddress")] public string StreetAddress { get; set; }
        [XmlAttribute("Address")] public string Location { get; set; }
        [XmlAttribute] public string Street { get { return Location?? StreetAddress; } }

        #endregion

        [XmlAttribute] public string City { get; set; }
        [XmlAttribute("Region")] public string State { get; set; }
        [XmlAttribute("PostalCode")] public int ZipCode { get; set; }
        [XmlAttribute] public string CountryCode { get; set; }
        [XmlAttribute("Country")] public string Country2 { get; set; }
        [XmlIgnore] public string Country { get { return CountryCode?? Country2; } }

    }
}
