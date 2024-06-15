using _4._07._23_2_.Abstract;
using _4._07._23_2_.Models;

namespace _4._07._23_2_.Concrete
{
    public class IsSahibiRepository : IIsSahibi
    {
        DataContext _context = new DataContext();

        public IsSahibi? GetIsSahibiById(int id)
        {
           return _context.isSahibis.FirstOrDefault(x => x.Id == id);
        }

        public IsSahibi CreateIsSahibi (IsSahibi isSahibi) {

            _context.isSahibis.Add(isSahibi);
            _context.SaveChanges();
            return isSahibi;
        }

        public List<IsSahibi> GetIsSahibi()
        {
            return _context.isSahibis.ToList();
        }

        public IsSahibi ? UpdateIsSahibi(IsSahibi isSahibi)
        {
            _context.isSahibis.Update(isSahibi);
            _context.SaveChanges();
            return isSahibi;
        }

        public void DeleteIsSahibi(int id)
        {
            var deleted = GetIsSahibiById(id);
            _context.isSahibis.Remove(deleted);
            _context.SaveChanges();
        }
    }
}
