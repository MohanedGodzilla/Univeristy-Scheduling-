namespace university_scheduler
{
    partial class viewProgramForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.newProgramBTN = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.deleteProgramBTN = new System.Windows.Forms.Button();
            this.editProgramBTN = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.programData = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.programData)).BeginInit();
            this.SuspendLayout();
            // 
            // newProgramBTN
            // 
            this.newProgramBTN.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.newProgramBTN.Image = global::university_scheduler.Properties.Resources.icons8_add_20;
            this.newProgramBTN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.newProgramBTN.Location = new System.Drawing.Point(3, 11);
            this.newProgramBTN.Name = "newProgramBTN";
            this.newProgramBTN.Size = new System.Drawing.Size(171, 37);
            this.newProgramBTN.TabIndex = 0;
            this.newProgramBTN.Text = "New";
            this.newProgramBTN.UseVisualStyleBackColor = true;
            this.newProgramBTN.Click += new System.EventHandler(this.newProgramBTN_Click);
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
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.deleteProgramBTN, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.editProgramBTN, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.newProgramBTN, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(620, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 289F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(177, 444);
            this.tableLayoutPanel2.TabIndex = 0;
            this.tableLayoutPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel2_Paint);
            // 
            // deleteProgramBTN
            // 
            this.deleteProgramBTN.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.deleteProgramBTN.Image = global::university_scheduler.Properties.Resources.icons8_delete_bin_20;
            this.deleteProgramBTN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.deleteProgramBTN.Location = new System.Drawing.Point(3, 113);
            this.deleteProgramBTN.Name = "deleteProgramBTN";
            this.deleteProgramBTN.Size = new System.Drawing.Size(171, 37);
            this.deleteProgramBTN.TabIndex = 2;
            this.deleteProgramBTN.Text = "Delete";
            this.deleteProgramBTN.UseVisualStyleBackColor = true;
            this.deleteProgramBTN.Click += new System.EventHandler(this.deleteProgramBTN_Click);
            // 
            // editProgramBTN
            // 
            this.editProgramBTN.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.editProgramBTN.Image = global::university_scheduler.Properties.Resources.icons8_edit_20__1_;
            this.editProgramBTN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.editProgramBTN.Location = new System.Drawing.Point(3, 62);
            this.editProgramBTN.Name = "editProgramBTN";
            this.editProgramBTN.Size = new System.Drawing.Size(171, 37);
            this.editProgramBTN.TabIndex = 1;
            this.editProgramBTN.Text = "Edit";
            this.editProgramBTN.UseVisualStyleBackColor = true;
            this.editProgramBTN.Click += new System.EventHandler(this.editProgramBTN_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Desktop;
            this.panel1.Controls.Add(this.programData);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(611, 444);
            this.panel1.TabIndex = 1;
            // 
            // programData
            // 
            this.programData.AllowUserToAddRows = false;
            this.programData.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.programData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.programData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.programData.DefaultCellStyle = dataGridViewCellStyle4;
            this.programData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.programData.Location = new System.Drawing.Point(0, 0);
            this.programData.Name = "programData";
            this.programData.ReadOnly = true;
            this.programData.RowHeadersWidth = 51;
            this.programData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.programData.Size = new System.Drawing.Size(611, 444);
            this.programData.TabIndex = 2;
            this.programData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.programData_CellDoubleClick);
            // 
            // viewProgramForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "viewProgramForm";
            this.Text = "viewProgramForm";
            this.Load += new System.EventHandler(this.viewProgramForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.programData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button newProgramBTN;
        private System.Windows.Forms.Button deleteProgramBTN;
        private System.Windows.Forms.Button editProgramBTN;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.DataGridView programData;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}