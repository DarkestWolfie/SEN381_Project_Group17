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
    public partial class Address : Form
    {
        public Address()
        {
            InitializeComponent();
        }

        address_d address = new DataLayer.address_d();
        BindingSource SourceA = new BindingSource();

        private void Address_Load(object sender, EventArgs e)
        {
            SourceA.DataSource = address.getAll();
            dataGridView1.DataSource = SourceA;
        }
    }
}
