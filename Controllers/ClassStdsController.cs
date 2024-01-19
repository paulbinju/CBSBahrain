using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CBSBahrainMVC.Models;

namespace CBSBahrainMVC.Controllers
{
    public class ClassStdsController : Controller
    {
        private readonly CBSBahrainContext _context;

        public ClassStdsController(CBSBahrainContext context)
        {
            _context = context;
        }

        // GET: ClassStds
        public async Task<IActionResult> Index()
        {
            return View(await _context.ClassStd.ToListAsync());
        }

        // GET: ClassStds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classStd = await _context.ClassStd
                .FirstOrDefaultAsync(m => m.ClassId == id);
            if (classStd == null)
            {
                return NotFound();
            }

            return View(classStd);
        }

        // GET: ClassStds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClassStds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClassId,ClassName")] ClassStd classStd)
        {
            if (ModelState.IsValid)
            {
                _context.Add(classStd);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(classStd);
        }

        // GET: ClassStds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classStd = await _context.ClassStd.FindAsync(id);
            if (classStd == null)
            {
                return NotFound();
            }
            return View(classStd);
        }

        // POST: ClassStds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClassId,ClassName")] ClassStd classStd)
        {
            if (id != classStd.ClassId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(classStd);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassStdExists(classStd.ClassId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(classStd);
        }

        // GET: ClassStds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classStd = await _context.ClassStd
                .FirstOrDefaultAsync(m => m.ClassId == id);
            if (classStd == null)
            {
                return NotFound();
            }

            return View(classStd);
        }

        // POST: ClassStds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var classStd = await _context.ClassStd.FindAsync(id);
            _context.ClassStd.Remove(classStd);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClassStdExists(int id)
        {
            return _context.ClassStd.Any(e => e.ClassId == id);
        }
    }
}
