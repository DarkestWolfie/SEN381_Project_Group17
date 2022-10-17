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
        }
    }
}
