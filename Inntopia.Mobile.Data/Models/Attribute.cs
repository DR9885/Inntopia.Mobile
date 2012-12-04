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
        [XmlAttribute] public int Code { get; set; }
        [XmlAttribute] public string Name { get; set; }

        [XmlAttribute] public int Value { get; set; }
        [XmlAttribute] public string InputType { get; set; }
        [XmlAttribute] public int DisplaySequence { get; set; }
    }
}
