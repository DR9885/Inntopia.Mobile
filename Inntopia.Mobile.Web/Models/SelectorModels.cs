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
    public class Widget
    {
        public Widget()
        {
            // Create a request using a URL that can receive a post. 
            WebRequest request = WebRequest.Create("http://www.inntopia.travel/aspnet/09/selector.aspx?salesid=80002&advancedsearch=1&returnxml=1");
            request.Method = "GET";
            request.ContentType = "application/xml";

            WebResponse response = request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            //string responseFromServer = reader.ReadToEnd();
            

            // Serialize the object
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Selector));
            Selector s = xmlSerializer.Deserialize(reader) as Selector;
            reader.Close();

            var ages = s.DefaultValues.NeedsChildAges;
        }
    }

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

    public class Category
    {
        [XmlAttribute("ID")]
        public int ID { get; set; }

        [XmlAttribute("Name")]
        public string Name { get; set; }
        
        [XmlAttribute("ShortName")]
        public string ShortName { get; set; }

        [XmlAttribute("DisplayType")]
        public int DisplayType { get; set; }
        
        [XmlAttribute("DisplaySeq")]
        public int DisplaySeq { get; set; }
    }

    public class SuperCategory
    {
        [XmlArrayItem("Category", typeof(Category))]
        public Category[] Categories { get; set; }

        [XmlAttribute("ID")]
        public int ID { get; set; }

        [XmlAttribute("Name")]
        public string Name { get; set; }
        
        [XmlAttribute("ShortName")]
        public string ShortName { get; set; }

        public int DisplayType { get; set; }
    }


}
