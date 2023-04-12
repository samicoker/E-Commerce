using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_Commerce.Models
{
    public class UserProfile
    {
        public string Id { get; set; }
        [DisplayName("Adı")]
        public string Name { get; set; }
        [DisplayName("Soyadı")]
        public string Surname { get; set; }
        [DisplayName("Kullanıcı Adı")]
        public string UserName { get; set; }
        [DisplayName("Email")]
        [EmailAddress(ErrorMessage ="Geçerli email adresi giriniz..")]
        public string Email { get; set; }
    }
}