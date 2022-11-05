using SEN381_Project_Group17.BusinessLayer;
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
    public partial class ClaimApplication : Form
    {

        string role;
        //Form Design:
        private int borderRadius = 30;
        private int borderSize = 2;
        private Color borderColor = Color.FromArgb(0, 255, 178);

        //Constructor:
        public ClaimApplication(string role)
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

        application_d application_d = new application_d();
        BindingSource applicationSource = new BindingSource();
        int applicationID;

        private void Application_Load(object sender, EventArgs e)
        {
            applicationSource.DataSource = application_d.getAll();
            dataGridView1.DataSource = applicationSource;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form hub = new UkupholisaHub(role);
            hub.ShowDialog();
            this.Close();
        }

        private void ClaimApplication_MouseDown(object sender, MouseEventArgs e)
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
        private void ClaimApplication_Paint(object sender, PaintEventArgs e)
        {
            FormRegionAndBorder(this, borderRadius, e.Graphics, borderColor, borderSize);
        }

        private void pnlContainer_Paint(object sender, PaintEventArgs e)
        {
            ControlRegionAndBorder(pnlContainer, borderRadius - (borderSize / 2), e.Graphics, borderColor);
        }

        private void ClaimApplication_ResizeEnd(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void ClaimApplication_SizeChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void ClaimApplication_Activated(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void find_Click(object sender, EventArgs e)
        {
            applicationSource.DataSource = application_d.search(int.Parse(search.Text));
            dataGridView1.DataSource = applicationSource;

            if (applicationSource.Position >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[applicationSource.Position];

                string date = row.Cells["applicationDate"].Value.ToString();
                string[] splits = date.Split('-');
                dateTimePicker1.Value = DateTime.Parse(splits[0] + "/" + splits[1] + "/" + splits[2]);
                status.Text = row.Cells["status"].Value.ToString();
                customerID.Text = row.Cells["applicationCustomerID"].Value.ToString();
                conditionID.Text = row.Cells["applicationConditionID"].Value.ToString();
                providerID.Text = row.Cells["applicationProviderID"].Value.ToString();

                applicationID = int.Parse(row.Cells["applicationID"].Value.ToString());

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (applicationSource.Position >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[applicationSource.Position];

                string date = row.Cells["applicationDate"].Value.ToString();
                string[] splits = date.Split('-');
                dateTimePicker1.Value = DateTime.Parse(splits[0] + "/" + splits[1] + "/" + splits[2]);
                status.Text = row.Cells["status"].Value.ToString();
                customerID.Text = row.Cells["applicationCustomerID"].Value.ToString();
                conditionID.Text = row.Cells["applicationConditionID"].Value.ToString();
                providerID.Text = row.Cells["applicationProviderID"].Value.ToString();

                applicationID = int.Parse(row.Cells["applicationID"].Value.ToString());

            }
        }

        private void add_Click(object sender, EventArgs e)
        {
            string date = dateTimePicker1.Value.ToShortDateString();
            string[] dateS = date.Split('/');
            date = dateS[0] + "-" + dateS[1] + "-" + dateS[2];

            application_b applicationObj = new application_b(applicationID, customerID.Text, int.Parse(conditionID.Text), int.Parse(providerID.Text), date, status.Text);

            MessageBox.Show(application_d.add(applicationObj));

            applicationSource.DataSource = application_d.getAll();
            dataGridView1.DataSource = applicationSource;
        }

        private void update_Click(object sender, EventArgs e)
        {
            string date = dateTimePicker1.Value.ToShortDateString();
            string[] dateS = date.Split('/');
            date = dateS[0] + "-" + dateS[1] + "-" + dateS[2];

            application_b applicationObj = new application_b(applicationID, customerID.Text, int.Parse(conditionID.Text), int.Parse(providerID.Text), date, status.Text);

            MessageBox.Show(application_d.update(applicationObj));

            applicationSource.DataSource = application_d.getAll();
            dataGridView1.DataSource = applicationSource;
        }

        private void delete_Click(object sender, EventArgs e)
        {
            MessageBox.Show(application_d.delete(applicationID));

            applicationSource.DataSource = application_d.getAll();
            dataGridView1.DataSource = applicationSource;
        }
    }
}
