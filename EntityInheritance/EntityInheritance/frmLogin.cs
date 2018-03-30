using EntityInheritance_MT;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityInheritance
{
    public partial class frmLogin : Form
    {
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------//

        public frmLogin()
        {
            InitializeComponent();
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------//

        private void frmLogin_Load(object sender, EventArgs e)
        {
            lblError.Visible = false;
            lblVersion.Text = "Entity Inheritance";
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------//

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Visible = false;
                if (IsValidate())
                {
                    Login user = new Login();
                    user = Login.Authenticate(txtUserName.Text, txtPassword.Text);
                    if (user != null)
                    {
                        frmTask obj = new frmTask();
                        obj.Show();
                        this.Hide();
                    }
                    else
                    {
                        lblError.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "EntityInheritance", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------//

        private bool IsValidate()
        {
            try
            {
                if (txtUserName.Text == String.Empty)
                {
                    return false;
                }
                else if (txtPassword.Text == String.Empty)
                {
                    return false;
                }
                else if (txtUserName.Text == String.Empty && txtPassword.Text == String.Empty)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "DataIntegration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------//
        
    }
}
