using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using LLajtaAventura.Models;
using System.Net.Http.Json;

namespace LLajtaAventura.Pages.CategoryEvents
{
	public class CarruselModel : PageModel
	{
        public int Id { get; set; }
        public TouristSiteDataDTO touristSiteData { get; set; } = new TouristSiteDataDTO();

        public async Task OnGetAsync()
        {
            if (Request.Query.ContainsKey("id") && int.TryParse(Request.Query["id"], out int id))
            {
                Id = id;
            }
            else
            {
                Id = 0;
            }
            if (Id > 0)
            {
                // Llamar a tu API para obtener lugares turísticos
                HttpClient client = new HttpClient();
                var response = await client.GetAsync("https://localhost:7298/Turismo/TouristSites/GetTouristSitieForImages?id=" + Id);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadFromJsonAsync<TouristSiteDataDTO>();
                    touristSiteData = data;
                }
            }
        }

    }

}
