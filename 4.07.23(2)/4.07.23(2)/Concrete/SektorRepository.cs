using _4._07._23_2_.Abstract;
using _4._07._23_2_.Models;

namespace _4._07._23_2_.Concrete
{
    public class SektorRepository : ISektor
    {
        DataContext _context= new DataContext();
        public Sektor CreateSektor(Sektor sektor)
        {
            _context.sektors.Add(sektor);
            _context.SaveChanges();
            return sektor;
        }
        public Sektor ? GetSektorById(int id)
        {
            return _context.sektors.FirstOrDefault(x => x.Id == id);
        }
    }
}
