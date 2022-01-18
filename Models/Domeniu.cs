using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proiect_Anca_Simulei.Models
{
    public class Domeniu
    {
        public int ID { get; set; }
        [Display(Name = "Nume domeniu")]
        public string NumeDomeniu { get; set; }
        public ICollection<Vin> Vin { get; set; }
    }
}
