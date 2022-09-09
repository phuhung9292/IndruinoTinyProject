using BusinessLayer;
using DataAcess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Respository.PhongBanRepo
{
    public class PhongBanRepository : IPhongBanRepository
    {
        public void savePhongBan(TblPhongBan pb) => PhongBanDAO.Instance.addPhongBan(pb);
    }
}
