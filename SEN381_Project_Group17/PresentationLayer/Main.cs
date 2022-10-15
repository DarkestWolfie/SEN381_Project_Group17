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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        customer_d customer = new DataLayer.customer_d();
        BindingSource SourceC = new BindingSource();
        employee_d employee = new DataLayer.employee_d();
        BindingSource SourceE = new BindingSource();

        private void Main_Load(object sender, EventArgs e)
        {
            SourceC.DataSource = customer.getAll();
            SourceE.DataSource = employee.getAll();

            dataGridView1.DataSource = SourceC;
            dataGridView2.DataSource = SourceE;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form address = new Address();
            address.Show();
        }
    }
}
