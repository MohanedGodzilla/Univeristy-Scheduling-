using System;
using System.Collections.Generic;
using System.Windows.Forms;
using university_scheduler.Data;
using university_scheduler.Model;
using Excel = Microsoft.Office.Interop.Excel;

namespace university_scheduler
{
    public partial class NoScheduleHome : Form
    {
        Scheduler scheduler;
        public NoScheduleHome()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 5;
            courses_view();
            programs_view();
            classrooms_view();
            resourses_view();
        }
        
        private void NoScheduleHome_Load(object sender, EventArgs e)
        {
            stInput.ShowUpDown = true;
            etInput.ShowUpDown = true;
            
            /*Generator gen = new Generator();
             gen.generateResource();
             gen.generateProgram();
             gen.generateCourse();
             gen.generateClassroom();*/
            //scheduler = new Scheduler();

        }

        private void courses_view() {
            viewCoursesForm frm = new viewCoursesForm() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.coursesView.Controls.Add(frm);
            frm.Show();
        }
        private void programs_view()
        {
            viewProgramForm frm = new viewProgramForm() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.programsView.Controls.Add(frm);
            frm.Show();
        }
        private void classrooms_view()
        {
            viewClassroomForm frm = new viewClassroomForm() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.classroomsView.Controls.Add(frm);
            frm.Show();
        }
        private void resourses_view()
        {
            viewResourcesForm frm = new viewResourcesForm() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.resourcesView.Controls.Add(frm);
            frm.Show();
        }

        private void stInput_ValueChanged(object sender, EventArgs e)
        {

        }

        private void coursesView_Click(object sender, EventArgs e)
        {

        }

        private void generateBTN_Click(object sender, EventArgs e) {
            //scheduler.start();
            saveClassroomsinExcel();
            HomeScreenWithTable Popup = new HomeScreenWithTable();
            DialogResult dialogResult = Popup.ShowDialog();
        }

        void saveClassroomsinExcel()
        {
            object misValue = System.Reflection.Missing.Value;
            // To create workbook
            Excel.Application classroomsApp = new Excel.Application();
            Excel.Workbook wb = classroomsApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            classroomsApp.DisplayAlerts = false;
            List<Classroom> classrooms = Classroom.getAll();
            foreach (Classroom classroom in classrooms)
            {
                List<Reservation> allResOfClass = Reservation.getResByClassId(classroom.id);
                genWorksheets(allResOfClass, classroomsApp, wb, classroom);
            }
            Excel.Sheets sheet1 = wb.Worksheets;
            sheet1[sheet1.Count].delete();
            string path = System.IO.Directory.GetCurrentDirectory();
            wb.SaveAs(@path+"/classrooms.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            wb.Close(true, misValue, misValue);
            /*Excel.Workbooks books = classroomsApp.Workbooks;
            Excel.Workbook book = books.Open(@"D:\classrooms.xls");*/
        }

        void genWorksheets(List<Reservation> allResOfClass, Excel.Application classroomsApp, Excel.Workbook wb, Classroom classroom)
        {

            Excel.Worksheet ws = (Excel.Worksheet)classroomsApp.Worksheets.Add();

            /* Excel.Worksheet ws = new Excel.Worksheet();
             ws = (Excel.Worksheet)wb.ActiveSheet;*/

            //Header
            ws.Cells[1] = "Course Name";
            ws.Cells[2] = "Course Code";
            ws.Cells[3] = "Day";
            ws.Cells[4] = "From";
            ws.Cells[5] = "To";

            //cells
            for (int i = 0; i < allResOfClass.Count; i++)
            {
                Course course = Course.getCourseById(allResOfClass[i].courseId);
                ws.Cells[i + 2, 1] = course.name;
                ws.Cells[i + 2, 2] = course.courseNamedId;
                ws.Cells[i + 2, 3] = allResOfClass[i].day;
                ws.Cells[i + 2, 4] = allResOfClass[i].from;
                ws.Cells[i + 2, 5] = allResOfClass[i].to;
            }
            ws.Name = classroom.name;
            /* //Open specified Worksheet on Workbook 
             Excel.Workbooks books = classroomsApp.Workbooks;*/
            //  Excel.Workbook book = books.Open(@"D:\Programs.xls");
            //Excel.Worksheet worksheet = (Excel.Worksheet)book.Sheets[ws.Name];
            //   ws.Activate();


        }
    }
}
