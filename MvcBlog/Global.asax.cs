using MvcBlog.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MvcBlog
{
    public class MvcApplication : System.Web.HttpApplication
    {
       
        protected void Application_Start(object sender, EventArgs e)
        {
            
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<ApplicationDbContext,
                MVCBlog.Migrations.Configuration>());
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Application["Totaluser"] = 0;
        }

        protected void Session_Start()
        {
            Application.Lock();
            Application["Totaluser"] = (int)Application["Totaluser"] + 1;
            Application.UnLock();
        }
    }
}
