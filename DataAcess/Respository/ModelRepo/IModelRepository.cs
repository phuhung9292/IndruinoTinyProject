using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Respository.ModelRepo
{
    public interface IModelRepository
    {
        void addModel(TblModel t);
    }
}
