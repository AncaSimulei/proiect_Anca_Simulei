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
        [Display(Name = "Nume vin")]
        public string Nume_Vin { get; set; }
        public string Producator { get; set; }
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Pret { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data imbutelierii")]
        public DateTime DataImbutelierii { get; set; }

        public int DomeniuID { get; set; }
        public Domeniu Domeniu { get; set; }

        public ICollection<CategorieVin> CategorieVin { get; set; }

    }
}
