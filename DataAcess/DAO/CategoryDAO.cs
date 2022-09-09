using BusinessLayer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.DAO
{
    public class CategoryDAO
    {
        private static CategoryDAO instance = null;
        private static object instanceLook = new object();

        public static CategoryDAO Instance
        {
            get
            {
                lock (instanceLook)
                {
                    if (instance == null)
                    {
                        instance = new CategoryDAO();
                    }
                    return instance;
                }
            }
        }
        public IEnumerable<TblCategory> getCategoríes()
        {
            IEnumerable<TblCategory> categories = null;
            try
            {
                var context = new IndruinoProductManagementContext();
                categories = context.TblCategories.ToList();
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return categories;
        }

        public IEnumerable<TblModel> getModels()
        {
            var list = new List<TblModel>();
            try
            {
                using  var db = new IndruinoProductManagementContext();
                list = db.TblModels.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return list;
        }

        public IEnumerable<TblPhongBan> getPhongBan()
        {
            var list = new List<TblPhongBan>();
            try
            {
                using var db= new IndruinoProductManagementContext();
                list = db.TblPhongBans.ToList();
            }catch(Exception ex)
            {
                throw ex;
            }
            return list;
        }

        public IEnumerable<TblUser> GetTblUsers()
        {
            var list = new List<TblUser>();
            try
            {
                using var db = new IndruinoProductManagementContext();
                list = db.TblUsers.ToList();    
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return list;
        }
        public  TblCategory getCategory(int id)
        {
            TblCategory category = null;
            try
            {
                var db = new IndruinoProductManagementContext();
                category = db.TblCategories.SingleOrDefault(x=>x.Id == id); 
            }catch (Exception ex)
            {
                throw ex;
            }
            return category;
        }

        public void addNewCategory(TblCategory t)
        {
            try
            {
                var db = new IndruinoProductManagementContext();
                db.TblCategories.Add(t);
                db.SaveChanges();
                int id = t.Id;
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public void update(TblCategory t)
        {
            using var db = new IndruinoProductManagementContext();
            db.TblCategories.Update(t);
            db.SaveChanges();
        }

        public void delete(int id)
        {
            TblCategory t = getCategory(id);
            if(t != null)
            {
                using var db = new IndruinoProductManagementContext();
                db.TblCategories.Remove(t);
                db.SaveChanges();
            }
        }
    }
}
