using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_Commerce.Models
{
    public class ShippingDetails // kullanıcı sipariş ver e tıkladığında adres bilgilerini doldurması için bu model oluştu
    {
        public string UserName { get; set; }
        [Required(ErrorMessage ="Lütfen adres giriniz")]
        public string Address { get; set; }
        [Required(ErrorMessage ="Lütfen şehir giriniz")]
        public string City { get; set; }
        [Required(ErrorMessage ="Lütfen ilçe giriniz")]
        public string District { get; set; }
        [Required(ErrorMessage ="Lütfen mahalle giriniz")]
        public string Neighbourhood { get; set; }
        [Required(ErrorMessage ="Lütfen Posta Kodu giriniz")]
        public string PostCode { get; set; }

    }
}