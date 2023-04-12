using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace E_Commerce.Identity
{
    public class IdentityInitializer:CreateDatabaseIfNotExists<IdentityDataContext>
    {
        static IdentityInitializer()
        {
            IdentityDataContext context = new IdentityDataContext();
            if (!context.Roles.Any(x => x.Name == "admin"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);
                var role = new ApplicationRole() { Name = "admin", Description = "admin rolü" };
                manager.Create(role);
            }
            if (!context.Roles.Any(x => x.Name == "user"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);
                var role = new ApplicationRole() { Name = "user", Description = "user rolü" };
                manager.Create(role);
            }
            if (!context.Users.Any(x => x.UserName == "samicoker"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser() { Name = "Sami", Surname = "Çoker", UserName = "samicoker", Email = "samicoker@gmail.com" };
                manager.Create(user, "123456");
                manager.AddToRole(user.Id, "admin"); // kullanıcıya admin rolünü verdik
                manager.AddToRole(user.Id, "user"); // şimdi de user rolü verdik
            }
            if (!context.Users.Any(x => x.UserName == "gurkanozcan"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser() { Name = "Gürkan", Surname = "Özcan", UserName = "gurkanozcan", Email = "gurkanozcan@gmail.com" };
                manager.Create(user, "123456");
                manager.AddToRole(user.Id, "user"); // şimdi de user rolü verdik
            }
        }
        //protected override void Seed(IdentityDataContext context)
        //{
        //    if (!context.Roles.Any(x => x.Name == "admin"))
        //    {
        //        var store = new RoleStore<ApplicationRole>(context);
        //        var manager = new RoleManager<ApplicationRole>(store);
        //        var role = new ApplicationRole() { Name = "admin", Description = "admin rolü" };
        //        manager.Create(role);
        //    }
        //    if (!context.Roles.Any(x => x.Name == "user"))
        //    {
        //        var store = new RoleStore<ApplicationRole>(context);
        //        var manager = new RoleManager<ApplicationRole>(store);
        //        var role = new ApplicationRole() { Name = "user", Description = "user rolü" };
        //        manager.Create(role);
        //    }
        //    if (!context.Users.Any(x => x.UserName == "samicoker"))
        //    {
        //        var store = new UserStore<ApplicationUser>(context);
        //        var manager = new UserManager<ApplicationUser>(store);
        //        var user = new ApplicationUser() { Name = "Sami", Surname = "Çoker", UserName = "samicoker", Email = "samicoker@gmail.com" };
        //        manager.Create(user, "123456");
        //        manager.AddToRole(user.Id, "admin"); // kullanıcıya admin rolünü verdik
        //        manager.AddToRole(user.Id, "user"); // şimdi de user rolü verdik
        //    }
        //    if (!context.Users.Any(x => x.UserName == "gurkanozcan"))
        //    {
        //        var store = new UserStore<ApplicationUser>(context);
        //        var manager = new UserManager<ApplicationUser>(store);
        //        var user = new ApplicationUser() { Name = "Gürkan", Surname = "Özcan", UserName = "gurkanozcan", Email = "gurkanozcan@gmail.com" };
        //        manager.Create(user, "123456");
        //        manager.AddToRole(user.Id, "user"); // şimdi de user rolü verdik
        //    }
        //    base.Seed(context);
        //}
    }
}