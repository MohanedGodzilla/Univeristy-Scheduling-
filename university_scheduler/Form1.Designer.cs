namespace university_scheduler
{
    partial class NoScheduleHome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NoScheduleHome));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.etInput = new System.Windows.Forms.DateTimePicker();
            this.stInput = new System.Windows.Forms.DateTimePicker();
            this.etLabel = new System.Windows.Forms.Label();
            this.stLabel = new System.Windows.Forms.Label();
            this.generateBTN = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.addCourseBTN = new System.Windows.Forms.Button();
            this.addClassroomBTN = new System.Windows.Forms.Button();
            this.addProgramBTN = new System.Windows.Forms.Button();
            this.addResourceBTN = new System.Windows.Forms.Button();
            this.coursesLabel = new System.Windows.Forms.Label();
            this.classroomsLabel = new System.Windows.Forms.Label();
            this.programsLabel = new System.Windows.Forms.Label();
            this.resourcesLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.etInput);
            this.panel2.Controls.Add(this.stInput);
            this.panel2.Controls.Add(this.etLabel);
            this.panel2.Controls.Add(this.stLabel);
            this.panel2.Controls.Add(this.generateBTN);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // etInput
            // 
            this.etInput.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            resources.ApplyResources(this.etInput, "etInput");
            this.etInput.Name = "etInput";
            // 
            // stInput
            // 
            this.stInput.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            resources.ApplyResources(this.stInput, "stInput");
            this.stInput.Name = "stInput";
            // 
            // etLabel
            // 
            resources.ApplyResources(this.etLabel, "etLabel");
            this.etLabel.Name = "etLabel";
            // 
            // stLabel
            // 
            resources.ApplyResources(this.stLabel, "stLabel");
            this.stLabel.Name = "stLabel";
            // 
            // generateBTN
            // 
            this.generateBTN.BackColor = System.Drawing.Color.LimeGreen;
            resources.ApplyResources(this.generateBTN, "generateBTN");
            this.generateBTN.ForeColor = System.Drawing.Color.Black;
            this.generateBTN.Name = "generateBTN";
            this.generateBTN.UseVisualStyleBackColor = false;
            this.generateBTN.Click += new System.EventHandler(this.button5_Click);
            // 
            // tableLayoutPanel2
            // 
            resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
            this.tableLayoutPanel2.Controls.Add(this.addCourseBTN, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.addClassroomBTN, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.addProgramBTN, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.addResourceBTN, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.coursesLabel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.classroomsLabel, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.programsLabel, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.resourcesLabel, 3, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel2_Paint);
            // 
            // addCourseBTN
            // 
            this.addCourseBTN.BackColor = System.Drawing.SystemColors.Highlight;
            this.addCourseBTN.DialogResult = System.Windows.Forms.DialogResult.OK;
            resources.ApplyResources(this.addCourseBTN, "addCourseBTN");
            this.addCourseBTN.Name = "addCourseBTN";
            this.addCourseBTN.UseVisualStyleBackColor = false;
            this.addCourseBTN.Click += new System.EventHandler(this.addCourseBTN_Click);
            // 
            // addClassroomBTN
            // 
            this.addClassroomBTN.BackColor = System.Drawing.SystemColors.Highlight;
            resources.ApplyResources(this.addClassroomBTN, "addClassroomBTN");
            this.addClassroomBTN.Name = "addClassroomBTN";
            this.addClassroomBTN.UseVisualStyleBackColor = false;
            this.addClassroomBTN.Click += new System.EventHandler(this.addClassroomBTN_Click);
            // 
            // addProgramBTN
            // 
            this.addProgramBTN.BackColor = System.Drawing.SystemColors.Highlight;
            resources.ApplyResources(this.addProgramBTN, "addProgramBTN");
            this.addProgramBTN.Name = "addProgramBTN";
            this.addProgramBTN.UseVisualStyleBackColor = false;
            this.addProgramBTN.Click += new System.EventHandler(this.addProgramBTN_Click);
            // 
            // addResourceBTN
            // 
            this.addResourceBTN.BackColor = System.Drawing.SystemColors.Highlight;
            resources.ApplyResources(this.addResourceBTN, "addResourceBTN");
            this.addResourceBTN.Name = "addResourceBTN";
            this.addResourceBTN.UseVisualStyleBackColor = false;
            // 
            // coursesLabel
            // 
            resources.ApplyResources(this.coursesLabel, "coursesLabel");
            this.coursesLabel.Name = "coursesLabel";
            // 
            // classroomsLabel
            // 
            resources.ApplyResources(this.classroomsLabel, "classroomsLabel");
            this.classroomsLabel.Name = "classroomsLabel";
            // 
            // programsLabel
            // 
            resources.ApplyResources(this.programsLabel, "programsLabel");
            this.programsLabel.Name = "programsLabel";
            // 
            // resourcesLabel
            // 
            resources.ApplyResources(this.resourcesLabel, "resourcesLabel");
            this.resourcesLabel.Name = "resourcesLabel";
            this.resourcesLabel.Click += new System.EventHandler(this.label4_Click);
            // 
            // NoScheduleHome
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "NoScheduleHome";
            this.Load += new System.EventHandler(this.NoScheduleHome_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DateTimePicker etInput;
        private System.Windows.Forms.DateTimePicker stInput;
        private System.Windows.Forms.Label etLabel;
        private System.Windows.Forms.Label stLabel;
        private System.Windows.Forms.Button generateBTN;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button addCourseBTN;
        private System.Windows.Forms.Button addClassroomBTN;
        private System.Windows.Forms.Button addProgramBTN;
        private System.Windows.Forms.Button addResourceBTN;
        private System.Windows.Forms.Label coursesLabel;
        private System.Windows.Forms.Label classroomsLabel;
        private System.Windows.Forms.Label programsLabel;
        private System.Windows.Forms.Label resourcesLabel;
    }
}

