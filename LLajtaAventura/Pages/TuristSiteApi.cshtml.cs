using LLajtaAventura.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LLajtaAventura.Pages
{
    public class TuristSiteApiModel : PageModel
    {
        public async Task<IActionResult> OnGet()
        {
            List<TouristSiteDataDTO> sities = new List<TouristSiteDataDTO>();
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync("https://localhost:7298/Turismo/TouristSites/GetTouristSities");
                if (response.IsSuccessStatusCode)
                {
                    sities = await response.Content.ReadFromJsonAsync<List<TouristSiteDataDTO>>();
                }
            }
            catch (Exception ex)
            {
                sities = new List<TouristSiteDataDTO>();
            }

            // Devuelve los datos como JSON
            return new JsonResult(sities);
        }
    }
}
