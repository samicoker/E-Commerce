using E_Commerce.Entity;
using E_Commerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Commerce.Controllers
{
    public class CartController : Controller
    {
        DataContext db = new DataContext();
        // GET: Cart
        public ActionResult Index()
        {
            return View(GetCart());
        }
        private void SaveOrder(Cart cart,ShippingDetails model)
        {
            var order = new Order();
            order.OrderNumber = "S" + (new Random()).Next(1111,9999).ToString();
            order.Total = cart.Total();
            order.OrderDate = DateTime.Now;
            order.UserName = User.Identity.Name;
            order.Adres = model.Adres;
            order.Sehir= model.Sehir;
            order.Semt = model.Semt;
            order.Mahalle = model.Mahalle;
            order.PostaKodu = model.PostaKodu;
            order.OrderLines = new List<OrderLine>();
            foreach (var item in cart.CartLines)
            {
                var orderLine = new OrderLine();
                orderLine.Quantity = item.Quantity;
                orderLine.Price = item.Product.Price * item.Quantity;
                orderLine.ProductId = item.Product.Id;
                order.OrderLines.Add(orderLine);
            }
            db.Orders.Add(order);
            db.SaveChanges();
        }
        public ActionResult Checkout()
        {
            return View(new ShippingDetails());
        }
        [HttpPost]
        public ActionResult Checkout(ShippingDetails model)
        {
            var cart = GetCart();

            if (cart.CartLines.Count == 0)
            {
                ModelState.AddModelError("UrunYok", "Sepetinizde ürün bulunmamaktadır..");
            }

            if (ModelState.IsValid)
            {
                SaveOrder(cart, model);
                cart.Clear();
                return View("SiparisTamamlandi");
            }
            else
            {
                return View(model);
            }
        }
        public PartialViewResult Summary()
        {
            return PartialView(GetCart());
        }
        public PartialViewResult Summary1()
        {
            return PartialView(GetCart());
        }
        public ActionResult RemoveFromCart(int id)
        {
            var product = db.Products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                GetCart().DeleteProduct(product);
            }
            return RedirectToAction("Index");
        }
        public ActionResult AddToCart(int id)
        {
            var product = db.Products.FirstOrDefault(p => p.Id == id);
            if (product!=null)
            {
                GetCart().AddProduct(product, 1);
            }
            return RedirectToAction("Index");
        }
        public Cart GetCart()
        {
            var cart = (Cart)Session["Cart"]; // tüm web programlama dillerinde oturum bilgilerini saklamak ve yönetmek için Session kullanılır. Session çerezlerden farklı olarak kullanıcının bilgisayarında değil de sunucuda saklanır. Burada kullanıcının kartı var mı diye bakıyoruz, alt satırda da yoksa kullanıcıya özel Cart ekliyoruz
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
    }
}