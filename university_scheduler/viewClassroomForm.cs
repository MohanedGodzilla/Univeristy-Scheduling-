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
    public partial class viewClassroomForm : Form
    {
        public string conString = "Data Source=localhost;Initial Catalog=course_scheduler;Integrated Security=True";
        public viewClassroomForm()
        {
            InitializeComponent();
        }

        private void viewClassroomForm_Load_1(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection(conString))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM class", cn))
                {
                    DataTable dt = new DataTable();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                    this.classData.DataSource = dt;
                }
            }
        }
        public void loaddata()// this function is called when the user is inserted a new tuple in the database from addClassRoomForm  
        {
            using (SqlConnection cn = new SqlConnection(conString))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM class", cn))
                {
                    DataTable dt = new DataTable();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                    this.classData.DataSource = dt;
                }
            }
        }

        private void newClassRoomBTN_Click(object sender, EventArgs e)
        {
            addClassRoomForm addClassRoomPopup = new addClassRoomForm();
            DialogResult dialogResult = addClassRoomPopup.ShowDialog();
        }

        private void editClassRoomBTN_Click(object sender, EventArgs e)
        {
            addClassRoomForm classRoomDataPassed = new addClassRoomForm(classData.SelectedRows[0].Cells[2].Value.ToString());
            classRoomDataPassed.Show();
        }

        private void deleteClassRoomBTN_Click(object sender, EventArgs e)
        {
            string selected_id = classData.SelectedRows[0].Cells[0].Value.ToString();
            SqlConnection cn = new SqlConnection(conString);
            cn.Open();
            if (cn.State == System.Data.ConnectionState.Open)
            {
                string query = "delete from class where id = " + selected_id;
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.ExecuteNonQuery();
                //--the following three lines is used to update the dataGridView and refresh it --//
                this.loaddata();
                this.classData.Update();
                this.classData.Refresh();
                //---//
                MessageBox.Show("class is deleted successfully..!");

            }
        }

        private void classData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            addClassRoomForm classRoomDataPassed = new addClassRoomForm(classData.SelectedRows[0].Cells[2].Value.ToString());
            classRoomDataPassed.Show();
        }
    }
}
