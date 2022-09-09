using System;
using System.Collections.Generic;

#nullable disable

namespace BusinessLayer
{
    public partial class TblPhongBan
    {
        public TblPhongBan()
        {
            TblCategories = new HashSet<TblCategory>();
        }

        public int Id { get; set; }
        public string TypePhongBan { get; set; }

        public virtual ICollection<TblCategory> TblCategories { get; set; }
    }
}
