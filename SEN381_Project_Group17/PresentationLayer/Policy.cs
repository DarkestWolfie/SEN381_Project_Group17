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
    public partial class Policy : Form
    {
        public Policy()
        {
            InitializeComponent();
        }

        policy_d policy_d = new policy_d();
        BindingSource policySource = new BindingSource();

        private void Policy_Load(object sender, EventArgs e)
        {
            policySource.DataSource = policy_d.getAll();
            dataGridView1.DataSource = policySource;
        }
    }
}
