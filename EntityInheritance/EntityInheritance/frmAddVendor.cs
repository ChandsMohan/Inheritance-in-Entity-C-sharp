using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using EntityInheritance_MT;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityInheritance
{
    public partial class frmAddVendor : Form
    {
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------//

        public frmAddVendor()
        {
            InitializeComponent();
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------//

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Vendor oVendor = new Vendor();
            oVendor.Id = 0;
            oVendor.Name = txtName.Text.Trim();
            oVendor.PhoneNo = txtPhoneNo.Text.Trim();
            oVendor.EmailId = txtEmailId.Text.Trim();
            oVendor.CreditPeriod = txtCreditPeriod.Text.Trim();
            oVendor.CreditLimit = Convert.ToDecimal(txtCreditLimited.Text.Trim());
            oVendor.CreatedDtTm = DateTime.Now;
            oVendor.ModifiedDtTm = DateTime.Now;
            long vendorId = oVendor.Save();
            ClearForm();
            if (vendorId > 0)
            {
                MessageBox.Show("Vendor added successfully", "EntityInheritance", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------//

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
