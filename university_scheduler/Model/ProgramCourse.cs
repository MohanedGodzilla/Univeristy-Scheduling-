using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace university_scheduler.Model
{
    class ProgramCourse
    {
        public int programId { get; set; }
        public int courseId { get; set; }
        public int isOptional { get; set; }


        
        public List<ProgramCourse> getAll()
        {
            List<ProgramCourse> progCourseData = new List<ProgramCourse>();
            SqlConnection cn = new SqlConnection(env.db_con_str);
            cn.Open();
            string query = "SELECT * FROM program_has_course";
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    progCourseData.Add(new ProgramCourse { programId = (int)reader.GetValue(0), courseId = (int)reader.GetValue(1), isOptional = (int)reader.GetValue(2) });
                }
                return progCourseData;
            }
        }

        public List<ProgramCourse> getAll(string dummyName)
        {
            List<ProgramCourse> progCourseData = new List<ProgramCourse>();
            SqlConnection cn = new SqlConnection(env.db_con_str);
            cn.Open();
            string query = "SELECT * FROM program_has_course WHERE name LIKE '% " + dummyName + "%'";
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    progCourseData.Add(new ProgramCourse { programId = (int)reader.GetValue(0), courseId = (int)reader.GetValue(1), isOptional = (int)reader.GetValue(2) });
                }
                return progCourseData;
            }
       }

        public static List<ProgramCourse> getCoursePrograms(int course_id) {
            List<ProgramCourse> progCourseData = new List<ProgramCourse>();
            SqlConnection cn = new SqlConnection(env.db_con_str);
            cn.Open();
            string query = $"SELECT * FROM program_has_course WHERE course_id = {course_id}";
            using (SqlCommand cmd = new SqlCommand(query, cn)) {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    progCourseData.Add(new ProgramCourse { programId = (int)reader.GetValue(0), courseId = (int)reader.GetValue(1), isOptional = (int)reader.GetValue(2) });
                }
                return progCourseData;
            }
        }

        public void insertProgram(int dummyCourseId, int dummyProgramId)
        {
            SqlConnection cn = new SqlConnection(env.db_con_str);
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
