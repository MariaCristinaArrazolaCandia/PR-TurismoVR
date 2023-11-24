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
	public class ArtModel : PageModel
	{
		public List<TouristSiteDataDTO> TouristSites { get; set; } = new List<TouristSiteDataDTO>();

        public async Task OnGetAsync()
        {
            // Llamar a tu API para obtener lugares turísticos
            HttpClient client = new HttpClient();
            var response = await client.GetAsync("https://localhost:7298/Turismo/TouristSites/GetTouristSities");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadFromJsonAsync<List<TouristSiteDataDTO>>();
                TouristSites = data;
            }
        }

    }

}
