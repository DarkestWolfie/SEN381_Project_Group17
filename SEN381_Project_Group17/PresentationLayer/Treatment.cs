﻿using SEN381_Project_Group17.DataLayer;
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
    public partial class Treatment : Form
    {
        public Treatment()
        {
            InitializeComponent();
        }

        treatment_d treatment_d = new treatment_d();
        BindingSource treatmentSource = new BindingSource();

        private void Treatment_Load(object sender, EventArgs e)
        {
            treatmentSource.DataSource = treatment_d.getAll();
            dataGridView1.DataSource = treatmentSource;
        }
    }
}
