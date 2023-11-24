using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using Turismo_API.Data;
using Turismo_API.Models;
using Turismo_API.Models.Custom;
using Turismo_API.Services;
using Turismo_API.Services.Interfaces;

namespace Turismo_API.Controllers
{
    [Route("Turismo/[controller]")]
    [ApiController]
    public class TouristSitesController : Controller
    {
        private readonly ITouristHoraryService _touristHoraryservice;
        private readonly IPhotoTouristSiteService _photoTouristSiteService;
        private readonly BdTurismoTiquipayaContext _context;

        public TouristSitesController(ITouristHoraryService touristHoraryService, IPhotoTouristSiteService photoTouristSiteService,BdTurismoTiquipayaContext context)
        {
            _touristHoraryservice = touristHoraryService;
            _photoTouristSiteService = photoTouristSiteService;
            _context = context;
        }

        [HttpPost]
        [Route("CreateSites")]
        public async Task<IActionResult> CreateSites([FromBody]TouristSiteDTO tsite)
        {
            if (tsite != null)
            {
                using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        await _context.TouristSites.AddAsync(tsite);
                        await _context.SaveChangesAsync();

                        await transaction.CommitAsync();

                        var urls = await _photoTouristSiteService.UploadImages(tsite.Images, tsite.Name);

                        foreach(var url in urls)
                        {
                            PhotoTouristSite photos = new PhotoTouristSite { 
                                Photo = url,
                                TouristSiteId = tsite.TouristSiteId
                            };
                            await _context.PhotoTouristSites.AddAsync(photos);
                        }
                        await _context.SaveChangesAsync();
                        await _touristHoraryservice.InsertHoraries(tsite.Horaries, tsite.TouristSiteId);
                        return Ok();
                    }
                    catch
                    {
                        await transaction.RollbackAsync();
                        return BadRequest();
                    }
                }
            }
            return BadRequest();
        }

        [HttpPut]
        [Route("UpdateSite")]
        public async Task<IActionResult> UpdateSite(TouristSite touristSite)
        {
            if (!TouristSiteExists(touristSite.TouristSiteId))
                return NotFound();

            var _touristSite = await _context.TouristSites.FindAsync(touristSite.TouristSiteId);
            if (_touristSite == null)
                return NotFound();

            try
            {
                //dbContext.Entry(entidad).Property(x => x.ColumnaQueQuieresIgnorar).IsModified = false;
                _touristSite.LastUpdate = DateTime.Now;
                _touristSite.Longitude = touristSite.Longitude;
                _touristSite.Latitude = touristSite.Latitude;
                _touristSite.PhoneNumber = touristSite.PhoneNumber;
                _touristSite.Name = touristSite.Name;
                _touristSite.Description = touristSite.Description;
                _touristSite.CategoryId = touristSite.CategoryId;
                _touristSite.Email  = touristSite.Email;
                _context.Entry(_touristSite).Property(x => x.RegisterDate).IsModified = false;
                //_context.Entry(touristSite).Property(x => x.Category).IsModified = false;

                _context.Entry(_touristSite).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("DeleteSite")]
        public async Task<IActionResult> DeleteSite(int id)
        {
            if (!TouristSiteExists(id))
                return NotFound();

            var touristSite = await _context.TouristSites
                .FindAsync(id);

            if (touristSite == null)
                return NotFound();

            touristSite.Status = "0";

            try
            {
                _context.Entry(touristSite).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest();
            }
        }

        /*[HttpPost]
        [Route("CreateHoraries")]
        public async Task<IActionResult> CreateHoraries([FromBody]List<Horary> horaries)
        {
            await _context.AddRangeAsync(horaries);
            await _context.SaveChangesAsync();
            return Ok();
        }*/


        [ApiExplorerSettings(IgnoreApi = true)]
        private bool TouristSiteExists(int id)
        {
            return _context.TouristSites.Any(e => e.TouristSiteId == id);
        }

        [HttpGet]
        [Route("GetTouristSities")]
        public async Task<IActionResult> GetTouristSities()
        {
            var data = _context.TouristSites
            .Select(x=>new TouristSiteDataDTO
            {
                TouristSiteId=x.TouristSiteId,
                Name = x.Name,
                Address = x.Address,
                Category = x.Category.Name,
                Description = x.Description,
                Email = x.Email,
                LastUpdate = x.LastUpdate,
                Latitude = x.Latitude,
                Longitude = x.Longitude,
                PhoneNumber = x.PhoneNumber,
                RegisterDate = x.RegisterDate,
                Status= x.Status,
                Imagenes=x.PhotoTouristSites.Select(x=>x.Photo).ToList()
            }).ToList();

            return Ok(data);
        }

        [HttpGet]
        [Route("GetTouristSite")]
        public async Task<IActionResult> GetTouristSite(int id)
        {
            var data = _context.TouristSites
            .Where(x => x.TouristSiteId==id).FirstOrDefault();

            return Ok(data);
        }

        [HttpGet]
        [Route("GetImages")]
        public async Task<IActionResult> GetImages(int id)
        {
            var data = _context.PhotoTouristSites
            .Where(x => x.TouristSiteId == id).ToList();

            return Ok(data);
        }
        [HttpGet]
        [Route("GetTouristSitieForImages")]
        public async Task<IActionResult> GetTouristSitieForImages(int id)
        {
            var data = _context.TouristSites
            .Where(x => x.TouristSiteId == id)
            .Select(x => new TouristSiteDataDTO
            {
                TouristSiteId = x.TouristSiteId,
                Name = x.Name,
                Address = x.Address,
                Category = x.Category.Name,
                Description = x.Description,
                Email = x.Email,
                LastUpdate = x.LastUpdate,
                Latitude = x.Latitude,
                Longitude = x.Longitude,
                PhoneNumber = x.PhoneNumber,
                RegisterDate = x.RegisterDate,
                Status = x.Status,
                Imagenes = x.PhotoTouristSites.Select(x => x.Photo).ToList()
            }).FirstOrDefault();

            return Ok(data);
        }
    }
}
