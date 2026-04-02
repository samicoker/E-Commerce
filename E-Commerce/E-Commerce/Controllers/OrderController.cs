using E_Commerce.Entity;
using E_Commerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Commerce.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        DataContext db = new DataContext();
        public ActionResult Index()
        {
            var orders = db.Orders.Select(x => new AdminOrder
            {
                Id = x.Id,
                OrderNumber = x.OrderNumber,
                OrderDate = x.OrderDate,
                OrderState = x.OrderState,
                Total = x.Total,
                Count = x.OrderDetails.Count,
            }).OrderByDescending(x=>x.OrderDate).ToList();

            return View(orders);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {

            var model = db.Orders.Where(x => x.Id == id).Select(x => new OrderDetailsModel
            {
                OrderId = x.Id,
                OrderNumber= x.OrderNumber,
                Total = x.Total,
                UserName = x.UserName,
                OrderDate = x.OrderDate,
                OrderState = x.OrderState,
                Address = x.Address,
                City = x.City,
                District = x.District,
                Neighbourhood = x.Neighbourhood,
                PostCode =x.PostCode,
                OrderLines = x.OrderDetails.Select(i=>new OrderLineModel()
                {
                    ProductId = i.ProductId,
                    Image = i.Product.Image,
                    ProductName = i.Product.Name,
                    Quantity = i.Quantity,
                    Price = i.Price,
                }).ToList()
            }).FirstOrDefault();

            return View(model);
        }
        [HttpPost]
        public ActionResult UpdateOrderState(int orderId, OrderState OrderState)
        {
            var order = db.Orders.FirstOrDefault(x=>x.Id == orderId);
            if(order != null)
            {
                order.OrderState = OrderState;
                db.SaveChanges();
                TempData["message"] = "Bilgiler Kaydedildi";
                return RedirectToAction("Details", new { id = orderId });
            }
            return RedirectToAction("Index");
        }

        public ActionResult BekleyenSiparisler()
        {
            var model = db.Orders.Where(x => x.OrderState == OrderState.Bekleniyor).ToList();
            return View(model);
        }
        public ActionResult TamamlananSiparisler()
        {
            var model = db.Orders.Where(x => x.OrderState == OrderState.Tamamlandı).ToList();
            return View(model);
        }

        public ActionResult PaketlenenSiparisler()
        {
            var model = db.Orders.Where(x => x.OrderState == OrderState.Paketlendi).ToList();
            return View(model);
        }
        public ActionResult KargolananSiparisler()
        {
            var model = db.Orders.Where(x => x.OrderState == OrderState.Kargolandı).ToList();
            return View(model);
        }
    }
}