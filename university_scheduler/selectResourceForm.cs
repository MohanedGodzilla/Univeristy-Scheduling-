using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace university_scheduler
{
    public partial class selectResourceForm : Form
    {
        public string conString = env.db_con_str;
        public List<int> checkedResource;
        private int courseORclassId;
        private string nameOfTable;
        Dictionary<int, int> idIndexMap = new Dictionary<int, int>();
        Dictionary<int, int> indexIdMap = new Dictionary<int, int>();
        public selectResourceForm(int id, string table)//edit
        {
            InitializeComponent();
            this.courseORclassId = id;
            this.nameOfTable = table;

            loadData(true);
        }

        public selectResourceForm(List<int> selectedIds, string table)
        { //open the form again at adding new course
            InitializeComponent();
            checkedResource = selectedIds;
            this.nameOfTable = table;
            loadData(false);
        }

        private void CheckedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
                checkedResource.Add(indexIdMap[e.Index]);
            else
                checkedResource.Remove(indexIdMap[e.Index]);
        }

        private void selectResourceForm_Load(object sender, EventArgs e)
        {
        /*
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
                        this.idIndexMap[(int)dt.Rows[i]["id"]] = i;
                        checkedListBox1.Items.Add(dt.Rows[i]["name"].ToString());
                    }
                }

                string query = "";

                if (nameOfTable == "class")
                {
                    query = "SELECT resource_id FROM class_has_resource WHERE class_id = " + this.courseORclassId;
                }
                else if (nameOfTable == "course")
                {
                    query = "SELECT resource_id FROM course_has_resource WHERE course_id = " + this.courseORclassId;
                }

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
            */
        }
        private void loadData(bool shouldLoadSelected)
        {
            if (checkedResource == null)
            {
                checkedResource = new List<int>();
            }
            using (SqlConnection cn = new SqlConnection(conString))
            {
                cn.Open();
                getResources(cn);
                if (shouldLoadSelected)
                {
                    checkedResource = new List<int>();
                    loadSelected(cn);
                }
                checkSelected();
                checkedListBox1.ItemCheck += CheckedListBox1_ItemCheck;
            }
        }

        void getResources(SqlConnection cn)
        {
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM resource", cn))
            {
                DataTable dt = new DataTable();
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int progId = (int)dt.Rows[i]["id"];
                    this.idIndexMap[progId] = i;
                    this.indexIdMap[i] = progId;
                    checkedListBox1.Items.Add(dt.Rows[i]["name"].ToString());
                }
            }
        }
        void loadSelected(SqlConnection cn)
        {
            string query = "";

            if (nameOfTable == "class")
            {
                query = "SELECT resource_id FROM class_has_resource WHERE class_id = " + this.courseORclassId;
            }
            else if (nameOfTable == "course")
            {
                query = "SELECT resource_id FROM course_has_resource WHERE course_id = " + this.courseORclassId;
            }

            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int id = (int)reader.GetValue(0);
                    checkedResource.Add(id);
                }
                reader.Close();
            }
        }
        void checkSelected()
        {
            for (int i = 0; i < checkedResource.Count; i++)
            {
                checkedListBox1.SetItemChecked(this.idIndexMap[checkedResource[i]], true);
            }
        }

        private void saveResourceBTN_Click(object sender, EventArgs e)
        {
            /*
            int i = 0;
            this.checkedResource = new List<int>();
            foreach (String s in checkedListBox1.CheckedItems)
            {
                using (SqlConnection cn = new SqlConnection(conString))
                {
                    cn.Open();
                    if (cn.State == System.Data.ConnectionState.Open)
                    {
                        string query = "SELECT id FROM resource WHERE name = '" + s + "' ; ";
                        SqlCommand cmd = new SqlCommand(query, cn);
                        cmd.ExecuteNonQuery();
                        this.selected_id = (int)cmd.ExecuteScalar();
                    }
                }
                this.checkedResource.Insert(i, this.selected_id);
                i++;
            }
            */
            this.Close();
        }

        private void newCourseBTN_Click(object sender, EventArgs e)
        {
            addResourceForm addResourcePopup = new addResourceForm();
            DialogResult dialogResult = addResourcePopup.ShowDialog();
            checkedListBox1.Update();
        }
    }
}
