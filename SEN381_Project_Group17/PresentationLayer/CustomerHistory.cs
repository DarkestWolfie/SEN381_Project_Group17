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
    public partial class CustomerHistory : Form
    {
        public CustomerHistory()
        {
            InitializeComponent();
        }

        customer_history_d cusHistory_d = new customer_history_d();
        BindingSource cusHistorySource = new BindingSource();

        private void CustomerHistory_Load(object sender, EventArgs e)
        {
            cusHistorySource.DataSource = cusHistory_d.getAll();
            dataGridView1.DataSource = cusHistorySource;
        }
    }
}
