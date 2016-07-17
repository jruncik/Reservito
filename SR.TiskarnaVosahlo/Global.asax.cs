using System;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebApplication1;

namespace TV.TiskarnaVosahlo
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            new Tiskarna.TiskarnaVosahlo();
        }

        protected void Session_Start(Object sender, EventArgs e)
        {
            Session["init"] = 0;
        }
    }
}
