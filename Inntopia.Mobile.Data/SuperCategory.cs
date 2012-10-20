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

        public int DisplayType { get; set; }
    }

}
