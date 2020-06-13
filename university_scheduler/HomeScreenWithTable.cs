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
            getNamesForViews("class", classroomsExcel);
            getNamesForViews("program", programsExcel);
        }


        void getNamesForViews(string table, System.Windows.Forms.DataGridView excelView )  {
            using (SqlConnection cn = new SqlConnection(env.db_con_str))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand($"select name from {table} ORDER BY case isnumeric(name) when 1 then convert(int,name)else 999999 end", cn))
                {
                    DataTable dt = new DataTable();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                    excelView.DataSource = dt;
                    cn.Close();
                }
                excelView.Columns[0].Width = 350;
                //
            }
        }

        private void classroomsExcel_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Open specified Worksheet on Workbook
            Excel.Application classroomsApp = new Excel.Application();
            string name = classroomsExcel.SelectedRows[0].Cells[0].Value.ToString();
            classroomsApp.Visible = true;
            Excel.Workbooks books = classroomsApp.Workbooks;
            string path = System.IO.Directory.GetCurrentDirectory();
            Excel.Workbook book = books.Open(@path + "/classrooms.xls");
            Excel.Worksheet worksheet = (Excel.Worksheet)book.Sheets[name];
            worksheet.Activate();
        }

        private void programsExcel_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Open specified Worksheet on Workbook
            Excel.Application programsApp = new Excel.Application();
            string name = programsExcel.SelectedRows[0].Cells[0].Value.ToString();
            programsApp.Visible = true;
            Excel.Workbooks books = programsApp.Workbooks;
            string path = System.IO.Directory.GetCurrentDirectory();
            Excel.Workbook book = books.Open(@path + "/programs.xls");
            Excel.Worksheet worksheet = (Excel.Worksheet)book.Sheets[name];
            worksheet.Activate();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable dtClass = Classroom.search();
            DataView DV = new DataView(dtClass);
            DV.RowFilter = string.Format("name LIKE '%{0}%'", searchClass.Text);
            classroomsExcel.DataSource = DV;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            DataTable dtProgram = Model.Program.search();
            DataView DV = new DataView(dtProgram);
            DV.RowFilter = string.Format("name LIKE '%{0}%'", searchProgram.Text);
            programsExcel.DataSource = DV;
        }

        private void generateNewBTN_Click(object sender, EventArgs e)
        {
            this.Hide();
            NoScheduleHome Popup = new NoScheduleHome();
            Popup.ShowDialog();
            this.Close();
        }

        private void viewBTN_Click(object sender, EventArgs e)
        {
            NoScheduleHome Popup = new NoScheduleHome();
            //Popup.panel2.Hide();
            var control = Popup.tableLayoutPanel1.GetControlFromPosition(1, 0);
            Popup.tableLayoutPanel1.Controls.Remove(control);
            TableLayoutColumnStyleCollection styles = Popup.tableLayoutPanel1.ColumnStyles;
            styles[1].Width = 0;
            viewResourcesForm res = new viewResourcesForm();
            Popup.Size = new System.Drawing.Size(1000, 600);
            Popup.Show();
            
        }

        /*private void controlSecondColumn() {
            viewResourcesForm res = new viewResourcesForm();
            res.tableLayoutPanel2.Hide();
            var control1 = res.tableLayoutPanel1.GetControlFromPosition(1, 0);
            res.tableLayoutPanel1.Controls.Remove(control1);
            TableLayoutColumnStyleCollection styles1 = res.tableLayoutPanel1.ColumnStyles;
            styles1[1].Width = 0;

            viewProgramForm pro = new viewProgramForm();
            var control2 = pro.tableLayoutPanel1.GetControlFromPosition(1, 0);
            pro.tableLayoutPanel1.Controls.Remove(control2);
            TableLayoutColumnStyleCollection styles2 = pro.tableLayoutPanel1.ColumnStyles;
            styles2[1].Width = 0;

            viewClassroomForm classroom = new viewClassroomForm();
            var control3 = classroom.tableLayoutPanel1.GetControlFromPosition(1, 0);
            classroom.tableLayoutPanel1.Controls.Remove(control3);
            TableLayoutColumnStyleCollection styles3 = classroom.tableLayoutPanel1.ColumnStyles;
            styles3[1].Width = 0;

            viewCoursesForm course = new viewCoursesForm();
            var control4 = course.tableLayoutPanel1.GetControlFromPosition(1, 0);
            course.tableLayoutPanel1.Controls.Remove(control4);
            TableLayoutColumnStyleCollection styles4 = course.tableLayoutPanel1.ColumnStyles;
            styles4[1].Width = 0;
        }*/
    }
}
