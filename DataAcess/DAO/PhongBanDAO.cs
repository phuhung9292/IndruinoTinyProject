using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.DAO
{
    public class PhongBanDAO
    {
        private static PhongBanDAO instance = null;
        private static object instanceLook = new object();

        public static PhongBanDAO Instance
        {
            get
            {
                lock (instanceLook)
                {
                    if (instance == null)
                    {
                        instance = new PhongBanDAO();
                    }
                    return instance;
                }
            }
        }

        public void addPhongBan(TblPhongBan pb)
        {
            using var db = new IndruinoProductManagementContext();
            db.TblPhongBans.Add(pb);
            db.SaveChanges();
            int id = pb.Id;
        }
    }
}
