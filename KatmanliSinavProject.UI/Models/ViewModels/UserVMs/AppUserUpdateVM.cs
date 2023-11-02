using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace KatmanliSinavProject.UI.Models.ViewModels.UserVMs
{
    public class AppUserUpdateVM
    {
        public string Id { get; set; }
        [Display(Name = "Ad: ")]
        [Required(ErrorMessage = "Ad Boş Geçilemez")]
        public string FirstName { get; set; }
        [Display(Name = "Soyad: ")]
        [Required(ErrorMessage = "Soyad Boş Geçilemez")]

        public string LastName { get; set; }

        [Display(Name = "Email: ")]
        [Required(ErrorMessage = "Mail Boş Geçilemez")]
        [EmailAddress]
        public string Email { get; set; }
        [Display(Name = "Telefon: ")]
        [Required(ErrorMessage = "Telefon Boş Geçilemez")]
        [Phone]
        public string PhoneNumber { get; set; }
    }
}
