using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Inntopia.Mobile.Data
{
    public class Image
    {
        [XmlAttribute] public string ID { get; set; }

        [XmlAttribute] public int DisplaySeq { set { DisplaySequence = value; } }
        [XmlAttribute] public int Sequence { set { DisplaySequence = value; }  }
        [XmlIgnore] public int DisplaySequence { get; set; }

        [XmlAttribute] public int Height { get; set; }
        [XmlAttribute] public int Width { get; set; }
        [XmlAttribute] public string Caption { get; set; }

        [XmlAttribute] public bool IsAbsolute { get; set; }
        [XmlAttribute] public string Path { set { URL = value; } }
        [XmlAttribute] public string FileName { set { URL = value; } }
        [XmlIgnore] public string URL { get; set; }
    }
}
