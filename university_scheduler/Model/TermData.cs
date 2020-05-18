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
        public int id;
        public int term;
        public int limit;
        public double section_count;
        public string conString = env.db_con_str;
        public Dictionary<int, Dictionary<dynamic, int>> schedule;
        public List<TermData> termDataList = new List<TermData>();
        public List<Program> programData = new List<Program>();

        public TermData(int id, int term, int limit) {
            this.id = id;
            this.term = term;
            this.limit = limit;
            this.schedule = new Dictionary<int, Dictionary<dynamic, int>>();
            for (int i = 0; i < Data.Generator.max_days; i++)
            {
                for (double j = 0; j < Data.Generator.max_time; j++)
                {
                    schedule[i] = new Dictionary<dynamic, int>();
                }
            }
        }


        public List<TermData> getAll()
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
                    termDataList.Add(new TermData ((int)reader.GetValue(0), (int)reader.GetValue(1), (int)reader.GetValue(2)));
                }
                cn.Close();
                return termDataList;
            }
        }

        public static List<TermData> getProgramTermData(int progId) {
            List<TermData> termDataList = new List<TermData>();
            SqlConnection cn = new SqlConnection(env.db_con_str);
            cn.Open();
            string query = $"SELECT * FROM term_program_limit WHERE program_id = {progId}";
            using (SqlCommand cmd = new SqlCommand(query, cn)) {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    termDataList.Add(new TermData((int)reader.GetValue(0), (int)reader.GetValue(1), (int)reader.GetValue(2)));
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
                cn.Close();
                return programData;
            }
        }

        public static void insert(int term, int limit, int progId)
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
