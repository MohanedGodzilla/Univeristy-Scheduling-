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
    public partial class selectResourceForm : Form
    {
        public string conString = "Data Source=localhost;Initial Catalog=course_scheduler;Integrated Security=True";
        public selectResourceForm()
        {
            InitializeComponent();
        }

        private void selectResourceForm_Load(object sender, EventArgs e)
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
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        checkedListBox1.Items.Add(dt.Rows[i]["name"].ToString());

                    }
                }
            }
        }

        private void saveResourceBTN_Click(object sender, EventArgs e)
        {

        }
    }
}
