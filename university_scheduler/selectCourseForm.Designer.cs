namespace university_scheduler {
    partial class selectCourseForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.saveProgramBTN = new System.Windows.Forms.Button();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // saveProgramBTN
            // 
            this.saveProgramBTN.Image = global::university_scheduler.Properties.Resources.icons8_save_20;
            this.saveProgramBTN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.saveProgramBTN.Location = new System.Drawing.Point(203, 298);
            this.saveProgramBTN.Margin = new System.Windows.Forms.Padding(4);
            this.saveProgramBTN.Name = "saveProgramBTN";
            this.saveProgramBTN.Size = new System.Drawing.Size(180, 44);
            this.saveProgramBTN.TabIndex = 11;
            this.saveProgramBTN.Text = "Save";
            this.saveProgramBTN.UseVisualStyleBackColor = true;
            this.saveProgramBTN.Click += new System.EventHandler(this.saveProgramBTN_Click);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(4, 13);
            this.checkedListBox1.Margin = new System.Windows.Forms.Padding(4);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(377, 244);
            this.checkedListBox1.TabIndex = 10;
            // 
            // selectCourseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 355);
            this.Controls.Add(this.saveProgramBTN);
            this.Controls.Add(this.checkedListBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "selectCourseForm";
            this.Text = "selectCourseForm";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button saveProgramBTN;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
    }
}