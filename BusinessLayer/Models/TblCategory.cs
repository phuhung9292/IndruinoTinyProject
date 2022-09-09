using System;
using System.Collections.Generic;

#nullable disable

namespace BusinessLayer
{
    public partial class TblCategory
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public int? IdModel { get; set; }
        public int? IdPhongBan { get; set; }
        public int? IdUserResponsibility { get; set; }
        public int? Quantity { get; set; }
        public string Dvt { get; set; }

        [System.ComponentModel.Browsable(false)]
        public virtual TblModel IdModelNavigation { get; set; }
        [System.ComponentModel.Browsable(false)]

        public virtual TblPhongBan IdPhongBanNavigation { get; set; }
        [System.ComponentModel.Browsable(false)]

        public virtual TblUser IdUserResponsibilityNavigation { get; set; }
    }
}
