using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using proiect_Anca_Simulei.Data;

namespace proiect_Anca_Simulei.Models
{
    public class CategoriiVinPageModel : PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(proiect_Anca_SimuleiContext context,
        Vin vin)
        {
            var allCategories = context.Categorie;
            var vinCategories = new HashSet<int>(
            vin.CategoriiVin.Select(c => c.CategorieID)); //
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategorieID = cat.ID,
                    Nume = cat.NumeCategorie,
                    Assigned = vinCategories.Contains(cat.ID)
                });
            }
        }
        public void UpdateVinCategories(proiect_Anca_SimuleiContext context,
        string[] selectedCategories, Vin vinToUpdate)
        {
            if (selectedCategories == null)
            {
                vinToUpdate.CategoriiVin = new List<CategorieVin>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var vinCategories = new HashSet<int>
            (vinToUpdate.CategoriiVin.Select(c => c.Categorie.ID));
            foreach (var cat in context.Categorie)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!vinCategories.Contains(cat.ID))
                    {
                        vinToUpdate.CategoriiVin.Add(
                        new CategorieVin
                        {
                            VinID = vinToUpdate.ID,
                            CategorieID = cat.ID
                        });
                    }
                }
                else
                {
                    if (vinCategories.Contains(cat.ID))
                    {
                        CategorieVin courseToRemove
                        = vinToUpdate
                        .CategoriiVin
                        .SingleOrDefault(i => i.CategorieID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }

        }
    }
}
