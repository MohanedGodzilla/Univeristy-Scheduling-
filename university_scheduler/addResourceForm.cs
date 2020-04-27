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
    public partial class addResourceForm : Form
    {
        public string conString = "Data Source = localhost; Initial Catalog = course_scheduler; Integrated Security = True";

        viewResourcesForm resForm = (viewResourcesForm)Application.OpenForms["viewResourcesForm"];// it's an object that is used in function addResourceBTN_Click() to reopen the form when adding a new tuple in the database

        public addResourceForm()
        {
            InitializeComponent();
            addResourceBTN.Show();
            saveResourceBTN.Hide();
        }

        public addResourceForm(string name) // constructor to get resourceName from (dataset)=>resourceData
        {
            InitializeComponent();
            addResourceBTN.Hide();
            saveResourceBTN.Show();
            resourceName.Text = name;
        }

        private void addResourceForm_Load(object sender, EventArgs e)
        {
            resourceCompo.SelectedIndex = 0; // to show the first index as the default value
        }
        

        private void addResourceBTN_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(conString);
            cn.Open();
            if (cn.State == System.Data.ConnectionState.Open)
            {
                string query = "insert into resource(name) values('" + resourceName.Text.ToString() + "')";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.ExecuteNonQuery();
                //--the following three lines is used to update the dataGridView and refresh it --//
                resForm.loaddata();
                resForm.resourceData.Update();
                resForm.resourceData.Refresh();
                //---//
                MessageBox.Show("Adding resource successfully..!");

            }
        }

        private void cancelResourceBTN_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveResourceBTN_Click(object sender, EventArgs e)
        {
            string selected_id = resForm.resourceData.SelectedRows[0].Cells[0].Value.ToString();
            SqlConnection cn = new SqlConnection(conString);
            cn.Open();
            if (cn.State == System.Data.ConnectionState.Open)
            {
                string query = "UPDATE resource SET name = '" + resourceName.Text.ToString() + "' WHERE id = " + selected_id;
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.ExecuteNonQuery();
                //--the following three lines is used to update the dataGridView and refresh it --//
                resForm.loaddata();
                resForm.resourceData.Update();
                resForm.resourceData.Refresh();
                //---//
                MessageBox.Show("updateing resource successfully..!");

            }
        }

        private void resourceName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
