using _4._07._23_2_.Models;

namespace _4._07._23_2_.Abstract
{
    public interface IILAN
    {

        List<Ilan> GetIlans();
        Ilan GetIlanById(int id);
        Ilan CreateIlan(Ilan Ilan);
        Ilan UpdateIlan(int id,Ilan ilan);
        Ilan DeleteIlan(int id);

        

    }
}
