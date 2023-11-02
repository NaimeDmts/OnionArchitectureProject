using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace KatmanliSinavProject.UI.Models.ViewModels.UserVMs
{
    public class RegisterVM
    {
        [Display(Name = "Kullanıcı Adı: ")]
        [Required(ErrorMessage = "Kullanıcı Adı Boş Geçilemez")]
        public string UserName { get; set; }

        [Display(Name = "Email: ")]
        [Required(ErrorMessage = "Mail Boş Geçilemez")]
        [EmailAddress]
        public string Email { get; set; }
        [Display(Name = "Telefon: ")]
        [Required(ErrorMessage = "Telefon Boş Geçilemez")]
        [Phone]
        public string PhoneNumber { get; set; }
        [Display(Name = "Şifre: ")]
        [Required(ErrorMessage = "Şifre Boş Geçilemez")]
        [DataType(DataType.Password)]
        [StringLength(10, ErrorMessage = "Max 10 min 3 olmalı", MinimumLength = 3)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Boş Geçilemez")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Girilen Şifreler Uyumulu olmalı.")]
        [StringLength(10, ErrorMessage = "Max 10 min 3 olmalı", MinimumLength = 3)]
        public string ConfirmPassword { get; set; }
    }
}
