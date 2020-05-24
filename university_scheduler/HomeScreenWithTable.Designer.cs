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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.excelViews = new System.Windows.Forms.TabControl();
            this.classroomsTables = new System.Windows.Forms.TabPage();
            this.programsTables = new System.Windows.Forms.TabPage();
            this.classroomsExcel = new System.Windows.Forms.DataGridView();
            this.programsExcel = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1.SuspendLayout();
            this.excelViews.SuspendLayout();
            this.classroomsTables.SuspendLayout();
            this.programsTables.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.classroomsExcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.programsExcel)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.excelViews, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.45794F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 86.54205F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(507, 515);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // excelViews
            // 
            this.excelViews.Controls.Add(this.classroomsTables);
            this.excelViews.Controls.Add(this.programsTables);
            this.excelViews.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.excelViews.Location = new System.Drawing.Point(3, 72);
            this.excelViews.Name = "excelViews";
            this.excelViews.SelectedIndex = 0;
            this.excelViews.Size = new System.Drawing.Size(501, 440);
            this.excelViews.TabIndex = 0;
            // 
            // classroomsTables
            // 
            this.classroomsTables.Controls.Add(this.classroomsExcel);
            this.classroomsTables.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.classroomsTables.Location = new System.Drawing.Point(4, 25);
            this.classroomsTables.Name = "classroomsTables";
            this.classroomsTables.Padding = new System.Windows.Forms.Padding(3);
            this.classroomsTables.Size = new System.Drawing.Size(493, 411);
            this.classroomsTables.TabIndex = 0;
            this.classroomsTables.Text = "Classrooms";
            this.classroomsTables.UseVisualStyleBackColor = true;
            // 
            // programsTables
            // 
            this.programsTables.Controls.Add(this.programsExcel);
            this.programsTables.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.programsTables.Location = new System.Drawing.Point(4, 25);
            this.programsTables.Name = "programsTables";
            this.programsTables.Padding = new System.Windows.Forms.Padding(3);
            this.programsTables.Size = new System.Drawing.Size(493, 411);
            this.programsTables.TabIndex = 1;
            this.programsTables.Text = "Programs";
            this.programsTables.UseVisualStyleBackColor = true;
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
            this.classroomsExcel.Location = new System.Drawing.Point(0, 0);
            this.classroomsExcel.MultiSelect = false;
            this.classroomsExcel.Name = "classroomsExcel";
            this.classroomsExcel.ReadOnly = true;
            this.classroomsExcel.RowHeadersVisible = false;
            this.classroomsExcel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.classroomsExcel.Size = new System.Drawing.Size(497, 336);
            this.classroomsExcel.TabIndex = 0;
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
            this.programsExcel.Location = new System.Drawing.Point(0, 0);
            this.programsExcel.Margin = new System.Windows.Forms.Padding(20);
            this.programsExcel.MultiSelect = false;
            this.programsExcel.Name = "programsExcel";
            this.programsExcel.ReadOnly = true;
            this.programsExcel.RowHeadersVisible = false;
            this.programsExcel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.programsExcel.Size = new System.Drawing.Size(497, 336);
            this.programsExcel.TabIndex = 1;
            // 
            // HomeScreenWithTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 515);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "HomeScreenWithTable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HomeScreenWithTable";
            this.Load += new System.EventHandler(this.HomeScreenWithTable_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.excelViews.ResumeLayout(false);
            this.classroomsTables.ResumeLayout(false);
            this.programsTables.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.classroomsExcel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.programsExcel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TabControl excelViews;
        private System.Windows.Forms.TabPage classroomsTables;
        private System.Windows.Forms.TabPage programsTables;
        private System.Windows.Forms.DataGridView classroomsExcel;
        private System.Windows.Forms.DataGridView programsExcel;
    }
}