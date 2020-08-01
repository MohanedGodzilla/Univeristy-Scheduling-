namespace university_scheduler
{
    partial class viewLoadForm
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
            this.cancelBTN = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // cancelBTN
            // 
            this.cancelBTN.BackColor = System.Drawing.Color.Red;
            this.cancelBTN.ForeColor = System.Drawing.SystemColors.Window;
            this.cancelBTN.Location = new System.Drawing.Point(285, 144);
            this.cancelBTN.Name = "cancelBTN";
            this.cancelBTN.Size = new System.Drawing.Size(149, 41);
            this.cancelBTN.TabIndex = 5;
            this.cancelBTN.Text = "CANCEL\r\n";
            this.cancelBTN.UseVisualStyleBackColor = false;
            this.cancelBTN.Click += new System.EventHandler(this.cancelBTN_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(139, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "( ) reserved slots/ ( ) total slots";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(14, 100);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(420, 27);
            this.progressBar1.TabIndex = 3;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // viewLoadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 193);
            this.Controls.Add(this.cancelBTN);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "viewLoadForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "viewLoadForm";
            this.Load += new System.EventHandler(this.viewLoadForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button cancelBTN;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.ProgressBar progressBar1;
        public System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}