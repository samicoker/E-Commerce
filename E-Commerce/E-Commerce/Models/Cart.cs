using E_Commerce.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce.Models
{
    public class Cart
    {
        private List<CartLine> _cartLines = new List<CartLine>();
        public List<CartLine> CartLines
        {
            get { return _cartLines; }
        }
        public void AddProduct(Product product, int quantity) // ürün ekleme
        {
            var line = _cartLines.FirstOrDefault(x => x.Product.Id == product.Id); // kullanıcının eklediği ürün sepette yoksa yeni CartLine yani yeni satır oluşturup içine ürün ve sayısını giriyoruz, eğer varsa da üzerine ekliyoruz.
            if (line == null)
            {
                _cartLines.Add(new CartLine() { Product = product, Quantity = quantity });
            }
            else
            {
                line.Quantity+=quantity;
            }
        }
        public void DeleteProduct(Product product)
        {
            _cartLines.RemoveAll(p=>p.Product.Id == product.Id);
        }
        public decimal Total() // tüm ürünlerin toplam fiyatı
        {
            return _cartLines.Sum(p => p.Product.Price * p.Quantity);
        }
        public void Clear()
        {
            _cartLines.Clear();
        }
    }
    public class CartLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}