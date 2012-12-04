using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inntopia.Mobile.Web.Models
{
    public class Gallery
    {
        public string JSONSettings { get; set; }
        public List<Image> Images { get; set; }
    }

    public class PhotoSwipeSettings
    {
        public bool allowUserZoom { get; set; }
        public bool enableMouseWheel { get; set; }
        public bool enableKeyboard { get; set; }
    }

    public class Image
    {
        public string Name { get; set; }
        public string URL { get; set; }
        public string Caption { get; set; }
    }
}