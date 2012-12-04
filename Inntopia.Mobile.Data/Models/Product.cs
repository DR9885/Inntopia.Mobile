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
        [XmlAttribute] public int Id { get; set; }
        [XmlAttribute] public string Name { get; set; }
        [XmlAttribute] public string Description { get; set; }

        [XmlAttribute] public float TotalPrice { get; set; }
        [XmlAttribute] public string Currency { get; set; }


        [XmlElement("ProductImage")] public Image[] ProductImages { get; set; }
        [XmlElement("Slide")] public Image[] Slides { get; set; }
        [XmlIgnore] public Image[] Images { 
            get { return ProductImages?? Slides; }
            set { Slides = value; }
        }
    }
}
