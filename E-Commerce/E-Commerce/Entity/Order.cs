using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce.Entity
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public decimal Total { get; set; }
        public DateTime OrderDate { get; set; }
        public string UserName { get; set; }
        public string Adres { get; set; }
        public string Sehir { get; set; }
        public string Semt { get; set; }
        public string Mahalle { get; set; }
        public string PostaKodu { get; set; }
        public virtual List<OrderLine> OrderLines { get; set; }

    }
    public class OrderLine  // ürün için oluşturuyoruz
    {
        public int Id { get; set; } // ürün ıd si
        public int OrderId { get; set; } // categoryId gibi düşünülebilir
        public virtual Order Order { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}