﻿using System.Web;
using System.Web.Mvc;

namespace Inntopia.BookingEngine.Mobile.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}