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

namespace university_scheduler
{
    public partial class viewCoursesForm : Form
    {
        public string conString = env.db_con_str;

        public viewCoursesForm()
        {
            InitializeComponent();
            this.loaddata();
        }

        private void viewCoursesForm_Load(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection(conString))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM course", cn))
                {
                    DataTable dt = new DataTable();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                    this.courseData.DataSource = dt;
                }
            }
        }

        public void loaddata()// this function will call when the user insert a new tuple in the database from addCourseForm  
        {
            using (SqlConnection cn = new SqlConnection(conString))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM course", cn))
                {
                    DataTable dt = new DataTable();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                    this.courseData.DataSource = dt;
                }
            }
        }

        private void courseData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            addCourseForm resDataPassed = new addCourseForm((int)courseData.SelectedRows[0].Cells[0].Value);
            resDataPassed.Show();
        }

        private void newCourseBTN_Click(object sender, EventArgs e)
        {
            addCourseForm addCoursePopup = new addCourseForm();
            DialogResult dialogResult = addCoursePopup.ShowDialog();
            this.loaddata();
            courseData.Update();
            courseData.Refresh();
        }
        private void editCourseBTN_Click(object sender, EventArgs e)
        {
            addCourseForm courseDataPassed = new addCourseForm((int)courseData.SelectedRows[0].Cells[0].Value);
            courseDataPassed.ShowDialog(this);
            this.loaddata();
            courseData.Update();
            courseData.Refresh();
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

            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void courseData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


    }
}
