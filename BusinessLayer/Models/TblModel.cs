using System;
using System.Collections.Generic;

#nullable disable

namespace BusinessLayer
{
    public partial class TblModel
    {
        public TblModel()
        {
            TblCategories = new HashSet<TblCategory>();
        }

        public int Id { get; set; }
        public string TypeModel { get; set; }

        public virtual ICollection<TblCategory> TblCategories { get; set; }
    }
}
