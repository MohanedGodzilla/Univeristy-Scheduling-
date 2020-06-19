namespace university_scheduler
{
    partial class addClassRoomForm
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
            this.saveClassBTN = new System.Windows.Forms.Button();
            this.addClassBTN = new System.Windows.Forms.Button();
            this.cancelClassBTN = new System.Windows.Forms.Button();
            this.examCounter = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lecCounter = new System.Windows.Forms.NumericUpDown();
            this.className = new System.Windows.Forms.TextBox();
            this.selectResource = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.isLab = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.examCounter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lecCounter)).BeginInit();
            this.SuspendLayout();
            // 
            // saveClassBTN
            // 
            this.saveClassBTN.BackColor = System.Drawing.Color.LimeGreen;
            this.saveClassBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.saveClassBTN.ForeColor = System.Drawing.Color.White;
            this.saveClassBTN.Location = new System.Drawing.Point(20, 243);
            this.saveClassBTN.Name = "saveClassBTN";
            this.saveClassBTN.Size = new System.Drawing.Size(90, 32);
            this.saveClassBTN.TabIndex = 7;
            this.saveClassBTN.Text = "Save";
            this.saveClassBTN.UseVisualStyleBackColor = false;
            this.saveClassBTN.Click += new System.EventHandler(this.saveClassBTN_Click);
            // 
            // addClassBTN
            // 
            this.addClassBTN.BackColor = System.Drawing.Color.LimeGreen;
            this.addClassBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.addClassBTN.ForeColor = System.Drawing.Color.White;
            this.addClassBTN.Location = new System.Drawing.Point(130, 243);
            this.addClassBTN.Name = "addClassBTN";
            this.addClassBTN.Size = new System.Drawing.Size(90, 32);
            this.addClassBTN.TabIndex = 6;
            this.addClassBTN.Text = "Add";
            this.addClassBTN.UseVisualStyleBackColor = false;
            this.addClassBTN.Click += new System.EventHandler(this.addClassBTN_Click);
            // 
            // cancelClassBTN
            // 
            this.cancelClassBTN.BackColor = System.Drawing.Color.Red;
            this.cancelClassBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.cancelClassBTN.ForeColor = System.Drawing.SystemColors.Control;
            this.cancelClassBTN.Location = new System.Drawing.Point(239, 243);
            this.cancelClassBTN.Name = "cancelClassBTN";
            this.cancelClassBTN.Size = new System.Drawing.Size(91, 32);
            this.cancelClassBTN.TabIndex = 8;
            this.cancelClassBTN.Text = "Cancel";
            this.cancelClassBTN.UseVisualStyleBackColor = false;
            this.cancelClassBTN.Click += new System.EventHandler(this.cancelClassBTN_Click);
            // 
            // examCounter
            // 
            this.examCounter.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.examCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.examCounter.Location = new System.Drawing.Point(155, 110);
            this.examCounter.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.examCounter.Name = "examCounter";
            this.examCounter.Size = new System.Drawing.Size(42, 22);
            this.examCounter.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "Exam Capacity\r\n";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Lecture Capacity\r\n";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Classroom Name";
            // 
            // lecCounter
            // 
            this.lecCounter.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.lecCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lecCounter.Location = new System.Drawing.Point(155, 66);
            this.lecCounter.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.lecCounter.Name = "lecCounter";
            this.lecCounter.Size = new System.Drawing.Size(42, 22);
            this.lecCounter.TabIndex = 2;
            // 
            // className
            // 
            this.className.Location = new System.Drawing.Point(155, 22);
            this.className.MaxLength = 30;
            this.className.Name = "className";
            this.className.Size = new System.Drawing.Size(175, 20);
            this.className.TabIndex = 1;
            // 
            // selectResource
            // 
            this.selectResource.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectResource.Location = new System.Drawing.Point(153, 188);
            this.selectResource.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.selectResource.Name = "selectResource";
            this.selectResource.Size = new System.Drawing.Size(86, 23);
            this.selectResource.TabIndex = 5;
            this.selectResource.Text = "-- select -- ";
            this.selectResource.UseVisualStyleBackColor = true;
            this.selectResource.Click += new System.EventHandler(this.selectResource_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 191);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 16);
            this.label4.TabIndex = 22;
            this.label4.Text = "Classroom Recource\r\n";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 16);
            this.label5.TabIndex = 23;
            this.label5.Text = "isLab\r\n";
            // 
            // isLab
            // 
            this.isLab.AutoSize = true;
            this.isLab.Location = new System.Drawing.Point(155, 155);
            this.isLab.Name = "isLab";
            this.isLab.Size = new System.Drawing.Size(26, 17);
            this.isLab.TabIndex = 4;
            this.isLab.Text = "\r\n";
            this.isLab.UseVisualStyleBackColor = true;
            this.isLab.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // addClassRoomForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 290);
            this.Controls.Add(this.isLab);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.selectResource);
            this.Controls.Add(this.className);
            this.Controls.Add(this.lecCounter);
            this.Controls.Add(this.saveClassBTN);
            this.Controls.Add(this.addClassBTN);
            this.Controls.Add(this.cancelClassBTN);
            this.Controls.Add(this.examCounter);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "addClassRoomForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Classroom";
            this.Load += new System.EventHandler(this.addClassRoomForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.examCounter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lecCounter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button saveClassBTN;
        private System.Windows.Forms.Button addClassBTN;
        private System.Windows.Forms.Button cancelClassBTN;
        private System.Windows.Forms.NumericUpDown examCounter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown lecCounter;
        private System.Windows.Forms.TextBox className;
        private System.Windows.Forms.Button selectResource;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox isLab;
    }
}