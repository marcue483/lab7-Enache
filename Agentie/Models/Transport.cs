using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Agentie.Models
{
    public class Transportare
    {
        [ScaffoldColumn(false)]
        [Key]
        public int TransportId { get; set; }

        [Required(ErrorMessage = "Câmpul este obligatoriu")]
        [RegularExpression(@"^[A-Z][a-z]+$", ErrorMessage = "Formatul denumirii nu este indicat corect")]
        [Display(Name = "Denumirea companiei")]
        public required string Name { get; set; }

        [Required]
        public int ClientId { get; set; }
        public Client? Client { get; set; }

        [Required]
        [Display(Name = "Preț")]
        public int Price { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [Display(Name = "Data")]
        public DateTime Data { get; set; }

        [Required]
        [Display(Name = "Nr de persoane")]
        public int PersonNR { get; set; }
    }
}
