﻿using System;
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
    public partial class EmployeeInfo : Form
    {
        public EmployeeInfo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void EmployeeInfo_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login Log = new Login();
            Log.Show();
            this.Close();
        }
    }
}
