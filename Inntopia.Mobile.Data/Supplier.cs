using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Inntopia.Mobile.Data
{
    public class Supplier
    {
        [XmlAttribute("ID")]
        public int ID { get; set; }

        [XmlAttribute("Name")]
        public string Name { get; set; }

        [XmlAttribute("Description")]
        public string Description { get; set; }

        [XmlAttribute("CategoryName")]
        public string CategoryName { get; set; }

        [XmlAttribute("CategoryID")]
        public int CategoryID { get; set; }

        [XmlAttribute("PricingCurrency")]
        public string PricingCurrency { get; set; }

        [XmlAttribute("Directions")]
        public string Directions { get; set; }

        [XmlAttribute("Website")]
        public string Website { get; set; }

        [XmlAttribute("Reservations")]
        public bool Reservations { get; set; }

        [XmlAttribute("City")]
        public string City { get; set; }

        [XmlAttribute("Region")]
        public string StateRegion { get; set; }
    }

}
