using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityInheritance_MT;
using System.Windows.Forms;

namespace EntityInheritance
{
    public partial class frmAddClient : Form
    {
        public frmAddClient()
        {
            InitializeComponent();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------//

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Client oclient = new Client();
            oclient.Id = 0;
            oclient.Name = txtName.Text.Trim();
            oclient.EmailId = txtEmailId.Text.Trim();
            oclient.PhoneNo = txtPhoneNo.Text.Trim();
            oclient.CreditPeriod = txtCreditPeriod.Text.Trim();
            oclient.CreditLimit = Convert.ToDecimal(txtCreditLimited.Text.Trim());
            oclient.CreatedDtTm = DateTime.Now;
            oclient.ModifiedDtTm = DateTime.Now;
            long ClientId = oclient.Save();
            ClearForm();
            if(ClientId > 0)
            {
                MessageBox.Show("Customer added successfully", "EntityInheritance", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------//

        public void ClearForm()
        {
            txtCreditLimited.Clear();
            txtCreditPeriod.Clear();
            txtEmailId.Clear();
            txtName.Clear();
            txtPhoneNo.Clear();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------//
    }
}
