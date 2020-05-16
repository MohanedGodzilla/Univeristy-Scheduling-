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

namespace university_scheduler {
    public partial class selectCourseForm : Form {

        public string conString = env.db_con_str;
        public List<int> checkedCourses;
        private int selected_id;
        private int programID;
        Dictionary<int, int> idIndexMap = new Dictionary<int, int>();
        Dictionary<int, int> indexIdMap = new Dictionary<int, int>();

        public selectCourseForm(int programID)//Edit
        {
            InitializeComponent();
            this.programID = programID;
            loadData(true);

        }

        public selectCourseForm(List<int> selectedIds) { //open the form again at adding new course
            InitializeComponent();
            checkedCourses = selectedIds;
            loadData(false);
        }

        private void CheckedListBox1_ItemCheck(object sender, ItemCheckEventArgs e) {
            if (e.NewValue == CheckState.Checked)
                checkedCourses.Add(indexIdMap[e.Index]);
            else
                checkedCourses.Remove(indexIdMap[e.Index]);
        }

        void loadData(bool shouldLoadSelected) {
            if (checkedCourses == null) {
                checkedCourses = new List<int>();
            }
            using (SqlConnection cn = new SqlConnection(conString)) {
                cn.Open();
                getCourses(cn);
                if (shouldLoadSelected) {
                    checkedCourses = new List<int>();
                    loadSelected(cn);
                }
                checkSelected();
                checkedListBox1.ItemCheck += CheckedListBox1_ItemCheck;
            }
        }

        void getCourses(SqlConnection cn) {
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM course", cn)) {
                DataTable dt = new DataTable();
                using (SqlDataAdapter da = new SqlDataAdapter(cmd)) {
                    da.Fill(dt);
                }
                for (int i = 0; i < dt.Rows.Count; i++) {
                    int courseID = (int)dt.Rows[i]["id"];
                    this.idIndexMap[courseID] = i;
                    this.indexIdMap[i] = courseID;
                    checkedListBox1.Items.Add(dt.Rows[i]["name"].ToString()+"("+ dt.Rows[i]["course_named_id"]+")");
                }
            }
        }

        void loadSelected(SqlConnection cn) {
            string query = "SELECT course_id FROM program_has_course WHERE program_id = " + this.programID;
            using (SqlCommand cmd = new SqlCommand(query, cn)) {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    int id = (int)reader.GetValue(0);
                    checkedCourses.Add(id);
                }
                reader.Close();
            }
        }

        void checkSelected() {
            for (int i = 0; i < checkedCourses.Count; i++) {
                checkedListBox1.SetItemChecked(this.idIndexMap[checkedCourses[i]], true);
            }
        }

        private void saveProgramBTN_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
