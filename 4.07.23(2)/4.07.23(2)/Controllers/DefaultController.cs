using _4._07._23_2_.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace _4._07._23_2_.Controllers
{
    //[Route("api/DefaultController")]

    
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    
    public class DefaultController : ControllerBase
    {
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        
        [HttpGet]
        public IActionResult UyeGoruntule()
        {
            using var x =  new DataContext();
            var values = x.isSahibis.ToList();
            return Ok(values);
        }

        //[System.Web.Http.HttpPost]
        [HttpPost]
        public IActionResult AdayEkle(JobSeeker seeker)
        {
            using var y = new DataContext();
            y.Add(seeker);
            y.SaveChanges();
            return Ok(y);           
        }

        
        [HttpGet("{id}")]
        public IActionResult IsSahibiGet(int id)
        {
            using var x = new DataContext();
            var issahibi = x.isSahibis.Find(id);
            if (issahibi==null)
            {
                return NotFound();

            }

            else
            {
                return Ok(issahibi);
            }

        }

        [HttpPut]
        public IActionResult IsSahibiGuncelle(IsSahibi ısSahibi)
        {
            using var x=new DataContext();
            var issahibi = x.isSahibis.Find(ısSahibi.Id);
            if (issahibi == null)
            {
                return NotFound();
            }

            else
            {
                issahibi.ad = ısSahibi.ad;
                x.Update(issahibi);
                x.SaveChanges();
                return Ok(issahibi); 
            }
        }
    }
}
