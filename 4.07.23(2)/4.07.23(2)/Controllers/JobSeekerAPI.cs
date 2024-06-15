using _4._07._23_2_.Abstract;
using _4._07._23_2_.Concrete;
using _4._07._23_2_.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _4._07._23_2_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class JobSeekerAPI : ControllerBase
    {
        public IJobSeek _jobseek;
        MeslekRepository mR= new MeslekRepository();
        IsBakanMeslekRepository ibmr = new IsBakanMeslekRepository();

        
        public JobSeekerAPI()    
        {
            _jobseek = new JobSeekerRepository();
        }


        // GET: api/<JobSeekerAPI>

        [HttpGet]
        public IEnumerable<JobSeeker> Get()
        {
            var js = _jobseek.GetAllJobSeek();

            return js;
        }

        // GET api/<JobSeekerAPI>/5
        [HttpGet("{mail}")]
        public IActionResult Get(string mail)
        {
            var js= _jobseek.GetJobSeekerByMail(mail);
            if (js != null)
            {
                    return Ok(js);
            }
            return NotFound();
           
        }

        // POST api/<JobSeekerAPI>

        [HttpPost]
        public IActionResult Post([FromBody] JobMeslek jm)
        {

            var js= _jobseek.CreateJobSeeker(jm.seeker); 
            mR.CreateMeslek(jm.meslek);// meslek tablosuna meslek kayıdı.
            ibmr.CreateIBM(jm.seeker.Id, jm.meslek.Id);  // ibm tablosuna kayıt 
            
            if (js != null)
            {
                return Ok(js);
            }
            return BadRequest();
            
        }

        // PUT api/<JobSeekerAPI>/5
        [HttpPut]
        public IActionResult Put([FromBody] JobSeeker jobSeeker)
        {
           if(_jobseek.GetJobSeekerById(jobSeeker.Id)!= null ) {

                return Ok(_jobseek.UpdateJobSeeker(jobSeeker));
            }

            return NotFound();
        }

        // DELETE api/<JobSeekerAPI>/5
        [HttpDelete("{mail}")]
        public IActionResult Delete(string mail)
        {
            if (_jobseek.GetJobSeekerByMail(mail) != null)
            {
                _jobseek.DeleteJobSeeker(mail);
                return Ok();
            }

            return NotFound();
        }
    }
}
