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
    public partial class Condition : Form
    {
        public Condition()
        {
            InitializeComponent();
        }

        condition_d condition_d = new condition_d();
        BindingSource conditionSource = new BindingSource();

        private void Condition_Load(object sender, EventArgs e)
        {
            conditionSource.DataSource = condition_d.getAll();
            dataGridView1.DataSource = conditionSource;
        }
    }
}
