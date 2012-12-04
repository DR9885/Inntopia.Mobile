using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Inntopia.Mobile.Data
{
    public class CodeSet
    {
        [XmlAttribute("Name")]
        public string Name { get; set; }

        [XmlElement("Code")]
        public Code[] Code { get; set; }
    }

    public class Code
    {
        [XmlAttribute("Description")]
        public string Description { get; set; }

        [XmlAttribute("Value")]
        public int Value { get; set; }

        [XmlAttribute("Default")]
        public int Default { get; set; }

        [XmlAttribute("Sequence")]
        public int Sequence { get; set; }
    }

}
