using BusinessLayer;
using DataAcess.Respository.CategoryRepo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IndruinoApp
{
    public partial class frmCategoryDetail : Form
    {
        public TblCategory CategoryDetail { get; set; }
        public ICategoryRepository cate { get; set; }
        public frmCategoryDetail()
        {
            InitializeComponent();
        }
        public void LoadListUser()
        {
            try
            {
                var uList = cate.getUsers();
                user.DataSource = uList;
                user.ValueMember = "Id";
                user.DisplayMember = "FullName";

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
        private void LoadPhongBanList()
        {
            try
            {
                var PList = cate.getPhongBan();
                pb.DataSource = PList;
                pb.ValueMember = "Id";
                pb.DisplayMember = "TypePhongBan";

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void LoadListModel()
        {
            try
            {
                var MList = cate.getModels();
                model.DataSource = MList;
                model.ValueMember = "Id";
                model.DisplayMember = "TypeModel";

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void frmCategoryDetail_Load(object sender, EventArgs e)
        {
            LoadListModel();
            LoadListUser(); 
            LoadPhongBanList();
            id.Text =CategoryDetail.Id.ToString();
            name.Text=CategoryDetail.CategoryName.ToString();
            model.SelectedIndex = int.Parse(CategoryDetail.IdModel.ToString())-1;
            pb.SelectedIndex = int.Parse(CategoryDetail.IdPhongBan.ToString())-1;
            user.SelectedIndex=int.Parse(CategoryDetail.IdUserResponsibility.ToString())-1;
            quantity.Text=CategoryDetail.Quantity.ToString();
            dvt.Text=CategoryDetail.Dvt.ToString();
            id.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var c = new TblCategory
            {
                Id = int.Parse(id.Text),
                CategoryName = name.Text,
                IdModel = int.Parse(model.SelectedIndex.ToString()) + 1,
                IdPhongBan = int.Parse(pb.SelectedIndex.ToString()) + 1,
                IdUserResponsibility = int.Parse(user.SelectedIndex.ToString()) + 1,
                Quantity = int.Parse(quantity.Text),
                Dvt = dvt.Text,
            };
            cate.updateCategory(c);
            MessageBox.Show("Sửa thành công");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult d;
            d = MessageBox.Show("Xóa ?", "quanli", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (d == DialogResult.OK)
            {
                var p = new TblCategory
                {
                    Id = int.Parse(id.Text)
                };
                cate.deleteCategory(p.Id);
                MessageBox.Show("xóa thành công");
                Close();
            }
        }
    }
}
