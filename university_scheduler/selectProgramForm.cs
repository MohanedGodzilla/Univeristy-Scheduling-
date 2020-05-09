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
    public partial class selectProgramForm : Form {
        public string conString = env.db_con_str;
        public List<int> checkedPrograms;
        private int selected_id;
        private int courseId;
        Dictionary<int, int> idIndexMap = new Dictionary<int, int>();
        Dictionary<int, int> indexIdMap = new Dictionary<int, int>();
        public selectProgramForm(int courseId)//Edit
        {
            InitializeComponent();
            this.courseId = courseId;
            loadData(true);

        }

        public selectProgramForm(List<int> selectedIds) { //open the form again at adding new course
            InitializeComponent();
            checkedPrograms = selectedIds;
            loadData(false);
        }

        private void CheckedListBox1_ItemCheck(object sender, ItemCheckEventArgs e) {
            if (e.NewValue == CheckState.Checked)
                checkedPrograms.Add(indexIdMap[e.Index]);
            else
                checkedPrograms.Remove(indexIdMap[e.Index]);
        }

        private void selectProgramForm_Load(object sender, EventArgs e) {

        }


        void loadData(bool shouldLoadSelected) {
            if (checkedPrograms == null) {
                checkedPrograms = new List<int>();
            }
            using (SqlConnection cn = new SqlConnection(conString)) {
                cn.Open();
                getPrograms(cn);
                if (shouldLoadSelected) {
                    checkedPrograms = new List<int>();
                    loadSelected(cn);
                }
                checkSelected();
                checkedListBox1.ItemCheck += CheckedListBox1_ItemCheck;
            }
        }

        void getPrograms(SqlConnection cn) {
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM program", cn)) {
                DataTable dt = new DataTable();
                using (SqlDataAdapter da = new SqlDataAdapter(cmd)) {
                    da.Fill(dt);
                }
                for (int i = 0; i < dt.Rows.Count; i++) {
                    int progId = (int)dt.Rows[i]["id"];
                    this.idIndexMap[progId] = i;
                    this.indexIdMap[i] = progId;
                    checkedListBox1.Items.Add(dt.Rows[i]["name"].ToString());
                }
            }
        }

        void loadSelected(SqlConnection cn) {
            string query = "SELECT program_id FROM program_has_course WHERE course_id = " + this.courseId;
            using (SqlCommand cmd = new SqlCommand(query, cn)) {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    int id = (int)reader.GetValue(0);
                    checkedPrograms.Add(id);
                }
                reader.Close();
            }
        }

        void checkSelected() {
            for (int i = 0; i < checkedPrograms.Count; i++) {
                checkedListBox1.SetItemChecked(this.idIndexMap[checkedPrograms[i]], true);
            }
        }


        private void saveProgramBTN_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e) {

        }
    }
}
