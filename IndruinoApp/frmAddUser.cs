using BusinessLayer;
using DataAcess.Respository.UserRepo;
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
    public partial class frmAddUser : Form
    {
        IUserRepository urepo = new UserRepository();
        public frmAddUser()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var p = new TblUser
            {
                IdRole = 1,
                Email = "Indruino@gmail.com",
                Password = "123",
                FullName = user.Text.ToString(),
            };
            urepo.addNewUser(p);
            MessageBox.Show("Thêm mới thành công");
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
