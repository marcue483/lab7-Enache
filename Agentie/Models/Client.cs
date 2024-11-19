using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Agentie.Models
{
    public class Client
    {
        [ScaffoldColumn(false)]
        [Key]
        public int ClientId { get; set; }

        [Required(ErrorMessage = "Câmpul este obligatoriu")]
        [RegularExpression(@"^[A-Z][a-z]+$", ErrorMessage = "Formatul numelui nu este indicat corect")]
        [Display(Name = "Nume")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Câmpul este obligatoriu")]
        [RegularExpression(@"^[A-Z][a-z]+$", ErrorMessage = "Formatul prenumelui nu este indicat corect")]
        [Display(Name = "Prenume")]
        public required string SName { get; set; }

        [Required(ErrorMessage = "Câmpul este obligatoriu")]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Formatul postei nu este indicat corect")]
        [Display(Name = "e-mail")]
        public required string Mail { get; set; }


        [Required]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [Display(Name = "Data")]
        public DateTime Data { get; set; }

        [Required]
        [Display(Name = "Durata")]
        public int Durata { get; set; }

        [Required]
        [Display(Name = "Nr de persoane")]
        public int PersonNR { get; set; }

        public ICollection<Hotel>? Hotels { get; set; }
        public ICollection<Transportare>? Transportares { get; set; }
    }
}
