using SEN381_Project_Group17.BusinessLayer;
using SEN381_Project_Group17.DataLayer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SEN381_Project_Group17.PresentationLayer
{
    public partial class CallCenter : Form
    {
        string[] durationTime = {"00", "00", "00"};
        string role;
        int id;

        //Form Design:
        private int borderRadius = 30;
        private int borderSize = 2;
        private Color borderColor = Color.FromArgb(0, 255, 178);

        //Constructor
        public CallCenter(string role, int empNumber)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(borderSize);
            this.pnlTitle.BackColor = borderColor;
            this.BackColor = borderColor;

            this.role = role;
            this.id = empNumber;
        }

        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private static extern void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private static extern void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
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

        int callID = 0;

        call_history_d call = new call_history_d();
        BindingSource callSource = new BindingSource();
        customer_d cust = new customer_d();
        BindingSource custSource = new BindingSource();

        private void button1_Click(object sender, EventArgs e)
        {
            if (role == "Call Agent")
            {
                this.Hide();
                Login hub = new Login();
                hub.ShowDialog();
                this.Close();
            }
            else
            {
                this.Hide();
                Form hub = new UkupholisaHub(role, id);
                hub.ShowDialog();
                this.Close();
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            callSource.DataSource = call.search(int.Parse(textBox1.Text));
            dataGridView1.DataSource = callSource;

            if (callSource.Position >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[callSource.Position];

                customerID.Text = row.Cells["callCustomerID"].Value.ToString();
                employeeID.Text = row.Cells["callEmployeeID"].Value.ToString();
                start.Text = row.Cells["start"].Value.ToString();
                end.Text = row.Cells["end"].Value.ToString();
                duration.Text = row.Cells["duration"].Value.ToString();
                string date = row.Cells["dateCreated"].Value.ToString();
                string[] splits = date.Split('-');
                dateCreated.Value = DateTime.Parse(splits[0] + "/" + splits[1] + "/" + splits[2]);


                callID = int.Parse(row.Cells["callID"].Value.ToString());
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (validation.callVal(customerID.Text, employeeID.Text, start.Text, end.Text, dateCreated.Text, duration.Text))
            {
                if (callID == 0)
                {
                    MessageBox.Show("Please select the record that you would like to update first");
                }
                else
                {
                    string date = dateCreated.Value.ToShortDateString();
                    string[] dateS = date.Split('/');
                    date = dateS[0] + "-" + dateS[1] + "-" + dateS[2];

                    call_history_b callObj = new call_history_b(callID, customerID.Text, int.Parse(employeeID.Text), start.Text, end.Text, date, duration.Text);

                    MessageBox.Show(call.update(callObj));

                    callSource.DataSource = call.getAll();
                    dataGridView1.DataSource = callSource;
                }
            }
            else
            {
                MessageBox.Show("Please enter values in all the vields");
            }
            
        }

        validation validation = new validation();

        private void CallCenter_Load(object sender, EventArgs e)
        {
            List<customer_b> list = validation.populateCustomer();

            foreach (customer_b item in list)
            {
                customerID.Items.Add(item.CustomerID);
            }

            List<employee_b> list2 = validation.populateEmployee();

            foreach (employee_b item in list2)
            {
                employeeID.Items.Add(item.EmployeeID);
            }

            start.Text = "00:00:00";
            end.Text = "00:00:00";
            duration.Text = "00:00:00";
            dateCreated.Text = DateTime.Now.ToShortDateString();
            employeeID.Text = id.ToString();

            if (role != "Admin")
            {
                employeeID.Enabled = false;
                button7.Hide();
                button5.Hide();
                dataGridView1.Hide();
                dataGridView2.Show();
                button3.Hide();
                label1.Hide();
                textBox1.Hide();
                button8.Hide();

                custSource.DataSource = cust.getAll();
                dataGridView2.DataSource = custSource;
            }
            else
            {
                employeeID.Enabled = true;
                button7.Show();
                dataGridView2.Hide();
                dataGridView1.Show();
                label1.Show();
                textBox1.Show();
                button8.Show();

                callSource.DataSource = call.getAll();
                dataGridView1.DataSource = callSource;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (callSource.Position >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[callSource.Position];

                customerID.Text = row.Cells["callCustomerID"].Value.ToString();
                employeeID.Text = row.Cells["callEmployeeID"].Value.ToString();
                start.Text = row.Cells["start"].Value.ToString();
                end.Text = row.Cells["end"].Value.ToString();
                duration.Text = row.Cells["duration"].Value.ToString();
                string date = row.Cells["dateCreated"].Value.ToString();
                string[] splits = date.Split('-');
                dateCreated.Value = DateTime.Parse(splits[0] + "/" + splits[1] + "/" + splits[2]);

                callID = int.Parse(row.Cells["callID"].Value.ToString());
            }
        }

        private void CallCenter_MouseDown(object sender, MouseEventArgs e)
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

        private void CallCenter_Paint(object sender, PaintEventArgs e)
        {
            FormRegionAndBorder(this, borderRadius, e.Graphics, borderColor, borderSize);
        }

        private void pnlContainer_Paint(object sender, PaintEventArgs e)
        {
            ControlRegionAndBorder(pnlContainer, borderRadius - (borderSize / 2), e.Graphics, borderColor);
        }

        private void CallCenter_ResizeEnd(object sender, EventArgs e)
        {
            this.Invalidate();
        }
        private void CallCenter_SizeChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }
        private void CallCenter_Activated(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (validation.callVal(customerID.Text, employeeID.Text, start.Text, end.Text, dateCreated.Text, duration.Text))
            {
                string date = dateCreated.Value.ToShortDateString();
                string[] dateS = date.Split('/');
                date = dateS[0] + "-" + dateS[1] + "-" + dateS[2];

                call_history_b callAdd = new call_history_b(callID, customerID.Text, int.Parse(employeeID.Text), start.Text, end.Text, date, duration.Text);

                MessageBox.Show(call.add(callAdd));

                callSource.DataSource = call.getAll();
                dataGridView1.DataSource = callSource;
            }
            else
            {
                MessageBox.Show("Please enter values in all the vields");
            }
        }

        private static System.Timers.Timer t;

        private void button2_Click(object sender, EventArgs e)
        {
            t = new System.Timers.Timer();
            t.AutoReset = true;
            t.Enabled = true;
            t.Elapsed += ontime;
            t.Interval = 1000;

            button3.Show();
            start.Text = DateTime.Now.ToLongTimeString();
        }

        private void time(object Sender, EventArgs e)
        {
            if (durationTime[2] == "59")
            {
                durationTime[2] = "00";
                if (durationTime[1] == "59")
                {
                    durationTime[1] = "00";
                    durationTime[0] = (int.Parse(durationTime[0]) + 1).ToString();
                }
                else
                {
                    durationTime[1] = (int.Parse(durationTime[1]) + 1).ToString();
                }
            }
            else
            {
                durationTime[2] = (int.Parse(durationTime[2]) + 1).ToString();
            }

            duration.Text = durationTime[0].ToString() + ":" + durationTime[1].ToString() + ":" + durationTime[2].ToString();
        }

        private void ontime(object Sender, EventArgs e)
        {
            if (durationTime[2] == "59")
            {
                durationTime[2] = "00";
                if (durationTime[1] == "59")
                {
                    durationTime[1] = "00";
                    durationTime[0] = (int.Parse(durationTime[0]) + 1).ToString();
                }
                else
                {
                    durationTime[1] = (int.Parse(durationTime[1]) + 1).ToString();
                }
            }
            else
            {
                durationTime[2] = (int.Parse(durationTime[2]) + 1).ToString();
            }

            ExecuteSecure(() => duration.Text = durationTime[0].ToString() + ":" + durationTime[1].ToString() + ":" + durationTime[2].ToString());
        }

        private void ExecuteSecure(Action action)
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(() =>
                {
                    action();
                }));
            }
            else
            {
                action();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.Hide();

            t.Stop();
            t.Dispose();

            end.Text = DateTime.Now.ToLongTimeString();
            button5.Show();
            durationTime[0] = "00";
            durationTime[1] = "00";
            durationTime[2] = "00";
        }

        private void customerID_SelectedValueChanged(object sender, EventArgs e)
        {
            if (duration.Text != "00:00:00")
            {
                ClaimApplication ca = new ClaimApplication(role, true);
                ca.Show();
            }
        }
    }
}
