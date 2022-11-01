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
    public partial class Product : Form
    {
        public Product()
        {
            InitializeComponent();
        }

        product_d product_d = new product_d();
        BindingSource productSource = new BindingSource();

        private void Product_Load(object sender, EventArgs e)
        {
            productSource.DataSource = product_d.getAll();
            dataGridView1.DataSource = productSource;
        }
    }
}
