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

        viewResourcesForm resForm = (viewResourcesForm)Application.OpenForms["viewResourcesForm"];// it's an object that is used in function button2_Click() to reopen the form when adding a new tuple in the database

        public addResourceForm()
        {
            InitializeComponent();
        }

        public addResourceForm(string name) // constructor to get resourceName from (dataset)=>resourceData
        {
            InitializeComponent();
            resourceName.Text = name;
        }

        private void addResourceForm_Load(object sender, EventArgs e)
        {
            resourceCompo.SelectedIndex = 0; // to show the first index as the default value
            //resourceName.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(conString);
            cn.Open();
            if (cn.State == System.Data.ConnectionState.Open){
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
    }
}
