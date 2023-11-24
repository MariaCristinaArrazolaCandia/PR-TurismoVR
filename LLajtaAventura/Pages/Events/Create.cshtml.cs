using LLajtaAventura.Data;
using LLajtaAventura.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection.Metadata;

namespace LLajtaAventura.Pages.Events
{
    public class CreateModel : PageModel
    {
        public IEnumerable<Category> categories;
        [BindProperty]
        public Event New_Event { get; set; }
        [BindProperty]
        public IFormFile formFile { get; set; }

        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public CreateModel(ApplicationDbContext db, IWebHostEnvironment hostingEnvironment)
        {
            _db = db;
            _hostingEnvironment = hostingEnvironment;
        }
        public void OnGet()
        {
            categories = _db.Category;
        }

        public async Task<ActionResult> OnPost()
        {
            if (!(formFile != null && formFile.Length > 0))
            {
                ModelState.AddModelError("formFile", "Error al cargar la imagen");
            }

            if (ModelState.IsValid)
            {
                New_Event.ImagePath = await SaveImageAsync(formFile);
                await _db.Event.AddAsync(New_Event);
                await _db.SaveChangesAsync();

                return RedirectToPage("/Index");
            }

            return Page();
        }

        private async Task<string> SaveImageAsync(IFormFile imageFile)
        {
            // Aquí implementa la lógica para guardar la imagen en una ubicación específica
            // y devuelve la ruta de la imagen guardada
            // Ejemplo de código para guardar la imagen en wwwroot/images
            var uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "img/upload");
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            var uniqueFileName = Guid.NewGuid().ToString() + "_" + imageFile.FileName;
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(stream);
            }

            return "/img/upload/" + uniqueFileName; // Ruta relativa al archivo guardado
        }
    }
}
