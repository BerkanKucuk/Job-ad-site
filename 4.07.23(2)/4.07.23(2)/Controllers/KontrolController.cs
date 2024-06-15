using _4._07._23_2_.Abstract;
using _4._07._23_2_.Controllers;
using _4._07._23_2_.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using NuGet.Common;
using System.Diagnostics;
using System.Diagnostics.Contracts;

public class KontrolController : Controller
{
   DataContext DataContext = new DataContext();

    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<IdentityUser> _userManager;
    public KontrolController(RoleManager<IdentityRole> roleManager,UserManager<IdentityUser> userManager)
    {
        _roleManager = roleManager;
        _userManager = userManager;
    }
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Uyelik()

    {
        return View();

    }

    public IActionResult IndexNew()
    {
        return View(Baglayici.GetIlanlar().ToList());
    }

    [HttpGet]
    public IActionResult GirisAday()
    {

        return View();
    }

    [HttpPost]
    public IActionResult GirisAday(kodalanim.LoginViewModel model)
    {
        // Ortak giriş sayfasından kullanıcının rolüne göre sayfaya yönlendirme;

        var sonuc = Baglayici.GirisKontrolu(model);
        if (sonuc.Result.IsSuccess == true) {
            string isbakan = "İşbakan";
            string isveren = "İşveren";
            var user = _userManager.Users.FirstOrDefault(x => x.UserName == model.Email);
            var aa = _userManager.GetRolesAsync(user);

            if (aa.Result.Contains(isbakan)) {

                var x = Baglayici.KullaniciBilgileri(model.Email);

                /*TempData["aday"] = x*/;

                kodalanim.JobSeeker aday = new kodalanim.JobSeeker();
                aday = x;

                return RedirectToAction("DogruGiris",aday);

        }
            else if (aa.Result.Contains(isveren))
                return RedirectToAction("DogruGiris2");

            else return View();
        }
        else return View();

    }

    [HttpGet]
    public IActionResult? DogruGiris(kodalanim.JobSeeker aday)
    {
        //kodalanim.JobSeeker _aday = (kodalanim.JobSeeker)TempData["aday"];

        return View(aday);
    }


    public IActionResult DogruGiris2()
    {
        return View();
    }

    /// ilan verme/ <summary>
    /// ilan verme/

    [HttpGet]
    public IActionResult CreateIlan()
    {
        return View();
    }

    [HttpPost]
    public IActionResult CreateIlan(Ilan ılan)
    {
        if (ModelState.IsValid)
        {
           IlansAPI ılansAPI = new IlansAPI();
           var c= ılansAPI.Post(ılan);
            if(c== Ok())
                RedirectToAction("IndexNew");
            
        }      
        return View();
    }

    [HttpGet]
    public IActionResult KayıtAday(string mail)
    {
        kodalanim.RegisterViewModel registerViewModel = new kodalanim.RegisterViewModel()
        {
            Email = mail
        };

        return View(registerViewModel);
    }
    

    [HttpPost]
    public async Task<IActionResult> KayıtAday(kodalanim.RegisterViewModel registerViewModel)
    {
     
        if (ModelState.IsValid)
        {
            var sonuc = Baglayici.Kayit(registerViewModel);
            if (sonuc.Result.IsSuccess == true)
            {
                string isbakan = "İşbakan";
                var user = _userManager.Users.FirstOrDefault(x => x.UserName == registerViewModel.Email);
                var RolAd = _roleManager.Roles.Where(x => x.Name == isbakan).FirstOrDefault();
                              
               var result= await _userManager.AddToRoleAsync(user, RolAd.Name);
                
                ViewData["abc"] = "kayıt başarılı";
                return RedirectToAction("Index", "JobSeekers");
            }
        }

        else ViewData["abc"] = "kayıt başarısız";
        return View();
    }

    [HttpGet]
    public IActionResult KayıtIsveren(string mail)
    {
        kodalanim.RegisterViewModel rvm = new kodalanim.RegisterViewModel()
        {
            Email = mail
        };

        return View(rvm);
        
    }

    [HttpPost]
    public async Task<IActionResult> KayıtIsveren(kodalanim.RegisterViewModel registerViewModel)
    {
        if (ModelState.IsValid)
        {
            var sonuc = Baglayici.Kayit(registerViewModel);
            if (sonuc.Result.IsSuccess == true)
            {

                string isbakan = "İşveren";
                var user = _userManager.Users.FirstOrDefault(x => x.UserName == registerViewModel.Email);
                var RolAd = _roleManager.Roles.Where(x => x.Name == isbakan).FirstOrDefault();

                var result = await _userManager.AddToRoleAsync(user, RolAd.Name);

                ViewData["abc"] = "kayıt başarılı";
                return RedirectToAction("Index", "IsSahibis");
            }
        }

        else ViewData["abc"] = "kayıt başarısız";
        return View();
    }

}