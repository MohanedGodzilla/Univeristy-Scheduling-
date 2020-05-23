using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace university_scheduler.Model
{
    class Course {
        public int id { get; set; }
        public string name { get; set; }
        public int creditHours { get; set; }
        public double lectureHours { get; set; }
        public double practiceHours { get; set; }
        public double labHours { get; set; }
        public int term { get; set; }
        public string courseNamedId { get; set; }
        public bool isActive { get; set; }
        public bool isReq { get; set; }

        public List<Program> programs { get; set; }
        

        public static int insertCourse(string dummyName, string codeNI, int crH, double lecH, double pracH, double labH, int dummyTerm, bool dummyActive) {
            try
            {
                SqlConnection cn = new SqlConnection(env.db_con_str);
                cn.Open();
                if (cn.State == System.Data.ConnectionState.Open)
                {
                    int val = 0;
                    if (dummyActive == true)
                    {
                        val = 1;
                    }
                    string query = "insert into course(name,credit_hours,lecture_hours,practice_hours,lab_hours,term,course_named_id,actived) OUTPUT INSERTED.ID values(" + "'" + dummyName + "' , '" + crH + "' , '" + lecH + "' , '" + pracH + "' , '" + labH + "' , '" + dummyTerm + "' , '" + codeNI + "' , '" + val + "' )";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    int courseId = (int)cmd.ExecuteScalar();
                    cn.Close();
                    return courseId;
                }
            }catch(Exception e) { }
            return -1;
        }

        public static List<Course> getAll()
        {
            List<Course> courseData = new List<Course>();
            SqlConnection cn = new SqlConnection(env.db_con_str);
            cn.Open();
            string query = "SELECT * FROM course ";
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    courseData.Add(setCourse(reader));
                }
                cn.Close();
                return courseData;
            }
        }

        public static List<Course> getAll(string dummyName)
        {
            List<Course> courseData = new List<Course>();
            SqlConnection cn = new SqlConnection(env.db_con_str);
            cn.Open();
            string query = "SELECT * FROM course WHERE name LIKE '% " + dummyName + "%'";
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    courseData.Add(setCourse(reader));
                }
                cn.Close();
                return courseData;
            }
            
        }


        static Course setCourse(SqlDataReader reader) {
            return new Course {
                id = (int)reader.GetValue(0),
                name = reader.GetValue(1).ToString(),
                creditHours = (int)reader.GetValue(2),
                lectureHours = (double)reader.GetValue(3),
                practiceHours = (double)reader.GetValue(4),
                labHours = (double)reader.GetValue(5),
                term = (int)reader.GetValue(6),
                courseNamedId = (string)reader.GetValue(7).ToString(),
                isActive = (bool)(reader.GetValue(8).ToString() == "1"),
                programs = getCoursePrograms((int)reader.GetValue(0)),
            };
        }

        private static List<Program> getCoursePrograms(int courseID) {
            List<Program> programs = new List<Program>();
            List<ProgramCourses> programCourses = ProgramCourses.getCoursePrograms(courseID);
            foreach (ProgramCourses programCourse in programCourses) {
               programs.Add(Program.getProgramById(programCourse.programId));
            }
            return programs;
        }

        public List<Program> getCoursePrograms() {
            return getCoursePrograms(this.id);
        }

        public List<Resource> getCourseResources() {
            List<Resource> courseResources = new List<Resource>();
            List<int> resourcesIds = courseHasResource.getResourcesIdsOfCourse(this.id);
            foreach (int resourceId in resourcesIds) {
                courseResources.Add(Resource.getResourceById(resourceId));
            }
            return courseResources;
        }
    }
}
