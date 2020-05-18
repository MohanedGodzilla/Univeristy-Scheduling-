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

        public string conString = env.db_con_str;

        public viewResourcesForm()
        {
            InitializeComponent();
        }

        //The following function for bring data from database
        public void connShowResource() {
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
                    cn.Close();
                }
            }
        }

        private void viewResourcesForm_Load(object sender, EventArgs e)
        {
            connShowResource();
        }

        // this function is called when the user inserted a new tuple in the database from addResourceForm  
        public void loaddata()
        {
            connShowResource();
        }

        //The following function for add a new Resource 
        private void newResourceBTN_Click(object sender, EventArgs e)
        {
            addResourceForm addResourcePopup = new addResourceForm();
            DialogResult dialogResult = addResourcePopup.ShowDialog();
        }

        //The following function for delete resource 
        private void deleteResourceBTN_Click(object sender, EventArgs e)
        {
            if (!canUpdate()) return;
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
                cn.Close();
                //---//
                MessageBox.Show("Resource is deleted successfully..!");

            }
        }

        //The following function for Edit the resources 

        public void passData_AddResourceForm() {
            if (!canUpdate()) return;
            addResourceForm resDataPassed = new addResourceForm((int)resourceData.SelectedRows[0].Cells[0].Value);
            resDataPassed.ShowDialog(this);
        }

        private void editResourceBTN_Click(object sender, EventArgs e)
        {
            passData_AddResourceForm();
            
        }

        private void resourceData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            passData_AddResourceForm();
        }

        bool canUpdate()
        {
            return (resourceData.SelectedRows != null &&
                resourceData.SelectedRows.Count > 0 &&
                resourceData.SelectedRows[0].Cells[0].Value != null);
        }

        private void resourceData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
