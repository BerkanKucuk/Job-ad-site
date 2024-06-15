using _4._07._23_2_.Abstract;
using _4._07._23_2_.Models;

namespace _4._07._23_2_.Concrete
{
    public class FirmaSektorRepository : IFirmaSektor
    {
        DataContext _context = new DataContext();

        public FirmaSektor CreateFS(int firmaid, int sektorid)
        {
            FirmaSektor firsek = new FirmaSektor();
            firsek.FirmaId = firmaid;
            firsek.SektorId = sektorid;
        
            _context.firmaSektors.Add( firsek );
            _context.SaveChanges();
            
            return firsek;
        }

        public FirmaSektor DeleteFS(int id)
        {
            var deleted = _context.firmaSektors.FirstOrDefault(x => x.Id == id);
            if (deleted != null)
            {
                _context.firmaSektors.Remove(deleted);
                _context.SaveChanges();
                return deleted;
            }

            else return null;
        }

        public FirmaSektor GetById(int firmaid,int sektorid)
        {
            return _context.firmaSektors.FirstOrDefault(x => x.FirmaId == firmaid && x.SektorId == sektorid);
        }


        public List<FirmaSektor> GetFS()
        {
            return _context.firmaSektors.ToList();
        }

        public FirmaSektor? UpdateFs(int id, int id2,Sektor sektor)
        {
            var istenenfirma = _context.firmaSektors.Where(x => x.FirmaId == id); // id = firma id'miz.
            if (istenenfirma != null)
            {
               var istenensektör=istenenfirma.FirstOrDefault(x => x.SektorId == id2);// firmanın istenilen parametredeki sektörünü bulma
               if (istenensektör != null)
                {
                    istenensektör.SektorId = sektor.Id;
                    _context.SaveChanges();
                }
                return istenensektör;
            }

            return null;
        }

        
    }


    }

