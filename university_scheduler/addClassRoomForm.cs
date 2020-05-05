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
    public partial class addClassRoomForm : Form
    {
        public string conString = env.db_con_str;

        viewClassroomForm classForm = (viewClassroomForm)Application.OpenForms["viewClassroomForm"];// it's an object that is used in function addClassRoomBTN_Click() to reopen the form when adding a new tuple in the database 
        public addClassRoomForm()
        {
            InitializeComponent();
            addClassBTN.Show();
            saveClassBTN.Hide();
        }

        public addClassRoomForm(int lecCap, string name, int examCap) // constructor to get resourceName from (dataset)=>resourceData
        {
            InitializeComponent();
            addClassBTN.Hide();
            saveClassBTN.Show();
            className.Text = name;
            this.lecCounter.Value = lecCap;
            this.examCounter.Value = examCap;
        }

        private void addClassRoomForm_Load(object sender, EventArgs e)
        {
            
        }

        private void saveClassBTN_Click(object sender, EventArgs e)
        {
            string selected_id = classForm.classData.SelectedRows[0].Cells[0].Value.ToString();
            SqlConnection cn = new SqlConnection(conString);
            cn.Open();
            if (cn.State == System.Data.ConnectionState.Open)
            {
                //"insert into class(name, lecture_capacity, exam_capacity) values( '" + className.Text.ToString() + "' ,'" + lecCounter.Value + "' ,'" + examCounter.Value + "' )";
                string query = "UPDATE class SET name = '" + className.Text.ToString() + "', lecture_capacity = '" + lecCounter.Value + "',exam_capacity = '" + examCounter.Value + "' WHERE id = " + selected_id;
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.ExecuteNonQuery();
                //--the following three lines is used to update the dataGridView and refresh it --//
                classForm.loaddata();
                classForm.classData.Update();
                classForm.classData.Refresh();
                //---//
                MessageBox.Show("updateing class successfully..!");

            }
            this.Close();
        }

        private void addClassBTN_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(conString);
            cn.Open();
            if (cn.State == System.Data.ConnectionState.Open)
            {
                string query = "insert into class(name, lecture_capacity, exam_capacity) values( '"+className.Text.ToString()+ "' ,'"+lecCounter.Value+ "' ,'" + examCounter.Value + "' )";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.ExecuteNonQuery();
                //--the following three lines is used to update the dataGridView and refresh it --//
                classForm.loaddata();
                classForm.classData.Update();
                classForm.classData.Refresh();
                //---//
                MessageBox.Show("Adding class successfully..!");

            }
            this.Close();
        }

        private void cancelClassBTN_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void className_TextChanged(object sender, EventArgs e)
        {

        }

        private void lecCounter_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
