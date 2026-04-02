using E_Commerce.Entity;
using E_Commerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Commerce.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        DataContext db = new DataContext();
        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            StateModel model = new StateModel();

            model.BekleyenSiparisCount=db.Orders.Where(x=>x.OrderState == OrderState.Bekleniyor).ToList().Count();
            model.TamamlananSiparisCount=db.Orders.Where(x=>x.OrderState == OrderState.Tamamlandı).ToList().Count();
            model.PaketlenenSiparisCount=db.Orders.Where(x=>x.OrderState == OrderState.Paketlendi).ToList().Count();
            model.KargolananSiparisCount=db.Orders.Where(x=>x.OrderState == OrderState.Kargolandı).ToList().Count();

            model.ProductCount = db.Products.Count();
            model.OrderCount = db.Orders.Count();

            return View(model);
        }

        public PartialViewResult NotificationsMenu()
        {
            var notifications = db.Orders.Where(x => x.OrderState == OrderState.Bekleniyor).ToList();

            return PartialView(notifications);
        }
    }
}