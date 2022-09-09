using BusinessLayer;
using DataAcess.Respository.PhongBanRepo;
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
    public partial class frmAddNewPhongBan : Form
    {
        IPhongBanRepository phongban = new PhongBanRepository();

        public frmAddNewPhongBan()
        {
            InitializeComponent();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var p = new TblPhongBan
            {
                TypePhongBan = pb.Text,
            };
            phongban.savePhongBan(p);

            MessageBox.Show("Thêm mới thành công");
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();    
        }
    }
}
