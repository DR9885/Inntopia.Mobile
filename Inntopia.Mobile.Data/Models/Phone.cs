using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Inntopia.Mobile.Data
{
    public class Phone
    {
        [XmlAttribute("Type")]
        public int Type { get; set; }

        [XmlAttribute("FullPhone")]
        public string FullPhone { get; set; }
    }
}
