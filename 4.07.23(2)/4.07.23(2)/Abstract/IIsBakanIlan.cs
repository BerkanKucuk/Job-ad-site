using _4._07._23_2_.Models;

namespace _4._07._23_2_.Abstract
{
        public interface IIsBakanIlan
        {

            IsBakanIlan CreateIBI(IsBakanIlan isBakanIlan);
            List<IsBakanIlan> GetIBI(IsBakanIlan isBakanIlan);
            IsBakanIlan GetByIdIBI(int id);
            IsBakanIlan UpdateIBI(int jsid,int ilanid,IsBakanIlan isBakanIlan);
            IsBakanIlan DeleteIBI(int id);
        }
    }