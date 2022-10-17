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
    public partial class ProviderInfo : Form
    {
        public ProviderInfo()
        {
            InitializeComponent();
        }

        provider_d provider = new provider_d();
        BindingSource providerSource = new BindingSource();

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login Log = new Login();
            this.Hide();
            Log.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            providerSource.DataSource = provider.search(int.Parse(textBox1.Text));
            dataGridView1.DataSource = providerSource;

            if (providerSource.Position >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[providerSource.Position];

                textBox3.Text = row.Cells["providerID"].Value.ToString();
                textBox2.Text = row.Cells["providerName"].Value.ToString();
                //textBox4.Text = row.Cells["status"].Value.ToString();
                textBox4.Text = row.Cells["province"].Value.ToString();
            }
        }
    }
}
