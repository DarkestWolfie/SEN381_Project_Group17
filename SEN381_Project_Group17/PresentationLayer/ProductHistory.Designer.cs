﻿namespace SEN381_Project_Group17.PresentationLayer
{
    partial class ProductHistory
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.find = new System.Windows.Forms.Button();
            this.search = new System.Windows.Forms.TextBox();
            this.add = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            this.update = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.productID = new System.Windows.Forms.TextBox();
            this.end = new System.Windows.Forms.TextBox();
            this.start = new System.Windows.Forms.TextBox();
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.pnlContainer.SuspendLayout();
            this.pnlTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(333, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 18);
            this.label1.TabIndex = 101;
            this.label1.Text = "Search";
            // 
            // find
            // 
            this.find.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.find.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(178)))));
            this.find.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.find.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.find.Image = global::SEN381_Project_Group17.Properties.Resources.search_7525;
            this.find.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.find.Location = new System.Drawing.Point(641, 62);
            this.find.Name = "find";
            this.find.Size = new System.Drawing.Size(148, 38);
            this.find.TabIndex = 100;
            this.find.Text = "Find";
            this.find.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.find.UseVisualStyleBackColor = true;
            this.find.Click += new System.EventHandler(this.find_Click);
            // 
            // search
            // 
            this.search.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search.Location = new System.Drawing.Point(417, 69);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(204, 26);
            this.search.TabIndex = 102;
            // 
            // add
            // 
            this.add.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.add.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(178)))));
            this.add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.add.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.add.Image = global::SEN381_Project_Group17.Properties.Resources.add_button_12004;
            this.add.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.add.Location = new System.Drawing.Point(29, 278);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(230, 47);
            this.add.TabIndex = 97;
            this.add.Text = "Add";
            this.add.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // delete
            // 
            this.delete.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.delete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(178)))));
            this.delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.delete.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delete.Image = global::SEN381_Project_Group17.Properties.Resources.delete_10406;
            this.delete.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.delete.Location = new System.Drawing.Point(547, 278);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(230, 47);
            this.delete.TabIndex = 98;
            this.delete.Text = "Delete";
            this.delete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.delete.UseVisualStyleBackColor = true;
            // 
            // update
            // 
            this.update.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.update.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(178)))));
            this.update.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.update.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.update.Image = global::SEN381_Project_Group17.Properties.Resources.reload_arrows_2846;
            this.update.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.update.Location = new System.Drawing.Point(287, 278);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(230, 47);
            this.update.TabIndex = 99;
            this.update.Text = "Update";
            this.update.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.update.UseVisualStyleBackColor = true;
            this.update.Click += new System.EventHandler(this.update_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(263, 106);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(526, 151);
            this.dataGridView1.TabIndex = 90;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 18);
            this.label2.TabIndex = 91;
            this.label2.Text = "Start";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 18);
            this.label3.TabIndex = 92;
            this.label3.Text = "End";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 18);
            this.label4.TabIndex = 93;
            this.label4.Text = "Product ID";
            // 
            // productID
            // 
            this.productID.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productID.Location = new System.Drawing.Point(109, 175);
            this.productID.Name = "productID";
            this.productID.Size = new System.Drawing.Size(126, 26);
            this.productID.TabIndex = 96;
            // 
            // end
            // 
            this.end.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.end.Location = new System.Drawing.Point(109, 141);
            this.end.Name = "end";
            this.end.Size = new System.Drawing.Size(126, 26);
            this.end.TabIndex = 95;
            // 
            // start
            // 
            this.start.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.start.Location = new System.Drawing.Point(109, 106);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(126, 26);
            this.start.TabIndex = 94;
            // 
            // pnlContainer
            // 
            this.pnlContainer.BackColor = System.Drawing.Color.Azure;
            this.pnlContainer.Controls.Add(this.pnlTitle);
            this.pnlContainer.Controls.Add(this.dataGridView1);
            this.pnlContainer.Controls.Add(this.label1);
            this.pnlContainer.Controls.Add(this.start);
            this.pnlContainer.Controls.Add(this.find);
            this.pnlContainer.Controls.Add(this.end);
            this.pnlContainer.Controls.Add(this.search);
            this.pnlContainer.Controls.Add(this.productID);
            this.pnlContainer.Controls.Add(this.add);
            this.pnlContainer.Controls.Add(this.label4);
            this.pnlContainer.Controls.Add(this.delete);
            this.pnlContainer.Controls.Add(this.label3);
            this.pnlContainer.Controls.Add(this.update);
            this.pnlContainer.Controls.Add(this.label2);
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(800, 341);
            this.pnlContainer.TabIndex = 103;
            this.pnlContainer.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlContainer_Paint);
            // 
            // pnlTitle
            // 
            this.pnlTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(178)))));
            this.pnlTitle.Controls.Add(this.pictureBox1);
            this.pnlTitle.Controls.Add(this.label5);
            this.pnlTitle.Controls.Add(this.button1);
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(800, 50);
            this.pnlTitle.TabIndex = 103;
            this.pnlTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTitle_MouseDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::SEN381_Project_Group17.Properties.Resources.UH_Logo;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(0, -10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(99, 60);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(282, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(181, 26);
            this.label5.TabIndex = 12;
            this.label5.Text = "Product History";
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Default;
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::SEN381_Project_Group17.Properties.Resources.x_10325;
            this.button1.Location = new System.Drawing.Point(750, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 50);
            this.button1.TabIndex = 11;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ProductHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 341);
            this.Controls.Add(this.pnlContainer);
            this.Name = "ProductHistory";
            this.Text = "ProductHistory";
            this.Activated += new System.EventHandler(this.ProductHistory_Activated);
            this.Load += new System.EventHandler(this.ProductHistory_Load);
            this.ResizeEnd += new System.EventHandler(this.ProductHistory_ResizeEnd);
            this.SizeChanged += new System.EventHandler(this.ProductHistory_SizeChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ProductHistory_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ProductHistory_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button find;
        private System.Windows.Forms.TextBox search;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.Button update;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox productID;
        private System.Windows.Forms.TextBox end;
        private System.Windows.Forms.TextBox start;
        private System.Windows.Forms.Panel pnlContainer;
        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
    }
}