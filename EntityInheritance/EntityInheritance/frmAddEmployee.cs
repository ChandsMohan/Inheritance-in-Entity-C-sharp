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
    public partial class frmAddEmployee : Form
    {
        public frmAddEmployee()
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------------------------------------//

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Employee oEmployee = new Employee();
            oEmployee.Id = 0;
            oEmployee.Name = txtName.Text.Trim();
            oEmployee.EmailId = txtEmailId.Text.Trim();
            oEmployee.PhoneNo = txtPhoneNo.Text.Trim();
            oEmployee.Salary = Convert.ToDecimal(txtSalary.Text);
            oEmployee.CreatedDtTm = DateTime.Now;
            oEmployee.ModifiedDtTm = DateTime.Now;
            long EmployeeId = oEmployee.Save();
            ClearForm();
            if (EmployeeId > 0)
            {
                MessageBox.Show("Employee added successfully", "EntityInheritance", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //------------------------------------------------------------------------------------------------------------------------------------------------------//

        public void ClearForm()
        {
            txtSalary.Clear();
            txtEmailId.Clear();
            txtName.Clear();
            txtPhoneNo.Clear();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------//
    }
}
