using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Inntopia.Mobile.Data
{
    public class ContactInfo
    {
        [XmlAttribute] public string Name { get; set; }
        [XmlAttribute] public string Directions { get; set; }
        [XmlAttribute] public string PricingCurrency { get; set; }

        [XmlAttribute] public int CategoryID { get; set; }
        [XmlAttribute] public string CategoryName { get; set; }

        [XmlElement] public Address Address { get; set; }
        [XmlElement] public Phone Phone { get; set; }
        [XmlElement] public Email Email { get; set; }

        [XmlAttribute] public string Website { get; set; }
        [XmlAttribute] public bool Reservations { get; set; }
        
    }
}
