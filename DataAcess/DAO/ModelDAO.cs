using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.DAO
{
    public class ModelDAO
    {
        private static ModelDAO instance = null;
        private static object instanceLook = new object();

        public static ModelDAO Instance
        {
            get
            {
                lock (instanceLook)
                {
                    if (instance == null)
                    {
                        instance = new ModelDAO();
                    }
                    return instance;
                }
            }
        }
        public void addModel(TblModel t)
        {
            using var db = new IndruinoProductManagementContext();
            db.TblModels.Add(t);
            db.SaveChanges();
            int id = t.Id;
        }
    }
}
