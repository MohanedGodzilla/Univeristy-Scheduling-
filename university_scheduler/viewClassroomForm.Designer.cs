namespace university_scheduler
{
    partial class viewClassroomForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.classData = new System.Windows.Forms.DataGridView();
            this.newClassRoomBTN = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.saveClassRoomBTN = new System.Windows.Forms.Button();
            this.deleteClassRoomBTN = new System.Windows.Forms.Button();
            this.editClassRoomBTN = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.classData)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.panel1.Controls.Add(this.classData);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(611, 444);
            this.panel1.TabIndex = 1;
            // 
            // classData
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.classData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.classData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.classData.DefaultCellStyle = dataGridViewCellStyle4;
            this.classData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.classData.Location = new System.Drawing.Point(0, 0);
            this.classData.Name = "classData";
            this.classData.ReadOnly = true;
            this.classData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.classData.Size = new System.Drawing.Size(611, 444);
            this.classData.TabIndex = 1;
            this.classData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.classData_CellDoubleClick);
            // 
            // newClassRoomBTN
            // 
            this.newClassRoomBTN.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.newClassRoomBTN.Image = global::university_scheduler.Properties.Resources.icons8_add_20;
            this.newClassRoomBTN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.newClassRoomBTN.Location = new System.Drawing.Point(3, 16);
            this.newClassRoomBTN.Name = "newClassRoomBTN";
            this.newClassRoomBTN.Size = new System.Drawing.Size(171, 37);
            this.newClassRoomBTN.TabIndex = 0;
            this.newClassRoomBTN.Text = "New";
            this.newClassRoomBTN.UseVisualStyleBackColor = true;
            this.newClassRoomBTN.Click += new System.EventHandler(this.newClassRoomBTN_Click);
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
            this.tableLayoutPanel2.Controls.Add(this.saveClassRoomBTN, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.deleteClassRoomBTN, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.editClassRoomBTN, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.newClassRoomBTN, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(620, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 220F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(177, 444);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // saveClassRoomBTN
            // 
            this.saveClassRoomBTN.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.saveClassRoomBTN.Image = global::university_scheduler.Properties.Resources.icons8_save_20;
            this.saveClassRoomBTN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.saveClassRoomBTN.Location = new System.Drawing.Point(3, 184);
            this.saveClassRoomBTN.Name = "saveClassRoomBTN";
            this.saveClassRoomBTN.Size = new System.Drawing.Size(171, 37);
            this.saveClassRoomBTN.TabIndex = 5;
            this.saveClassRoomBTN.Text = "Save";
            this.saveClassRoomBTN.UseVisualStyleBackColor = true;
            this.saveClassRoomBTN.Visible = false;
            // 
            // deleteClassRoomBTN
            // 
            this.deleteClassRoomBTN.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.deleteClassRoomBTN.Image = global::university_scheduler.Properties.Resources.icons8_delete_bin_20;
            this.deleteClassRoomBTN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.deleteClassRoomBTN.Location = new System.Drawing.Point(3, 128);
            this.deleteClassRoomBTN.Name = "deleteClassRoomBTN";
            this.deleteClassRoomBTN.Size = new System.Drawing.Size(171, 37);
            this.deleteClassRoomBTN.TabIndex = 2;
            this.deleteClassRoomBTN.Text = "Delete";
            this.deleteClassRoomBTN.UseVisualStyleBackColor = true;
            this.deleteClassRoomBTN.Click += new System.EventHandler(this.deleteClassRoomBTN_Click);
            // 
            // editClassRoomBTN
            // 
            this.editClassRoomBTN.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.editClassRoomBTN.Image = global::university_scheduler.Properties.Resources.icons8_edit_20__1_;
            this.editClassRoomBTN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.editClassRoomBTN.Location = new System.Drawing.Point(3, 72);
            this.editClassRoomBTN.Name = "editClassRoomBTN";
            this.editClassRoomBTN.Size = new System.Drawing.Size(171, 37);
            this.editClassRoomBTN.TabIndex = 1;
            this.editClassRoomBTN.Text = "Edit";
            this.editClassRoomBTN.UseVisualStyleBackColor = true;
            this.editClassRoomBTN.Click += new System.EventHandler(this.editClassRoomBTN_Click);
            // 
            // viewClassroomForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "viewClassroomForm";
            this.Text = "viewClassroomForm";
            this.Load += new System.EventHandler(this.viewClassroomForm_Load_1);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.classData)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button newClassRoomBTN;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button deleteClassRoomBTN;
        private System.Windows.Forms.Button editClassRoomBTN;
        public System.Windows.Forms.Button saveClassRoomBTN;
        public System.Windows.Forms.DataGridView classData;
    }
}