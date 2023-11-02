using KatmanliSinavProject.BLL.DTOs.MakaleDTOs;
using KatmanliSinavProject.UI.Models.ViewModels.MakaleVMs;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace KatmanliSinavProject.UI.Models.ViewModels.UserVMs
{
    public class AppUserVM
    {
        [Display(Name = "Kullanıcı Adı: ")]
        [Required(ErrorMessage = "Kullanıcı Adı Boş Geçilemez")]
        public string UserName { get; set; }
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
        public IList<MakaleVM> Makales { get; set; }

    }
}
