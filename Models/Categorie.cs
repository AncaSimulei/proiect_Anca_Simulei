using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proiect_Anca_Simulei.Models
{
    public class Categorie
    {
        public int ID { get; set; }
        [Display(Name = "Nume categorie")]
        public string NumeCategorie { get; set; }
        public ICollection<CategorieVin> CategorieVinuri { get; set; }
    }
}
