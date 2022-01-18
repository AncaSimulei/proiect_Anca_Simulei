using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using proiect_Anca_Simulei.Data;
using proiect_Anca_Simulei.Models;

namespace proiect_Anca_Simulei.Pages.Vinuri
{
    public class IndexModel : PageModel
    {
        private readonly proiect_Anca_Simulei.Data.proiect_Anca_SimuleiContext _context;

        public IndexModel(proiect_Anca_Simulei.Data.proiect_Anca_SimuleiContext context)
        {
            _context = context;
        }

        public IList<Vin> Vin { get;set; }

        public VinData VinD { get; set; }
        public int VinID { get; set; }
        public int CategorieID { get; set; }
        public async Task OnGetAsync(int? id, int? categorieID)
        {
            VinD = new VinData();

            VinD.Vinuri = await _context.Vin
            .Include(b => b.Domeniu)
            .Include(b => b.CategoriiVin)
            .ThenInclude(b => b.Categorie)
            .AsNoTracking()
            .OrderBy(b => b.Nume_Vin)
            .ToListAsync();
            if (id != null)
            {
                VinID = id.Value;
                Vin vin = VinD.Vinuri
                .Where(i => i.ID == id.Value).Single();
                VinD.Categorii = vin.CategoriiVin.Select(s => s.Categorie);
            }
        }
    }
}
