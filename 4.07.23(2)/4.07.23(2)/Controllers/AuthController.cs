//using _4._07._23_2_.Models;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.IdentityModel.Tokens;
//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;
//using System.Text;


//namespace _4._07._23_2_.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]



//    public class AuthController : ControllerBase
//    {
//        DataContext db = new DataContext();
//        string signingKey = "benim sifreleme algoritmam 215431534131 dfödçsöfdsö";


//        private JobSeeker? KimlikDenetimi(string mail, string sifre)
//        {
//            return db.Seekers.FirstOrDefault(x => x.mail.ToLower() == mail
//            && x.KullanıcıSifresi == sifre);
//        }

//        [HttpPost]
//        public IActionResult Giris(string mail, string sifre)
//        {
//            var kullanici = KimlikDenetimi(mail, sifre);
//            if (kullanici == null) return NotFound("kULLANICI BULUNAMADI");

//            var token = Get(mail, sifre);

//            return Ok(token);
//        }


//        [HttpGet]
//        public string Get(string mail, string sifre)
//        {
//            var claims = new[]
//            {
//                new Claim(ClaimTypes.NameIdentifier,mail),
//                //new Claim(JwtRegisteredClaimNames.Email,sifre)
//            };


//            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingKey));
//            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

//            var jwtSecurityToken = new JwtSecurityToken(
//                issuer: "www.wikipedi.com",
//                audience: "BuBenimKullandığımAudienceDegeri",
//                claims: claims,
//                expires: DateTime.Now.AddMinutes(40),
//                notBefore: DateTime.Now,
//                signingCredentials: credentials
//                );


//            var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

//            return token;
//        }

//        // ------------------------------------ token doğrulama ------------------------------------------

//        [HttpGet("ValidateToken")]
//        public bool Validatetoken(string token)
//        {
//            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingKey));
//            try
//            {
//                JwtSecurityTokenHandler handler = new();
//                handler.ValidateToken(token, new TokenValidationParameters()
//                {
//                    ValidateIssuerSigningKey = true,
//                    IssuerSigningKey = securityKey,
//                    ValidateLifetime = true,
//                    ValidateAudience = false,
//                    ValidateIssuer = false
//                },

//                    out SecurityToken validatedToken);
//                var jwtToken = (JwtSecurityToken)validatedToken;

//                var claims = jwtToken.Claims.ToList();
//                return true;
//            }

//            catch (System.Exception)
//            {
//                return false;
//            }

//        }
//    }
//}
