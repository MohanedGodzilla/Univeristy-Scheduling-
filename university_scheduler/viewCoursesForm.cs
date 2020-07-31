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

namespace university_scheduler
{
    public partial class viewCoursesForm : Form
    {
        public string conString = env.db_con_str;
        public int viewCourse_disableSaveBTN = 0;

        public viewCoursesForm()
        {
            InitializeComponent();
            //this.loaddata();
        }
       

        public viewCoursesForm(int flag)
        {
            InitializeComponent();
            this.viewCourse_disableSaveBTN = flag;
            //this.loaddata();
            var control = this.tableLayoutPanel1.GetControlFromPosition(1, 0);
            this.tableLayoutPanel1.Controls.Remove(control);
            TableLayoutColumnStyleCollection styles = this.tableLayoutPanel1.ColumnStyles;
            styles[1].Width = 0;
        }

        public void connShowCourse()
        {
            using (SqlConnection cn = new SqlConnection(conString))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT id,name,course_named_id as 'code',lecture_hours as 'lec hours',practice_hours as 'sec hours',lab_hours as 'lab hours' FROM course", cn))
                {
                    DataTable dt = new DataTable();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                    this.courseData.DataSource = dt;
                    cn.Close();
                }
                courseData.Columns[0].Width = 40;
                courseData.Columns[1].Width = 180;
                courseData.Columns[3].Width = 60;
                courseData.Columns[4].Width = 60;
                courseData.Columns[5].Width = 60;
            }
        }

        private void viewCoursesForm_Load(object sender, EventArgs e)
        {
            connShowCourse();
        }

        public void loaddata()// this function will call when the user insert a new tuple in the database from addCourseForm  
        {
            connShowCourse();
        }

        private void courseData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.viewCourse_disableSaveBTN == 0)
            {
                addCourseForm courseDataPassed = new addCourseForm((int)courseData.SelectedRows[0].Cells[0].Value,0);
                courseDataPassed.Text = "Edit Course";
                courseDataPassed.ShowDialog(this);
            }
            else if (this.viewCourse_disableSaveBTN == 1)
            {
                addCourseForm courseDataPassed = new addCourseForm((int)courseData.SelectedRows[0].Cells[0].Value,1);
                courseDataPassed.Text = "Edit Course";
                courseDataPassed.ShowDialog(this);
            }
        }

        private void newCourseBTN_Click(object sender, EventArgs e)
        {
            addCourseForm addCoursePopup = new addCourseForm();
            DialogResult dialogResult = addCoursePopup.ShowDialog();
        }
        private void editCourseBTN_Click(object sender, EventArgs e)
        {
            addCourseForm courseDataPassed = new addCourseForm((int)courseData.SelectedRows[0].Cells[0].Value,0);
            courseDataPassed.Text = "Edit Course";
            courseDataPassed.ShowDialog(this);
        }
        private void deleteCourseBTN_Click(object sender, EventArgs e)
        {
            int selected_id = (int)courseData.SelectedRows[0].Cells[0].Value;
            SqlConnection cn = new SqlConnection(conString);
            cn.Open();
            if (cn.State == System.Data.ConnectionState.Open)
            {
                string query = "delete from course where id = " + selected_id;
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.ExecuteNonQuery();
                //--the following three lines is used to update the dataGridView and refresh it --//
                this.loaddata();
                this.courseData.Update();
                this.courseData.Refresh();
                //---//
                MessageBox.Show("Course is deleted successfully..!");
                cn.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable dtClass = Course.search();
            DataView DV = new DataView(dtClass);
            DV.RowFilter = string.Format("name LIKE '%{0}%'", textBox1.Text);
            courseData.DataSource = DV;
        }

        private void deleteAllBTN_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(conString);
            cn.Open();
            if (cn.State == System.Data.ConnectionState.Open)
            {
                string message = "By clicking OK, All Courses will be permenantly DELETED\nmake sure from your choice";
                string title = " All courses will be deleted";
                MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (result != DialogResult.OK)
                {
                    return;
                }
                else
                {
                    string query = "delete from course";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "DBCC CHECKIDENT (course, RESEED, 0)";
                    cmd.ExecuteNonQuery();
                    //--the following three lines is used to update the dataGridView and refresh it --//
                    this.loaddata();
                    this.courseData.Update();
                    this.courseData.Refresh();
                    cn.Close();
                    //---//
                    MessageBox.Show("All Courses are deleted successfully..!");
                }
            }
        }
    }
}
