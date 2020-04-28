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
    public partial class viewResourcesForm : Form
    {
        
        public string conString = "Data Source=localhost;Initial Catalog=course_scheduler;Integrated Security=True";
        public viewResourcesForm()
        {
            InitializeComponent();
        }
        
        private void viewResourcesForm_Load(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection(conString))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM resource", cn))
                {
                    DataTable dt = new DataTable();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                    this.resourceData.DataSource = dt;
                }
            }
        }

        public void loaddata()// this function is called when the user is inserted a new tuple in the database from addResourceForm  
        {
            using (SqlConnection cn = new SqlConnection(conString))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM resource", cn))
                {
                    DataTable dt = new DataTable();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                    this.resourceData.DataSource = dt;
                }
            } 
        }
        
        private void resourceData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            addResourceForm resDataPassed = new addResourceForm(resourceData.SelectedRows[0].Cells[1].Value.ToString());
            resDataPassed.Show();
        }

        private void newResourceBTN_Click(object sender, EventArgs e)
        {
            addResourceForm addCoursePopup = new addResourceForm();
            DialogResult dialogResult = addCoursePopup.ShowDialog();
        }

        private void deleteResourceBTN_Click(object sender, EventArgs e)
        {
            string selected_id = resourceData.SelectedRows[0].Cells[0].Value.ToString();
            SqlConnection cn = new SqlConnection(conString);
            cn.Open();
            if (cn.State == System.Data.ConnectionState.Open)
            {
                string query = "delete from resource where id = " + selected_id ;
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.ExecuteNonQuery();
                //--the following three lines is used to update the dataGridView and refresh it --//
                this.loaddata();
                this.resourceData.Update();
                this.resourceData.Refresh();
                //---//
                MessageBox.Show("Resource is deleted successfully..!");

            }
        }


        private void editResourceBTN_Click(object sender, EventArgs e)
        {
            addResourceForm resDataPassed = new addResourceForm(resourceData.SelectedRows[0].Cells[1].Value.ToString());
            /*resourceData.EndEdit();
            editResourceBTN.Focus();*/
            resDataPassed.Show();
            
        }

        private void saveResourceBTN_Click(object sender, EventArgs e)
        {

        }
    }
}
