using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.DAO
{
    public class UserDAO
    {
        private static UserDAO instance = null;
        private static object instanceLook = new object();

        public static UserDAO Instance
        {
            get
            {
                lock (instanceLook)
                {
                    if (instance == null)
                    {
                        instance = new UserDAO();
                    }
                    return instance;
                }
            }
        }
        public void addNewUser(TblUser t)
        {
            using var db = new IndruinoProductManagementContext();
            db.TblUsers.Add(t);
            db.SaveChanges();
            int id = t.Id;
        }
    }
}
