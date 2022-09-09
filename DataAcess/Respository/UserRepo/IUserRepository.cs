using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Respository.UserRepo
{
    public interface IUserRepository
    {
        void addNewUser(TblUser t);
    }
}
