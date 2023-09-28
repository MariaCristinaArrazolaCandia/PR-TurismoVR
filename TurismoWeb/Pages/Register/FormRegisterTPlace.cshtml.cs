using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TurismoWeb.Data;
using TurismoWeb.Models;

namespace TurismoWeb.Pages.Register
{
    public class FormRegisterTPlaceModel : PageModel
    {
        // Other properties and methods

        public List<Category> Categories { get; set; }

        public void OnGet()
        {
            // Fetch categories from the database and assign them to the Categories property.
            Categories = GetCategoriesFromDatabase();
        }

        private List<Category> GetCategoriesFromDatabase()
        {
            // Implement your database retrieval logic here and return a list of Category objects.
            // Example:
            var categories = AppDbContext.Categories.ToList();
            return categories;
        }

    }

}
