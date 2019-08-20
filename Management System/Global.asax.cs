using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Management_System
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //System.Timers.Timer time = new System.Timers.Timer();
            //time.Start();
            //time.Interval = 60000; // 2 hours
            //time.Elapsed += time_elapsed;
        }
        public void time_elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            @Management_System.Controllers.HomeController.CheckSubmission();
        }
    }
}
