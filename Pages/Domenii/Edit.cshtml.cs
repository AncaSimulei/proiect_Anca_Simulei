using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using proiect_Anca_Simulei.Data;
using proiect_Anca_Simulei.Models;

namespace proiect_Anca_Simulei.Pages.Domenii
{
    public class EditModel : PageModel
    {
        private readonly proiect_Anca_Simulei.Data.proiect_Anca_SimuleiContext _context;

        public EditModel(proiect_Anca_Simulei.Data.proiect_Anca_SimuleiContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Domeniu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DomeniuExists(Domeniu.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DomeniuExists(int id)
        {
            return _context.Domeniu.Any(e => e.ID == id);
        }
    }
}
