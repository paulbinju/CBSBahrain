using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CBSBahrainMVC.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace CBSBahrainMVC.Controllers
{
    public class SongBanksController : Controller
    {
        private readonly CBSBahrainContext _context;

        public SongBanksController(CBSBahrainContext context)
        {
            _context = context;
        }

        // GET: SongBanks
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("Loggedin") == null)
            {
                return RedirectToAction("Login", "Home");
            }

            var cBSBahrainContext = _context.SongBank.Include(s => s.Category).OrderBy(x => x.Category).ThenBy(x => x.Title);
            return View(await cBSBahrainContext.ToListAsync());
        }

        // GET: SongBanks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (HttpContext.Session.GetString("Loggedin") == null)
            {
                return RedirectToAction("Login", "Home");
            }

            if (id == null)
            {
                return NotFound();
            }

            var songBank = await _context.SongBank
                .Include(s => s.Category)
                .FirstOrDefaultAsync(m => m.SongId == id);
            if (songBank == null)
            {
                return NotFound();
            }

            return View(songBank);
        }

        // GET: SongBanks/Create
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("Loggedin") == null)
            {
                return RedirectToAction("Login", "Home");
            }
            //ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "Category1");
            ViewBag.Categories = _context.Category.ToList();
            return View();
        }

        // POST: SongBanks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SongId,CategoryId,Title,Lyrics,YoutubeUrl")] SongBank songBank, List<IFormFile> FileAttachment)
        {
            if (HttpContext.Session.GetString("Loggedin") == null)
            {
                return RedirectToAction("Login", "Home");
            }


            if (ModelState.IsValid)
            {
                songBank.CreateDate = DateTime.Now;
                _context.Add(songBank);
                await _context.SaveChangesAsync();

                long size = FileAttachment.Sum(f => f.Length);


                foreach (var formFile in FileAttachment)
                {
                    if (formFile.Length > 0)
                    {
                        var filePath = formFile.FileName;

                        string ImageName = "Song-" + songBank.SongId + Path.GetExtension(filePath);

                        songBank.FileAttachment = ImageName;
                        _context.Attach(songBank).Property(x => x.FileAttachment).IsModified = true;
                        _context.SaveChanges();

                        //Get url To Save
                        string SavePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/SongFiles", ImageName);
                        songBank.FileAttachment = ImageName;

                        using (var stream = new FileStream(SavePath, FileMode.Create))
                        {
                            formFile.CopyTo(stream);
                        }
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryId", songBank.CategoryId);
            return View(songBank);
        }

        // GET: SongBanks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (HttpContext.Session.GetString("Loggedin") == null)
            {
                return RedirectToAction("Login", "Home");
            }
            if (id == null)
            {
                return NotFound();
            }

            var songBank = await _context.SongBank.FindAsync(id);
            if (songBank == null)
            {
                return NotFound();
            }

            //ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryId", songBank.CategoryId);

            ViewBag.Categories = _context.Category.ToList();


            return View(songBank);
        }

        // POST: SongBanks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SongId,CategoryId,Title,Lyrics,YoutubeUrl")] SongBank songBank, List<IFormFile> FileAttachment)
        {

            if (HttpContext.Session.GetString("Loggedin") == null)
            {
                return RedirectToAction("Login", "Home");
            }


            if (id != songBank.SongId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    songBank.CreateDate = DateTime.Now;
                    _context.Update(songBank);
                    await _context.SaveChangesAsync();

                    long size = FileAttachment.Sum(f => f.Length);


                    foreach (var formFile in FileAttachment)
                    {
                        if (formFile.Length > 0)
                        {
                            var filePath = formFile.FileName;

                            string ImageName = "Song-" + songBank.SongId + Path.GetExtension(filePath);

                            songBank.FileAttachment = ImageName;
                            _context.Attach(songBank).Property(x => x.FileAttachment).IsModified = true;
                            _context.SaveChanges();

                            //Get url To Save
                            string SavePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/SongFiles", ImageName);
                            songBank.FileAttachment = ImageName;

                            using (var stream = new FileStream(SavePath, FileMode.Create))
                            {
                                formFile.CopyTo(stream);
                            }
                        }
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SongBankExists(songBank.SongId))
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
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryId", songBank.CategoryId);
            return View(songBank);
        }

        // GET: SongBanks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {

            if (HttpContext.Session.GetString("Loggedin") == null)
            {
                return RedirectToAction("Login", "Home");
            }


            if (HttpContext.Session.GetString("Loggedin") == null)
            {
                return RedirectToAction("Login", "Home");
            }
            if (id == null)
            {
                return NotFound();
            }

            var songBank = await _context.SongBank
                .Include(s => s.Category)
                .FirstOrDefaultAsync(m => m.SongId == id);
            if (songBank == null)
            {
                return NotFound();
            }

            return View(songBank);
        }

        // POST: SongBanks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            if (HttpContext.Session.GetString("Loggedin") == null)
            {
                return RedirectToAction("Login", "Home");
            }


            var songBank = await _context.SongBank.FindAsync(id);
            _context.SongBank.Remove(songBank);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SongBankExists(int id)
        {
            return _context.SongBank.Any(e => e.SongId == id);
        }
    }
}
