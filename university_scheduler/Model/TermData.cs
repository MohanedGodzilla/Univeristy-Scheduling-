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
        public string conString = env.db_con_str;
        public Dictionary<int, Dictionary<dynamic, int>> schedule;
        public List<TermData> termDataList = new List<TermData>();
        public List<Program> programData = new List<Program>();

        public TermData()
        {
            this.id = 0;
            this.term = 0;
            this.limit = 0;
            this.max_days = 0;
            this.max_time = 0;
        }

        public TermData(int id, int term, int limit,int max_days,int max_time) {
            this.id = id;
            this.term = term;
            this.limit = limit;
            this.max_days = max_days;
            this.max_time = max_time;
            this.schedule = new Dictionary<int, Dictionary<dynamic, int>>();
            for (int i = 0; i < max_days; i++)
            {
                for (double j = 0; j < max_time; j++)
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
