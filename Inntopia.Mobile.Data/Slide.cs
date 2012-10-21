using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Inntopia.Mobile.Data
{
    public class Slide
    {
        [XmlAttribute("IsUrl")]
        public bool IsUrl { get; set; }

        [XmlAttribute("Sequence")]
        public int Sequence { get; set; }

        [XmlAttribute("Height")]
        public int Height { get; set; }

        [XmlAttribute("Width")]
        public int Width { get; set; }

        [XmlAttribute("Caption")]
        public string Caption { get; set; }

        [XmlAttribute("Path")]
        public string Path { get; set; }

        [XmlAttribute("ImageId")]
        public string ImageId { get; set; }
    }
}
