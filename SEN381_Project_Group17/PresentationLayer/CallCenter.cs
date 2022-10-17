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
    public partial class CallCenter : Form
    {
        public CallCenter()
        {
            InitializeComponent();
        }

        int callID = 0;

        call_history_d call = new call_history_d();
        BindingSource callSource = new BindingSource();

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            callSource.DataSource = call.search(int.Parse(textBox1.Text));
            dataGridView1.DataSource = callSource;

            if (callSource.Position >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[callSource.Position];

                textBox2.Text = row.Cells["callCustomerID"].Value.ToString();
                textBox3.Text = row.Cells["callEmployeeID"].Value.ToString();
                textBox4.Text = row.Cells["start"].Value.ToString();
                textBox5.Text = row.Cells["end"].Value.ToString();
                textBox6.Text = row.Cells["dateCreated"].Value.ToString();

                callID = int.Parse(row.Cells["callID"].Value.ToString());
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            call_history_b callObj = new call_history_b(callID, int.Parse(textBox2.Text), int.Parse(textBox3.Text), DateTime.Parse(textBox4.Text), DateTime.Parse(textBox5.Text), DateTime.Parse(textBox6.Text));

            MessageBox.Show(call.update(callObj));
        }
    }
}
