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
    public partial class ClientInfo : Form
    {

        string role;

        //Form Design:
        private int borderRadius = 30;
        private int borderSize = 2;
        private Color borderColor = Color.FromArgb(0, 255, 178);

        //Constructor
        public ClientInfo(string role)
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

        string customerID;
        int addressID;

        customer_b customer_b = new customer_b();

        customer_d customer_d = new customer_d();
        BindingSource customerSource = new BindingSource();

        address_d address_d = new address_d();
        BindingSource addressSource = new BindingSource();

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form hub = new UkupholisaHub(role);
            hub.ShowDialog();
            this.Close();
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
            if (validation.clientInfoVal(name.Text, surname.Text, customerID, familyID.Text, familyRole.Text, gender.Text, addressLine.Text, city.Text, province.Text, postalCode.Text))
            {
                string date = dateTimePicker1.Value.ToShortDateString();
                string[] dateS = date.Split('/');
                date = dateS[0] + "-" + dateS[1] + "-" + dateS[2];

                customer_b customerObj = new customer_b(customerID, int.Parse(familyID.Text), addressID, name.Text, surname.Text, idNum.Text, gender.Text, familyRole.Text, date);
                address_b addressObj = new address_b(addressID, addressLine.Text, city.Text, province.Text, postalCode.Text);

                MessageBox.Show(customer_d.update(customerObj) + "\n\n" + address_d.update(addressObj));

                customerSource.DataSource = customer_d.getAll();
                dataGridView1.DataSource = customerSource;

                addressSource.DataSource = address_d.search(addressID);
                dataGridView2.Visible = true;
                dataGridView2.DataSource = addressSource;
            }
            else
            {
                MessageBox.Show("Please enter values in all the vields");
            }
        }

        private void ClientInfo_Load(object sender, EventArgs e)
        {
            customerSource.DataSource = customer_d.getAll();
            dataGridView1.DataSource = customerSource;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (customerSource.Position >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[customerSource.Position];

                name.Text = row.Cells["custName"].Value.ToString();
                surname.Text = row.Cells["custSurname"].Value.ToString();
                string date = row.Cells["dob"].Value.ToString();
                string[] splits = date.Split('-');
                dateTimePicker1.Value = DateTime.Parse(splits[0] + "/" + splits[1] + "/" + splits[2]);
                idNum.Text = row.Cells["idNumber"].Value.ToString();
                familyID.Text = row.Cells["familyID"].Value.ToString();
                familyRole.Text = row.Cells["familyRole"].Value.ToString();
                gender.Text = row.Cells["gender"].Value.ToString();

                customerID = row.Cells["customerID"].Value.ToString();
                addressID = int.Parse(row.Cells["customerAddressID"].Value.ToString());

                addressSource.DataSource = address_d.search(addressID);
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

        validation validation = new validation();

        private void add_Click(object sender, EventArgs e)
        {
            if (validation.clientInfoVal(name.Text, surname.Text, customerID, familyID.Text, familyRole.Text, gender.Text, addressLine.Text, city.Text, province.Text, postalCode.Text))
            {
                int newAddressID = address_d.getCount();
                string newCustomerID = customer_b.GenerateID(surname.Text);

                string date = dateTimePicker1.Value.ToShortDateString();
                string[] dateS = date.Split('/');
                date = dateS[0] + "-" + dateS[1] + "-" + dateS[2];

                address_b addressAdd = new address_b(addressLine.Text, city.Text, province.Text, postalCode.Text);
                customer_b customerAdd = new customer_b(newCustomerID, int.Parse(familyID.Text), newAddressID, name.Text, surname.Text, idNum.Text, gender.Text, familyRole.Text, date);

                MessageBox.Show(address_d.add(addressAdd) + "\n\n" + customer_d.add(customerAdd));

                customerSource.DataSource = customer_d.getAll();
                dataGridView1.DataSource = customerSource;

                addressSource.DataSource = address_d.search(newAddressID);
                dataGridView2.Visible = true;
                dataGridView2.DataSource = addressSource;
            }
            else
            {
                MessageBox.Show("Please enter values in all the vields");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            customerSource.DataSource = customer_d.search(search.Text);
            dataGridView1.DataSource = customerSource;

            if (customerSource.Position >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[customerSource.Position];

                name.Text = row.Cells["custName"].Value.ToString();
                surname.Text = row.Cells["custSurname"].Value.ToString();
                string date = row.Cells["dob"].Value.ToString();
                string[] splits = date.Split('-');
                dateTimePicker1.Value = DateTime.Parse(splits[0] + "/" + splits[1] + "/" + splits[2]);
                idNum.Text = row.Cells["idNumber"].Value.ToString();
                familyID.Text = row.Cells["familyID"].Value.ToString();
                familyRole.Text = row.Cells["familyRole"].Value.ToString();
                gender.Text = row.Cells["gender"].Value.ToString();

                customerID = row.Cells["customerID"].Value.ToString();
                addressID = int.Parse(row.Cells["customerAddressID"].Value.ToString());

                addressSource.DataSource = address_d.search(addressID);
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

        private void delete_Click(object sender, EventArgs e)
        {
            MessageBox.Show(customer_d.delete(customerID));

            customerSource.DataSource = customer_d.getAll();
            dataGridView1.DataSource = customerSource;
            dataGridView2.Visible = true;
            dataGridView2.DataSource = addressSource;
        }
    }
}
