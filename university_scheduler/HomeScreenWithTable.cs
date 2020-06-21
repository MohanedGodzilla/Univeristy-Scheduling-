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
        public string conString = env.db_con_str;
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
            int returnJustName = 2;
            DataTable dtClass = Classroom.search(returnJustName);
            DataView DV = new DataView(dtClass);
            DV.RowFilter = string.Format("name LIKE '%{0}%'", searchClass.Text);
            classroomsExcel.DataSource = DV;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            int returnJustName = 2;
            DataTable dtProgram = Model.Program.search(returnJustName);
            DataView DV = new DataView(dtProgram);
            DV.RowFilter = string.Format("name LIKE '%{0}%'", searchProgram.Text);
            programsExcel.DataSource = DV;
        }

        private void generateNewBTN_Click(object sender, EventArgs e)
        {
            string message = "By clicking OK, All reservations will be permenantly DELETED\nmake sure from your choice";
            string title = " All reservations will be deleted";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (result != DialogResult.OK)
            {
                return;
            }
            else
            {
                SqlConnection cn = new SqlConnection(conString);
                cn.Open();
                string query = "delete from reservation_has_program";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.ExecuteNonQuery();
                cmd.CommandText = "DBCC CHECKIDENT (reservation, RESEED, 0)";
                cmd.ExecuteNonQuery();

                query = "delete from reservation";
                cmd = new SqlCommand(query, cn);
                cmd.ExecuteNonQuery();
                cmd.CommandText = "DBCC CHECKIDENT (reservation, RESEED, 0)";
                cmd.ExecuteNonQuery();
                cn.Close();
                //---//
                MessageBox.Show("All reservations are deleted successfully..!");
                NoScheduleHome Popup = new NoScheduleHome();
                Popup.MdiParent = this.ParentForm;
                this.Hide();
                Popup.ShowDialog();
                this.Close();
            }
        }

        private void viewBTN_Click(object sender, EventArgs e)
        {
            int comeFromThisForm = 1;
            NoScheduleHome Popup = new NoScheduleHome(comeFromThisForm);
            var control = Popup.tableLayoutPanel1.GetControlFromPosition(1, 0);
            Popup.tableLayoutPanel1.Controls.Remove(control);
            TableLayoutColumnStyleCollection styles = Popup.tableLayoutPanel1.ColumnStyles;
            styles[1].Width = 0;
            Popup.Size = new System.Drawing.Size(800, 642);
            Popup.Show();
        }

        private void aboutBTN_Click(object sender, EventArgs e)
        {
            aboutUs Popup = new aboutUs();
            Popup.Show();
        }
    }
}
