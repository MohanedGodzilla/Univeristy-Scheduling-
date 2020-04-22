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

        public string conString = "Data Source = localhost; Initial Catalog = course_scheduler; Integrated Security = True";
        public viewResourcesForm()
        {
            InitializeComponent();
        }
        
        private void viewResourcesForm_Load(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection("conString"))
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
            using (SqlConnection cn = new SqlConnection("conString"))
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

        private void Button1_Click(object sender, EventArgs e)
        {
            addResourceForm addCoursePopup = new addResourceForm();
            DialogResult dialogResult = addCoursePopup.ShowDialog();
        }

        private void resourceData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            addResourceForm resDataPassed = new addResourceForm(resourceData.SelectedRows[0].Cells[1].Value.ToString());
            resDataPassed.Show();
        }
    }
}
