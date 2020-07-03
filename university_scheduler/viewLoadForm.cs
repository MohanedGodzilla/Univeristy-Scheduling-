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
using Excel = Microsoft.Office.Interop.Excel;
using university_scheduler.Model;

namespace university_scheduler
{
    public partial class viewLoadForm : Form
    {

        int reserved = 0;
        int total = 0;
        public viewLoadForm()
        {
            InitializeComponent();
        }

        public static string res = "";

        NoScheduleHome x = new NoScheduleHome();
        private void viewLoadForm_Load(object sender, EventArgs e)
        {
            x.stInput.ShowUpDown = true;
            x.etInput.ShowUpDown = true;
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

        public void onNewReservation(int reserved, int total)
        {
            this.reserved = reserved;
            this.total = total;
            backgroundWorker1.ReportProgress(Convert.ToInt32(reserved * 100 / total));
            if (backgroundWorker1.CancellationPending) {
                backgroundWorker1.ReportProgress(0);
                return;
            }
        }
        void genWorksheets(List<Reservation> allResOfClass, Excel.Application classroomsApp, Excel.Workbook wb, string name, string model)
        {
            Dictionary<int, string> dayAsString = new Dictionary<int, string>();
            dayAsString.Add(0, "sat");
            dayAsString.Add(1, "sun");
            dayAsString.Add(2, "mon");
            dayAsString.Add(3, "tues");
            dayAsString.Add(4, "wed");
            dayAsString.Add(5, "thur");
            dayAsString.Add(6, "fri");
            Excel.Worksheet ws = (Excel.Worksheet)classroomsApp.Worksheets.Add();

            //Header of Excel
            ws.Cells[1] = "Day";
            ws.Cells[2] = "Course Name";
            ws.Cells[3] = "Course Code";
            ws.Cells[4] = "From";
            ws.Cells[5] = "To";
            if (model == "program")
            {
                ws.Cells[6] = "Classroom";
            }
            //cells of excel
            for (int i = 0; i < allResOfClass.Count; i++)
            {
                Course course = Course.getCourseById(allResOfClass[i].courseId);
                ws.Cells[i + 2, 1] = dayAsString[allResOfClass[i].day]; // convert day from integers to map 
                ws.Cells[i + 2, 2] = course.name;
                ws.Cells[i + 2, 3] = course.courseNamedId;
                ws.Cells[i + 2, 4] = allResOfClass[i].from + x.stInput.Value.Hour;
                ws.Cells[i + 2, 5] = allResOfClass[i].to + x.stInput.Value.Hour;
                if (model == "program")
                {
                    //get the name of the classroom of this reservation
                    ws.Cells[i + 2, 6] = Classroom.getClassroomById(allResOfClass[i].classId)[0].name;
                }
            }
            ws.Name = name;
        }
        void saveClassroomsinExcel(DoWorkEventArgs e)
        {
            object misValue = System.Reflection.Missing.Value;
            // To create workbook
            Excel.Application classroomsApp = new Excel.Application();
            Excel.Workbook wb = classroomsApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            classroomsApp.DisplayAlerts = false;
            List<Classroom> classrooms = Classroom.getAll();

            int savedClasses = 0;
            //this.label1.Text += "\n saving classroom in excel ...";
            foreach (Classroom classroom in classrooms)
            {
                savedClasses++;
                List<Reservation> allResOfClass = Reservation.getResByClassId(classroom.id);
                genWorksheets(allResOfClass, classroomsApp, wb, classroom.name, "classroom");
                
                backgroundWorker1.ReportProgress(Convert.ToInt32(savedClasses * 100 / classrooms.Count));
                if (backgroundWorker1.CancellationPending)
                {
                    e.Cancel = true;
                    backgroundWorker1.ReportProgress(0);
                    return;
                }
                
            }
            //this.label1.Text += " ... done";

            Excel.Sheets sheet1 = wb.Worksheets;
            sheet1[sheet1.Count].delete();
            string path = System.IO.Directory.GetCurrentDirectory();
            wb.SaveAs(@path + "/classrooms.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            wb.Close(true, misValue, misValue);
        }

        void saveProgramssinExcel(DoWorkEventArgs e)
        {
            object misValue = System.Reflection.Missing.Value;
            // To create workbook
            Excel.Application classroomsApp = new Excel.Application();
            Excel.Workbook wb = classroomsApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            classroomsApp.DisplayAlerts = false;
            List<Model.Program> programs = Model.Program.getAll();
            int savedProg = 0;
            //this.label1.Text += "\n saving program in excel ...";
            foreach (Model.Program program in programs)
            {
                savedProg++;
                List<Reservation> allResOfProg = ReservationHasProgram.getProgramReservations(program.id);
                genWorksheets(allResOfProg, classroomsApp, wb, program.name, "program");
                
                backgroundWorker1.ReportProgress(Convert.ToInt32(savedProg * 100 / programs.Count));
                if (backgroundWorker1.CancellationPending)
                {
                    e.Cancel = true;
                    backgroundWorker1.ReportProgress(0);
                    return;
                }
                
            }
            //this.label1.Text += "... done";
            Excel.Sheets sheet1 = wb.Worksheets;
            sheet1[sheet1.Count].delete();
            string path = System.IO.Directory.GetCurrentDirectory();
            wb.SaveAs(@path + "/programs.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            wb.Close(true, misValue, misValue);
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Scheduler scheduler = new Scheduler(getCourses(Data.SchedulerConfigs.selectedTerm), getClassrooms(), Data.SchedulerConfigs.maxTime, Data.SchedulerConfigs.maxDays);
            scheduler.addOnNewReservation(onNewReservation);
             scheduler.start();
            /*t.Start();
            e.Result = "end :)";
            t.Wait();*/
            scheduler.saveReservations();
            saveClassroomsinExcel(e);
            saveProgramssinExcel(e);
        }

        List<Course> getCourses(int term) {
            return Course.getCoursesByTerm(term);
        }

        List<Classroom> getClassrooms() {
            return Classroom.getAll();
        }


        int times = 0;
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //Scheduler scheduler = new Scheduler();
            //int tot = scheduler.getTotal();
            progressBar1.Value = e.ProgressPercentage;
            //label1.Text = e.ProgressPercentage.ToString() + " %";
            
            
            if(e.ProgressPercentage != 100 && times == 0)
            {
                label1.Text = $" ( {reserved.ToString()} ) reserved slots / ( {total.ToString()} ) total slots \n\n {e.ProgressPercentage.ToString()}  %";
            }
            else if (e.ProgressPercentage == 100 && times == 0)
            {
                times++;
                label1.Text = $" ( {reserved.ToString()} ) reserved slots / ( {total.ToString()} ) total slots \n\n {e.ProgressPercentage.ToString()}  %";
                label1.Text += "\n saving Reservations ...";
                
            }
            else if (e.ProgressPercentage != 100 && times == 1)
            {
                label1.Text = "saving classroom in excel ... \n";
                label1.Text += $"{e.ProgressPercentage} %";
            }
            else if (e.ProgressPercentage == 100 && times == 1)
            {
                label1.Text = "saving classroom in excel ... done";
                times++;
            }
            else if (e.ProgressPercentage != 100 && times == 2)
            {

                label1.Text = "saving program in excel ...\n";
                label1.Text += $"{e.ProgressPercentage} %";
            }
            else if (e.ProgressPercentage == 100 && times == 2)
            {
                label1.Text += $"\n ...done";
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                label1.Text = "Scheduling has been canceled";
                res = "Scheduling has been canceled";
                this.Close();
            }
            else if (e.Error != null)
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
            if (backgroundWorker1.IsBusy)
            {
                backgroundWorker1.CancelAsync();
                this.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e) {

        }
    }
}
