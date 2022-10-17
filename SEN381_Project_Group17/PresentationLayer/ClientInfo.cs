using SEN381_Project_Group17.BusinessLayer;
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
    public partial class ClientInfo : Form
    {
        public ClientInfo()
        {
            InitializeComponent();
        }

        int customerID = 0;

        customer_d customer = new customer_d();
        BindingSource customerSource = new BindingSource();

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            customerSource.DataSource = customer.search(int.Parse(textBox1.Text));
            dataGridView1.DataSource = customerSource;

            if (customerSource.Position >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[customerSource.Position];

                textBox2.Text = row.Cells["custName"].Value.ToString();
                textBox3.Text = row.Cells["custSurname"].Value.ToString();
                textBox4.Text = row.Cells["dob"].Value.ToString();
                textBox5.Text = row.Cells["idNumber"].Value.ToString();
                textBox6.Text = row.Cells["familyID"].Value.ToString();
                textBox7.Text = row.Cells["familyRole"].Value.ToString();
                textBox8.Text = row.Cells["customerAddressID"].Value.ToString();
                textBox9.Text = row.Cells["gender"].Value.ToString();

                customerID = int.Parse(row.Cells["customerID"].Value.ToString());
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            customer_b customerObj = new customer_b(customerID, int.Parse(textBox6.Text), int.Parse(textBox8.Text), textBox2.Text, textBox3.Text, textBox5.Text, textBox9.Text, textBox7.Text, DateTime.Parse(textBox4.Text));
            MessageBox.Show(customer.update(customerObj));
        }
    }
}
