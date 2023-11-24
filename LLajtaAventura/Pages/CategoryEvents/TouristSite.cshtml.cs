using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LLajtaAventura.Models;
using Newtonsoft.Json; // Agrega esta línea

namespace LLajtaAventura.Pages.CategoryEvents
{
    public class TouristSiteModel : PageModel
    {
        private readonly HttpClient _httpClient;
        public TouristSiteModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public TouristSiteDataDTO[] TouristSites { get; set; }
        //public TouristSiteDataDTO TouristSite { get; set; }
        /*public void OnGet()
        {
            TouristSite = new TouristSiteDataDTO
            {
                TouristSiteId = 1,
                Name = "Lugar Turístico Ejemplo",
                Description = "Descripción del lugar turístico de ejemplo."
                // Otras propiedades...
            };
        }*/
        public async Task OnGetAsync()
        {

            // Consumir la API
            var response = await _httpClient.GetStringAsync("https://localhost:7298/Turismo/TouristSites/GetTouristSities");
            TouristSites = JsonConvert.DeserializeObject<TouristSiteDataDTO[]>(response);
        }
    }
}
