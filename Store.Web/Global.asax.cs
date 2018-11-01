using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Store.Common;

namespace Store.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Init database
            // System.Data.Entity.Database.SetInitializer(new StoreSeedData());

            AreaRegistration.RegisterAllAreas();
            // Autofac and Automapper configurations
            Bootstrapper.Run();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_Error(Object sender, EventArgs e)
        {
            var exception = Server.GetLastError();

            //log error
            LogException(exception);
        }

        protected void LogException(Exception exc)
        {
            if (exc == null)
                return;


            //ignore 404 HTTP errors
            var httpException = exc as HttpException;
            if (httpException != null && httpException.GetHttpCode() == 404)
                return;

            try
            {
                
            }
            catch (Exception)
            {
                //don't throw new exception if occurs
            }
        }
    }
}
