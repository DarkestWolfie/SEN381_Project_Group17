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
    public partial class CustomerAccount : Form
    {
        public CustomerAccount()
        {
            InitializeComponent();
        }

        account_d account_d = new account_d();
        BindingSource accountSource = new BindingSource();

        private void CustomerAccount_Load(object sender, EventArgs e)
        {
            accountSource.DataSource = account_d.getAll();
            dataGridView1.DataSource = accountSource;
        }
    }
}
