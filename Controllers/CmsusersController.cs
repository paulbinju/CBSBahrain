using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CBSBahrainMVC.Models;
using Microsoft.AspNetCore.Http;

namespace CBSBahrainMVC.Controllers
{
    public class CmsusersController : Controller
    {
        private readonly CBSBahrainContext _context;

        public CmsusersController(CBSBahrainContext context)
        {
            _context = context;
        }

        // GET: Cmsusers
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Cmsuser.ToListAsync());
        //}

        //// GET: Cmsusers/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var cmsuser = await _context.Cmsuser
        //        .FirstOrDefaultAsync(m => m.UserId == id);
        //    if (cmsuser == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(cmsuser);
        //}

        //// GET: Cmsusers/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Cmsusers/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("UserId,UserName,Password,CreatedOn")] Cmsuser cmsuser)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(cmsuser);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(cmsuser);
        //}


        public ActionResult Logout() {

            HttpContext.Session.Remove("Loggedin");
            return RedirectToAction("Login", "Home");

        }

        // GET: Cmsusers/Edit/5
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

            var cmsuser = await _context.Cmsuser.FindAsync(id);
            if (cmsuser == null)
            {
                return NotFound();
            }
            return View(cmsuser);
        }

        // POST: Cmsusers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,UserName,Password,CreatedOn")] Cmsuser cmsuser)
        {
            if (id != cmsuser.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    cmsuser.CreatedOn = DateTime.Now;
                    _context.Update(cmsuser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CmsuserExists(cmsuser.UserId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Login", "Home");
            }
            return View(cmsuser);
        }

        // GET: Cmsusers/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var cmsuser = await _context.Cmsuser
        //        .FirstOrDefaultAsync(m => m.UserId == id);
        //    if (cmsuser == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(cmsuser);
        //}

        //// POST: Cmsusers/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var cmsuser = await _context.Cmsuser.FindAsync(id);
        //    _context.Cmsuser.Remove(cmsuser);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool CmsuserExists(int id)
        {
            return _context.Cmsuser.Any(e => e.UserId == id);
        }
    }
}
