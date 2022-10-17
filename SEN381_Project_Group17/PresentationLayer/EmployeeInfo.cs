using SEN381_Project_Group17.DataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEN381_Project_Group17.PresentationLayer
{
    public partial class EmployeeInfo : Form
    {
        public EmployeeInfo()
        {
            InitializeComponent();
        }

        employee_d employee = new employee_d();
        BindingSource employeeSource = new BindingSource();

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void EmployeeInfo_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login Log = new Login();
            Log.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            employeeSource.DataSource = employee.search(int.Parse(textBox1.Text));
            dataGridView1.DataSource = employeeSource;

            if (employeeSource.Position >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[employeeSource.Position];

                textBox2.Text = row.Cells["employeeID"].Value.ToString();
                textBox3.Text = row.Cells["empName"].Value.ToString();
                textBox4.Text = row.Cells["email"].Value.ToString();
                textBox5.Text = row.Cells["phoneNumber"].Value.ToString();
                textBox6.Text = row.Cells["role"].Value.ToString();
                textBox7.Text = row.Cells["userName"].Value.ToString();
                textBox8.Text = row.Cells["password"].Value.ToString();
            }

        }
    }
}
