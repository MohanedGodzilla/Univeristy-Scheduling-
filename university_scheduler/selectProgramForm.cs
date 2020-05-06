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
    public partial class selectProgramForm : Form
    {
        public string conString = env.db_con_str;
        public List<int> checkedPrograms;
        private int selected_id;
        private int courseId;
        Dictionary<int, int> idIndexMap = new Dictionary<int, int>();
        public selectProgramForm(int courseId)
        {
            InitializeComponent();
            this.courseId = courseId;
        }

        private void selectProgramForm_Load(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection(conString))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM program", cn))
                {
                    DataTable dt = new DataTable();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        this.idIndexMap[(int)dt.Rows[i]["id"]] = i;
                        checkedListBox1.Items.Add(dt.Rows[i]["name"].ToString());
                    }
                }
                string query = "SELECT program_id FROM program_has_course WHERE course_id = " + this.courseId;
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int id = (int)reader.GetValue(0);
                        checkedListBox1.SetItemChecked(this.idIndexMap[id], true);
                    }
                    reader.Close();
                }
            }
        }


        private void saveProgramBTN_Click(object sender, EventArgs e)
        {
            int i = 0;
            this.checkedPrograms = new List<int>();
            foreach (String s in checkedListBox1.CheckedItems)
            {
                using (SqlConnection cn = new SqlConnection(conString))
                {
                    cn.Open();
                    if (cn.State == System.Data.ConnectionState.Open)
                    {
                        string query = "SELECT id FROM program WHERE name = '" + s + "' ; ";
                        SqlCommand cmd = new SqlCommand(query, cn);
                        cmd.ExecuteNonQuery();
                        this.selected_id = (int)cmd.ExecuteScalar();
                    }
                }
                this.checkedPrograms.Insert(i, this.selected_id);
                i++;
            }
            this.Close();
        }
    }
}
