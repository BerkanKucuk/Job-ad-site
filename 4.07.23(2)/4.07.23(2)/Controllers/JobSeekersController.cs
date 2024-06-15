using _4._07._23_2_.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _4._07._23_2_.Controllers
{
    public class JobSeekersController : Controller
    {
        private readonly DataContext _context;

        public JobSeekersController(DataContext context)
        {
            _context = context;
        }

        // GET: JobSeekers
        public async Task<IActionResult> Index()
        {
            return _context.Seekers != null ?
                        View(await _context.Seekers.ToListAsync()) :
                        Problem("Entity set 'DataContext.Seekers'  is null.");
        }

        // GET: JobSeekers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Seekers == null)
            {
                return NotFound();
            }

            var jobSeeker = await _context.Seekers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jobSeeker == null)
            {
                return NotFound();
            }

            return View(jobSeeker);
        }

        // GET: JobSeekers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: JobSeekers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ad,soyad,mail,telno,sehir,ilce,dogumtarihi,egitimSeviyesi,cinsiyet,KullanıcıSifresi")] JobSeeker jobSeeker, Meslek meslek)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jobSeeker);
                await _context.SaveChangesAsync();
                return RedirectToAction("KayıtAday", "Kontrol", new { mail = jobSeeker.mail });
                //return RedirectToAction(nameof(Index));
            }
            return View(jobSeeker);
        }

        // GET: JobSeekers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Seekers == null)
            {
                return NotFound();
            }

            var jobSeeker = await _context.Seekers.FindAsync(id);
            if (jobSeeker == null)
            {
                return NotFound();
            }
            return View(jobSeeker);
        }

        // POST: JobSeekers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ad,soyad,mail,telno,sehir,ilce,dogumtarihi,egitimSeviyesi,cinsiyet,KullanıcıSifresi")] JobSeeker jobSeeker)
        {
            if (id != jobSeeker.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jobSeeker);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobSeekerExists(jobSeeker.Id))
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
            return View(jobSeeker);
        }

        // GET: JobSeekers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Seekers == null)
            {
                return NotFound();
            }

            var jobSeeker = await _context.Seekers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jobSeeker == null)
            {
                return NotFound();
            }

            return View(jobSeeker);
        }

        // POST: JobSeekers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Seekers == null)
            {
                return Problem("Entity set 'DataContext.Seekers'  is null.");
            }
            var jobSeeker = await _context.Seekers.FindAsync(id);
            if (jobSeeker != null)
            {
                _context.Seekers.Remove(jobSeeker);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobSeekerExists(int id)
        {
            return (_context.Seekers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
