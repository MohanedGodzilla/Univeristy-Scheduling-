namespace university_scheduler
{
    partial class viewResourcesForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.resourceData = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.deleteAllBTN = new System.Windows.Forms.Button();
            this.deleteResourceBTN = new System.Windows.Forms.Button();
            this.editResourceBTN = new System.Windows.Forms.Button();
            this.newResourceBTN = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resourceData)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.resourceData);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(611, 444);
            this.panel1.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(82, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(335, 24);
            this.textBox1.TabIndex = 4;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Search";
            // 
            // resourceData
            // 
            this.resourceData.AllowUserToAddRows = false;
            this.resourceData.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.resourceData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.resourceData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.resourceData.DefaultCellStyle = dataGridViewCellStyle2;
            this.resourceData.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.resourceData.Location = new System.Drawing.Point(0, 62);
            this.resourceData.Name = "resourceData";
            this.resourceData.ReadOnly = true;
            this.resourceData.RowHeadersWidth = 51;
            this.resourceData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.resourceData.Size = new System.Drawing.Size(611, 382);
            this.resourceData.TabIndex = 5;
            this.resourceData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.resourceData_CellContentClick);
            this.resourceData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.resourceData_CellDoubleClick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 77.125F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.875F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.deleteAllBTN, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.deleteResourceBTN, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.editResourceBTN, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.newResourceBTN, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(620, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.37984F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.37985F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.37985F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 41.86047F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(177, 444);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // deleteAllBTN
            // 
            this.deleteAllBTN.BackColor = System.Drawing.Color.Red;
            this.deleteAllBTN.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.deleteAllBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteAllBTN.ForeColor = System.Drawing.SystemColors.Window;
            this.deleteAllBTN.Image = global::university_scheduler.Properties.Resources.icons8_deleteAll_20;
            this.deleteAllBTN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.deleteAllBTN.Location = new System.Drawing.Point(3, 293);
            this.deleteAllBTN.Name = "deleteAllBTN";
            this.deleteAllBTN.Size = new System.Drawing.Size(171, 45);
            this.deleteAllBTN.TabIndex = 3;
            this.deleteAllBTN.Text = "Delete All";
            this.deleteAllBTN.UseVisualStyleBackColor = false;
            this.deleteAllBTN.Click += new System.EventHandler(this.deleteAllBTN_Click);
            // 
            // deleteResourceBTN
            // 
            this.deleteResourceBTN.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.deleteResourceBTN.Image = global::university_scheduler.Properties.Resources.icons8_delete_bin_20;
            this.deleteResourceBTN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.deleteResourceBTN.Location = new System.Drawing.Point(3, 158);
            this.deleteResourceBTN.Name = "deleteResourceBTN";
            this.deleteResourceBTN.Size = new System.Drawing.Size(171, 37);
            this.deleteResourceBTN.TabIndex = 2;
            this.deleteResourceBTN.Text = "Delete";
            this.deleteResourceBTN.UseVisualStyleBackColor = true;
            this.deleteResourceBTN.Click += new System.EventHandler(this.deleteResourceBTN_Click);
            // 
            // editResourceBTN
            // 
            this.editResourceBTN.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.editResourceBTN.Image = global::university_scheduler.Properties.Resources.icons8_edit_20__1_;
            this.editResourceBTN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.editResourceBTN.Location = new System.Drawing.Point(3, 92);
            this.editResourceBTN.Name = "editResourceBTN";
            this.editResourceBTN.Size = new System.Drawing.Size(171, 37);
            this.editResourceBTN.TabIndex = 1;
            this.editResourceBTN.Text = "Edit";
            this.editResourceBTN.UseVisualStyleBackColor = true;
            this.editResourceBTN.Click += new System.EventHandler(this.editResourceBTN_Click);
            // 
            // newResourceBTN
            // 
            this.newResourceBTN.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.newResourceBTN.Image = global::university_scheduler.Properties.Resources.icons8_add_20;
            this.newResourceBTN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.newResourceBTN.Location = new System.Drawing.Point(3, 26);
            this.newResourceBTN.Name = "newResourceBTN";
            this.newResourceBTN.Size = new System.Drawing.Size(171, 37);
            this.newResourceBTN.TabIndex = 0;
            this.newResourceBTN.Text = "New";
            this.newResourceBTN.UseVisualStyleBackColor = true;
            this.newResourceBTN.Click += new System.EventHandler(this.newResourceBTN_Click);
            // 
            // viewResourcesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "viewResourcesForm";
            this.Text = "viewResourcesForm";
            this.Load += new System.EventHandler(this.viewResourcesForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resourceData)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.DataGridView resourceData;
        public System.Windows.Forms.Button deleteResourceBTN;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        public System.Windows.Forms.Button newResourceBTN;
        public System.Windows.Forms.Button editResourceBTN;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button deleteAllBTN;
    }

    
}