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
    public class LessonsController : Controller
    {
        private readonly CBSBahrainContext _context;

        public LessonsController(CBSBahrainContext context)
        {
            _context = context;
        }

        // GET: Lessons
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("Loggedin") == null)
            {
                return RedirectToAction("Login", "Home");
            }


            var cBSBahrainContext = _context.Lesson.Include(l => l.Class).OrderBy(x => x.ClassId).ThenBy(x => x.Title);
            return View(await cBSBahrainContext.ToListAsync());
        }

        // GET: Lessons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lesson = await _context.Lesson
                .Include(l => l.Class)
                .FirstOrDefaultAsync(m => m.LessonId == id);
            if (lesson == null)
            {
                return NotFound();
            }

            return View(lesson);
        }

        // GET: Lessons/Create
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("Loggedin") == null)
            {
                return RedirectToAction("Login", "Home");
            }

            ViewData["ClassId"] = new SelectList(_context.ClassStd, "ClassId", "ClassName");
            return View();
        }

        // POST: Lessons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LessonId,ClassId,Title,FileAttachment")] Lesson lesson, List<IFormFile> FileAttachment)
        {

            if (HttpContext.Session.GetString("Loggedin") == null)
            {
                return RedirectToAction("Login", "Home");
            }

            _context.Add(lesson);
            await _context.SaveChangesAsync();


            long size = FileAttachment.Sum(f => f.Length);


            foreach (var formFile in FileAttachment)
            {
                if (formFile.Length > 0)
                {
                    var filePath = formFile.FileName;

                    string ImageName = filePath.Replace(" ", "_");

                    lesson.FileAttachment = ImageName;
                    _context.Attach(lesson).Property(x => x.FileAttachment).IsModified = true;
                    _context.SaveChanges();

                    //Get url To Save
                    string SavePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/LessonFiles", ImageName);
                    lesson.FileAttachment = ImageName;

                    using (var stream = new FileStream(SavePath, FileMode.Create))
                    {
                        formFile.CopyTo(stream);
                    }
                }
            }

     


            return RedirectToAction(nameof(Index));

        }

        // GET: Lessons/Edit/5
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

            var lesson = await _context.Lesson.FindAsync(id);
            if (lesson == null)
            {
                return NotFound();
            }
            ViewData["ClassId"] = new SelectList(_context.ClassStd, "ClassId", "ClassName", lesson.ClassId);
            return View(lesson);
        }

        // POST: Lessons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LessonId,ClassId,Title,FileAttachment")] Lesson lesson, List<IFormFile> FileAttachment)
        {
            if (HttpContext.Session.GetString("Loggedin") == null)
            {
                return RedirectToAction("Login", "Home");
            }

            if (id != lesson.LessonId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lesson);
                    await _context.SaveChangesAsync();

                    long size = FileAttachment.Sum(f => f.Length);


                    foreach (var formFile in FileAttachment)
                    {
                        if (formFile.Length > 0)
                        {
                            var filePath = formFile.FileName;

                            //string ImageName = "Lesson-" + lesson.LessonId + Path.GetExtension(filePath);

                            string ImageName = filePath.Replace(" ", "_");

                            lesson.FileAttachment = ImageName;
                            _context.Attach(lesson).Property(x => x.FileAttachment).IsModified = true;
                            _context.SaveChanges();

                            //Get url To Save
                            string SavePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/LessonFiles", ImageName);
                            lesson.FileAttachment = ImageName;

                            using (var stream = new FileStream(SavePath, FileMode.Create))
                            {
                                formFile.CopyTo(stream);
                            }
                        }
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LessonExists(lesson.LessonId))
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
            ViewData["ClassId"] = new SelectList(_context.ClassStd, "ClassId", "ClassId", lesson.ClassId);
            return View(lesson);
        }

        // GET: Lessons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (HttpContext.Session.GetString("Loggedin") == null)
            {
                return RedirectToAction("Login", "Home");
            }

            if (id == null)
            {
                return NotFound();
            }

            var lesson = await _context.Lesson
                .Include(l => l.Class)
                .FirstOrDefaultAsync(m => m.LessonId == id);
            if (lesson == null)
            {
                return NotFound();
            }

            return View(lesson);
        }

        // POST: Lessons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (HttpContext.Session.GetString("Loggedin") == null)
            {
                return RedirectToAction("Login", "Home");
            }


            var lesson = await _context.Lesson.FindAsync(id);
            _context.Lesson.Remove(lesson);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LessonExists(int id)
        {
            return _context.Lesson.Any(e => e.LessonId == id);
        }
    }
}
