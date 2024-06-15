using _4._07._23_2_.Abstract;
using _4._07._23_2_.Concrete;
using _4._07._23_2_.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _4._07._23_2_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SektorController : ControllerBase
    {
        public ISektor isektor;

        // GET: api/<SektorController>
        public SektorController()
        {
            isektor=new SektorRepository();
        }


        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<SektorController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SektorController>
        [HttpPost]
        public Sektor Post([FromBody] Sektor sektor)
        {
            return isektor.CreateSektor(sektor);
        }

        // PUT api/<SektorController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SektorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
