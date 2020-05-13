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
        List<TermData> termDataList = new List<TermData>();
        //List<Program> programData = new List<Program>();

        public List<TermData> getAll()
        {
            SqlConnection cn = new SqlConnection(conString);
            cn.Open();
            string query = "SELECT * FROM term_program_limit ";
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    this.termDataList.Add(new TermData { id = (int)reader.GetValue(0), term = (int)reader.GetValue(1), limit = (int)reader.GetValue(2)});
                }

                return termDataList;
            }
            cn.Close();
        }

        /*public List<Program> getPrograms(int dummyProgramID)
        {
            SqlConnection cn = new SqlConnection(conString);
            cn.Open();
            string query = "SELECT * FROM program p WHERE p.id = " + dummyProgramID;
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()){
                    this.programData.Add(new Program { id = (int)reader.GetValue(0), name = (string)reader.GetValue(1)});
                }

                return programData;
            }
        }*/
    }
}
