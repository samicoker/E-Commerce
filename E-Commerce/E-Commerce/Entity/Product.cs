using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace E_Commerce.Entity
{
    //[Table("Products")]
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public bool Slider { get; set; } // Slaytta kullancağımız ürünleri getirmek için kullanacağız
        public bool IsHome { get; set; } // Anasayfada görünüp görünmeyeceği
        public bool IsFeatured { get; set; } // Öne çıkan ürünler
        public bool IsApproved { get; set; } // Onaylı bir ürün mü, true ise ürün satıştadır, false ise listelenmez kullanıcılar görmez ama admin panelde görünür
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}