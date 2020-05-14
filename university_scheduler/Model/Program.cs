using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace university_scheduler.Model
{
    class Program
    {
        public int id { get; set; }
        public string name { get; set; }

        public string conString = env.db_con_str;

        List<TermData> termsData = new List<TermData>();

        List<Program> progData = new List<Program>();
        public List<Program> getAll()
        {
            SqlConnection cn = new SqlConnection(conString);
            cn.Open();
            string query = "SELECT * FROM program";
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    this.progData.Add(new Program { id = (int)reader.GetValue(0), name = (string)reader.GetValue(1) });
                }
                return progData;
            }
        }

        public List<Program> getAll(string dummyName)
        {
            SqlConnection cn = new SqlConnection(conString);
            cn.Open();
            string query = "SELECT * FROM program WHERE name LIKE '% " + dummyName + "%'";
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    this.progData.Add(new Program { id = (int)reader.GetValue(0), name = (string)reader.GetValue(1) });
                }
                return progData;
            }
        }

        public void insert(string name, TermData termsData)
        {
            SqlConnection cn = new SqlConnection(conString);
            cn.Open();
            if (cn.State == System.Data.ConnectionState.Open)
            {
                string query = "insert into program(name) output INSERTED.ID values( '" + name + "' )";
                SqlCommand cmd = new SqlCommand(query, cn);
                int progId = (int)cmd.ExecuteNonQuery();

                for (int i = 0; i < 8; i++)
                {
                    query = "insert into term_program_limit(term, limit, program_id) values( '" + termsData.term + "' ,'" + termsData.limit[i] + "' ,'" + progId + "' )";
                    cmd = new SqlCommand(query, cn);
                    cmd.ExecuteNonQuery();
                }
            }
            cn.Close();
        }
    }
}
