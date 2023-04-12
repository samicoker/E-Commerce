using E_Commerce.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Commerce.Controllers
{
    public class HomeController : Controller
    {
        DataContext db = new DataContext();

        public ActionResult Search(string q)
        {
            var products = db.Products.Where(x=>x.IsApproved);

            if (!string.IsNullOrEmpty(q))
            {
                products = products.Where(x => x.Name.Contains(q) || x.Description.Contains(q));
            }
            return View(products.ToList());
        }
        public PartialViewResult Slider()
        {
            var products = db.Products.Where(x => x.IsApproved && x.Slider).Take(5).ToList();
            return PartialView(products);
        }
        public PartialViewResult _FeaturedProductList()
        {
            var products = db.Products.Where(x=>x.IsApproved && x.IsFeatured).Take(5).ToList();
            return PartialView(products);
        }
        // GET: Home
        public ActionResult Index()
        {

            List<Product> products = new List<Product>
            {
                //new Product{Id=1, Name="Test",CategoryId=1,Description="açıklama deneme",Image="50299859_2184832821769918_7218346797591166976_n.png",IsApproved=true,IsFeatured=true,IsHome=true,Price=250,Slider=true,Stock=150},
                //new Product{Id=2, Name="Test1",CategoryId=1,Description="açıklama1 deneme",Image="101084493_661253271102154_6497855060045725696_n.png",IsApproved=true,IsFeatured=true,IsHome=true,Price=250,Slider=true,Stock=150},
                //new Product{Id=3, Name="Test2",CategoryId=1,Description="açıklama deneme",Image="50299859_2184832821769918_7218346797591166976_n.png",IsApproved=true,IsFeatured=true,IsHome=true,Price=250,Slider=true,Stock=150}
            };
            //return View(products);
            return View(db.Products.Where(x=>x.IsApproved && x.IsHome).ToList());

        }
        public ActionResult ProductDetails(int id)
        {
            //List<Product> products = new List<Product>
            //{
            //    new Product{Id=1, Name="Test",CategoryId=1,Description="açıklama deneme",Image="50299859_2184832821769918_7218346797591166976_n.png",IsApproved=true,IsFeatured=true,IsHome=true,Price=250,Slider=true,Stock=150},
            //    new Product{Id=2, Name="Test1",CategoryId=1,Description="açıklama1 deneme",Image="101084493_661253271102154_6497855060045725696_n.png",IsApproved=true,IsFeatured=true,IsHome=true,Price=250,Slider=true,Stock=150},
            //    new Product{Id=3, Name="Test2",CategoryId=1,Description="açıklama deneme",Image="50299859_2184832821769918_7218346797591166976_n.png",IsApproved=true,IsFeatured=true,IsHome=true,Price=250,Slider=true,Stock=150}
            //};
            var products = db.Products.ToList();
            return View(products.Where(x=>x.Id==id).FirstOrDefault());
        }
        public ActionResult Product()
        {
            List<Product> products = new List<Product>
            {
                new Product{Id=1, Name="Test",CategoryId=1,Description="açıklama deneme",Image="50299859_2184832821769918_7218346797591166976_n.png",IsApproved=true,IsFeatured=true,IsHome=true,Price=250,Slider=true,Stock=150},
                new Product{Id=2, Name="Test1",CategoryId=1,Description="açıklama1 deneme",Image="101084493_661253271102154_6497855060045725696_n.png",IsApproved=true,IsFeatured=true,IsHome=true,Price=250,Slider=true,Stock=150},
                new Product{Id=3, Name="Test2",CategoryId=1,Description="açıklama deneme",Image="50299859_2184832821769918_7218346797591166976_n.png",IsApproved=true,IsFeatured=true,IsHome=true,Price=250,Slider=true,Stock=150},
                new Product{Id=4, Name="Test2",CategoryId=1,Description="açıklama deneme",Image="50299859_2184832821769918_7218346797591166976_n.png",IsApproved=true,IsFeatured=true,IsHome=true,Price=250,Slider=true,Stock=150}
            };
            //return View(products);
            return View(db.Products.ToList());
        }
        public ActionResult ProductList(int id)
        {
            return View(db.Products.Where(x=>x.CategoryId==id).ToList());
        }
    }
}