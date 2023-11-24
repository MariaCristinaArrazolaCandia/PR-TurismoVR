using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Turismo.Web.Models;
using Turismo.Web.Models.DTO;
using Turismo.Web.db;

namespace Turismo.Web.Controllers
{
    public class AccesoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserRequest usuario)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.PostAsJsonAsync(
                "https://localhost:7298/Turismo/Access/Login", usuario);
                var estaado = response.EnsureSuccessStatusCode();
                AuthResponse authResponse = null;
                if (estaado.IsSuccessStatusCode)
                {
                    authResponse = await response.Content.ReadFromJsonAsync<AuthResponse>();

                    if(authResponse != null)
                    {
                        var claims = new List<Claim>()
                        {
                            new Claim(ClaimTypes.Name, authResponse.fullName),
                            new Claim(ClaimTypes.Email, usuario.email),
                            new Claim(ClaimTypes.Role, authResponse.Rol),
                            new Claim(ClaimTypes.NameIdentifier, authResponse.userID.ToString())
                        };

                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                    }
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception ex)
            {

            }
            return View(usuario);
        }

        public async Task<IActionResult> Salir()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Acceso");
        }
    }
}
