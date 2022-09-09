using BusinessLayer;
using DataAcess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Respository.CategoryRepo
{
    public class CategoryRepository : ICategoryRepository
    {
        public void deleteCategory(int id) => CategoryDAO.Instance.delete(id);

        public IEnumerable<TblCategory> getCategories() => CategoryDAO.Instance.getCategoríes();

        public IEnumerable<TblModel> getModels() => CategoryDAO.Instance.getModels();

        public IEnumerable<TblPhongBan> getPhongBan() => CategoryDAO.Instance.getPhongBan();

        public IEnumerable<TblUser> getUsers() => CategoryDAO.Instance.GetTblUsers();   

        public void saveCategory(TblCategory category) => CategoryDAO.Instance.addNewCategory(category);

        public void updateCategory(TblCategory category) => CategoryDAO.Instance.update(category);
    }
}
