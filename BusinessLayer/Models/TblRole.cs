using System;
using System.Collections.Generic;

#nullable disable

namespace BusinessLayer
{
    public partial class TblRole
    {
        public TblRole()
        {
            TblUsers = new HashSet<TblUser>();
        }

        public int Id { get; set; }
        public string TypeRole { get; set; }

        public virtual ICollection<TblUser> TblUsers { get; set; }
    }
}
