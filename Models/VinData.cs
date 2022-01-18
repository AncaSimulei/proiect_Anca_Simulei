using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiect_Anca_Simulei.Models
{
    public class VinData
    {
        public IEnumerable<Vin> Vinuri { get; set; }
        public IEnumerable<Categorie> Categorii { get; set; }
        public IEnumerable<CategorieVin> CategoriiVin { get; set; }
    }
}
