using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using university_scheduler.Model;

namespace university_scheduler
{
    public partial class viewClassroomForm : Form
    {
        public string conString = env.db_con_str;
        public viewClassroomForm()
        {
            InitializeComponent();
            this.loaddata();
            classData.Columns[0].Width = 40;
            classData.Columns[1].Width = 400;
            classData.Columns[2].Width = 60;
            classData.Columns[3].Width = 60;
        }

        public viewClassroomForm(int flag)
        {
            InitializeComponent();
            this.loaddata();
            classData.Columns[0].Width = 40;
            classData.Columns[1].Width = 400;
            classData.Columns[2].Width = 60;
            classData.Columns[3].Width = 60;
            var control = this.tableLayoutPanel1.GetControlFromPosition(1, 0);
            this.tableLayoutPanel1.Controls.Remove(control);
            TableLayoutColumnStyleCollection styles = this.tableLayoutPanel1.ColumnStyles;
            styles[1].Width = 0;
        }

        private void viewClassroomForm_Load_1(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection(conString))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT id,name,lecture_capacity as 'lec cap' , exam_capacity as 'exam cap'  FROM class", cn))
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
                using (SqlCommand cmd = new SqlCommand("SELECT id,name,lecture_capacity as 'lec cap' , exam_capacity as 'exam cap' FROM class", cn))
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
            this.loaddata();
            classData.Update();
            classData.Refresh();
        }

        private void editClassRoomBTN_Click(object sender, EventArgs e)
        {
            addClassRoomForm classRoomDataPassed = new addClassRoomForm((int)classData.SelectedRows[0].Cells[0].Value);
            classRoomDataPassed.Text = "Edit Classroom";
            classRoomDataPassed.ShowDialog(this);
            this.loaddata();
            classData.Update();
            classData.Refresh();
        }

        private void deleteClassRoomBTN_Click(object sender, EventArgs e)
        {
            int selected_id = (int)classData.SelectedRows[0].Cells[0].Value;
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
            addClassRoomForm classRoomDataPassed = new addClassRoomForm((int)classData.SelectedRows[0].Cells[0].Value);
            classRoomDataPassed.ShowDialog(this);
            classData.Update();
            classData.Refresh();
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable dtClass = Classroom.search(1);
            DataView DV = new DataView(dtClass);
            DV.RowFilter = string.Format("name LIKE '%{0}%'", textBox1.Text);
            classData.DataSource = DV;
        }
    }
}
