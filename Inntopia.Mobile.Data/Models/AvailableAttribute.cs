using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Inntopia.Mobile.Data
{
    public class AvailableAttribute
    {
        [XmlAttribute] public int Code { get; set; }
        [XmlAttribute] public int CodeType { get; set; }
        [XmlAttribute] public string Level { get; set; }
        [XmlAttribute] public int Value { get; set; }
        [XmlAttribute] public int Count { get; set; }
    }
}
