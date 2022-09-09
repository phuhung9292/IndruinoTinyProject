using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Respository.CategoryRepo
{
    public interface ICategoryRepository
    {
        IEnumerable<TblCategory> getCategories();
        
        void saveCategory(TblCategory category);

        void deleteCategory(int id);

        void updateCategory(TblCategory category);

        IEnumerable<TblUser> getUsers();
        IEnumerable<TblPhongBan> getPhongBan();

        IEnumerable<TblModel> getModels();
    }
}
