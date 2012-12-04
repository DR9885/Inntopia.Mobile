using Inntopia.Mobile.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Inntopia.Mobile.Web.Models
{
    [XmlRoot("SearchResults")]
    public class SearchResponse
    {

        [XmlArray("Locations")]
        [XmlArrayItem("Location")]
        public Supplier[] Locations { get; set; }

        //[XmlArray("DisplayPrefs")]
        //[XmlArrayItem("Pref")]
        //public DisplayPref[] DisplayPrefs { get; set; }
    }

    public class Session
    {
        [XmlAttribute("ID")]
        public string ID { get; set; }
    }

    public class DisplayPref
    {
        [XmlAttribute("ID")]
        public int ID { get; set; }

        [XmlAttribute("Name")]
        public string Name { get; set; }

        [XmlAttribute("Value")]
        public bool Enabled { get; set; }
    }
}