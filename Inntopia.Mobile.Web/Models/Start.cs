using Inntopia.Mobile.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Inntopia.Mobile.Web.Models
{
    [XmlRoot("Start")]
    public class InntopiaStart
    {
        [XmlArray("PreferredResellers")]
        [XmlArrayItem("PreferredReseller")]
        public Supplier[] PreferedResellers { get; set; }

        public InntopiaStart()
        {
//            PreferedResellers.OrderBy();
        }
    }

    public class Start
    {

    }
}