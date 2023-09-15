using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TurismoWeb.Pages.Login
{
    public class LoginModel : PageModel
    {
        public void OnGet()
        {
        }
        public async Task<ActionResult> OnPost()
        {
            return RedirectToPage("../Login");
        }
    }
}
