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
    }
}