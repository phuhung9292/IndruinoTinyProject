using BusinessLayer;
using DataAcess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Respository.ModelRepo
{
    public class ModelRepository : IModelRepository
    {
        public void addModel(TblModel t) => ModelDAO.Instance.addModel(t);
    }
}
