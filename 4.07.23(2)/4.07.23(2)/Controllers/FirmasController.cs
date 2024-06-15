//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using _4._07._23_2_.Models;
//using Aspose.Html;
//using Microsoft.EntityFrameworkCore.Metadata.Internal;

//namespace _4._07._23_2_.Controllers
//{
//    public class FirmasController : Controller
//    {
//        private readonly DataContext _context;

//        public FirmasController(DataContext context)
//        {
//            _context = context;
//        }

//        // GET: Firmas
//        public async Task<IActionResult> Index()
//        {
//            var dataContext = _context.firmas.Include(f => f.IsSahibi);
//            return View(await dataContext.ToListAsync());
//        }

//        // GET: Firmas/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null || _context.firmas == null)
//            {
//                return NotFound();
//            }

//            var firma = await _context.firmas
//                .Include(f => f.IsSahibi)
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (firma == null)
//            {
//                return NotFound();
//            }

//            return View(firma);
//        }

//        // GET: Firmas/Create
//        public IActionResult Create(int IsSahibiId)
//        {
//            Firma a = new Firma {
//                IsSahibiId = IsSahibiId
//            };
//            ViewData["IsSahibiId"] = new SelectList(_context.isSahibis, "Id", "Id");
//            return View(a);
//        } 
        

//        // POST: Firmas/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("Id,ad,Adres,mail,kurulusYili,website,telno,aciklama,IsSahibiId")] Firma firma)
//        {
//            if (ModelState.IsValid)
//            { 
//                _context.Add(firma);
//                await _context.SaveChangesAsync();
//                ViewBag.yazı = "Kayıt tamamlandı giriş yapıp ilan verebilirsiniz";
//                return RedirectToAction(nameof(Index));
//            }
//            ViewData["IsSahibiId"] = new SelectList(_context.isSahibis, "Id", "Id", firma.IsSahibiId);
//            return View(firma);
//        }

//        // GET: Firmas/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null || _context.firmas == null)
//            {
//                return NotFound();
//            }

//            var firma = await _context.firmas.FindAsync(id);
//            if (firma == null)
//            {
//                return NotFound();
//            }
//            ViewData["IsSahibiId"] = new SelectList(_context.isSahibis, "Id", "Id", firma.IsSahibiId);
//            return View(firma);
//        }

//        // POST: Firmas/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("Id,ad,Adres,mail,kurulusYili,website,telno,aciklama,IsSahibiId")] Firma firma)
//        {
//            if (id != firma.Id)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(firma);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!FirmaExists(firma.Id))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            ViewData["IsSahibiId"] = new SelectList(_context.isSahibis, "Id", "Id", firma.IsSahibiId);
//            return View(firma);
//        }

//        // GET: Firmas/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null || _context.firmas == null)
//            {
//                return NotFound();
//            }

//            var firma = await _context.firmas
//                .Include(f => f.IsSahibi)
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (firma == null)
//            {
//                return NotFound();
//            }

//            return View(firma);
//        }

//        // POST: Firmas/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            if (_context.firmas == null)
//            {
//                return Problem("Entity set 'DataContext.firmas'  is null.");
//            }
//            var firma = await _context.firmas.FindAsync(id);
//            if (firma != null)
//            {
//                _context.firmas.Remove(firma);
//            }
            
//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool FirmaExists(int id)
//        {
//          return (_context.firmas?.Any(e => e.Id == id)).GetValueOrDefault();
//        }
//    }
//}
