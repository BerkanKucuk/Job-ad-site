using _4._07._23_2_.Concrete;
using _4._07._23_2_.Models;
using Microsoft.AspNetCore.Mvc;
using NuGet.DependencyResolver;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _4._07._23_2_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FirmaSektorController : ControllerBase
    {
        // GET: api/<FirmaSektorController>
        FirmaSektorRepository fsrp= new FirmaSektorRepository();
        FirmaRepository fr= new FirmaRepository();
        SektorRepository sr= new SektorRepository();
        DataContext dataContext = new DataContext();

        [HttpGet]
        public IEnumerable<FirmaSektor> Get()
        {
            return fsrp.GetFS();
        }

        // GET api/<FirmaSektorController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<FirmaSektorController>
        [HttpPost]
        public IActionResult Post(int firmaId,int sektorId)
        {
            if (fr.GetFirmaId(firmaId) == null || sr.GetSektorById(sektorId) == null)
                return NotFound();

            else
                return Ok(fsrp.CreateFS(firmaId, sektorId));
        }

        // PUT api/<FirmaSektorController>/5
        [HttpPut()]
        public IActionResult Put(int firmaid,int sektorid, [FromBody] Sektor sektor)
        {
            var xy=fsrp.UpdateFs(firmaid,sektorid,sektor);
            if (xy != null)
                return Ok(xy);

            else return BadRequest();
;        }

        // DELETE api/<FirmaSektorController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var a = fsrp.DeleteFS(id);
            if (a != null)
            {
                return Ok(a);
            }
            return NotFound();
        }

    }
}
