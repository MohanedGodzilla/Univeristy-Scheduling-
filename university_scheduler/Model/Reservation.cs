using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace university_scheduler.Model
{
    class Reservation
    {
        public int courseId { get; set; }
        public int classId { get; set; }
        public int day { get; set; }
        public double from { get; set; }
        public double to { get; set; }
        public bool isParctice { get; set; }

        public string conString = env.db_con_str;
        List<Reservation> reservationData = new List<Reservation>();
        //List<Classroom> classroomData = new List<Classroom>();
        List<Course> courseData = new List<Course>();

        public List<Reservation> getAll() {
            SqlConnection cn = new SqlConnection(conString);
            cn.Open();
            string query = "SELECT * FROM reservation ";
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    this.reservationData.Add(new Reservation { courseId = (int)reader.GetValue(0), classId = (int)reader.GetValue(1) , day = (int)reader.GetValue(4) , from = (double)reader.GetValue(2) , to = (double)reader.GetValue(3) , isParctice = (bool)reader.GetValue(2) });
                }

                return reservationData;
            }
        }

        /*public List<Classroom> getClassroom(int dummyClassID)
        {
            SqlConnection cn = new SqlConnection(conString);
            cn.Open();
            string query = "SELECT * FROM class c WHERE c.id = " + dummyClassID;
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()){
                    this.classroomData.Add(new Classroom { id = (int)reader.GetValue(0), lec_capacity = (int)reader.GetValue(1), name = (string)reader.GetValue(2), exam_capacity = (int)reader.GetValue(3)});
                }

                return classroomData;
            }
        }*/

        public List<Course> getCourse(int dummyCourseID)
        {
            SqlConnection cn = new SqlConnection(conString);
            cn.Open();
            string query = "SELECT * FROM course c WHERE c.id = " + dummyCourseID;
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()){
                    this.courseData.Add(new Course { id = (int)reader.GetValue(0), name = (string)reader.GetValue(1), creditHours = (int)reader.GetValue(2), lectureHours = (float)reader.GetValue(3), practiceHours = (double)reader.GetValue(4), labHours = (float)reader.GetValue(5), term = (int)reader.GetValue(6), courseNamedId = (string)reader.GetValue(7), isActive = (bool)reader.GetValue(8)});
                }

                return courseData;
            }
        }
    }
}
