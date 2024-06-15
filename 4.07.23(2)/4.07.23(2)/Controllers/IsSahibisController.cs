using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _4._07._23_2_.Models;

namespace _4._07._23_2_.Controllers
{
    public class IsSahibisController : Controller
    {
        private readonly DataContext _context;

        public IsSahibisController(DataContext context)
        {
            _context = context;
        }

        // GET: IsSahibis
        public async Task<IActionResult> Index()
        {
              return _context.isSahibis != null ? 
                          View(await _context.isSahibis.ToListAsync()) :
                          Problem("Entity set 'DataContext.isSahibis'  is null.");
        }

        // GET: IsSahibis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.isSahibis == null)
            {
                return NotFound();
            }

            var isSahibi = await _context.isSahibis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (isSahibi == null)
            {
                return NotFound();
            }

            return View(isSahibi);
        }

        // GET: IsSahibis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: IsSahibis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ad,soyisim,mail,telno,KullanıcıSifresi")] IsSahibi isSahibi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(isSahibi);
                await _context.SaveChangesAsync();
                int id = _context.isSahibis.Max(k => k.Id);
                //ViewBag.Id = id;
                //return RedirectToAction("Create", "Firmas", new {IsSahibiId=id});
                return RedirectToAction("KayıtIsveren","Kontrol", new { mail = isSahibi.mail });
            }
            return View(isSahibi);
        }

        // GET: IsSahibis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.isSahibis == null)
            {
                return NotFound();
            }

            var isSahibi = await _context.isSahibis.FindAsync(id);
            if (isSahibi == null)
            {
                return NotFound();
            }
            return View(isSahibi);
        }

        // POST: IsSahibis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ad,soyisim,mail,telno,KullanıcıSifresi")] IsSahibi isSahibi)
        {
            if (id != isSahibi.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(isSahibi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IsSahibiExists(isSahibi.Id))
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
            return View(isSahibi);
        }

        // GET: IsSahibis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.isSahibis == null)
            {
                return NotFound();
            }

            var isSahibi = await _context.isSahibis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (isSahibi == null)
            {
                return NotFound();
            }

            return View(isSahibi);
        }

        // POST: IsSahibis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.isSahibis == null)
            {
                return Problem("Entity set 'DataContext.isSahibis'  is null.");
            }
            var isSahibi = await _context.isSahibis.FindAsync(id);
            if (isSahibi != null)
            {
                _context.isSahibis.Remove(isSahibi);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IsSahibiExists(int id)
        {
          return (_context.isSahibis?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
