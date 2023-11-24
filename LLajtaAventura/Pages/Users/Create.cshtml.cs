using LLajtaAventura.Data;
using LLajtaAventura.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LLajtaAventura.Pages.Users
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public User New_User { get; set; }
        [BindProperty]
        public string ConfirmPassw { get; set; }
        private readonly ApplicationDbContext _db;
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
        }

        public async Task<ActionResult> OnPost()
        {
            if (New_User.Password != ConfirmPassw)
            {
                ModelState.AddModelError("ConfirmPassw", "Las contraseñas no coinciden");
            }
            var existingUser = await _db.User.FirstOrDefaultAsync(b => b.UserName == New_User.UserName);
            if (existingUser != null)
            {
                ModelState.AddModelError("New_User.UserName", "Ya existe un usuario con ese nombre");
            }

            if (ModelState.IsValid)
            {
                await _db.User.AddAsync(New_User);
                await _db.SaveChangesAsync();

                return RedirectToPage("/Index");
            }
            return Page();
        }
    }
}
