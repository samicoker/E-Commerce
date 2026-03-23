using Microsoft.Owin;
using Owin;
using System;
using System.Threading.Tasks;

[assembly: OwinStartup(typeof(E_Commerce.App_Start.Startup1))] //Uygulama başlarken Startup1 sınıfını çalıştır

namespace E_Commerce.App_Start
{
    public class Startup1
    {
        public void Configuration(IAppBuilder app)// Request gelir ve buradaki ayarlara göre işlenir
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888

            app.UseCookieAuthentication(new Microsoft.Owin.Security.Cookies.CookieAuthenticationOptions
            {//Kullanıcı login olunca cookie ile kimliğini sakla
                AuthenticationType = "ApplicationCookie",//Bu sadece bir isim. Ama kritik.Login olurken bunu kullanman gerekir:
                LoginPath = new PathString("/Account/Login")// Eğer kullanıcı login olarak girmesi gereken bir sayfaya ([Authorize] olan bir sayfaya) login olmadan giderse onu /Account Controllerin Login metoduna yönlendir
            });
        }
    }
}
