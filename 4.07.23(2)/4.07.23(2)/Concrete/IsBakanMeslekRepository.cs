using _4._07._23_2_.Abstract;
using _4._07._23_2_.Models;
using Microsoft.AspNetCore.Mvc;

namespace _4._07._23_2_.Concrete
{
    public class IsBakanMeslekRepository : IIsBakanMeslek
    {
        DataContext _context= new DataContext();

        public IsBakanMeslek CreateIBM(int JsId,int MeslekId)
        {
            IsBakanMeslek ibm = new IsBakanMeslek(); ibm.MeslekId = MeslekId; ibm.JobSeekerId = JsId;

            _context.ısBakanMesleks.Add(ibm);
            _context.SaveChanges();
            return ibm;
        }

        public IsBakanMeslek? DeleteIBM(int id)
        {
            var deleted = _context.ısBakanMesleks.FirstOrDefault(x => x.Id == id);
            if (deleted != null)
            {
                _context.ısBakanMesleks.Remove(deleted);
                _context.SaveChanges();
                return deleted;
            }

            else return null;
        }   

        public List<IsBakanMeslek> GetIsBakanMeslek()
        {
            return _context.ısBakanMesleks.ToList();
        }

        public IsBakanMeslek ? UpdateIBM(int Jsid,int mid,Meslek meslek)
        {
            var istenenisbakan = _context.ısBakanMesleks.Where(x => x.JobSeekerId == Jsid);
            if (istenenisbakan != null)
            {
                var istenenmeslek = istenenisbakan.FirstOrDefault(x => x.MeslekId == mid);// isbakanın istenilen parametredeki mesleğini bulma
                if (istenenmeslek != null)
                {
                    istenenmeslek.MeslekId = meslek.Id;
                    _context.SaveChanges();
                }
                return istenenmeslek;
            }
            return null;

        }

        
    }
}
