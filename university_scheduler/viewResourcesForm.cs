using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using university_scheduler.Model;
using System.Windows.Forms;

namespace university_scheduler
{
    public partial class viewResourcesForm : Form
    {

        public string conString = env.db_con_str;
        public int viewResource_disableSaveBTN = 0;
        public viewResourcesForm()
        {
            InitializeComponent();
        }

        public viewResourcesForm(int flag)
        {
            InitializeComponent();
            this.viewResource_disableSaveBTN = flag;
            var control = this.tableLayoutPanel1.GetControlFromPosition(1, 0);
            this.tableLayoutPanel1.Controls.Remove(control);
            TableLayoutColumnStyleCollection styles = this.tableLayoutPanel1.ColumnStyles;
            styles[1].Width = 0;
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
                resourceData.Columns[0].Width = 40;
                resourceData.Columns[1].Width = 500;
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
            if (this.viewResource_disableSaveBTN == 0){
                if (!canUpdate()) return;
                addResourceForm resDataPassed = new addResourceForm((int)resourceData.SelectedRows[0].Cells[0].Value,0);
                resDataPassed.ShowDialog(this);
            }
            else if(this.viewResource_disableSaveBTN == 1){
                if (!canUpdate()) return;
                addResourceForm resDataPassed = new addResourceForm((int)resourceData.SelectedRows[0].Cells[0].Value, 1);
                resDataPassed.ShowDialog(this);
            }
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable dtClass = Resource.search();
            DataView DV = new DataView(dtClass);
            DV.RowFilter = string.Format("name LIKE '%{0}%'", textBox1.Text);
            resourceData.DataSource = DV;
        }

        private void deleteAllBTN_Click(object sender, EventArgs e)
        {
            if (!canUpdate()) return;
            SqlConnection cn = new SqlConnection(conString);
            cn.Open();
            if (cn.State == System.Data.ConnectionState.Open)
            {
                string message = "By clicking OK, All Resources will be permenantly DELETED\nmake sure from your choice";
                string title = " All resources will be deleted";
                MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (result != DialogResult.OK)
                {
                    return;
                }
                else {
                    string query = "delete from resource";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "DBCC CHECKIDENT (resource, RESEED, 0)";
                    cmd.ExecuteNonQuery();
                    //--the following three lines is used to update the dataGridView and refresh it --//
                    this.loaddata();
                    this.resourceData.Update();
                    this.resourceData.Refresh();
                    cn.Close();
                    //---//
                    MessageBox.Show("All Resources are deleted successfully..!");
                }
            }
        }
    }
}
