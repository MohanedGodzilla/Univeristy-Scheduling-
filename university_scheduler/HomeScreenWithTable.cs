using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using university_scheduler.Model;
using Excel = Microsoft.Office.Interop.Excel;

namespace university_scheduler
{
    public partial class HomeScreenWithTable : Form
    {
        public HomeScreenWithTable()
        {
            InitializeComponent();
        }

        private void HomeScreenWithTable_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            object misValue = System.Reflection.Missing.Value;
            // To create workbook
            Excel.Application classroomsApp = new Excel.Application();
            //classroomsApp.Visible = true;
            Excel.Workbook wb = classroomsApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);

            List<Classroom> classrooms=  Classroom.getAll();
            foreach (Classroom classroom in classrooms) {
                List<Reservation> allResOfClass =  Reservation.getResByClassId(classroom.id);
                genWorksheets(allResOfClass,classroomsApp,wb, classroom);
            }
            Excel.Sheets sheet1 = wb.Worksheets;
            sheet1[sheet1.Count].delete();
            wb.SaveAs(@"D:\classrooms.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
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
            for (int i = 0; i < allResOfClass.Count; i++) {
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
