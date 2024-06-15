using kodalanim;
using System.Collections;
using System.Threading.Tasks;
using System;
namespace _4._07._23_2_.Models
{
    public static class Baglayici
    {
        static swaggerClient swaggerClient = new swaggerClient("https://localhost:7107/", new HttpClient());


        public static ICollection<kodalanim.Ilan> GetIlanlar()
        {
            var bilgi = swaggerClient.IlansAPIAllAsync().GetAwaiter().GetResult();
            return bilgi;
        }


        public static async Task<kodalanim.UserManagerResponse> GirisKontrolu(kodalanim.LoginViewModel model)
        {
     
            var sonuc = await swaggerClient.LoginAsync(model);
            return sonuc;
        }

        public static void IlanEkle(kodalanim.Ilan ilan)
        {

            swaggerClient.IlansAPIPOSTAsync(ilan);

        }

        public static Task<kodalanim.UserManagerResponse>Kayit(kodalanim.RegisterViewModel model)
        {
           var sonuc= swaggerClient.RegisterAsync(model);
  
            return sonuc;
        }


        public static kodalanim.JobSeeker? KullaniciBilgileri(string mail)
        {

            var allusers = swaggerClient.JobSeekerAPIAllAsync().GetAwaiter().GetResult();

            var specialuser = allusers.FirstOrDefault(x => x.Mail == mail);

            return specialuser;

        }
    }

}

