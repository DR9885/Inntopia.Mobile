using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Inntopia.Mobile.Data
{
    public class SuperCategory
    {
        [XmlElement("Category", typeof(Category))]
        public Category[] Categories { get; set; }

        [XmlAttribute("ID")]
        public int ID { get; set; }

        [XmlAttribute("Name")]
        public string Name { get; set; }

        [XmlAttribute("ShortName")]
        public string ShortName { get; set; }

        public string Icon
        {
            get
            {
                switch (ShortName)
                {
                    case "Shuttle": return "truck";
                    case "Lodging": return "fahome";
                    case "Activities": return "grid";
                    case "Lifts": return "direction";
                    case "Spa": return "tint";
                    case "Equipment": return "bell";
                    case "Air": return "plane";
                    case "Golf": return "flag";
                    case "Car": return "truck";
                    case "Events":return "drink";
                    case "Misc": return "tag";
                    case "Merchandise": return "lock";
                    case "Services": return "lightning";

                    default: return "";
                }
            }
        }
    }

}
