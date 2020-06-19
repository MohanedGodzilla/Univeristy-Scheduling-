using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace university_scheduler
{
    public partial class viewLoadForm : Form
    {
        public viewLoadForm()
        {
            InitializeComponent();
        }

        public static string res = "";
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void viewLoadForm_Load(object sender, EventArgs e)
        {

        }

        /*
        public static void SetProgress(int progress)
        {
            progressBar1.Value = progress;
            //bar.Value = progress;
        }

        public static void SetMax(int max)
        {
            progressBar1.Maximum = max;
        }

        public static void SetMin(int min)
        {
            progressBar1.Minimum = min;
        }

        public static void SetLableText(string txt)
        {
            label1.Text = txt;
        }
        */

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            /*
            int sum = 0;
            for(int i=1; i<=100; i++)
            {
                Thread.Sleep(100);
                sum = sum + i;
                backgroundWorker1.ReportProgress(i);

                if(backgroundWorker1.CancellationPending)
                {
                    e.Cancel = true;
                    backgroundWorker1.ReportProgress(0);
                    return;
                }
            }
            e.Result = sum;
            */
            Scheduler scheduler = new Scheduler();
            scheduler.start(this, e);
            scheduler.saveReservations();
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //Scheduler scheduler = new Scheduler();
            //int tot = scheduler.getTotal();
            progressBar1.Value = e.ProgressPercentage;
            //label1.Text = e.ProgressPercentage.ToString() + " %";
            label1.Text =  $" ( {Scheduler.reserved.ToString()} ) reserved slots / ( {Scheduler.total.ToString()} ) total slots \n\n {e.ProgressPercentage.ToString()}  %";
            if(e.ProgressPercentage == 100)
            {
                label1.Text += "\n saving Reservations ...";
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(e.Cancelled)
            {
                label1.Text = "Scheduling has been canceled";
                res = "Scheduling has been canceled";
                this.Close();
            }
            else if(e.Error != null)
            {
                label1.Text = e.Error.ToString();
                res = e.Error.ToString();
                this.Close();
            }
            else
            {
                label1.Text = e.Result.ToString();
                res = e.Result.ToString();
                res += "\n saving Reservations ... done";
                res += "\n Generating Excel Sheets...";
                this.Close();
            }
        }

        public void startBrogress()
        {
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void cancelBTN_Click(object sender, EventArgs e)
        {
            if(backgroundWorker1.IsBusy)
            {
                backgroundWorker1.CancelAsync();
            }
        }
    }
}
