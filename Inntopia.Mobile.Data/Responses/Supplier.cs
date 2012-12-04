using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Inntopia.Mobile.Data
{
    [XmlRoot("Supplier")]
    public class Supplier
    {
        // Base
        [XmlAttribute] public int ID { get; set; }
        [XmlAttribute] public string Name { get; set; }
        [XmlAttribute] public string Description { get; set; }

        // Category
        [XmlAttribute] public int CategoryID { get; set; }
        [XmlAttribute] public string CategoryName { get; set; }

        [XmlAttribute] public bool Reservations { get; set; }
        [XmlAttribute] public string PricingCurrency { get; set; }

        #region Location

        // Search.aspx
        [XmlAttribute] public string City { set { RequireAddress(); Address.City = value; } }
        [XmlAttribute] public string Region { set { RequireAddress(); Address.State = value; } }
        [XmlAttribute("Address")] public string Street { set { RequireAddress(); Address.StreetAddress = value; } }
        public void RequireAddress() { if (Address == null) Address = new Address(); }

        // Selector.aspx
        [XmlElement] public Address Address { get; set; }
        [XmlAttribute] public string Directions { get; set; }

        #endregion

        #region Contact Info

        [XmlElement] public Phone Phone { get; set; }
        [XmlElement] public Email Email { get; set; }

        #endregion

        [XmlArray("Slides")]
        [XmlArrayItem("Product")]
        public Product[] SlideProducts { set { Products = value; } }
        [XmlElement("Product")]
        public Product[] Products { get; set; }

        [XmlArray("SearchAttributes")]
        [XmlArrayItem("AttributeType")]
        public AttributeType[] AttributeTypes { get; set; }

        [XmlArray("Attributes")]
        [XmlArrayItem("Attribute")]
        public AvailableAttribute[] AvailableAttributes { get; set; }

        [XmlAttribute] public string Website { get; set; }
        
    }
}
