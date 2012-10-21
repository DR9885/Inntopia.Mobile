using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Inntopia.Mobile.Data
{
    public class Attribute
    {
        [XmlAttribute("Value")]
        public int Value { get; set; }

        [XmlAttribute("DisplaySequence")]
        public int DisplaySequence { get; set; }

        [XmlAttribute("InputType")]
        public string InputType { get; set; }

        [XmlAttribute("CodeName")]
        public string CodeName { get; set; }

        [XmlAttribute("Code")]
        public int Code { get; set; }

    }
}
