using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Inntopia.Mobile.Data
{
    public class Category
    {
        [XmlAttribute("ID")]
        public int ID { get; set; }

        [XmlAttribute("Name")]
        public string Name { get; set; }

        [XmlAttribute("ShortName")]
        public string ShortName { get; set; }

        [XmlAttribute("DisplayType")]
        public int DisplayType { get; set; }

        [XmlAttribute("DisplaySeq")]
        public int DisplaySeq { get; set; }
    }
}
