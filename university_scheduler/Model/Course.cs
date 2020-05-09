using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace university_scheduler.Model
{
    class Course
    {
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
        public string conString = env.db_con_str;
        List<Course> courseData = new List<Course>();
        List<Resource> resourceData = new List<Resource>();

        public List<Course> getAll()
        {
            SqlConnection cn = new SqlConnection(conString);
            cn.Open();
            string query = "SELECT * FROM course ";
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    this.courseData.Add(new Course { id = (int)reader.GetValue(0), name = (string)reader.GetValue(1), creditHours = (int)reader.GetValue(2), lectureHours = (float)reader.GetValue(3), practiceHours = (double)reader.GetValue(4), labHours = (float)reader.GetValue(5), term = (int)reader.GetValue(6), courseNamedId = (string)reader.GetValue(7), isActive = (bool)reader.GetValue(8) });
                }

                return courseData;
            }
        }

        public List<Course> getAll(string dummyName)
        {
            SqlConnection cn = new SqlConnection(conString);
            cn.Open();
            string query = "SELECT * FROM course WHERE name LIKE '% " + dummyName + "%'";
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    this.courseData.Add(new Course { id = (int)reader.GetValue(0), name = (string)reader.GetValue(1), creditHours = (int)reader.GetValue(2), lectureHours = (float)reader.GetValue(3), practiceHours = (double)reader.GetValue(4), labHours = (float)reader.GetValue(5), term = (int)reader.GetValue(6), courseNamedId = (string)reader.GetValue(7), isActive = (bool)reader.GetValue(8) });
                }

                return courseData;
            }
        }

        public List<Resource> getResource(int dummyResourceID)
        {
            SqlConnection cn = new SqlConnection(conString);
            cn.Open();
            string query = "SELECT * FROM resource r WHERE r.id = " + dummyResourceID;
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    this.resourceData.Add(new Resource { id = (int)reader.GetValue(0), name = (string)reader.GetValue(1) });
                }

                return resourceData;
            }
        }
    }
}
