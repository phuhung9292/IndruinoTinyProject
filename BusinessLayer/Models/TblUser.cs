using System;
using System.Collections.Generic;

#nullable disable

namespace BusinessLayer
{
    public partial class TblUser
    {
        public TblUser()
        {
            TblCategories = new HashSet<TblCategory>();
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public int? IdRole { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual TblRole IdRoleNavigation { get; set; }
        public virtual ICollection<TblCategory> TblCategories { get; set; }
    }
}
