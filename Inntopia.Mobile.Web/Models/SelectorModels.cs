using Inntopia.Mobile.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;

namespace Inntopia.Mobile.Web.Models
{
    [XmlRoot("Selector")]
    public class Selector {

        [XmlElement("DefaultValues")]
        public DefaultValues DefaultValues { get; set; }

        [XmlArray("AvailableCategories")]
        [XmlArrayItem("SuperCategory", typeof(SuperCategory))]
        public SuperCategory[] SuperCategories { get; set; }
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
