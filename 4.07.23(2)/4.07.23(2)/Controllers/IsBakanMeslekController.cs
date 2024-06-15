using _4._07._23_2_.Abstract;
using _4._07._23_2_.Concrete;
using _4._07._23_2_.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _4._07._23_2_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IsBakanMeslekController : ControllerBase
    {
        public IIsBakanMeslek _ibm;
        
        MeslekRepository mr = new MeslekRepository();
        JobSeekerRepository jsr  = new JobSeekerRepository();

        public IsBakanMeslekController()
        {
            _ibm= new IsBakanMeslekRepository();
        }


        [HttpGet]

        public IActionResult Get()
        {
            return Ok(_ibm.GetIsBakanMeslek());
        }

        [HttpPost]
        public IActionResult Post(int Jsid,int Meslekid)
        {
            if(mr.GetMeslekById(Meslekid)== null || jsr.GetJobSeekerById(Jsid)== null)
                return NotFound();

            else return Ok(_ibm.CreateIBM(Jsid, Meslekid));
        }

        [HttpPut]
        public IActionResult Put(int JsId,int  MeslekId, [FromBody] Meslek meslek) {

            var sonuc = _ibm.UpdateIBM(JsId, MeslekId, meslek);
            if (sonuc != null)
                return Ok(sonuc);

            else return BadRequest();

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) { 
            
            var a = _ibm.DeleteIBM(id);
            if (a != null)
            {
                return Ok(a);
            }

            return NotFound();
        }

    }

}
