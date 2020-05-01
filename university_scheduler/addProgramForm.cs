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
        viewProgramForm viewProgramForm = (viewProgramForm)Application.OpenForms["viewProgramForm"];

        public addProgramForm() {
            InitializeComponent();
            initLimits();
            addProgramBTN.Visible = true;
        }
        public addProgramForm(int prog_id) {
            InitializeComponent();
            initLimits();
            this.prog_id = prog_id;
            loadData();
            saveProgramBTN.Visible = true;
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
    }
}
