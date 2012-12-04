using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Inntopia.Mobile.Data
{
    public class Policy
    {
        [XmlAttribute] public int ID { get; set; }
        [XmlAttribute] public string Name { get; set; }
        [XmlAttribute] public string Description { get; set; }
    }
}
