using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiect_Anca_Simulei.Models
{
    public class CategorieVin
    {
        public int ID { get; set; }
        public int VinID { get; set; }
        public Vin Vin { get; set; }
        public int CategorieID { get; set; }
        public Categorie Categorie { get; set; }
    }
}
