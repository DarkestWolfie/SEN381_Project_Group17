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
    public partial class ProductHistory : Form
    {
        public ProductHistory()
        {
            InitializeComponent();
        }

        product_history_d prodHistory_d = new product_history_d();
        BindingSource prodHistorySource = new BindingSource();

        private void ProductHistory_Load(object sender, EventArgs e)
        {
            prodHistorySource.DataSource = prodHistory_d.getAll();
            dataGridView1.DataSource = prodHistorySource;
        }
    }
}
