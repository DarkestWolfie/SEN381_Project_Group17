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

        string customerID;
        int addressID;

        customer_d customer = new customer_d();
        BindingSource customerSource = new BindingSource();

        address_d address = new address_d();
        BindingSource addressSource = new BindingSource();

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            customerSource.DataSource = customer.search(textBox1.Text);
            dataGridView1.DataSource = customerSource;

            if (customerSource.Position >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[customerSource.Position];

                name.Text = row.Cells["custName"].Value.ToString();
                surname.Text = row.Cells["custSurname"].Value.ToString();
                dob.Text = row.Cells["dob"].Value.ToString();
                idNum.Text = row.Cells["idNumber"].Value.ToString();
                familyID.Text = row.Cells["familyID"].Value.ToString();
                familyRole.Text = row.Cells["familyRole"].Value.ToString();
                gender.Text = row.Cells["gender"].Value.ToString();

                customerID = row.Cells["customerID"].Value.ToString();
                addressID = int.Parse(row.Cells["customerAddressID"].Value.ToString());

                addressSource.DataSource = address.search(addressID);
                dataGridView2.Visible = true;
                dataGridView2.DataSource = addressSource;

                if (customerSource.Position >= 0)
                {
                    DataGridViewRow rowAddress = this.dataGridView2.Rows[addressSource.Position];

                    addressLine.Text = rowAddress.Cells["addressLine"].Value.ToString();
                    city.Text = rowAddress.Cells["city"].Value.ToString();
                    province.Text = rowAddress.Cells["province"].Value.ToString();
                    postalCode.Text = rowAddress.Cells["postalCode"].Value.ToString();
                }
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
            customer_b customerObj = new customer_b(customerID, int.Parse(familyID.Text), addressID, name.Text, surname.Text, idNum.Text, gender.Text, familyRole.Text, dob.Text);
            address_b addressObj = new address_b(addressID, addressLine.Text, city.Text, province.Text, postalCode.Text);
            MessageBox.Show(address.update(addressObj));
            MessageBox.Show(customer.update(customerObj));

            customerSource.DataSource = customer.getAll();
            dataGridView1.DataSource = customerSource;

            addressSource.DataSource = address.search(addressID);
            dataGridView2.Visible = true;
            dataGridView2.DataSource = addressSource;
        }

        private void ClientInfo_Load(object sender, EventArgs e)
        {
            customerSource.DataSource = customer.getAll();
            dataGridView1.DataSource = customerSource;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (customerSource.Position >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[customerSource.Position];

                name.Text = row.Cells["custName"].Value.ToString();
                surname.Text = row.Cells["custSurname"].Value.ToString();
                dob.Text = row.Cells["dob"].Value.ToString();
                idNum.Text = row.Cells["idNumber"].Value.ToString();
                familyID.Text = row.Cells["familyID"].Value.ToString();
                familyRole.Text = row.Cells["familyRole"].Value.ToString();
                gender.Text = row.Cells["gender"].Value.ToString();

                customerID = row.Cells["customerID"].Value.ToString();
                addressID = int.Parse(row.Cells["customerAddressID"].Value.ToString());

                addressSource.DataSource = address.search(addressID);
                dataGridView2.Visible = true;
                dataGridView2.DataSource = addressSource;

                if (customerSource.Position >= 0)
                {
                    DataGridViewRow rowAddress = this.dataGridView2.Rows[addressSource.Position];

                    addressLine.Text = rowAddress.Cells["addressLine"].Value.ToString();
                    city.Text = rowAddress.Cells["city"].Value.ToString();
                    province.Text = rowAddress.Cells["province"].Value.ToString();
                    postalCode.Text = rowAddress.Cells["postalCode"].Value.ToString();
                }
            }
        }
    }
}
