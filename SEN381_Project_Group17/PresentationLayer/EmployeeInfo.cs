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
    public partial class EmployeeInfo : Form
    {
        string role;

        //Form Design:
        private int borderRadius = 30;
        private int borderSize = 2;
        private Color borderColor = Color.FromArgb(0, 255, 178);

        //Constructor
        public EmployeeInfo(string role)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(borderSize);
            this.pnlTitle.BackColor = borderColor;
            this.BackColor = borderColor;

            this.role = role;
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

        int employeeID = 0;

        employee_d employee = new employee_d();
        BindingSource employeeSource = new BindingSource();

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form hub = new UkupholisaHub(role);
            hub.ShowDialog();
            this.Close();
        }

        private void EmployeeInfo_Load(object sender, EventArgs e)
        {
            employeeSource.DataSource = employee.getAll();
            dataGridView1.DataSource = employeeSource;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login Log = new Login();
            Log.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (search.Text == "")
            {
                employeeSource.DataSource = employee.getAll();
                dataGridView1.DataSource = employeeSource;
            }
            else
            {
                employeeSource.DataSource = employee.search(int.Parse(search.Text));
                dataGridView1.DataSource = employeeSource;

                if (employeeSource.Position >= 0)
                {
                    DataGridViewRow row = this.dataGridView1.Rows[employeeSource.Position];

                    name.Text = row.Cells["empName"].Value.ToString();
                    email.Text = row.Cells["email"].Value.ToString();
                    number.Text = row.Cells["phoneNumber"].Value.ToString();
                    empRole.Text = row.Cells["role"].Value.ToString();
                    userName.Text = row.Cells["userName"].Value.ToString();
                    password.Text = row.Cells["password"].Value.ToString();

                    employeeID = int.Parse(row.Cells["employeeID"].Value.ToString());
                }
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (employeeSource.Position >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[employeeSource.Position];

                name.Text = row.Cells["empName"].Value.ToString();
                email.Text = row.Cells["email"].Value.ToString();
                number.Text = row.Cells["phoneNumber"].Value.ToString();
                empRole.Text = row.Cells["role"].Value.ToString();
                userName.Text = row.Cells["userName"].Value.ToString();
                password.Text = row.Cells["password"].Value.ToString();

                employeeID = int.Parse(row.Cells["employeeID"].Value.ToString());
            }
        }

        private void EmployeeInfo_MouseDown(object sender, MouseEventArgs e)
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

        private void EmployeeInfo_Paint(object sender, PaintEventArgs e)
        {
            FormRegionAndBorder(this, borderRadius, e.Graphics, borderColor, borderSize);
        }

        private void pnlContainer_Paint(object sender, PaintEventArgs e)
        {
            ControlRegionAndBorder(pnlContainer, borderRadius - (borderSize / 2), e.Graphics, borderColor);
        }

        private void EmployeeInfo_ResizeEnd(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void EmployeeInfo_SizeChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void EmployeeInfo_Activated(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void update_Click(object sender, EventArgs e)
        {
            if (validation.empInfoVal(name.Text, email.Text, number.Text, empRole.Text, userName.Text, password.Text))
            {
                if (employeeID == 0)
                {
                    MessageBox.Show("Please select the record that you would like to update first");
                }
                else
                {
                    employee_b employeeObj = new employee_b(employeeID, name.Text, email.Text, number.Text, empRole.Text, userName.Text, password.Text);
                    MessageBox.Show(employee.update(employeeObj));

                    employeeSource.DataSource = employee.getAll();
                    dataGridView1.DataSource = employeeSource;
                }
            }
            else
            {
                MessageBox.Show("Please enter values in all the vields");
            }
        }

        validation validation = new validation();

        private void add_Click(object sender, EventArgs e)
        {
            if (validation.empInfoVal(name.Text, email.Text, number.Text, empRole.Text, userName.Text, password.Text))
            {
                employee_b employeeObj = new employee_b(employeeID, name.Text, email.Text, number.Text, empRole.Text, userName.Text, password.Text);
                MessageBox.Show(employee.add(employeeObj));

                employeeSource.DataSource = employee.getAll();
                dataGridView1.DataSource = employeeSource;
            }
            else
            {
                MessageBox.Show("Please enter values in all the vields");
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            MessageBox.Show(employee.delete(employeeID));

            employeeSource.DataSource = employee.getAll();
            dataGridView1.DataSource = employeeSource;
        }
    }
}
