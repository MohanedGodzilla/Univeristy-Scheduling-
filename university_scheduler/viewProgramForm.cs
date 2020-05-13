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
    public partial class viewProgramForm : Form {
        public viewProgramForm() {
            InitializeComponent();
        }

        private void newProgramBTN_Click(object sender, EventArgs e) {
            addProgramForm addProgramForm = new addProgramForm();
            DialogResult dialogResult = addProgramForm.ShowDialog();
        }

        private void viewProgramForm_Load(object sender, EventArgs e) {
            loadData();
        }


        public void loadData() {
            using (SqlConnection cn = new SqlConnection(env.db_con_str)) {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM program", cn)) {
                    DataTable dt = new DataTable();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd)) {
                        da.Fill(dt);
                    }
                    this.programData.DataSource = dt;
                }
            }
        }

        private void editProgramBTN_Click(object sender, EventArgs e) {
            if (!canUpdate()) return;
            addProgramForm addProgramForm = new addProgramForm((int)programData.SelectedRows[0].Cells[0].Value);
            addProgramForm.Show();
        }

        private void deleteProgramBTN_Click(object sender, EventArgs e) {
            if (!canUpdate()) return;
            string selected_id = programData.SelectedRows[0].Cells[0].Value.ToString();
            SqlConnection cn = new SqlConnection(env.db_con_str);
            cn.Open();
            if (cn.State == System.Data.ConnectionState.Open) {
                string query = "delete from term_program_limit where program_id = " + selected_id;
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.ExecuteNonQuery();
                query = "delete from program where id = " + selected_id;
                cmd = new SqlCommand(query, cn);
                cmd.ExecuteNonQuery();
                //--the following three lines is used to update the dataGridView and refresh it --//
                this.loadData();
                this.programData.Update();
                this.programData.Refresh();
                //---//
                MessageBox.Show("Program is deleted successfully..!");

            }
        }

        bool canUpdate() {
            return (programData.SelectedRows != null &&
                programData.SelectedRows.Count > 0 &&
                programData.SelectedRows[0].Cells[0].Value != null);
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void programData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
