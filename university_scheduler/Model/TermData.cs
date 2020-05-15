using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace university_scheduler.Model
{
    class TermData
    {
        public int id { get; set; }
        public int term { get; set; }
        public int limit { get; set; }
        public double section_count { get; set; }
        public int max_days { get; set; }
        public int max_time { get; set; }

        List<Program> programData = new List<Program>();

        public static List<TermData> getAll()
        {
            List<TermData> termDataList = new List<TermData>();
            SqlConnection cn = new SqlConnection(env.db_con_str);
            cn.Open();
            string query = "SELECT * FROM term_program_limit ";
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    termDataList.Add(new TermData { id = (int)reader.GetValue(0), term = (int)reader.GetValue(1), limit = (int)reader.GetValue(2)});
                }
                cn.Close();
                return termDataList;
            }
        }

        public List<Program> getPrograms(int dummyProgramID)
        {
            SqlConnection cn = new SqlConnection(env.db_con_str);
            cn.Open();
            string query = "SELECT * FROM program p WHERE p.id = " + dummyProgramID;
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    this.programData.Add(new Program { id = (int)reader.GetValue(0), name = (string)reader.GetValue(1) });
                }

                return programData;
            }
        }
        public void insert(int term, int limit, int progId)
        {
            SqlConnection cn = new SqlConnection(env.db_con_str);
            cn.Open();
            if (cn.State == System.Data.ConnectionState.Open)
            {
                string query = "insert into term_program_limit(term, limit, program_id) values( '" + term + "' ,'" + limit + "' ,'" + progId + "' )";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.ExecuteNonQuery();
            }
            cn.Close();
        }
    }
}
