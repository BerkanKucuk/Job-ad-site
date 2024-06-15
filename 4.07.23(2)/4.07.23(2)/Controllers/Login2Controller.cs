using _4._07._23_2_.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace _4._07._23_2_.Controllers
{
    public class Login2Controller : Controller
    {
        DataContext c = new DataContext();
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(JobSeeker js) {


            var _mail = js.mail;
            var sifre = js.KullanıcıSifresi;
            var durum= c.Seekers.Where(x => x.mail == _mail && x.KullanıcıSifresi == sifre).Any();
            if(durum==true) {
                return RedirectToAction("KullanıcıBilgileri",new { _mail_ =js.mail});
            }
            else
            {
                ViewBag.hata = "Kullanıcı adı veya sifre yanlış";
                return View();
            }


        }
        //public IActionResult KullanıcıBilgileri(string _mail_)
        //{
        //    JobSeekerAPI jobSeekerAPI = new JobSeekerAPI();
        //    JobSeeker bilgi=jobSeekerAPI.Get(_mail_);

        //    ViewData["ad"] = bilgi.ad;
        //    ViewData["soyad"] = bilgi.soyad;
        //    ViewData["mail"] = bilgi.mail;
        //    ViewData["telno"] = bilgi.telno;
        //    ViewData["sehir"] = bilgi.sehir;
        //    ViewData["ilce"] = bilgi.ilce;
        //    ViewData["dogum"] = bilgi.dogumtarihi;
        //    ViewData["egitim"] = bilgi.egitimSeviyesi;
        //    ViewData["cinsiyet"] = bilgi.cinsiyet;

        //    //string ad = bilgi.ad;
        //    //string soyad = bilgi.soyad;
        //    //string mail= bilgi.mail;
        //    //string sehir = bilgi.sehir;

        //    return View(bilgi);
        //}

        [HttpGet]
        public IActionResult IsSahibiIndex(IsSahibi isSahibi)
        {
            var _mail = isSahibi.mail;
            var sifre = isSahibi.KullanıcıSifresi;
            var durum = c.isSahibis.Where(x=>x.mail==_mail && x.KullanıcıSifresi==sifre).Any();

            if (durum == true)
                return RedirectToAction("DashBoard");

            //AuthController authController = new AuthController();
            //if(durum==true)
            //{

            //    var token = authController.Get(_mail, sifre);
            //    bool _state = authController.Validatetoken(token);
            //    if(!_state==true) 
            //        return NotFound("Kullanıcı Bulunamadı");

            //    return RedirectToAction("");
            //}
            else
            {
                ViewBag.hata = "Kullanıcı adı veya sifre yanlış";
                return View();
            }
        }
    }
   
}
