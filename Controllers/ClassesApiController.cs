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
    public class ClassesApiController : ControllerBase
    {
        private readonly CBSBahrainContext _context;

        public ClassesApiController(CBSBahrainContext context)
        {
            _context = context;
        }

        // GET: api/ClassesApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClassStd>>> GetClassStd()
        {
            return await _context.ClassStd.ToListAsync();
        }

        // GET: api/ClassesApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClassStd>> GetClassStd(int id)
        {
            var classStd = await _context.ClassStd.FindAsync(id);

            if (classStd == null)
            {
                return NotFound();
            }

            return classStd;
        }

        // PUT: api/ClassesApi/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClassStd(int id, ClassStd classStd)
        {
            if (id != classStd.ClassId)
            {
                return BadRequest();
            }

            _context.Entry(classStd).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClassStdExists(id))
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

        // POST: api/ClassesApi
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<ClassStd>> PostClassStd(ClassStd classStd)
        {
            _context.ClassStd.Add(classStd);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClassStd", new { id = classStd.ClassId }, classStd);
        }

        // DELETE: api/ClassesApi/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ClassStd>> DeleteClassStd(int id)
        {
            var classStd = await _context.ClassStd.FindAsync(id);
            if (classStd == null)
            {
                return NotFound();
            }

            _context.ClassStd.Remove(classStd);
            await _context.SaveChangesAsync();

            return classStd;
        }

        private bool ClassStdExists(int id)
        {
            return _context.ClassStd.Any(e => e.ClassId == id);
        }
    }
}
