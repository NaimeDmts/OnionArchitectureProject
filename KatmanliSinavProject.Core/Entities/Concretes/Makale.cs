using KatmanliSinavProject.Core.Entities.Abstraction;
using KatmanliSinavProject.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatmanliSinavProject.Core.Entities.Concretes
{
    [Table("TblMakale")]
    public class Makale : IBaseEntity
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Baslik { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(max)")]
        public string Icerik { get; set; }
        public double OrtalamaOkumaSuresi { get; set; }
        [Required]
        [Column(TypeName = "date")]
        public DateTime MakaleYazimTarihi { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public Status Status { get; set; } = Status.Active;
        public string AppUserId { get; set; }
        public int KonuId { get; set; }

        //Navigation Properties
        public virtual AppUser AppUser { get; set; }
        public virtual Konu Konu { get; set; }
    }
}
