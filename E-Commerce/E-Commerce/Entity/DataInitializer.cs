using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace E_Commerce.Entity
{
    public class DataInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            //var categories = new List<Category>()
            //{
            //    new Category { Name="KAMERA",Description="Kamera Ürünleri"},
            //    new Category { Name="TELEFON",Description="Telefon Ürünleri"},
            //    new Category { Name="BİLGİSAYAR",Description="Bilgisayar Ürünleri"},
            //};

            //foreach (var item in categories)
            //{
            //    context.Categories.Add(item);
            //}
            //context.SaveChanges();
            //context.SaveChanges();

            context.Categories.AddOrUpdate(
    c => c.Name,
    new Category { Name = "KAMERA", Description = "Kamera Ürünleri" },
    new Category { Name = "TELEFON", Description = "Telefon Ürünleri" },
    new Category { Name = "BİLGİSAYAR", Description = "Bilgisayar Ürünleri" }
);

            context.SaveChanges();


//            context.Products.AddOrUpdate(
//    p => p.Name,
//    new Product { Name = "Canon", Price = 200, Stock = 125, IsHome = true, IsApproved = true },
//    new Product { Name = "Asus", Price = 2000, Stock = 100, IsHome = true, IsApproved = true }
//);

//            context.SaveChanges();


            var products = new List<Product>()
            {
                new Product{Name = "Canon",Description = "Kamera Ürünleri",Price=200m,Stock=125,IsHome=true,IsApproved = true,IsFeatured=false,Slider=true,CategoryId=1,Image="a.jpg"},
                new Product{Name = "Asus",Description = "Bilgisayar Ürünleri",Price=2000m,Stock=100,IsHome=true,IsApproved = true,IsFeatured=true,Slider=true,CategoryId=3,Image="b.jpg"},
                new Product{Name = "Lenovo",Description = "Bilgisayar Ürünleri",Price=35000,Stock=50,IsHome=false,IsApproved = true,IsFeatured=true,Slider=false,CategoryId=3,Image="c.jpg"},
                new Product{Name = "Samsung8s",Description = "Telefon Ürünleri",Price=50000,Stock=50,IsHome=true,IsApproved = true,IsFeatured=true,Slider=true,CategoryId=2,Image="d.jpg"},
            };

            foreach (var item in products)
            {
                context.Products.Add(item);
            }
            context.SaveChanges();
            base.Seed(context);
        }
    }
}