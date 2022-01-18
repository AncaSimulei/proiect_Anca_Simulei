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
    public class DetailsModel : PageModel
    {
        private readonly proiect_Anca_Simulei.Data.proiect_Anca_SimuleiContext _context;

        public DetailsModel(proiect_Anca_Simulei.Data.proiect_Anca_SimuleiContext context)
        {
            _context = context;
        }

        public Domeniu Domeniu { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Domeniu = await _context.Domeniu.FirstOrDefaultAsync(m => m.ID == id);

            if (Domeniu == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
