using _4._07._23_2_.Abstract;
using _4._07._23_2_.Concrete;
using _4._07._23_2_.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _4._07._23_2_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    [Authorize(Roles ="Kullanıcı")]
    public class FirmaAPIController : ControllerBase
    {

        public IFirma _firma;

        IsSahibiRepository isr = new IsSahibiRepository();
        DataContext dataContext = new DataContext();
        
        SektorRepository serepo = new SektorRepository();

        FirmaSektorRepository fsr = new FirmaSektorRepository();

        // GET: api/<FirmaAPIController>

        public FirmaAPIController()
        {
            _firma=new FirmaRepository();
        }

        [HttpGet("Get")]

        public List<Firma> Get()
        {
            return _firma.GetAllFirma();
        }


        // GET api/<FirmaAPIController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var xx = _firma.GetFirmaId(id);

            if ( xx == null)
                return NotFound();

            else return Ok(xx);
        }

        // POST api/<FirmaAPIController>
        [HttpPost]
        public IActionResult Post([FromBody] FirSek firSek)
        {
             // burası parametre vs değişecek.
            //var durum = dataContext.isSahibis.FirstOrDefault(x => x.Id == IsSahibiId);

            //if (durum != null) {
            //    firma.IsSahibiId = IsSahibiId;
            //    //firma.IsSahibi = isr.GetIsSahibiById((int)firma.IsSahibiId);
            //    }   

            var frm = _firma.CreateFirma(firSek.firma);
            serepo.CreateSektor(firSek.sektor);  // sektör tablosuna kayıt
            fsr.CreateFS(firSek.firma.Id, firSek.sektor.Id);

            if (frm != null)
                return Ok(frm);
            
            else
                return BadRequest();
            
        }

        // PUT api/<FirmaAPIController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id,[FromBody] Firma firma)
        {
            var aa =_firma.UpdateFirma(firma, id);
            if (aa != null)
                return Ok(aa);

            return BadRequest();
        }
                

        // DELETE api/<FirmaAPIController>/5


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var firma = dataContext.firmas.Find(id);

            if (firma == null)
                return NotFound();

            dataContext.firmas.Remove(firma);
            dataContext.SaveChanges();
            return Ok();

        }
    }
}
