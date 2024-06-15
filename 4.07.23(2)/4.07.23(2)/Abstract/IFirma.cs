using _4._07._23_2_.Models;

namespace _4._07._23_2_.Abstract
{
    public interface IFirma
    {
        List<Firma> GetAllFirma();

        Firma GetFirmaByMail(string mail);

        Firma CreateFirma(Firma firma);

        Firma UpdateFirma(Firma firma,int id);

        void DeleteFirma(int id);

        Firma GetFirmaId(int id);
    }
}
