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
            this.coursesView = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.programsView = new System.Windows.Forms.TabPage();
            this.classroomsView = new System.Windows.Forms.TabPage();
            this.resourcesView = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.etInput = new System.Windows.Forms.DateTimePicker();
            this.stInput = new System.Windows.Forms.DateTimePicker();
            this.etLabel = new System.Windows.Forms.Label();
            this.stLabel = new System.Windows.Forms.Label();
            this.generateBTN = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // coursesView
            // 
            resources.ApplyResources(this.coursesView, "coursesView");
            this.coursesView.Name = "coursesView";
            this.coursesView.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabControl1);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.coursesView);
            this.tabControl1.Controls.Add(this.programsView);
            this.tabControl1.Controls.Add(this.classroomsView);
            this.tabControl1.Controls.Add(this.resourcesView);
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // programsView
            // 
            resources.ApplyResources(this.programsView, "programsView");
            this.programsView.Name = "programsView";
            this.programsView.UseVisualStyleBackColor = true;
            // 
            // classroomsView
            // 
            resources.ApplyResources(this.classroomsView, "classroomsView");
            this.classroomsView.Name = "classroomsView";
            this.classroomsView.UseVisualStyleBackColor = true;
            // 
            // resourcesView
            // 
            resources.ApplyResources(this.resourcesView, "resourcesView");
            this.resourcesView.Name = "resourcesView";
            this.resourcesView.UseVisualStyleBackColor = true;
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
            // 
            // etInput
            // 
            this.etInput.AccessibleRole = System.Windows.Forms.AccessibleRole.ScrollBar;
            resources.ApplyResources(this.etInput, "etInput");
            this.etInput.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.etInput.Name = "etInput";
            // 
            // stInput
            // 
            resources.ApplyResources(this.stInput, "stInput");
            this.stInput.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.stInput.Name = "stInput";
            this.stInput.ValueChanged += new System.EventHandler(this.stInput_ValueChanged);
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
            // 
            // NoScheduleHome
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "NoScheduleHome";
            this.Load += new System.EventHandler(this.NoScheduleHome_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage coursesView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage programsView;
        private System.Windows.Forms.TabPage classroomsView;
        private System.Windows.Forms.TabPage resourcesView;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DateTimePicker etInput;
        private System.Windows.Forms.DateTimePicker stInput;
        private System.Windows.Forms.Label etLabel;
        private System.Windows.Forms.Label stLabel;
        private System.Windows.Forms.Button generateBTN;
    }
}

