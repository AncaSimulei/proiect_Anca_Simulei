using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiect_Anca_Simulei.Models
{
    public class Domeniu
    {
        public int ID { get; set; }
        public string NumeDomeniu { get; set; }
        public ICollection<Vin> Vin { get; set; }
    }
}
