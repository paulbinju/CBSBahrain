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
    public class LessonClassStdsApiController : ControllerBase
    {
        private readonly CBSBahrainContext _context;

        public LessonClassStdsApiController(CBSBahrainContext context)
        {
            _context = context;
        }

        // GET: api/LessonClassStdsApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LessonClassStd>>> GetLessonClassStd()
        {
            return await _context.LessonClassStd.ToListAsync();
        }

        // GET: api/LessonClassStdsApi/5
        [HttpGet("{id}")]
        public async Task<IEnumerable<LessonClassStd>> GetLessonClassStd(int id)
        {
             
            return await _context.LessonClassStd.Where(x => x.ClassId == id).ToListAsync(); ;
        }

        // PUT: api/LessonClassStdsApi/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLessonClassStd(int id, LessonClassStd lessonClassStd)
        {
            if (id != lessonClassStd.LessonId)
            {
                return BadRequest();
            }

            _context.Entry(lessonClassStd).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LessonClassStdExists(id))
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

        // POST: api/LessonClassStdsApi
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<LessonClassStd>> PostLessonClassStd(LessonClassStd lessonClassStd)
        {
            _context.LessonClassStd.Add(lessonClassStd);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLessonClassStd", new { id = lessonClassStd.LessonId }, lessonClassStd);
        }

        // DELETE: api/LessonClassStdsApi/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LessonClassStd>> DeleteLessonClassStd(int id)
        {
            var lessonClassStd = await _context.LessonClassStd.FindAsync(id);
            if (lessonClassStd == null)
            {
                return NotFound();
            }

            _context.LessonClassStd.Remove(lessonClassStd);
            await _context.SaveChangesAsync();

            return lessonClassStd;
        }

        private bool LessonClassStdExists(int id)
        {
            return _context.LessonClassStd.Any(e => e.LessonId == id);
        }
    }
}
