namespace university_scheduler
{
    partial class addResourceForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.resourceName = new System.Windows.Forms.TextBox();
            this.addResourceBTN = new System.Windows.Forms.Button();
            this.cancelResourceBTN = new System.Windows.Forms.Button();
            this.saveResourceBTN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Resource Name";
            // 
            // resourceName
            // 
            this.resourceName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resourceName.Location = new System.Drawing.Point(144, 30);
            this.resourceName.MaxLength = 30;
            this.resourceName.Name = "resourceName";
            this.resourceName.Size = new System.Drawing.Size(153, 22);
            this.resourceName.TabIndex = 3;
            this.resourceName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.resourceName_KeyDown);
            // 
            // addResourceBTN
            // 
            this.addResourceBTN.BackColor = System.Drawing.Color.LimeGreen;
            this.addResourceBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.addResourceBTN.ForeColor = System.Drawing.Color.White;
            this.addResourceBTN.Location = new System.Drawing.Point(118, 89);
            this.addResourceBTN.Name = "addResourceBTN";
            this.addResourceBTN.Size = new System.Drawing.Size(90, 32);
            this.addResourceBTN.TabIndex = 6;
            this.addResourceBTN.Text = "Add";
            this.addResourceBTN.UseVisualStyleBackColor = false;
            this.addResourceBTN.Click += new System.EventHandler(this.addResourceBTN_Click);
            // 
            // cancelResourceBTN
            // 
            this.cancelResourceBTN.BackColor = System.Drawing.Color.Red;
            this.cancelResourceBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.cancelResourceBTN.ForeColor = System.Drawing.SystemColors.Control;
            this.cancelResourceBTN.Location = new System.Drawing.Point(221, 89);
            this.cancelResourceBTN.Name = "cancelResourceBTN";
            this.cancelResourceBTN.Size = new System.Drawing.Size(91, 32);
            this.cancelResourceBTN.TabIndex = 5;
            this.cancelResourceBTN.Text = "Cancel";
            this.cancelResourceBTN.UseVisualStyleBackColor = false;
            this.cancelResourceBTN.Click += new System.EventHandler(this.cancelResourceBTN_Click);
            // 
            // saveResourceBTN
            // 
            this.saveResourceBTN.BackColor = System.Drawing.Color.LimeGreen;
            this.saveResourceBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.saveResourceBTN.ForeColor = System.Drawing.Color.White;
            this.saveResourceBTN.Location = new System.Drawing.Point(15, 89);
            this.saveResourceBTN.Name = "saveResourceBTN";
            this.saveResourceBTN.Size = new System.Drawing.Size(90, 32);
            this.saveResourceBTN.TabIndex = 8;
            this.saveResourceBTN.Text = "Save";
            this.saveResourceBTN.UseVisualStyleBackColor = false;
            this.saveResourceBTN.Click += new System.EventHandler(this.saveResourceBTN_Click);
            // 
            // addResourceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 136);
            this.Controls.Add(this.saveResourceBTN);
            this.Controls.Add(this.addResourceBTN);
            this.Controls.Add(this.cancelResourceBTN);
            this.Controls.Add(this.resourceName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "addResourceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Resource";
            this.Load += new System.EventHandler(this.addResourceForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox resourceName;
        private System.Windows.Forms.Button addResourceBTN;
        private System.Windows.Forms.Button cancelResourceBTN;
        private System.Windows.Forms.Button saveResourceBTN;
    }
}