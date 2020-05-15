using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace university_scheduler.Model {
    class Program {
        public int id { get; set; }
        public string name { get; set; }

        List<TermData> termsData = new List<TermData>();

        public static List<Program> getAll() {
            List<Program> progData = new List<Program>();
            SqlConnection cn = new SqlConnection(env.db_con_str);
            cn.Open();
            string query = "SELECT * FROM program";
            using (SqlCommand cmd = new SqlCommand(query, cn)) {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    progData.Add(new Program { id = (int)reader.GetValue(0), name = (string)reader.GetValue(1) });
                }
                return progData;
            }
        }

        public static List<Program> getAll(string dummyName) {
            List<Program> progData = new List<Program>();
            SqlConnection cn = new SqlConnection(env.db_con_str);
            cn.Open();
            string query = "SELECT * FROM program WHERE name LIKE '% " + dummyName + "%'";
            using (SqlCommand cmd = new SqlCommand(query, cn)) {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    progData.Add(new Program { id = (int)reader.GetValue(0), name = (string)reader.GetValue(1) });
                }
                return progData;
            }
        }

        public static Program getProgramById(int programID) {

            SqlConnection cn = new SqlConnection(env.db_con_str);
            cn.Open();
            string query = $"SELECT * FROM program WHERE id = {programID}";
            Program program;
            using (SqlCommand cmd = new SqlCommand(query, cn)) {
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                program = new Program {
                    id = (int)reader.GetValue(0),
                    name = (string)reader.GetValue(1),
                };

            }
            cn.Close();
            return program;
        }

        public void insert(string name) {
            SqlConnection cn = new SqlConnection(env.db_con_str);
            cn.Open();
            if (cn.State == System.Data.ConnectionState.Open) {
                string query = "insert into program(name) values( '" + name + "' )";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.ExecuteNonQuery();
            }
            cn.Close();
        }

        public int getCurrentProgramId() {
            SqlConnection cn = new SqlConnection(env.db_con_str);
            cn.Open();
            string query = "SELECT MAX(id) from program";
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.ExecuteNonQuery();
            return (int)cmd.ExecuteScalar();
        }
    }
}
