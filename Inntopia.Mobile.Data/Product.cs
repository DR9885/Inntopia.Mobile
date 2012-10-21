using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Inntopia.Mobile.Data
{
    public class Product
    {
        [XmlElement("Slide", typeof(Slide))]
        public Slide[] Slides { get; set; }

        [XmlAttribute("ProductId")]
        public int ProductId { get; set; }

        [XmlAttribute("ProductName")]
        public string ProductName { get; set; }

    }
}
