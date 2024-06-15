using _4._07._23_2_.Concrete;
using _4._07._23_2_.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _4._07._23_2_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IlansAPI : ControllerBase
    {
        IlansRepository ir = new IlansRepository();
        // GET: api/<IlansAPI>
        [HttpGet]
        public IEnumerable<Ilan> Get()
        {
            return ir.GetIlans();
        }

        // GET api/<IlansAPI>/5
        [HttpGet("{id}")]
        public Ilan Get(int id)
        {
            var x = ir.GetIlanById(id);
            if (x == null)
                return x;
            else
                return x;
        }

        // POST api/<IlansAPI>

        
        [HttpPost]
        public IActionResult Post([FromBody] Ilan ilan)
        {
            var ilan2 = ir.CreateIlan(ilan);
            if (ilan2 != null)
                return Ok(ilan2);

            else return BadRequest();
        }

        // PUT api/<IlansAPI>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id,[FromBody] Ilan ilan)
        {
            var sonuc = ir.UpdateIlan(id,ilan);
            if (sonuc != null)
                return Ok(sonuc);

            else return BadRequest();
        }

        // DELETE api/<IlansAPI>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var a = ir.DeleteIlan(id);
            if (a != null)
                return Ok();

            else return NotFound();
        }
    }
}
