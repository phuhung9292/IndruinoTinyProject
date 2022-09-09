using BusinessLayer;
using DataAcess.Respository.ModelRepo;
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
    public partial class frmAddNewModel : Form
    {
        IModelRepository mrepo = new ModelRepository();
        public frmAddNewModel()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var p = new TblModel
            {
                TypeModel = model.Text.ToString(),
            };
            mrepo.addModel(p);
            MessageBox.Show("Thêm mới thành công");
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
