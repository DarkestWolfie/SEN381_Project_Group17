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
    public partial class UkupholisaHub : Form
    {
        
        public UkupholisaHub()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CallCenter CC = new CallCenter();
            CC.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ClientInfo CI = new ClientInfo();
            CI.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            EmployeeInfo EI = new EmployeeInfo();
            EI.Show();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ProviderInfo PI = new ProviderInfo();
            PI.Show();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Address Ad = new Address();
            Ad.Show();
            this.Close();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Main Ma = new Main();
            Ma.Show();
            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login Log = new Login();
            Log.Show();
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void UkupholisaHub_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
