using _4._07._23_2_.Models;

namespace _4._07._23_2_.Abstract
{
    public interface IFirmaSektor 
    {
        FirmaSektor CreateFS(int id, int id2);

        List<FirmaSektor> GetFS();

        FirmaSektor UpdateFs(int id, int id2,Sektor sektor);

        FirmaSektor GetById(int id,int id2);
        
        FirmaSektor DeleteFS(int id);



    }
}
