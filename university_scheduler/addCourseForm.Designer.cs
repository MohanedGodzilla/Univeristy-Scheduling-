namespace university_scheduler
{
    partial class addCourseForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.saveBTN = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.isActive = new System.Windows.Forms.CheckBox();
            this.labHours = new System.Windows.Forms.NumericUpDown();
            this.practiceHours = new System.Windows.Forms.NumericUpDown();
            this.lecHours = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.courseName = new System.Windows.Forms.TextBox();
            this.courseCode = new System.Windows.Forms.TextBox();
            this.creditHours = new System.Windows.Forms.NumericUpDown();
            this.termCombo = new System.Windows.Forms.ComboBox();
            this.isRequired = new System.Windows.Forms.CheckBox();
            this.selectResource = new System.Windows.Forms.Button();
            this.addCourseBTN = new System.Windows.Forms.Button();
            this.cancelBTN = new System.Windows.Forms.Button();
            this.selectProgramBTN = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.labHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.practiceHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lecHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.creditHours)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.saveBTN);
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Controls.Add(this.addCourseBTN);
            this.panel1.Controls.Add(this.cancelBTN);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(453, 488);
            this.panel1.TabIndex = 0;
            // 
            // saveBTN
            // 
            this.saveBTN.BackColor = System.Drawing.Color.LimeGreen;
            this.saveBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.saveBTN.ForeColor = System.Drawing.Color.White;
            this.saveBTN.Location = new System.Drawing.Point(85, 448);
            this.saveBTN.Name = "saveBTN";
            this.saveBTN.Size = new System.Drawing.Size(90, 32);
            this.saveBTN.TabIndex = 5;
            this.saveBTN.Text = "Save";
            this.saveBTN.UseVisualStyleBackColor = false;
            this.saveBTN.Click += new System.EventHandler(this.saveBTN_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.42072F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.57928F));
            this.tableLayoutPanel1.Controls.Add(this.isActive, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.labHours, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.practiceHours, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lecHours, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.label10, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.label11, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this.courseName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.courseCode, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.creditHours, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.termCombo, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.isRequired, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.selectResource, 1, 10);
            this.tableLayoutPanel1.Controls.Add(this.selectProgramBTN, 1, 9);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 11;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(494, 424);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // isActive
            // 
            this.isActive.AutoSize = true;
            this.isActive.Checked = true;
            this.isActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.isActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.isActive.Location = new System.Drawing.Point(187, 314);
            this.isActive.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.isActive.Name = "isActive";
            this.isActive.Size = new System.Drawing.Size(64, 20);
            this.isActive.TabIndex = 18;
            this.isActive.Text = "Active";
            this.isActive.UseVisualStyleBackColor = true;
            // 
            // labHours
            // 
            this.labHours.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.labHours.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labHours.Location = new System.Drawing.Point(187, 200);
            this.labHours.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.labHours.Name = "labHours";
            this.labHours.Size = new System.Drawing.Size(51, 22);
            this.labHours.TabIndex = 16;
            // 
            // practiceHours
            // 
            this.practiceHours.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.practiceHours.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.practiceHours.Location = new System.Drawing.Point(187, 162);
            this.practiceHours.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.practiceHours.Name = "practiceHours";
            this.practiceHours.Size = new System.Drawing.Size(51, 22);
            this.practiceHours.TabIndex = 15;
            // 
            // lecHours
            // 
            this.lecHours.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.lecHours.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lecHours.Location = new System.Drawing.Point(187, 124);
            this.lecHours.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.lecHours.Name = "lecHours";
            this.lecHours.Size = new System.Drawing.Size(51, 22);
            this.lecHours.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Course Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(178, 38);
            this.label2.TabIndex = 1;
            this.label2.Text = "Course Code";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(178, 38);
            this.label3.TabIndex = 2;
            this.label3.Text = "Credit Hours";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(178, 38);
            this.label4.TabIndex = 3;
            this.label4.Text = "Lecture Hours";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 152);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(178, 38);
            this.label5.TabIndex = 4;
            this.label5.Text = "Practice Hours";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 190);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(178, 38);
            this.label6.TabIndex = 5;
            this.label6.Text = "Lab Hours";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(3, 228);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(178, 38);
            this.label7.TabIndex = 6;
            this.label7.Text = "Term";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(3, 266);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(178, 38);
            this.label8.TabIndex = 7;
            this.label8.Text = "University Requirement";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(3, 304);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(178, 38);
            this.label9.TabIndex = 8;
            this.label9.Text = "Course Activation";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(3, 342);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(178, 38);
            this.label10.TabIndex = 9;
            this.label10.Text = "Course Programs ";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(3, 380);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(178, 44);
            this.label11.TabIndex = 10;
            this.label11.Text = "Course Resourse";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // courseName
            // 
            this.courseName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.courseName.Location = new System.Drawing.Point(187, 10);
            this.courseName.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.courseName.Name = "courseName";
            this.courseName.Size = new System.Drawing.Size(219, 22);
            this.courseName.TabIndex = 11;
            this.courseName.TextChanged += new System.EventHandler(this.courseName_TextChanged);
            // 
            // courseCode
            // 
            this.courseCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.courseCode.Location = new System.Drawing.Point(187, 48);
            this.courseCode.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.courseCode.Name = "courseCode";
            this.courseCode.Size = new System.Drawing.Size(219, 22);
            this.courseCode.TabIndex = 12;
            this.courseCode.TextChanged += new System.EventHandler(this.courseCode_TextChanged);
            // 
            // creditHours
            // 
            this.creditHours.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.creditHours.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.creditHours.Location = new System.Drawing.Point(187, 86);
            this.creditHours.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.creditHours.Name = "creditHours";
            this.creditHours.Size = new System.Drawing.Size(51, 22);
            this.creditHours.TabIndex = 13;
            // 
            // termCombo
            // 
            this.termCombo.AccessibleName = "";
            this.termCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.termCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.termCombo.FormattingEnabled = true;
            this.termCombo.Items.AddRange(new object[] {
            "Level 1 - Semester 1",
            "Level 1 - Semester 2",
            "Level 2 - Semester 1",
            "Level 2 - Semester 2",
            "Level 3 - Semester 1",
            "Level 3 - Semester 2",
            "Level 4 - Semester 1",
            "Level 4 - Semester 2"});
            this.termCombo.Location = new System.Drawing.Point(187, 238);
            this.termCombo.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.termCombo.Name = "termCombo";
            this.termCombo.Size = new System.Drawing.Size(219, 24);
            this.termCombo.TabIndex = 5;
            this.termCombo.Tag = "";
            // 
            // isRequired
            // 
            this.isRequired.AutoSize = true;
            this.isRequired.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.isRequired.Location = new System.Drawing.Point(187, 276);
            this.isRequired.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.isRequired.Name = "isRequired";
            this.isRequired.Size = new System.Drawing.Size(86, 20);
            this.isRequired.TabIndex = 17;
            this.isRequired.Text = "Required ";
            this.isRequired.UseVisualStyleBackColor = true;
            // 
            // selectResource
            // 
            this.selectResource.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectResource.Location = new System.Drawing.Point(187, 390);
            this.selectResource.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.selectResource.Name = "selectResource";
            this.selectResource.Size = new System.Drawing.Size(86, 23);
            this.selectResource.TabIndex = 19;
            this.selectResource.Text = "-- select -- ";
            this.selectResource.UseVisualStyleBackColor = true;
            this.selectResource.Click += new System.EventHandler(this.selectResource_Click);
            // 
            // addCourseBTN
            // 
            this.addCourseBTN.BackColor = System.Drawing.Color.LimeGreen;
            this.addCourseBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.addCourseBTN.ForeColor = System.Drawing.Color.White;
            this.addCourseBTN.Location = new System.Drawing.Point(203, 448);
            this.addCourseBTN.Name = "addCourseBTN";
            this.addCourseBTN.Size = new System.Drawing.Size(90, 32);
            this.addCourseBTN.TabIndex = 3;
            this.addCourseBTN.Text = "Add";
            this.addCourseBTN.UseVisualStyleBackColor = false;
            this.addCourseBTN.Click += new System.EventHandler(this.addCourseBTN_Click);
            // 
            // cancelBTN
            // 
            this.cancelBTN.BackColor = System.Drawing.Color.Red;
            this.cancelBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.cancelBTN.ForeColor = System.Drawing.SystemColors.Control;
            this.cancelBTN.Location = new System.Drawing.Point(318, 448);
            this.cancelBTN.Name = "cancelBTN";
            this.cancelBTN.Size = new System.Drawing.Size(91, 32);
            this.cancelBTN.TabIndex = 2;
            this.cancelBTN.Text = "Cancel";
            this.cancelBTN.UseVisualStyleBackColor = false;
            this.cancelBTN.Click += new System.EventHandler(this.cancelBTN_Click);
            // 
            // selectProgramBTN
            // 
            this.selectProgramBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectProgramBTN.Location = new System.Drawing.Point(187, 352);
            this.selectProgramBTN.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.selectProgramBTN.Name = "selectProgramBTN";
            this.selectProgramBTN.Size = new System.Drawing.Size(86, 23);
            this.selectProgramBTN.TabIndex = 19;
            this.selectProgramBTN.Text = "-- select --";
            this.selectProgramBTN.UseVisualStyleBackColor = true;
            this.selectProgramBTN.Click += new System.EventHandler(this.selectProgramBTN_Click);
            // 
            // addCourseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 488);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "addCourseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Course ";
            this.Load += new System.EventHandler(this.addCourseForm_Load);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.labHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.practiceHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lecHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.creditHours)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button addCourseBTN;
        private System.Windows.Forms.Button cancelBTN;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown labHours;
        private System.Windows.Forms.NumericUpDown practiceHours;
        private System.Windows.Forms.NumericUpDown lecHours;
        private System.Windows.Forms.TextBox courseName;
        private System.Windows.Forms.TextBox courseCode;
        private System.Windows.Forms.NumericUpDown creditHours;
        private System.Windows.Forms.ComboBox termCombo;
        private System.Windows.Forms.CheckBox isActive;
        private System.Windows.Forms.CheckBox isRequired;
        private System.Windows.Forms.Button selectResource;
        private System.Windows.Forms.Button saveBTN;
        private System.Windows.Forms.Button selectProgramBTN;
    }
}