using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proiect_Anca_Simulei.Models
{
    public class Vin
    {
        public int ID { get; set; }

        [Required, StringLength(150, MinimumLength = 3)]

        [Display(Name = "Nume vin")]
        public string Nume_Vin { get; set; }

        [RegularExpression(@"^[A-Z][a-z]+\s[A-Z][a-z]+$", ErrorMessage = "Numele producatorului trebuie sa fie de forma 'Prenume Nume'"),
            Required, StringLength(50, MinimumLength = 3)]

        public string Producator { get; set; }

        [Range(1, 300)]

        [Column(TypeName = "decimal(6, 2)")]
        public decimal Pret { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data imbutelierii")]
        public DateTime DataImbutelierii { get; set; }

        public int DomeniuID { get; set; }
        public Domeniu Domeniu { get; set; }

        [Display(Name = "Categorii Vin")]
        public ICollection<CategorieVin> CategoriiVin { get; set; }

    }
}
