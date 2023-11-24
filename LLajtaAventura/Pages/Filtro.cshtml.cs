using LLajtaAventura.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace LLajtaAventura.Pages
{
    public class FiltroModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; } = "";

        [BindProperty(SupportsGet = true)]
        public string SelectedCriteria { get; set; } = "";


        public List<SelectListItem> Criterios { get; set; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "", Text =  "Seleccione una categoria" },
            new SelectListItem { Value = "Naturaleza y Paisajes", Text =  "Naturaleza y Paisajes" },
            new SelectListItem { Value = "Historia y Cultura", Text =  "Historia y Cultura" },
            new SelectListItem { Value = "Aventura y Deporte", Text =  "Aventura y Deporte" },
            new SelectListItem { Value = "Gastronomía Local", Text =  "Gastronomía Local" },
            new SelectListItem { Value = "Religión y Espiritualidad", Text =  "Religión y Espiritualidad" },
            new SelectListItem { Value = "Arte y Entretenimiento", Text =  "Arte y Entretenimiento" },
            new SelectListItem { Value = "Fiestas y Eventos Locales", Text =  "Fiestas y Eventos Locales" },
            new SelectListItem { Value = "Educación y Ciencia", Text =  "Educación y Ciencia" },
            new SelectListItem { Value = "Ecoturismo", Text =  "Ecoturismo" },
            new SelectListItem { Value = "Artesanía y Compras", Text = "Artesanía y Compras" },
            // Agrega más opciones según tus necesidades
        };

        public void OnGet()
        {
            // Lógica para manejar la búsqueda inicial si es necesario
            // Por ejemplo, puedes cargar todos los resultados sin filtrar
        }

        //public void OnGetBuscar()
        //{
        //    // Lógica para manejar la búsqueda cuando se envía el formulario
        //    // Aquí deberías realizar la consulta a tu base de datos u otra fuente de datos
        //    // y llenar Resultados con los resultados de la búsqueda.

        //    // Por ejemplo:
        //    // Resultados = ObtenerResultados(SearchTerm, SelectedCriteria);
        //}
        public List<touristData> TouristSites { get; set; } = new List<touristData>();

        public void OnPost()
        {
            // Llamar a tu API para obtener lugares turísticos
            HttpClient client = new HttpClient();
            var response = client.GetAsync("https://localhost:7298/Turismo/TouristSites/GetTouristSities").Result;
            if (response.IsSuccessStatusCode)
            {

                List<touristData> newList = new List<touristData>();

                var data = response.Content.ReadFromJsonAsync<List<touristData>>().Result;
                if (string.IsNullOrEmpty(SearchTerm)) SearchTerm = "";
                if (string.IsNullOrEmpty(SelectedCriteria)) SelectedCriteria = "";
                foreach (var item in data)
                {
                    if ((SelectedCriteria.ToLower() != "" || item.Category.ToLower() == SelectedCriteria.ToLower()) || (string.IsNullOrEmpty(item.Name) || item.Name.ToLower().Contains(SearchTerm?.ToLower())))
                    {
                        newList.Add(item);
                    }
                }
                TouristSites = newList;
            }
            this.SearchTerm = SearchTerm + "";
            this.SelectedCriteria = SelectedCriteria + "";
        }
        public class touristData
        {
            public int TouristSiteId { get; set; }
            public string Name { get; set; } = null!;
            public string Address { get; set; } = null!;
            public string Description { get; set; } = null!;
            public string PhoneNumber { get; set; } = null!;
            public string Email { get; set; } = null!;
            public DateTime RegisterDate { get; set; }
            public DateTime? LastUpdate { get; set; }
            public string Status { get; set; } = null!;
            public string Longitude { get; set; } = null!;
            public string Latitude { get; set; } = null!;
            public string Category { get; set; } = "";
            public List<string> Imagenes { get; set; }
        }
    }
}
