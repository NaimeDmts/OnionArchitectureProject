using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace KatmanliSinavProject.UI.Models.ViewModels.UserVMs
{
    public class LoginVM
    {
        [Display(Name = "Email: ")]
        [Required(ErrorMessage = "Mail Boş Geçilemez")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Şifre: ")]
        [Required(ErrorMessage = "Şifre Boş Geçilemez")]
        [DataType(DataType.Password)]
        [StringLength(10, ErrorMessage = "Max 10 min 3 olmalı", MinimumLength = 3)]
        public string Password { get; set; }
    }
}
