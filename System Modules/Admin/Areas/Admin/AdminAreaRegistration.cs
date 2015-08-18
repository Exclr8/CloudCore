﻿using System.Web.Mvc;

namespace CloudCore.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { controller = "Main", action = "Index", area = "Admin", id = UrlParameter.Optional },
                new [] { "CloudCore.Admin.Controllers" }
            );
        }
    }
}