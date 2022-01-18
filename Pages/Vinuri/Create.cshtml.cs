using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using proiect_Anca_Simulei.Data;
using proiect_Anca_Simulei.Models;

namespace proiect_Anca_Simulei.Pages.Vinuri
{
    public class CreateModel : CategoriiVinPageModel
    {
        private readonly proiect_Anca_Simulei.Data.proiect_Anca_SimuleiContext _context;

        public CreateModel(proiect_Anca_Simulei.Data.proiect_Anca_SimuleiContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["DomeniuID"] = new SelectList(_context.Set<Domeniu>(), "ID", "NumeDomeniu");

            var vin = new Vin();
            vin.CategoriiVin = new List<CategorieVin>();
            PopulateAssignedCategoryData(_context, vin);

            return Page();
        }

        [BindProperty]
        public Vin Vin { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newVin = new Vin();
            if (selectedCategories != null)
            {
                newVin.CategoriiVin = new List<CategorieVin>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new CategorieVin
                    {
                        CategorieID = int.Parse(cat)
                    };
                    newVin.CategoriiVin.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Vin>(
            newVin,
            "Vin",
            i => i.Nume_Vin, i => i.Producator,
            i => i.Pret, i => i.DataImbutelierii, i => i.DomeniuID))
            {
                _context.Vin.Add(newVin);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedCategoryData(_context, newVin);
            return Page();
        }
    }
}
