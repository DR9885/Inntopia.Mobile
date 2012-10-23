using Inntopia.Mobile.Data;
using System.Xml.Serialization;

namespace Inntopia.Mobile.Web.Models
{
    [XmlRoot("Selector")]
    public class Selector {

        [XmlElement("DefaultValues")]
        public DefaultValues DefaultValues { get; set; }

        [XmlArray("AvailableCategories")]
        [XmlArrayItem("SuperCategory")]
        public SuperCategory[] SuperCategories { get; set; }

        [XmlArray("AttributeType")]
        [XmlArrayItem("Attribute")]
        public Attribute[] Attributes { get; set; }
    }

    public class DefaultValues
    {
        [XmlAttribute("DisplayTeeTimes")]
        public int HasTeeTimes { get; set; }

        [XmlAttribute("RequestChildAges")]
        public bool NeedsChildAges { get; set; }

        [XmlAttribute("DatelessAllowed")]
        public bool CanSearchDateless { get; set; }

        [XmlAttribute("Language")]
        public string Language { get; set; }
    }

}
