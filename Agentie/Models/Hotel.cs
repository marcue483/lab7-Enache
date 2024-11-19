using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Agentie.Models
{
    public class Hotel
    {
        [ScaffoldColumn(false)]
        [Key]
        public int HotelId { get; set; }

        [Required(ErrorMessage = "Câmpul este obligatoriu")]
        [RegularExpression(@"^[A-Z][a-z]+$", ErrorMessage = "Formatul denumirei nu este indicat corect")]
        [Display(Name = "Denumirea Hotelului")]
        public required string Name { get; set; }

        [Required]
        [Display(Name = "Preț")]
        public int Price { get; set; }

        [Required]
        [Range(1, 5, ErrorMessage = "Nota este eronata")]
        [Display(Name = "Stele")]
        public int Stele { get; set; }

        [Required]
        [Display(Name = "Locație")]
        public required string Location { get; set; }

        [Required]
        public int ClientId { get; set; }
        public Client? Client { get; set; }

        [Required]
        public int PackageId { get; set; }
        public Package? Package { get; set; }
        public virtual ICollection<Transportare> Transports { get; set; } = new List<Transportare>(); 
    }
}
