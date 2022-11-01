namespace SEN381_Project_Group17.PresentationLayer
{
    partial class ClaimApplication
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
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.providerID = new System.Windows.Forms.TextBox();
            this.customerID = new System.Windows.Forms.TextBox();
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
            this.conditionID = new System.Windows.Forms.TextBox();
            this.status = new System.Windows.Forms.TextBox();
            this.date = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(13, 149);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 18);
            this.label6.TabIndex = 135;
            this.label6.Text = "Customer ID";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(13, 217);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 18);
            this.label7.TabIndex = 136;
            this.label7.Text = "Provider ID";
            // 
            // providerID
            // 
            this.providerID.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.providerID.Location = new System.Drawing.Point(124, 217);
            this.providerID.Name = "providerID";
            this.providerID.Size = new System.Drawing.Size(100, 26);
            this.providerID.TabIndex = 138;
            // 
            // customerID
            // 
            this.customerID.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerID.Location = new System.Drawing.Point(124, 149);
            this.customerID.Name = "customerID";
            this.customerID.Size = new System.Drawing.Size(100, 26);
            this.customerID.TabIndex = 137;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(332, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 18);
            this.label1.TabIndex = 133;
            this.label1.Text = "Search";
            // 
            // find
            // 
            this.find.FlatAppearance.BorderColor = System.Drawing.Color.LightBlue;
            this.find.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.find.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.find.Location = new System.Drawing.Point(640, 38);
            this.find.Name = "find";
            this.find.Size = new System.Drawing.Size(148, 38);
            this.find.TabIndex = 132;
            this.find.Text = "Find";
            this.find.UseVisualStyleBackColor = true;
            // 
            // search
            // 
            this.search.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search.Location = new System.Drawing.Point(416, 45);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(204, 26);
            this.search.TabIndex = 134;
            // 
            // add
            // 
            this.add.FlatAppearance.BorderColor = System.Drawing.Color.Goldenrod;
            this.add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.add.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.add.Location = new System.Drawing.Point(12, 366);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(230, 47);
            this.add.TabIndex = 129;
            this.add.Text = "Add";
            this.add.UseVisualStyleBackColor = true;
            // 
            // delete
            // 
            this.delete.FlatAppearance.BorderColor = System.Drawing.Color.Goldenrod;
            this.delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.delete.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delete.Location = new System.Drawing.Point(558, 366);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(230, 47);
            this.delete.TabIndex = 130;
            this.delete.Text = "Delete";
            this.delete.UseVisualStyleBackColor = true;
            // 
            // update
            // 
            this.update.FlatAppearance.BorderColor = System.Drawing.Color.Goldenrod;
            this.update.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.update.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.update.Location = new System.Drawing.Point(286, 366);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(230, 47);
            this.update.TabIndex = 131;
            this.update.Text = "Update";
            this.update.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(230, 82);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(558, 161);
            this.dataGridView1.TabIndex = 122;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 18);
            this.label2.TabIndex = 123;
            this.label2.Text = "Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 18);
            this.label3.TabIndex = 124;
            this.label3.Text = "Status";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 18);
            this.label4.TabIndex = 125;
            this.label4.Text = "Condition ID";
            // 
            // conditionID
            // 
            this.conditionID.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.conditionID.Location = new System.Drawing.Point(124, 185);
            this.conditionID.Name = "conditionID";
            this.conditionID.Size = new System.Drawing.Size(100, 26);
            this.conditionID.TabIndex = 128;
            // 
            // status
            // 
            this.status.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.status.Location = new System.Drawing.Point(124, 117);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(100, 26);
            this.status.TabIndex = 127;
            // 
            // date
            // 
            this.date.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date.Location = new System.Drawing.Point(124, 82);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(100, 26);
            this.date.TabIndex = 126;
            // 
            // Application
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.providerID);
            this.Controls.Add(this.customerID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.find);
            this.Controls.Add(this.search);
            this.Controls.Add(this.add);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.update);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.conditionID);
            this.Controls.Add(this.status);
            this.Controls.Add(this.date);
            this.Name = "Application";
            this.Text = "Application";
            this.Load += new System.EventHandler(this.Application_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox providerID;
        private System.Windows.Forms.TextBox customerID;
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
        private System.Windows.Forms.TextBox conditionID;
        private System.Windows.Forms.TextBox status;
        private System.Windows.Forms.TextBox date;
    }
}