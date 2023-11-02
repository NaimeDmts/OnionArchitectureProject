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
    [Table("TblKonu")]
    public class Konu : IBaseEntity
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Baslik { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public Status Status { get; set; } = Status.Active;

        //Navigation Properties
        public virtual ICollection<Makale> Makales { get; set; }
    }
}
