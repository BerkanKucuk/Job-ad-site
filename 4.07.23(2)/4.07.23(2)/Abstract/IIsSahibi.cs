using _4._07._23_2_.Models;

namespace _4._07._23_2_.Abstract
{
    public interface IIsSahibi
    {
        List<IsSahibi> GetIsSahibi();
        IsSahibi GetIsSahibiById(int id);

        IsSahibi CreateIsSahibi(IsSahibi isSahibi);

        IsSahibi UpdateIsSahibi(IsSahibi isSahibi);

        void DeleteIsSahibi(int id);


    }
}
