using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _4._07._23_2_.Models;
using _4._07._23_2_.Concrete;

namespace _4._07._23_2_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IsSahibiAPIController : ControllerBase
    {
        private readonly DataContext _context;

        IsSahibiRepository isr = new IsSahibiRepository();
        public IsSahibiAPIController(DataContext context)
        {
            _context = context;
        }

        // GET: api/IsSahibis1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IsSahibi>>> GetisSahibis()
        {
          if (_context.isSahibis == null)
          {
              return NotFound();
          }
            return await _context.isSahibis.ToListAsync();
        }

        // GET: api/IsSahibis1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IsSahibi>> GetIsSahibi(int id)
        {
          if (_context.isSahibis == null)
          {
              return NotFound();
          }
            var isSahibi = await _context.isSahibis.FindAsync(id);

            if (isSahibi == null)
            {
                return NotFound();
            }

            return isSahibi;
        }

        // PUT: api/IsSahibis1/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIsSahibi(int id, IsSahibi isSahibi)
        {
            var updated = _context.isSahibis.Find(id);
            if (updated == null)
                return NotFound();

            isSahibi.Id = id;
            return Ok(isr.UpdateIsSahibi(isSahibi));
            
        }

        // POST: api/IsSahibis1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<IsSahibi>> PostIsSahibi(IsSahibi issahibi)
        {
          if (_context.isSahibis == null)
          {
              return Problem("Entity set 'DataContext.isSahibis'  is null.");
          }

            _context.isSahibis.Add(issahibi);
            await _context.SaveChangesAsync();

         // zamanı gelince kullanılacak
         // var isid=issahibi.Id; 

            return CreatedAtAction("GetIsSahibi", new { id = issahibi.Id }, issahibi);
        }

        // DELETE: api/IsSahibis1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIsSahibi(int id)
        {
            if (_context.isSahibis == null)
            {
                return NotFound();
            }
            var isSahibi = await _context.isSahibis.FindAsync(id);
            if (isSahibi == null)
            {
                return NotFound();
            }

            _context.isSahibis.Remove(isSahibi);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IsSahibiExists(int id)
        {
            return (_context.isSahibis?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
