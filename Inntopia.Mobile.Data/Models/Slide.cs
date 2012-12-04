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

        [XmlElement("DisplaySeq")] public int? DisplaySequence { get; set; }
        [XmlElement("Sequence")] public int? DisplaySeq { get; set; }
        [XmlIgnore] public int? Sequence {
            get { return DisplaySequence ?? DisplaySeq; }
            set { DisplaySeq = value; }
        }

        [XmlAttribute] public int Height { get; set; }
        [XmlAttribute] public int Width { get; set; }
        [XmlAttribute] public string Caption { get; set; }

        [XmlAttribute] public bool IsAbsolute { get; set; }

        [XmlElement("Path")] public string Path { get; set; }
        [XmlElement("FileName")] public string FileName { get; set; }
        [XmlIgnore] public string URL {
            get { return Path ?? FileName; }
            set { Path = value; }
        }
    }



}
