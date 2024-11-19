using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Agentie.Models
{
    public class Package
    {
        [ScaffoldColumn(false)]
        [Key]
        public int PackageId { get; set; }

        [Required(ErrorMessage = "Câmpul este obligatoriu")]
        [RegularExpression(@"^[A-Z][a-z]+$", ErrorMessage = "Formatul denumirei nu este indicat corect")]
        [Display(Name = "Denumirea pachetului")]
        public required string Name { get; set; }

        [Required]
        [Display(Name = "Preț adaugator")]
        public int Price { get; set; }

        public ICollection<Hotel>? Hotels { get; set; }
    }
}
