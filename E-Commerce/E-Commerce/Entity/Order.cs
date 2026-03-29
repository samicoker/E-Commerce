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
        public string Address { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Neighbourhood { get; set; }
        public string PostCode { get; set; }
        public virtual List<OrderDetails> OrderDetails { get; set; }

    }
    public class OrderDetails  // ürün için oluşturuyoruz
    {
        public int Id { get; set; } // ürün ıd si gibi düşünülebilir
        public int OrderId { get; set; } // categoryId gibi düşünülebilir
        public virtual Order Order { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}