using _4._07._23_2_.Models;

namespace _4._07._23_2_.Abstract
{
    public interface ISektor
    {

        Sektor CreateSektor(Sektor sektor);

        Sektor GetSektorById(int id);
    }
}
