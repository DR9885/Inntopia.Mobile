using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Inntopia.Mobile.Data
{
    public class Card
    {
        [XmlAttribute("Type")]
        public string Type { get; set; }

    }
}
