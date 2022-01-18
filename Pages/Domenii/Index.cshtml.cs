using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using proiect_Anca_Simulei.Data;
using proiect_Anca_Simulei.Models;

namespace proiect_Anca_Simulei.Pages.Domenii
{
    public class IndexModel : PageModel
    {
        private readonly proiect_Anca_Simulei.Data.proiect_Anca_SimuleiContext _context;

        public IndexModel(proiect_Anca_Simulei.Data.proiect_Anca_SimuleiContext context)
        {
            _context = context;
        }

        public IList<Domeniu> Domeniu { get;set; }

        public async Task OnGetAsync()
        {
            Domeniu = await _context.Domeniu.ToListAsync();
        }
    }
}
