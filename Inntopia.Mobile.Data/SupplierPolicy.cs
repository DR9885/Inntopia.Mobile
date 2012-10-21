using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Inntopia.Mobile.Data
{
    public class SupplierPolicy
    {
        [XmlAttribute("Description")]
        public string Description { get; set; }

        [XmlAttribute("Name")]
        public string Name { get; set; }

        [XmlAttribute("ID")]
        public int ID { get; set; }

    }
}
