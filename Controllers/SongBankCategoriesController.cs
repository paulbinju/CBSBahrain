using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CBSBahrainMVC.Models;

namespace CBSBahrainMVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongBankCategoriesController : ControllerBase
    {
        private readonly CBSBahrainContext _context;

        public SongBankCategoriesController(CBSBahrainContext context)
        {
            _context = context;
        }

        // GET: api/SongBankCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SongBankCategory>>> GetSongBankCategory()
        {
            return await _context.SongBankCategory.ToListAsync();
        }

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<SongBankCategory>>> GetSongBankCategoryCatList(int id)
        //{
        //    return await _context.SongBankCategory.Where(x => x.CategoryId == id).ToListAsync();
        //}



        // GET: api/SongBankCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SongBankCategory>> GetSongBankCategory(int id)
        {
            var songBankCategory = await _context.SongBankCategory.FindAsync(id);

            if (songBankCategory == null)
            {
                return NotFound();
            }

            return songBankCategory;
        }

        // PUT: api/SongBankCategories/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSongBankCategory(int id, SongBankCategory songBankCategory)
        {
            if (id != songBankCategory.SongId)
            {
                return BadRequest();
            }

            _context.Entry(songBankCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SongBankCategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/SongBankCategories
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<SongBankCategory>> PostSongBankCategory(SongBankCategory songBankCategory)
        {
            _context.SongBankCategory.Add(songBankCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSongBankCategory", new { id = songBankCategory.SongId }, songBankCategory);
        }

        // DELETE: api/SongBankCategories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SongBankCategory>> DeleteSongBankCategory(int id)
        {
            var songBankCategory = await _context.SongBankCategory.FindAsync(id);
            if (songBankCategory == null)
            {
                return NotFound();
            }

            _context.SongBankCategory.Remove(songBankCategory);
            await _context.SaveChangesAsync();

            return songBankCategory;
        }

        private bool SongBankCategoryExists(int id)
        {
            return _context.SongBankCategory.Any(e => e.SongId == id);
        }
    }
}
