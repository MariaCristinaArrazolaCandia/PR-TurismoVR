using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Turismo.Web.Models;
using Turismo.Web.Models.DTO;

namespace Turismo.Web.Controllers
{
    public class TouristSiteController : Controller
    {
        public async Task<IActionResult> Index()
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
            return View(sities);
        }
        public IActionResult Create()
        {
            List<CategoryDTO> categories = new List<CategoryDTO>();
            categories = GetCategories();
            ViewBag.CategoryId = new SelectList(categories, "CategoryId", "Name");

            return View();
        }

        private static List<CategoryDTO> GetCategories()
        {
            List<CategoryDTO> users = new List<CategoryDTO>();
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = client.GetAsync("https://localhost:7298/Turismo/Categories/GetCategories").Result;
                if (response.IsSuccessStatusCode)
                {
                    users = response.Content.ReadFromJsonAsync<List<CategoryDTO>>().Result;
                }
            }
            catch (Exception ex)
            {
                users = new List<CategoryDTO>();
            }

            return users;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Turismo.Web.Models.DTO.TouristSiteDTO touristSiteDTO)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    List<string> images = new List<string>();
                    foreach (var file in touristSiteDTO.Photos)
                    {

                        // Verificar la extensión del archivo
                        var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
                        var fileExtension = Path.GetExtension(file.FileName).ToLowerInvariant();

                        if (!allowedExtensions.Contains(fileExtension))
                        {
                            ModelState.AddModelError("Photos", "La extensión del archivo no es válida. Solo se permiten archivos jpg y png.");
                            //return View("Index"); // Reemplaza "Index" con la vista apropiada
                            return View(touristSiteDTO);
                        }

                        // Leer la imagen en un arreglo de bytes
                        byte[] imageData;
                        using (var stream = new MemoryStream())
                        {
                            await file.CopyToAsync(stream);
                            imageData = stream.ToArray();
                        }

                        // Convertir el arreglo de bytes a una cadena Base64
                        string base64String = Convert.ToBase64String(imageData);
                        images.Add(base64String);
                    }

                    touristSiteDTO.Images = images;

                    if(!string.IsNullOrEmpty(touristSiteDTO.OpeningDays)
                        && !string.IsNullOrEmpty(touristSiteDTO.OpeningHour)
                        && !string.IsNullOrEmpty(touristSiteDTO.ClosingHour))
                    {
                        touristSiteDTO.Horaries = new List<Models.DTO.Horary> {
                            new Models.DTO.Horary()
                            {
                                OpeningDays=touristSiteDTO.OpeningDays,
                                OpeningHour=touristSiteDTO.OpeningHour,
                                ClosingHour=touristSiteDTO.ClosingHour,
                                RegisterDate=DateTime.Now,
                                Status=1
                            }
                        };
                    }
                    touristSiteDTO.RegisterDate = DateTime.Now;
                    HttpClient client = new HttpClient();
                    HttpResponseMessage response = await client.PostAsJsonAsync(
                    "https://localhost:7298/Turismo/TouristSites/CreateSites", touristSiteDTO);
                    var estaado = response.EnsureSuccessStatusCode();
                    if (estaado.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
                catch(Exception ex)
                {

                }
            }
            
            List<CategoryDTO> categories = new List<CategoryDTO>();
            categories = GetCategories();
            ViewBag.CategoryId = new SelectList(categories, "CategoryId", "Name", touristSiteDTO.CategoryId);

            return View(touristSiteDTO);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            //List<CategoryDTO> categories = new List<CategoryDTO>();
            //categories = GetCategories();
            //ViewBag.CategoryId = new SelectList(categories, "CategoryId", "Name");

            //return View();
            TouristSiteDTO touristSiteDTO = new TouristSiteDTO();
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync("https://localhost:7298/Turismo/TouristSites/GetTouristSite?id=" + id);
                if (response.IsSuccessStatusCode)
                {
                    touristSiteDTO = await response.Content.ReadFromJsonAsync<TouristSiteDTO>();
                }
            }
            catch (Exception ex)
            {
                touristSiteDTO = new TouristSiteDTO();
            }

            List<CategoryDTO> categories = new List<CategoryDTO>();
            categories = GetCategories();
            ViewBag.CategoryId = new SelectList(categories, "CategoryId", "Name", touristSiteDTO.CategoryId);
            return View(touristSiteDTO);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Turismo.Web.Models.TouristSite touristSiteDTO)
        {
            if (ModelState.IsValid)
            {

                // HttpClient client = new HttpClient();
                // HttpResponseMessage response = await client.PostAsJsonAsync(
                //"api/products", product);
                // response.EnsureSuccessStatusCode();

                //_context.Add(user);
                //await _context.SaveChangesAsync();
                touristSiteDTO.LastUpdate = DateTime.Now;
                touristSiteDTO.Status = "1";
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.PutAsJsonAsync(
                "https://localhost:7298/Turismo/TouristSites/UpdateSite", touristSiteDTO);
                var estaado = response.EnsureSuccessStatusCode();
                if (estaado.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            List<CategoryDTO> categories = new List<CategoryDTO>();
            categories = GetCategories();
            ViewBag.CategoryId = new SelectList(categories, "CategoryId", "Name", touristSiteDTO.CategoryId);

            return View(touristSiteDTO);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PutAsJsonAsync(
            "https://localhost:7298/Turismo/TouristSites/DeleteSite?id=" + id, 1);
            var estaado = response.EnsureSuccessStatusCode();
            if (estaado.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            return NotFound();
        }

        public async Task<IActionResult> MostrarImagenes(int? id)
        {
            List<PhotoTouristSiteDTO> sities = new List<PhotoTouristSiteDTO>();
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync("https://localhost:7298/Turismo/TouristSites/GetImages?id=" + id);
                if (response.IsSuccessStatusCode)
                {
                    sities = await response.Content.ReadFromJsonAsync<List<PhotoTouristSiteDTO>>();
                }
            }
            catch (Exception ex)
            {
                sities = new List<PhotoTouristSiteDTO>();
            }
            return View(sities);
        }

    }
}
