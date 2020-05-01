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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.resourceData = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.saveResourceBTN = new System.Windows.Forms.Button();
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
            this.panel1.Controls.Add(this.resourceData);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(814, 546);
            this.panel1.TabIndex = 1;
            // 
            // resourceData
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.resourceData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.resourceData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.resourceData.DefaultCellStyle = dataGridViewCellStyle6;
            this.resourceData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resourceData.Location = new System.Drawing.Point(0, 0);
            this.resourceData.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.resourceData.Name = "resourceData";
            this.resourceData.ReadOnly = true;
            this.resourceData.RowHeadersWidth = 51;
            this.resourceData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.resourceData.Size = new System.Drawing.Size(814, 546);
            this.resourceData.TabIndex = 0;
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
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1067, 554);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.saveResourceBTN, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.deleteResourceBTN, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.editResourceBTN, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.newResourceBTN, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(826, 4);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 271F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(237, 546);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // saveResourceBTN
            // 
            this.saveResourceBTN.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.saveResourceBTN.Image = global::university_scheduler.Properties.Resources.icons8_save_20;
            this.saveResourceBTN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.saveResourceBTN.Location = new System.Drawing.Point(4, 222);
            this.saveResourceBTN.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.saveResourceBTN.Name = "saveResourceBTN";
            this.saveResourceBTN.Size = new System.Drawing.Size(229, 46);
            this.saveResourceBTN.TabIndex = 3;
            this.saveResourceBTN.Text = "Save";
            this.saveResourceBTN.UseVisualStyleBackColor = true;
            this.saveResourceBTN.Visible = false;
            this.saveResourceBTN.Click += new System.EventHandler(this.saveResourceBTN_Click);
            // 
            // deleteResourceBTN
            // 
            this.deleteResourceBTN.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.deleteResourceBTN.Image = global::university_scheduler.Properties.Resources.icons8_delete_bin_20;
            this.deleteResourceBTN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.deleteResourceBTN.Location = new System.Drawing.Point(4, 154);
            this.deleteResourceBTN.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.deleteResourceBTN.Name = "deleteResourceBTN";
            this.deleteResourceBTN.Size = new System.Drawing.Size(229, 46);
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
            this.editResourceBTN.Location = new System.Drawing.Point(4, 86);
            this.editResourceBTN.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.editResourceBTN.Name = "editResourceBTN";
            this.editResourceBTN.Size = new System.Drawing.Size(229, 46);
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
            this.newResourceBTN.Location = new System.Drawing.Point(4, 18);
            this.newResourceBTN.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.newResourceBTN.Name = "newResourceBTN";
            this.newResourceBTN.Size = new System.Drawing.Size(229, 46);
            this.newResourceBTN.TabIndex = 0;
            this.newResourceBTN.Text = "New";
            this.newResourceBTN.UseVisualStyleBackColor = true;
            this.newResourceBTN.Click += new System.EventHandler(this.newResourceBTN_Click);
            // 
            // viewResourcesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "viewResourcesForm";
            this.Text = "viewResourcesForm";
            this.Load += new System.EventHandler(this.viewResourcesForm_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.resourceData)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button newResourceBTN;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button editResourceBTN;
        public System.Windows.Forms.DataGridView resourceData;
        public System.Windows.Forms.Button saveResourceBTN;
        public System.Windows.Forms.Button deleteResourceBTN;
    }
}