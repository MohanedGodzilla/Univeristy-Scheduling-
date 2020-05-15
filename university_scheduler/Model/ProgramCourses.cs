using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace university_scheduler.Model
{
    class ProgramCourses
    {
        public int programId { get; set; }
        public int courseId { get; set; }
        public int isOptional { get; set; }

        public string conString = env.db_con_str;

        List<ProgramCourses> progCourseData = new List<ProgramCourses>();
        public List<ProgramCourses> getAll()
        {
            SqlConnection cn = new SqlConnection(conString);
            cn.Open();
            string query = "SELECT * FROM program_has_course";
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    this.progCourseData.Add(new ProgramCourses { programId = (int)reader.GetValue(0), courseId = (int)reader.GetValue(1), isOptional = (int)reader.GetValue(2) });
                }
                return progCourseData;
            }
        }

        public List<ProgramCourses> getAll(string dummyName)
        {
            SqlConnection cn = new SqlConnection(conString);
            cn.Open();
            string query = "SELECT * FROM program_has_course WHERE name LIKE '% " + dummyName + "%'";
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    this.progCourseData.Add(new ProgramCourses { programId = (int)reader.GetValue(0), courseId = (int)reader.GetValue(1), isOptional = (int)reader.GetValue(2) });
                }
                return progCourseData;
            }
       }

        public void insertProgram(int dummyCourseId, int dummyProgramId)
        {
            SqlConnection cn = new SqlConnection(conString);
            cn.Open();
            if (cn.State == System.Data.ConnectionState.Open)
            {
                string query = "insert into program_has_course(course_id,program_id) values('" + dummyCourseId + "' , '" + dummyProgramId + "')";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.ExecuteNonQuery();
                //---//
            }
            cn.Close();
        }
    }
}
