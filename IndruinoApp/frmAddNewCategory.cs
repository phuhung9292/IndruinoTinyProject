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
    public partial class frmAddNewCategory : Form
    {
        public frmAddNewCategory()
        {
            InitializeComponent();
        }
        public ICategoryRepository cateRepo{ get; set; }

        public void LoadListUser()
        {
            try
            {
                var uList = cateRepo.getUsers();
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
                var PList = cateRepo.getPhongBan();
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
                var MList = cateRepo.getModels();
                model.DataSource = MList;
                model.ValueMember = "Id";
                model.DisplayMember = "TypeModel";

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
       
                try
                {
                    var newCate = new TblCategory
                    {
                        CategoryName = name.Text,
                        IdModel = int.Parse(model.SelectedIndex.ToString())+1,
                        IdPhongBan = int.Parse(pb.SelectedIndex.ToString()) + 1,
                        IdUserResponsibility = int.Parse(user.SelectedIndex.ToString()) + 1,
                        Quantity = int.Parse(quantity.Text),
                        Dvt = dvt.Text,
                    };
                    cateRepo.saveCategory(newCate);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("thêm mới thất bại ");
                }
           
            MessageBox.Show("Thêm mới thành công");
            Close();

        }

        private void frmAddNewCategory_Load(object sender, EventArgs e)
        {
            LoadListModel();
            LoadListUser();
            LoadPhongBanList();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAddNewPhongBan frmAddNewPhongBan = new frmAddNewPhongBan();
            if(frmAddNewPhongBan.ShowDialog() == DialogResult.OK)
            {
                LoadPhongBanList();
            }
            LoadPhongBanList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmAddUser frmAddUser = new frmAddUser();
            if(frmAddUser.ShowDialog() == DialogResult.OK)
            {
                LoadListUser();
            }
            LoadListUser();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmAddNewModel frmAddNewModel = new frmAddNewModel();
            if( frmAddNewModel.ShowDialog() == DialogResult.OK)
            {
                LoadListModel();
            }
            LoadListModel();

        }
    }
}
