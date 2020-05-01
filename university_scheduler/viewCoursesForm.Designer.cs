namespace university_scheduler
{
    partial class viewCoursesForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.saveCourseBTN = new System.Windows.Forms.Button();
            this.deleteCourseBTN = new System.Windows.Forms.Button();
            this.editCourseBTN = new System.Windows.Forms.Button();
            this.newCourseBTN = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.courseData = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.courseData)).BeginInit();
            this.SuspendLayout();
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
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.saveCourseBTN, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.deleteCourseBTN, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.editCourseBTN, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.newCourseBTN, 0, 0);
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
            this.tableLayoutPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel2_Paint);
            // 
            // saveCourseBTN
            // 
            this.saveCourseBTN.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.saveCourseBTN.Image = global::university_scheduler.Properties.Resources.icons8_save_20;
            this.saveCourseBTN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.saveCourseBTN.Location = new System.Drawing.Point(3, 184);
            this.saveCourseBTN.Name = "saveCourseBTN";
            this.saveCourseBTN.Size = new System.Drawing.Size(171, 37);
            this.saveCourseBTN.TabIndex = 3;
            this.saveCourseBTN.Text = "Save";
            this.saveCourseBTN.UseVisualStyleBackColor = true;
            this.saveCourseBTN.Click += new System.EventHandler(this.button4_Click);
            // 
            // deleteCourseBTN
            // 
            this.deleteCourseBTN.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.deleteCourseBTN.Image = global::university_scheduler.Properties.Resources.icons8_delete_bin_20;
            this.deleteCourseBTN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.deleteCourseBTN.Location = new System.Drawing.Point(3, 128);
            this.deleteCourseBTN.Name = "deleteCourseBTN";
            this.deleteCourseBTN.Size = new System.Drawing.Size(171, 37);
            this.deleteCourseBTN.TabIndex = 2;
            this.deleteCourseBTN.Text = "Delete";
            this.deleteCourseBTN.UseVisualStyleBackColor = true;
            this.deleteCourseBTN.Click += new System.EventHandler(this.deleteCourseBTN_Click);
            // 
            // editCourseBTN
            // 
            this.editCourseBTN.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.editCourseBTN.Image = global::university_scheduler.Properties.Resources.icons8_edit_20__1_;
            this.editCourseBTN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.editCourseBTN.Location = new System.Drawing.Point(3, 72);
            this.editCourseBTN.Name = "editCourseBTN";
            this.editCourseBTN.Size = new System.Drawing.Size(171, 37);
            this.editCourseBTN.TabIndex = 1;
            this.editCourseBTN.Text = "Edit";
            this.editCourseBTN.UseVisualStyleBackColor = true;
            this.editCourseBTN.Click += new System.EventHandler(this.editCourseBTN_Click);
            // 
            // newCourseBTN
            // 
            this.newCourseBTN.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.newCourseBTN.Image = global::university_scheduler.Properties.Resources.icons8_add_20;
            this.newCourseBTN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.newCourseBTN.Location = new System.Drawing.Point(3, 16);
            this.newCourseBTN.Name = "newCourseBTN";
            this.newCourseBTN.Size = new System.Drawing.Size(171, 37);
            this.newCourseBTN.TabIndex = 0;
            this.newCourseBTN.Text = "New";
            this.newCourseBTN.UseVisualStyleBackColor = true;
            this.newCourseBTN.Click += new System.EventHandler(this.newCourseBTN_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.panel1.Controls.Add(this.courseData);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(611, 444);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // courseData
            // 
            this.courseData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.courseData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.courseData.Location = new System.Drawing.Point(0, 0);
            this.courseData.Name = "courseData";
            this.courseData.Size = new System.Drawing.Size(611, 444);
            this.courseData.TabIndex = 0;
            this.courseData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.courseData_CellContentClick);
            // 
            // viewCoursesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "viewCoursesForm";
            this.Text = "viewCoursesForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.courseData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button deleteCourseBTN;
        private System.Windows.Forms.Button editCourseBTN;
        private System.Windows.Forms.Button newCourseBTN;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView courseData;
        private System.Windows.Forms.Button saveCourseBTN;
    }
}