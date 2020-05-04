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
    public partial class addCourseForm : Form
    {
        
        public string conString =env.db_con_str ;
        public int courseId;

        public addCourseForm()
        {
            InitializeComponent();
            addCourseBTN.Show();
            saveBTN.Hide();
        }
        public addCourseForm(int courseId)
        {
            
            InitializeComponent();
            this.courseId = courseId;
            addCourseBTN.Hide();
            saveBTN.Show();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void addCourseForm_Load(object sender, EventArgs e)
        {
            termCombo.SelectedIndex = 0;
        }
        

        private void addCourseBTN_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(conString);
            cn.Open();
            if (cn.State == System.Data.ConnectionState.Open)
            {
                int val=0;
                if(isActive.Checked == true)
                {
                    val = 1;
                }
                string query = "insert into course(name,credit_hours,lecture_hours,practice_hours,lab_hours,term,course_named_id,actived) values(" +"'" +courseName.Text.ToString() + "' , '" + creditHours.Text + "' , '" + lecHours.Text + "' , '" + practiceHours.Text + "' , '" + labHours.Text + "' , '" + (termCombo.SelectedIndex + 1) + "' , '" + courseCode.Text + "' , '" + val+"' )";
                SqlCommand cmd = new SqlCommand(query, cn);

                cmd.ExecuteNonQuery();
                //---//
                MessageBox.Show("Adding course successfully..!");
                this.Close();
            }

        }

        private void saveBTN_Click(object sender, EventArgs e)
        {
            int selected_id = courseId;
            SqlConnection cn = new SqlConnection(conString);
            cn.Open();
            if (cn.State == System.Data.ConnectionState.Open)
            {
                int val = 0;
                if (isActive.Checked == true)
                {
                    val = 1;
                }
                string query = "UPDATE course SET name = '"+courseName.Text + "' , credit_hours = '" + creditHours.Value + "' , lecture_hours = '" + lecHours.Value + "' , practice_hours = '" + practiceHours.Text + "' , lab_hours = '" + labHours.Text + "' , term = '" + (termCombo.SelectedIndex + 1) + "' , course_named_id =  '" + courseCode.Text + "' , actived = '" + val + "' WHERE id = " + selected_id;
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.ExecuteNonQuery();
                //---//
                MessageBox.Show("updateing course successfully...!");
                this.Close();
            }
        }


        private void cancelBTN_Click(object sender, EventArgs e)
        {
            this.Close();

        }


        private void selectResource_Click(object sender, EventArgs e)
        {
            selectResourceForm resForm = new selectResourceForm();
            DialogResult dialogresult = resForm.ShowDialog();
        }
        private void selectProgramBTN_Click(object sender, EventArgs e)
        {
            selectProgramForm progForm = new selectProgramForm();
            DialogResult dialogresult = progForm.ShowDialog();
        }

        private void courseName_TextChanged(object sender, EventArgs e)
        {

        }

        private void courseCode_TextChanged(object sender, EventArgs e)
        {

        }



        private void show_EditForm()
        {
            //this function to show data in Edit form

        }
    }
}
