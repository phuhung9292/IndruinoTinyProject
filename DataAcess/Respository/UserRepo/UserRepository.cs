using BusinessLayer;
using DataAcess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Respository.UserRepo
{
    public class UserRepository : IUserRepository
    {
        public void addNewUser(TblUser t) => UserDAO.Instance.addNewUser(t);
    }
}
