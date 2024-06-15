using _4._07._23_2_.Abstract;
using _4._07._23_2_.Models;

namespace _4._07._23_2_.Concrete
{
    public class FirmaRepository : IFirma
    {
        DataContext _context = new DataContext();
        public Firma CreateFirma(Firma firma)
        {
            _context.firmas.Add(firma);
            _context.SaveChanges();
            return firma;
        }

        public void DeleteFirma(int id)
        {
            throw new NotImplementedException();
        }

        public List<Firma> GetAllFirma()
        {
            return _context.firmas.ToList();
        }

        public Firma GetFirmaByMail(string mail)
        {
            throw new NotImplementedException();
        }

        public Firma ? GetFirmaId(int id)
        {
            return _context.firmas.Find(id);
        }

        public  Firma? UpdateFirma(Firma firma,int id)
        {
            var tobeupdated = GetFirmaId(id);
            if (tobeupdated != null)
            {
                tobeupdated.ad=firma.ad;
                tobeupdated.Adres = firma.Adres;
                tobeupdated.mail = firma.mail;
                tobeupdated.kurulusYili = firma.kurulusYili;
                tobeupdated.website = firma.website;
                tobeupdated.telno = firma.telno;
                tobeupdated.aciklama= firma.aciklama;
                tobeupdated.IsSahibiId=firma.IsSahibiId;

                _context.SaveChanges();
                return tobeupdated;
            }

            return null;
        }
    }
}
