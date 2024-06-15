using _4._07._23_2_.Models;

namespace _4._07._23_2_.Abstract
{
    public interface IIsBakanMeslek
    {

        IsBakanMeslek CreateIBM(int id,int id2);

        List<IsBakanMeslek> GetIsBakanMeslek();

        IsBakanMeslek UpdateIBM(int id, int id2,Meslek meslek);

        IsBakanMeslek DeleteIBM(int id);

    }
}
