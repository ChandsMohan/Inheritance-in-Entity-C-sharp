using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityInheritance
{
    public partial class frmStartScreen : Form
    {
        public frmStartScreen()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int count;
            for (count = 0; count <= 5; count++)
            {
                progressBar1.Value = count;
            }
            timer1.Enabled = false;
            this.Visible = false;

            frmLogin obj = new frmLogin();
            obj.Show();
            this.Hide();
        }
    }
}
