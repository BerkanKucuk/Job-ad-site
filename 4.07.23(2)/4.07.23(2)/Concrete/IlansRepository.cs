using _4._07._23_2_.Abstract;
using _4._07._23_2_.Models;
using Microsoft.EntityFrameworkCore;

namespace _4._07._23_2_.Concrete
{
    public class IlansRepository : IILAN
    {
        DataContext _context= new DataContext();
        public Ilan CreateIlan(Ilan ilan)
        {
            Ilan yeni = new Ilan();

            yeni.aciklama = ilan.aciklama;
            yeni.DeneyimId = ilan.DeneyimId;
            yeni.Deneyim = _context.deneyims.FirstOrDefault(x => x.Id == ilan.DeneyimId);
            yeni.GetDate = ilan.GetDate;
            yeni.egitimseviyesi = ilan.egitimseviyesi;
            yeni.maaş = ilan.maaş;
            yeni.FirmaId = ilan.FirmaId;
            yeni.Firma = _context.firmas.FirstOrDefault(x => x.Id==ilan.FirmaId);
            yeni.firmaWebSite = ilan.firmaWebSite;
            yeni.CalismaTuruId= ilan.CalismaTuruId;
            yeni.CalismaTuru = _context.calismaTuru.FirstOrDefault(x => x.Id == ilan.CalismaTuruId);

            _context.Add(yeni);
            _context.SaveChanges();
            return yeni;

        }

        public Ilan DeleteIlan(int id)
        {
            var deleted=GetIlanById(id);
            if (deleted != null)
            {
                _context.Ilans.Remove(deleted);
                _context.SaveChanges();
                return deleted;
            }
            else return null;
        }

        public Ilan? GetIlanById(int id)
        {
            return _context.Ilans.Include(x=>x.Deneyim).Include(x => x.Firma).Include(x => x.CalismaTuru).FirstOrDefault(x=>x.Id==id);
        }

        public List<Ilan> GetIlans()
        {
            return _context.Ilans.Include(x => x.Deneyim).Include(x => x.Firma).Include(x => x.CalismaTuru).ToList();
        }

        public Ilan? UpdateIlan(int id, Ilan ilan)
        {
            var updated= GetIlanById(id);
            if (updated != null)
            {
                updated.aciklama = ilan.aciklama;
                updated.DeneyimId = ilan.DeneyimId;
                updated.GetDate = ilan.GetDate;
                updated.egitimseviyesi = ilan.egitimseviyesi;
                updated.maaş = ilan.maaş;
                updated.FirmaId = ilan.FirmaId;
                updated.firmaWebSite = ilan.firmaWebSite;
                updated.CalismaTuruId = ilan.CalismaTuruId;

                _context.SaveChanges();
                return updated;
            }
            else return null;
        }
    }
}
