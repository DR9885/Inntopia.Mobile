using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Inntopia.Mobile.Data
{
    public class AttributeType  
    {
        [XmlElement("Attribute")]
        public Attribute[] Attributes { get; set; }

        [XmlAttribute("DisplaySequence")]
        public int DisplaySequence { get; set; }

        [XmlAttribute("CodeTypeDesc")]
        public string CodeTypeDesc { get; set; }

        [XmlAttribute("CodeType")]
        public int CodeType { get; set; }


    }
}
