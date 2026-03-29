using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_Commerce.Models
{
    public class ChangePasswordModel
    {
        [Required]
        [DisplayName("Eski Şifre")]
        public string OldPassword { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Şifre en az 5 karakter olmalı")]
        [DisplayName("Yeni Şifre")]
        public string NewPassword { get; set; }
        [Required]
        [DisplayName("Yeni Şifre Tekrar")]
        [Compare("NewPassword",ErrorMessage="Şifreler aynı değil..")]
        public string ConNewPassword { get; set; }
    }
}