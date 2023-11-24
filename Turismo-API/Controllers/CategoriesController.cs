using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using Turismo_API.Data;
using Turismo_API.Models;

namespace Turismo_API.Controllers
{
    [Route("Turismo/[controller]")]
    [ApiController]
    public class CategoriesController : Controller
    {
        private readonly BdTurismoTiquipayaContext _context;
        public CategoriesController(BdTurismoTiquipayaContext context) 
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetCategories")]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _context.Categories.ToListAsync();

            if (categories.IsNullOrEmpty())
                return NotFound();

            return Ok(categories);
        }

        [HttpPost]
        [Route("CreateCategory")]
        public async Task<IActionResult> CreateCategory([FromBody]Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        [Route("UpdateCategory")]
        public async Task<IActionResult> UpdateCategory([FromBody]Category category)
        {
            if (!CategoryExists(category.CategoryId))
                return NotFound();
            
            try
            {
                _context.Entry(category).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch(DbUpdateConcurrencyException)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("DeleteCategory")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            if (!CategoryExists(id))
                return NotFound();

            var category = await _context.Categories.FindAsync(id);

            if (category == null)
                return NotFound();

            category.Status = "0";

            try
            {
                _context.Entry(category).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest();
            }
        }


        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.CategoryId == id);
        }

    }
}
