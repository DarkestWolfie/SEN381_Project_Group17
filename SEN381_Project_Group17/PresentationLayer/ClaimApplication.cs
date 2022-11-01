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
    public partial class ClaimApplication : Form
    {
        public ClaimApplication()
        {
            InitializeComponent();
        }

        application_d application_d = new application_d();
        BindingSource applicationSource = new BindingSource();

        private void Application_Load(object sender, EventArgs e)
        {
            applicationSource.DataSource = application_d.getAll();
            dataGridView1.DataSource = applicationSource;
        }
    }
}
