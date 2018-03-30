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
    public partial class frmTask : Form
    {
        //---------------------------------------------------------------------------------------------------------------------------------------//

        public frmTask()
        {
            InitializeComponent();
        }

        //---------------------------------------------------------------------------------------------------------------------------------------//

        private bool CheckForDuplicateForm(Form newForm)
        {
            bool b = false;
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.GetType() == newForm.GetType())
                {
                    frm.Activate();
                    b = true;
                }
            }
            return b;
        }

        //---------------------------------------------------------------------------------------------------------------------------------------//

        private void createEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEmployee frmN = new frmAddEmployee();
            bool frmPresent = CheckForDuplicateForm(frmN);
            if (frmPresent)
                return;
            else if (!frmPresent)
            {
                frmN.MdiParent = this;
                frmN.Show();
            }
        }

        //---------------------------------------------------------------------------------------------------------------------------------------//

        private void addCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddClient obj = new frmAddClient();
            bool frmPresent = CheckForDuplicateForm(obj);
            if (frmPresent)
                return;
            else if (!frmPresent)
            {
                obj.MdiParent = this;
                obj.Show();
            }
        }

        //---------------------------------------------------------------------------------------------------------------------------------------//

        private void addVendorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddVendor obj = new frmAddVendor();
            bool frmPresent = CheckForDuplicateForm(obj);
            if (frmPresent)
                return;
            else if (!frmPresent)
            {
                obj.MdiParent = this;
                obj.Show();
            }
        }

        //---------------------------------------------------------------------------------------------------------------------------------------//

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to exit", "Exit", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        //---------------------------------------------------------------------------------------------------------------------------------------//

        private void frmTask_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Do you want to exit", "Exit", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        //---------------------------------------------------------------------------------------------------------------------------------------//
    }
}
