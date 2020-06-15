using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace university_scheduler {

    public partial class addProgramForm : Form {

        public string conString = env.db_con_str;
        private Dictionary<int, KeyValuePair<int, int>> termLimit = new Dictionary<int, KeyValuePair<int, int>>();
        private List<NumericUpDown> limits;
        private int prog_id;

        public List<int> selectedCourseList;
        public List<int> oldSelectedCourseList;
        public List<int> deletedCourseList;
        public List<int> addedCourseList;
        bool isEdit = false;

        viewProgramForm viewProgramForm = (viewProgramForm)Application.OpenForms["viewProgramForm"];

        public addProgramForm() {
            InitializeComponent();
            initLimits();
            addProgramBTN.Visible = true;
        }
        public addProgramForm(int prog_id, int viewProgram_disableSaveBTN) {
      
            InitializeComponent();
            initLimits();
            this.prog_id = prog_id;
            loadData();
            if (viewProgram_disableSaveBTN == 0)
            {
                saveProgramBTN.Visible = true;
            }
            else if (viewProgram_disableSaveBTN == 1)
            {
                saveProgramBTN.Hide();
            }
            isEdit = true;
        }

        private void initLimits() {
            limits = new List<NumericUpDown> {
                y1t1,
                y1t2,
                y2t1,
                y2t2,
                y3t1,
                y3t2,
                y4t1,
                y4t2
            };
        }

        public void loadData() {
            SqlConnection cn = new SqlConnection(conString);
            cn.Open();
            if (cn.State == System.Data.ConnectionState.Open) {
                loadProgram(cn);
                loadTerms(cn);
            }
            cn.Close();

        }

        public void loadProgram(SqlConnection cn) {
            using (SqlCommand cmd = new SqlCommand("SELECT name FROM program WHERE id = " + prog_id, cn)) {
                string name = cmd.ExecuteScalar().ToString();
                programName.Text = name;
            }
        }

        public void loadTerms(SqlConnection cn) {
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM term_program_limit WHERE program_id = " + prog_id, cn)) {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    int id = (int)reader.GetValue(0);
                    int term = (int)reader.GetValue(1);
                    int limit = (int)reader.GetValue(2);
                    termLimit[term] = new KeyValuePair<int, int>(id, limit);
                }
                reader.Close();
            }
            for (int i = 0; i < 8; i++) {
                limits[i].Value = termLimit[i + 1].Value;
            }

        }

        private void addProgramBTN_Click(object sender, EventArgs e) {
            SqlConnection cn = new SqlConnection(conString);
            cn.Open();
            if (cn.State == System.Data.ConnectionState.Open) {
                prog_id = insertProgram(cn);
                insertProgramTerms(cn);
                addCourseForProgram(prog_id);
                MessageBox.Show("Added Program successfully!: " + prog_id);
                viewProgramForm.loadData();
            }
            cn.Close();
            this.Close();
        }

        int insertProgram(SqlConnection cn) {
            string query = "insert into program(name) output INSERTED.ID values( '" + programName.Text.ToString() + "' )";
            SqlCommand cmd = new SqlCommand(query, cn);
            return (int)cmd.ExecuteScalar();
        }
        void insertProgramTerms(SqlConnection cn) {

            for (int i = 0; i < 8; i++) {
                string query = "insert into term_program_limit(term,limit,program_id) values( '" + (i + 1) + "' ,'" + limits[i].Value + "' ,'" + prog_id + "' )";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.ExecuteNonQuery();
            }

        }

        void updateData() {
            SqlConnection cn = new SqlConnection(conString);
            cn.Open();
            if (cn.State == System.Data.ConnectionState.Open) {
                updateProgram(cn);
                updateTerms(cn);
                editProgramForCourse(prog_id);
                MessageBox.Show("Updated Program successfully!: " + prog_id);
                viewProgramForm.loadData();
            }
            cn.Close();
            this.Close();

        }

        void updateProgram(SqlConnection cn) {
            string query = "UPDATE program SET name = '" + programName.Text + "' WHERE id = " + prog_id;
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.ExecuteNonQuery();
        }
        void updateTerms(SqlConnection cn) {
            for (int i = 0; i < 8; i++) {
                string query = "UPDATE term_program_limit SET limit = '" + limits[i].Value + "' WHERE id = " + termLimit[i + 1].Key;
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.ExecuteNonQuery();
            }
        }

        private void saveProgramBTN_Click(object sender, EventArgs e) {
            updateData();
        }

        private void cancelProgramBTN_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void label7_Click(object sender, EventArgs e) {

        }

        private void label6_Click(object sender, EventArgs e) {

        }

        private void addProgramForm_Load(object sender, EventArgs e) {

        }

        private void selectProgramBTN_Click(object sender, EventArgs e) {
            selectCourseForm courseForm;
            if (isEdit && selectedCourseList == null) {//is editing
                courseForm = new selectCourseForm(this.prog_id);
            } else {
                courseForm = new selectCourseForm(selectedCourseList);
            }
            DialogResult dialogresult = courseForm.ShowDialog();
            this.selectedCourseList = courseForm.checkedCourses;
        }

        private void addCourseForProgram(int id) {
            for (int i = 0; i < this.selectedCourseList.Count; i++) {
                SqlConnection cn = new SqlConnection(conString);
                cn.Open();
                if (cn.State == System.Data.ConnectionState.Open) {
                    string query = "insert into program_has_course(course_id,program_id) values(" + this.selectedCourseList[i] + " , " + id + " )";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.ExecuteNonQuery();
                    //---//
                }
                cn.Close();
            }
        }

        private void editProgramForCourse(int id) {
            try {
                this.deletedCourseList = new List<int>();
                this.addedCourseList = new List<int>();
                bringIdsOfCourseHasProgram(id);
                compareListsCourse(this.oldSelectedCourseList, this.selectedCourseList);
                SqlConnection cn = new SqlConnection(conString);
                cn.Open();
                if (cn.State == System.Data.ConnectionState.Open) {
                    for (int j = 0; j < deletedCourseList.Count; j++) {
                        string query = "DELETE FROM program_has_course WHERE course_id = " + deletedCourseList[j] + "AND program_id = " + id;
                        SqlCommand cmd = new SqlCommand(query, cn);
                        cmd.ExecuteNonQuery();
                    }
                    for (int j = 0; j < addedCourseList.Count; j++) {
                        string query = "INSERT INTO program_has_course (program_id, course_id ) VALUES( '" + id + "' , '" + addedCourseList[j]  + "')";
                        SqlCommand cmd = new SqlCommand(query, cn);
                        cmd.ExecuteNonQuery();
                    }
                }
                cn.Close();
            } catch (Exception e) { }
        }

        private void bringIdsOfCourseHasProgram(int programId) {
            SqlConnection cn = new SqlConnection(conString);
            cn.Open();
            string query = "SELECT course_id FROM program_has_course WHERE program_id = " + programId;
            using (SqlCommand cmd = new SqlCommand(query, cn)) {
                SqlDataReader reader = cmd.ExecuteReader();
                int count = 0;
                this.oldSelectedCourseList = new List<int>();
                while (reader.Read()) {
                    int id = (int)reader.GetValue(0);
                    oldSelectedCourseList.Insert(count, id);
                    count++;
                }
                reader.Close();
            }
        }

        private void compareListsCourse(List<int> oldSelected, List<int> newSelected) {
            for (int i = 0; i < oldSelected.Count; i++) {
                if (!newSelected.Contains(oldSelected[i])) {
                    this.deletedCourseList.Add(oldSelected[i]);
                }
            }
            for (int i = 0; i < newSelected.Count; i++) {
                if (!oldSelected.Contains(newSelected[i])) {
                    this.addedCourseList.Add(newSelected[i]);
                }
            }
        }
    }
}
