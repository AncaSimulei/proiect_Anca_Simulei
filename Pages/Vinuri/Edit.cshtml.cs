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

namespace proiect_Anca_Simulei.Pages.Vinuri
{
    public class EditModel : CategoriiVinPageModel
    {
        private readonly proiect_Anca_Simulei.Data.proiect_Anca_SimuleiContext _context;

        public EditModel(proiect_Anca_Simulei.Data.proiect_Anca_SimuleiContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Vin Vin { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Vin = await _context.Vin
                .Include(b => b.Domeniu)
                .Include(b => b.CategoriiVin).ThenInclude(b => b.Categorie)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);
              

            if (Vin == null)
            {
                return NotFound();
            }

            PopulateAssignedCategoryData(_context, Vin);

            ViewData["DomeniuID"] = new SelectList(_context.Set<Domeniu>(), "ID", "NumeDomeniu");

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[]
        selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            var vinToUpdate = await _context.Vin
            .Include(i => i.Domeniu)
            .Include(i => i.CategoriiVin)
            .ThenInclude(i => i.Categorie)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (vinToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Vin>(
            vinToUpdate,
            "Vin",
            i => i.Nume_Vin, i => i.Producator,
            i => i.Pret, i => i.DataImbutelierii, i => i.Domeniu))
            {
                UpdateVinCategories(_context, selectedCategories, vinToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateBookCategories pentru a aplica informatiile din checkboxuri la entitatea Books care
            //este editata
            UpdateVinCategories(_context, selectedCategories, vinToUpdate);
            PopulateAssignedCategoryData(_context, vinToUpdate);
            return Page();
        }
    


private bool VinExists(int id)
        {
            return _context.Vin.Any(e => e.ID == id);
        }
    }
}
