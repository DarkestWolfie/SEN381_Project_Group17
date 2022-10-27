﻿using SEN381_Project_Group17.BusinessLayer;
using SEN381_Project_Group17.DataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEN381_Project_Group17.PresentationLayer
{
    public partial class ClientInfo : Form
    {
        //Form Design:
        private int borderRadius = 30;
        private int borderSize = 2;
        private Color borderColor = Color.Goldenrod;

        //Constructor
        public ClientInfo()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(borderSize);
            this.pnlTitle.BackColor = borderColor;
            this.BackColor = borderColor;
        }

        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style |= 0x20000; // <--- Minimize the form from the task bar
                return cp;
            }
        }

        //Private Methods
        private GraphicsPath GetRoundedPath(Rectangle rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            float curveSize = radius * 2F;
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
            path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
            path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
            path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
            path.CloseFigure();
            return path;
        }

        private void FormRegionAndBorder(Form form, float radius, Graphics graph, Color borderColor, float borderSize)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                using (GraphicsPath roundPath = GetRoundedPath(form.ClientRectangle, radius))
                using (Pen penBorder = new Pen(borderColor, borderSize))
                using (Matrix transform = new Matrix())
                {
                    graph.SmoothingMode = SmoothingMode.AntiAlias;
                    form.Region = new Region(roundPath);
                    if (borderSize >= 1)
                    {
                        Rectangle rect = form.ClientRectangle;
                        float scaleX = 1.0F - ((borderSize + 1) / rect.Width);
                        float scaleY = 1.0F - ((borderSize + 1) / rect.Height);
                        transform.Scale(scaleX, scaleY);
                        transform.Translate(borderSize / 1.6F, borderSize / 1.6F);
                        graph.Transform = transform;
                        graph.DrawPath(penBorder, roundPath);
                    }
                }
            }
        }

        private void ControlRegionAndBorder(Control control, float radius, Graphics graph, Color borderColor)
        {
            using (GraphicsPath roundPath = GetRoundedPath(control.ClientRectangle, radius))
            using (Pen penBorder = new Pen(borderColor, 1))
            {
                graph.SmoothingMode = SmoothingMode.AntiAlias;
                control.Region = new Region(roundPath);
                graph.DrawPath(penBorder, roundPath);
            }
        }

        string customerID;
        int addressID;

        customer_d customer = new customer_d();
        BindingSource customerSource = new BindingSource();

        address_d address = new address_d();
        BindingSource addressSource = new BindingSource();

        private void button1_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            this.Hide();
            Form hub = new UkupholisaHub();
            hub.ShowDialog();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            customerSource.DataSource = customer.search(textBox1.Text);
            dataGridView1.DataSource = customerSource;

            if (customerSource.Position >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[customerSource.Position];

                name.Text = row.Cells["custName"].Value.ToString();
                surname.Text = row.Cells["custSurname"].Value.ToString();
                dob.Text = row.Cells["dob"].Value.ToString();
                idNum.Text = row.Cells["idNumber"].Value.ToString();
                familyID.Text = row.Cells["familyID"].Value.ToString();
                familyRole.Text = row.Cells["familyRole"].Value.ToString();
                gender.Text = row.Cells["gender"].Value.ToString();

                customerID = row.Cells["customerID"].Value.ToString();
                addressID = int.Parse(row.Cells["customerAddressID"].Value.ToString());

                addressSource.DataSource = address.search(addressID);
                dataGridView2.Visible = true;
                dataGridView2.DataSource = addressSource;

                if (customerSource.Position >= 0)
                {
                    DataGridViewRow rowAddress = this.dataGridView2.Rows[addressSource.Position];

                    addressLine.Text = rowAddress.Cells["addressLine"].Value.ToString();
                    city.Text = rowAddress.Cells["city"].Value.ToString();
                    province.Text = rowAddress.Cells["province"].Value.ToString();
                    postalCode.Text = rowAddress.Cells["postalCode"].Value.ToString();
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            customer_b customerObj = new customer_b(customerID, int.Parse(familyID.Text), addressID, name.Text, surname.Text, idNum.Text, gender.Text, familyRole.Text, dob.Text);
            address_b addressObj = new address_b(addressID, addressLine.Text, city.Text, province.Text, postalCode.Text);

            MessageBox.Show(customer.update(customerObj) + "\n\n" + address.update(addressObj));

            customerSource.DataSource = customer.getAll();
            dataGridView1.DataSource = customerSource;

            addressSource.DataSource = address.search(addressID);
            dataGridView2.Visible = true;
            dataGridView2.DataSource = addressSource;
        }

        private void ClientInfo_Load(object sender, EventArgs e)
        {
            customerSource.DataSource = customer.getAll();
            dataGridView1.DataSource = customerSource;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (customerSource.Position >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[customerSource.Position];

                name.Text = row.Cells["custName"].Value.ToString();
                surname.Text = row.Cells["custSurname"].Value.ToString();
                dob.Text = row.Cells["dob"].Value.ToString();
                idNum.Text = row.Cells["idNumber"].Value.ToString();
                familyID.Text = row.Cells["familyID"].Value.ToString();
                familyRole.Text = row.Cells["familyRole"].Value.ToString();
                gender.Text = row.Cells["gender"].Value.ToString();

                customerID = row.Cells["customerID"].Value.ToString();
                addressID = int.Parse(row.Cells["customerAddressID"].Value.ToString());

                addressSource.DataSource = address.search(addressID);
                dataGridView2.Visible = true;
                dataGridView2.DataSource = addressSource;

                if (customerSource.Position >= 0)
                {
                    DataGridViewRow rowAddress = this.dataGridView2.Rows[addressSource.Position];

                    addressLine.Text = rowAddress.Cells["addressLine"].Value.ToString();
                    city.Text = rowAddress.Cells["city"].Value.ToString();
                    province.Text = rowAddress.Cells["province"].Value.ToString();
                    postalCode.Text = rowAddress.Cells["postalCode"].Value.ToString();
                }
            }
        }

        private void ClientInfo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pnlTitle_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void DrawPath(Rectangle rect, Graphics graph, Color color)
        {
            using (GraphicsPath roundPath = GetRoundedPath(rect, borderRadius))
            using (Pen penBorder = new Pen(color, 3))
            {
                graph.DrawPath(penBorder, roundPath);
            }
        }
        private struct FormBoundsColors
        {
            public Color TopLeftColor;
            public Color TopRightColor;
            public Color BottomLeftColor;
            public Color BottomRightColor;
        }
        private FormBoundsColors GetFormBoundsColors()
        {
            var fbColor = new FormBoundsColors();
            using (var bmp = new Bitmap(1, 1))
            using (Graphics graph = Graphics.FromImage(bmp))
            {
                Rectangle rectBmp = new Rectangle(0, 0, 1, 1);
                //Top Left
                rectBmp.X = this.Bounds.X - 1;
                rectBmp.Y = this.Bounds.Y;
                graph.CopyFromScreen(rectBmp.Location, Point.Empty, rectBmp.Size);
                fbColor.TopLeftColor = bmp.GetPixel(0, 0);
                //Top Right
                rectBmp.X = this.Bounds.Right;
                rectBmp.Y = this.Bounds.Y;
                graph.CopyFromScreen(rectBmp.Location, Point.Empty, rectBmp.Size);
                fbColor.TopRightColor = bmp.GetPixel(0, 0);
                //Bottom Left
                rectBmp.X = this.Bounds.X;
                rectBmp.Y = this.Bounds.Bottom;
                graph.CopyFromScreen(rectBmp.Location, Point.Empty, rectBmp.Size);
                fbColor.BottomLeftColor = bmp.GetPixel(0, 0);
                //Bottom Right
                rectBmp.X = this.Bounds.Right;
                rectBmp.Y = this.Bounds.Bottom;
                graph.CopyFromScreen(rectBmp.Location, Point.Empty, rectBmp.Size);
                fbColor.BottomRightColor = bmp.GetPixel(0, 0);
            }
            return fbColor;
        }
        //Event Methods
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);

            //Smoothing the outer borders
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rectForm = this.ClientRectangle;
            int mWidth = rectForm.Width / 2;
            int mHeight = rectForm.Height / 2;
            var fbColors = GetFormBoundsColors();

            //Top Left
            DrawPath(rectForm, e.Graphics, fbColors.TopLeftColor);

            //Top Right
            Rectangle rectTopRight = new Rectangle(mWidth, rectForm.Y, mWidth, mHeight);
            DrawPath(rectTopRight, e.Graphics, fbColors.TopRightColor);

            //Bottom Left
            Rectangle rectBottomLeft = new Rectangle(rectForm.X, rectForm.X + mHeight, mWidth, mHeight);
            DrawPath(rectBottomLeft, e.Graphics, fbColors.BottomLeftColor);

            //Bottom Right
            Rectangle rectBottomRight = new Rectangle(mWidth, rectForm.Y + mHeight, mWidth, mHeight);
            DrawPath(rectBottomRight, e.Graphics, fbColors.BottomRightColor);
        }

        private void ClientInfo_Paint(object sender, PaintEventArgs e)
        {
            FormRegionAndBorder(this, borderRadius, e.Graphics, borderColor, borderSize);
        }

        private void pnlContainer_Paint(object sender, PaintEventArgs e)
        {
            ControlRegionAndBorder(pnlContainer, borderRadius - (borderSize / 2), e.Graphics, borderColor);
        }

        private void ClientInfo_ResizeEnd(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void ClientInfo_SizeChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void ClientInfo_Activated(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void add_Click(object sender, EventArgs e)
        {
            int newAddressID = address.getCount();
            string newCustomerID = "D00000002";
            
            address_b addressAdd = new address_b(addressLine.Text, city.Text, province.Text, postalCode.Text);
            customer_b customerAdd = new customer_b(newCustomerID, int.Parse(familyID.Text), newAddressID, name.Text, surname.Text, idNum.Text, gender.Text, familyRole.Text, dob.Text);

            //MessageBox.Show(customer.update(customerObj) + "\n\n" + address.update(addressObj));

            //customerSource.DataSource = customer.getAll();
            //dataGridView1.DataSource = customerSource;

            //addressSource.DataSource = address.search(addressID);
            //dataGridView2.Visible = true;
            //dataGridView2.DataSource = addressSource;
        }
    }
}
