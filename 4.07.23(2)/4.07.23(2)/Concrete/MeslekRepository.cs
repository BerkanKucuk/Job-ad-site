using _4._07._23_2_.Abstract;
using _4._07._23_2_.Models;

namespace _4._07._23_2_.Concrete
{
    public class MeslekRepository : IMeslek
    {
        DataContext _context = new DataContext();

        public Meslek CreateMeslek(Meslek meslek)
        {
            _context.mesleks.Add(meslek);
            _context.SaveChanges();
            return meslek;
        }

        public Meslek? GetMeslekById(int id)
        {
           return _context.mesleks.FirstOrDefault(x=>x.Id==id);
        }
    }
}
