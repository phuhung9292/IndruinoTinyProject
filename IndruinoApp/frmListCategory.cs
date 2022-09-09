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
    public partial class frmListCategory : Form
    {
        ICategoryRepository cateRepo = new CategoryRepository();
        public frmListCategory()
        {
            InitializeComponent();
        }
        BindingSource source;

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
        public void LoadListFilterUser()
        {
            try
            {
                var uList = cateRepo.getUsers();
                filterUser.DataSource = uList;
                filterUser.ValueMember = "Id";
                filterUser.DisplayMember = "FullName";
                //filterUser.SelectedIndex = -1;
            }catch (Exception ex)
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
        public void LoadListCategory()
        {
            var list = cateRepo.getCategories();
            BindingSource source = new BindingSource();
            source.DataSource = list;

            name.DataBindings.Clear();
            model.DataBindings.Clear();
            pb.DataBindings.Clear();
            user.DataBindings.Clear();
            quantity.DataBindings.Clear();
            dvt.DataBindings.Clear();

            name.DataBindings.Add("Text", source, "CategoryName");
            model.DataBindings.Add("SelectedValue", source, "IdModel");
            pb.DataBindings.Add("SelectedValue", source, "IdPhongBan");
            user.DataBindings.Add("SelectedValue", source, "IdUserResponsibility");
            quantity.DataBindings.Add("Text", source, "Quantity");
            dvt.DataBindings.Add("Text", source, "Dvt");

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = source;
        }


        private void frmListCategory_Load(object sender, EventArgs e)
        {
            LoadListUser();
            LoadListCategory();
            LoadPhongBanList();
            LoadListModel();
            user.Enabled = false;
            model.Enabled = false;
            pb.Enabled = false;
            quantity.Enabled = false;
            dvt.Enabled = false;
            name.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAddNewCategory frmAddNewCategory = new frmAddNewCategory
            {
                cateRepo = cateRepo,
            };
            if(frmAddNewCategory.ShowDialog()== DialogResult.OK)
            {
                LoadListUser();
                LoadListCategory();
                LoadPhongBanList();
                LoadListModel();
            }
            LoadListUser();
            LoadListCategory();
            LoadPhongBanList();
            LoadListModel();
        }

       

        private void filterUser_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            LoadListCategory();
            dynamic value;
            int? check =-1;
            try
            {
                value = cb.SelectedIndex.ToString();
                check =int.Parse(value)+1;
                List<TblCategory> listCate = (List<TblCategory>)cateRepo.getCategories();
                if (check!=-1)
                {
                    List<TblCategory> tmpl = new List<TblCategory>();
                    var list = cateRepo.getCategories();
                    for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
                    {
                        //int a = int.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString());

                        if (int.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString()) == check)
                        {
                            tmpl.Add(listCate[i]);   
                        }
                    }
                    
                    dataGridView1.DataSource = tmpl;

                }
                else
                {
                    dataGridView1.DataSource = listCate;

                }
            }catch (Exception ex)
            {
                throw ex;
            }
        }

        private void filterUser_Click(object sender, EventArgs e)
        {
            LoadListFilterUser();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            frmCategoryDetail frmCategoryDetail = new frmCategoryDetail
            {
                CategoryDetail = new TblCategory
                {
                    Id = int.Parse(row.Cells[0].Value.ToString()),
                    CategoryName = row.Cells[1].Value.ToString(),
                    IdModel = int.Parse(row.Cells[2].Value.ToString()),
                    IdPhongBan = int.Parse(row.Cells[3].Value.ToString()),
                    IdUserResponsibility = int.Parse(row.Cells[4].Value.ToString()),
                    Quantity = int.Parse(row.Cells[5].Value.ToString()),
                    Dvt = row.Cells[6].Value.ToString(),
                },
                cate = cateRepo,
            

            };
            if(frmCategoryDetail.ShowDialog() == DialogResult.OK)
            {
                LoadListCategory();
            }
            LoadListCategory();

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            string value = textBox7.Text;
            List<TblCategory> list = (List<TblCategory>)cateRepo.getCategories();
            if (!String.IsNullOrEmpty(value))
            {
                LoadListCategory();
                List<TblCategory> list2 = new List<TblCategory>();
                foreach(TblCategory category in list)
                {
                    if (category.CategoryName.ToString().ToLower().Contains(value.ToLower()))
                    {
                        list2.Add(category);
                    }
                }
                dataGridView1.DataSource = list2;
            }
            else
            {
                LoadListCategory();
            }
        }
    }   
}
