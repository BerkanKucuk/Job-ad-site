using _4._07._23_2_.Abstract;
using _4._07._23_2_.Concrete;
using _4._07._23_2_.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _4._07._23_2_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeslekController : ControllerBase
    {
        public IMeslek _meslek;

        public MeslekController()
        {
            _meslek= new MeslekRepository();
        }


        // GET: api/<MeslekController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<MeslekController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MeslekController>
        [HttpPost]
        public Meslek Post([FromBody] Meslek meslek)
        {
            return _meslek.CreateMeslek(meslek);
        }

        // PUT api/<MeslekController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MeslekController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
