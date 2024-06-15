using _4._07._23_2_.Models;

namespace _4._07._23_2_.Abstract
{
    public interface IMeslek
    {

        Meslek CreateMeslek(Meslek meslek);

        Meslek GetMeslekById(int id);

    }
}
