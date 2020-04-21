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
        public viewResourcesForm()
        {
            InitializeComponent();
        }

        private void viewResourcesForm_Load(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection("Data Source = localhost; Initial Catalog = course_scheduler; Integrated Security = True"))
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
    }
}
