using _4._07._23_2_.Abstract;
using _4._07._23_2_.Models;

namespace _4._07._23_2_.Concrete
{
    public class IsBakanIlanRepository : IIsBakanIlan
    {
        DataContext _context= new DataContext();
        public IsBakanIlan CreateIBI(IsBakanIlan isBakanIlan)
        {
            IsBakanIlan ibi = new IsBakanIlan();
            ibi.IlanId = isBakanIlan.IlanId;
            ibi.JobSeekerId = isBakanIlan.JobSeekerId;

            _context.ısBakanIlans.Add(ibi);
            _context.SaveChanges();
            return ibi;
        }

        public IsBakanIlan? DeleteIBI(int id)
        {
            var deleted = _context.ısBakanIlans.FirstOrDefault(x => x.Id == id);
            if (deleted != null)
            {
                _context.ısBakanIlans.Remove(deleted);
                _context.SaveChanges();
                return deleted;
            }

            else return null;
        }

        public IsBakanIlan? GetByIdIBI(int id)
        {
            return _context.ısBakanIlans.Find(id);
        }

        public List<IsBakanIlan> GetIBI(IsBakanIlan isBakanIlan)
        {
            return _context.ısBakanIlans.ToList();
        }

        public IsBakanIlan? UpdateIBI(int jsid,int ilanid,IsBakanIlan isBakanIlan)
        {
            var istenenkisi= _context.ısBakanIlans.Where(x => x.JobSeekerId== jsid);
            if (istenenkisi != null )
            {
                var istenenilan = istenenkisi.FirstOrDefault(x => x.IlanId == ilanid);
                if(istenenilan != null)
                {
                    istenenilan.IlanId=isBakanIlan.IlanId;
                    _context.SaveChanges();
                }

                return istenenilan;
            }

            return null;
        }
    }
}
