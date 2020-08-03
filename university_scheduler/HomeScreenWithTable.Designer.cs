namespace university_scheduler
{
    partial class HomeScreenWithTable
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeScreenWithTable));
            this.excelViews = new System.Windows.Forms.TabControl();
            this.classroomsTables = new System.Windows.Forms.TabPage();
            this.searchClass = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.classroomsExcel = new System.Windows.Forms.DataGridView();
            this.programsTables = new System.Windows.Forms.TabPage();
            this.searchProgram = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.programsExcel = new System.Windows.Forms.DataGridView();
            this.aboutBTN = new System.Windows.Forms.Button();
            this.viewBTN = new System.Windows.Forms.Button();
            this.generateNewBTN = new System.Windows.Forms.Button();
            this.levelCombo = new System.Windows.Forms.ComboBox();
            this.excelViews.SuspendLayout();
            this.classroomsTables.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.classroomsExcel)).BeginInit();
            this.programsTables.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.programsExcel)).BeginInit();
            this.SuspendLayout();
            // 
            // excelViews
            // 
            this.excelViews.Controls.Add(this.classroomsTables);
            this.excelViews.Controls.Add(this.programsTables);
            this.excelViews.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.excelViews.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.excelViews.Location = new System.Drawing.Point(0, 79);
            this.excelViews.Name = "excelViews";
            this.excelViews.SelectedIndex = 0;
            this.excelViews.Size = new System.Drawing.Size(1209, 524);
            this.excelViews.TabIndex = 1;
            // 
            // classroomsTables
            // 
            this.classroomsTables.Controls.Add(this.searchClass);
            this.classroomsTables.Controls.Add(this.label1);
            this.classroomsTables.Controls.Add(this.classroomsExcel);
            this.classroomsTables.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.classroomsTables.Location = new System.Drawing.Point(4, 25);
            this.classroomsTables.Name = "classroomsTables";
            this.classroomsTables.Padding = new System.Windows.Forms.Padding(3);
            this.classroomsTables.Size = new System.Drawing.Size(1201, 495);
            this.classroomsTables.TabIndex = 0;
            this.classroomsTables.Text = "Classrooms";
            this.classroomsTables.UseVisualStyleBackColor = true;
            // 
            // searchClass
            // 
            this.searchClass.Location = new System.Drawing.Point(72, 15);
            this.searchClass.Name = "searchClass";
            this.searchClass.Size = new System.Drawing.Size(438, 26);
            this.searchClass.TabIndex = 2;
            this.searchClass.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "search";
            // 
            // classroomsExcel
            // 
            this.classroomsExcel.AllowUserToAddRows = false;
            this.classroomsExcel.AllowUserToDeleteRows = false;
            this.classroomsExcel.AllowUserToResizeRows = false;
            this.classroomsExcel.BackgroundColor = System.Drawing.Color.White;
            this.classroomsExcel.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.classroomsExcel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.classroomsExcel.ColumnHeadersVisible = false;
            this.classroomsExcel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.classroomsExcel.Location = new System.Drawing.Point(3, 50);
            this.classroomsExcel.MultiSelect = false;
            this.classroomsExcel.Name = "classroomsExcel";
            this.classroomsExcel.ReadOnly = true;
            this.classroomsExcel.RowHeadersVisible = false;
            this.classroomsExcel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.classroomsExcel.Size = new System.Drawing.Size(1195, 442);
            this.classroomsExcel.TabIndex = 0;
            this.classroomsExcel.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.classroomsExcel_CellDoubleClick);
            // 
            // programsTables
            // 
            this.programsTables.Controls.Add(this.levelCombo);
            this.programsTables.Controls.Add(this.searchProgram);
            this.programsTables.Controls.Add(this.label2);
            this.programsTables.Controls.Add(this.programsExcel);
            this.programsTables.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.programsTables.Location = new System.Drawing.Point(4, 25);
            this.programsTables.Name = "programsTables";
            this.programsTables.Padding = new System.Windows.Forms.Padding(3);
            this.programsTables.Size = new System.Drawing.Size(1201, 495);
            this.programsTables.TabIndex = 1;
            this.programsTables.Text = "Programs";
            this.programsTables.UseVisualStyleBackColor = true;
            // 
            // searchProgram
            // 
            this.searchProgram.Location = new System.Drawing.Point(390, 15);
            this.searchProgram.Name = "searchProgram";
            this.searchProgram.Size = new System.Drawing.Size(438, 26);
            this.searchProgram.TabIndex = 4;
            this.searchProgram.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(324, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "search";
            // 
            // programsExcel
            // 
            this.programsExcel.AllowUserToAddRows = false;
            this.programsExcel.AllowUserToDeleteRows = false;
            this.programsExcel.AllowUserToResizeRows = false;
            this.programsExcel.BackgroundColor = System.Drawing.Color.White;
            this.programsExcel.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.programsExcel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.programsExcel.ColumnHeadersVisible = false;
            this.programsExcel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.programsExcel.Location = new System.Drawing.Point(3, 50);
            this.programsExcel.Margin = new System.Windows.Forms.Padding(20);
            this.programsExcel.MultiSelect = false;
            this.programsExcel.Name = "programsExcel";
            this.programsExcel.ReadOnly = true;
            this.programsExcel.RowHeadersVisible = false;
            this.programsExcel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.programsExcel.Size = new System.Drawing.Size(1195, 442);
            this.programsExcel.TabIndex = 1;
            this.programsExcel.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.programsExcel_CellDoubleClick);
            // 
            // aboutBTN
            // 
            this.aboutBTN.BackColor = System.Drawing.SystemColors.Control;
            this.aboutBTN.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.aboutBTN.FlatAppearance.BorderSize = 0;
            this.aboutBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.aboutBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.aboutBTN.Image = global::university_scheduler.Properties.Resources.icons8_contact_us_30;
            this.aboutBTN.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.aboutBTN.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.aboutBTN.Location = new System.Drawing.Point(1120, 3);
            this.aboutBTN.Name = "aboutBTN";
            this.aboutBTN.Size = new System.Drawing.Size(82, 62);
            this.aboutBTN.TabIndex = 5;
            this.aboutBTN.Text = "About us";
            this.aboutBTN.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.aboutBTN.UseVisualStyleBackColor = false;
            this.aboutBTN.Click += new System.EventHandler(this.aboutBTN_Click);
            // 
            // viewBTN
            // 
            this.viewBTN.BackColor = System.Drawing.SystemColors.Control;
            this.viewBTN.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.viewBTN.FlatAppearance.BorderSize = 0;
            this.viewBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.viewBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.viewBTN.Image = global::university_scheduler.Properties.Resources.icons8_view_30;
            this.viewBTN.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.viewBTN.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.viewBTN.Location = new System.Drawing.Point(1032, 3);
            this.viewBTN.Name = "viewBTN";
            this.viewBTN.Size = new System.Drawing.Size(82, 62);
            this.viewBTN.TabIndex = 4;
            this.viewBTN.Text = "View Data";
            this.viewBTN.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.viewBTN.UseVisualStyleBackColor = false;
            this.viewBTN.Click += new System.EventHandler(this.viewBTN_Click);
            // 
            // generateNewBTN
            // 
            this.generateNewBTN.BackColor = System.Drawing.SystemColors.Control;
            this.generateNewBTN.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.generateNewBTN.FlatAppearance.BorderSize = 0;
            this.generateNewBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.generateNewBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.generateNewBTN.Image = global::university_scheduler.Properties.Resources.icons8_police_car_light_30;
            this.generateNewBTN.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.generateNewBTN.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.generateNewBTN.Location = new System.Drawing.Point(7, 3);
            this.generateNewBTN.Name = "generateNewBTN";
            this.generateNewBTN.Size = new System.Drawing.Size(82, 70);
            this.generateNewBTN.TabIndex = 3;
            this.generateNewBTN.Text = "Generate new";
            this.generateNewBTN.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.generateNewBTN.UseVisualStyleBackColor = false;
            this.generateNewBTN.Click += new System.EventHandler(this.generateNewBTN_Click);
            // 
            // levelCombo
            // 
            this.levelCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.levelCombo.FormattingEnabled = true;
            this.levelCombo.Items.AddRange(new object[] {
            "Level 1",
            "Level 2",
            "Level 3 ",
            "Level 4 "});
            this.levelCombo.Location = new System.Drawing.Point(19, 15);
            this.levelCombo.Margin = new System.Windows.Forms.Padding(4);
            this.levelCombo.Name = "levelCombo";
            this.levelCombo.Size = new System.Drawing.Size(163, 28);
            this.levelCombo.TabIndex = 37;
            // 
            // HomeScreenWithTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1209, 603);
            this.Controls.Add(this.aboutBTN);
            this.Controls.Add(this.viewBTN);
            this.Controls.Add(this.generateNewBTN);
            this.Controls.Add(this.excelViews);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "HomeScreenWithTable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "University Scheduling";
            this.Load += new System.EventHandler(this.HomeScreenWithTable_Load);
            this.excelViews.ResumeLayout(false);
            this.classroomsTables.ResumeLayout(false);
            this.classroomsTables.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.classroomsExcel)).EndInit();
            this.programsTables.ResumeLayout(false);
            this.programsTables.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.programsExcel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl excelViews;
        private System.Windows.Forms.TabPage classroomsTables;
        private System.Windows.Forms.TextBox searchClass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView classroomsExcel;
        private System.Windows.Forms.TabPage programsTables;
        private System.Windows.Forms.TextBox searchProgram;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView programsExcel;
        private System.Windows.Forms.Button generateNewBTN;
        private System.Windows.Forms.Button viewBTN;
        private System.Windows.Forms.Button aboutBTN;
        private System.Windows.Forms.ComboBox levelCombo;
    }
}