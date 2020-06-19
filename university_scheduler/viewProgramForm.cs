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
using university_scheduler.Model;

namespace university_scheduler {
    public partial class viewProgramForm : Form {

        public int viewProgram_disableSaveBTN = 0;

        public viewProgramForm() {
            InitializeComponent();
        }

        public viewProgramForm(int flag)
        {
            InitializeComponent();
            this.viewProgram_disableSaveBTN = flag;
            var control = this.tableLayoutPanel1.GetControlFromPosition(1, 0);
            this.tableLayoutPanel1.Controls.Remove(control);
            TableLayoutColumnStyleCollection styles = this.tableLayoutPanel1.ColumnStyles;
            styles[1].Width = 0;
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

                programData.Columns[0].Width = 40;
                programData.Columns[1].Width = 340;
                cn.Close();
            }
        }

        private void editProgramBTN_Click(object sender, EventArgs e) {
            if (!canUpdate()) return;
            addProgramForm addProgramForm = new addProgramForm((int)programData.SelectedRows[0].Cells[0].Value,0);
            addProgramForm.ShowDialog();
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

        private void programData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.viewProgram_disableSaveBTN == 0)
            {
                if (!canUpdate()) return;
                addProgramForm addProgramForm = new addProgramForm((int)programData.SelectedRows[0].Cells[0].Value,0);
                addProgramForm.Show();
            }
            else if(this.viewProgram_disableSaveBTN == 1)
            {
                if (!canUpdate()) return;
                addProgramForm addProgramForm = new addProgramForm((int)programData.SelectedRows[0].Cells[0].Value,1);
                addProgramForm.Show();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable dtClass = Model.Program.search(1);
            DataView DV = new DataView(dtClass);
            DV.RowFilter = string.Format("name LIKE '%{0}%'", textBox1.Text);
            programData.DataSource = DV;
        }

        private void deleteAllBTN_Click(object sender, EventArgs e)
        {
            if (!canUpdate()) return;
            SqlConnection cn = new SqlConnection(env.db_con_str);
            cn.Open();
            if (cn.State == System.Data.ConnectionState.Open)
            {
                string message = "By clicking OK, All Programs will be permenantly DELETED\nmake sure from your choice";
                string title = " All programs will be deleted";
                MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (result != DialogResult.OK)
                {
                    return;
                }
                else
                {
                    string query = "delete from program";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "DBCC CHECKIDENT (program, RESEED, 0)";
                    cmd.ExecuteNonQuery();
                    //--the following three lines is used to update the dataGridView and refresh it --//
                    this.loadData();
                    this.programData.Update();
                    this.programData.Refresh();
                    cn.Close();
                    //---//
                    MessageBox.Show("All Programs are deleted successfully..!");
                }
            }
        }
    }
}
