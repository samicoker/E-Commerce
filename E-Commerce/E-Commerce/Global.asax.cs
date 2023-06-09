using E_Commerce.Entity;
using E_Commerce.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace E_Commerce
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            Database.SetInitializer<DataContext>(null); // bunu entitynin alt�ndaki DataContext class�n�n static yap�c� metotundan kopyalad�k
            Database.SetInitializer(new IdentityInitializer());
        }
    }
}
