using System;
using System.Collections.Generic;
using System.Data;
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
        public bool isPractice { get; set; }

        List<Classroom> classroomData = new List<Classroom>();
        List<Course> courseData = new List<Course>();

        public Reservation() {
            this.courseId = 0;
            this.classId = 0;
            this.day = 0;
            this.from = 0;
            this.to = 0;
            this.isPractice = false;
        }

        public Reservation(int dummyCourseId, int dummyClassId, int dummyDay, double dummyFrom, double dummyTo,bool dummyIsPractice)
        {
            this.courseId = dummyCourseId;
            this.classId = dummyClassId;
            this.day = dummyDay;
            this.from = dummyFrom;
            this.to = dummyTo;
            this.isPractice = dummyIsPractice;
        }

        public void insertReserv(int dummyCourseId, int dummyclassId,double dummyFrom, double dummyTo, int dummyDay, bool dummyIsPractice) {
            SqlConnection cn = new SqlConnection(env.db_con_str);
            cn.Open();
            int val = 0;
            if (dummyIsPractice == true){
                val = 1;
            }
            if (cn.State == System.Data.ConnectionState.Open){
                string query = "insert into reservation(course_id,class_id,from,to,day,is_practice) values('" + dummyCourseId + " , " + dummyclassId + " , " + dummyFrom + " , " + dummyTo + " , " + dummyDay + " , " + val + " ) ";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.ExecuteNonQuery();
            }
            cn.Close();
        }

        public static List<Reservation> getAll() {
            List<Reservation> reservationData = new List<Reservation>();
            SqlConnection cn = new SqlConnection(env.db_con_str);
            cn.Open();
            string query = "SELECT * FROM reservation ";
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    reservationData.Add(new Reservation { courseId = (int)reader.GetValue(0), classId = (int)reader.GetValue(1) , day = (int)reader.GetValue(4) , from = (double)reader.GetValue(2) , to = (double)reader.GetValue(3) , isPractice = (bool)reader.GetValue(2) });
                }
                cn.Close();
                return reservationData;
            }
        }

        public static List<Reservation> getResByClassId(int classId)
        {
            List<Reservation> reservationData = new List<Reservation>();
            SqlConnection cn = new SqlConnection(env.db_con_str);
            cn.Open();
            using (SqlCommand cmd = new SqlCommand($"SELECT * FROM reservation WHERE class_id = {classId} ", cn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    reservationData.Add(new Reservation { courseId = (int)reader.GetValue(0), classId = (int)reader.GetValue(1), day = (int)reader.GetValue(4), from = (double)reader.GetValue(2), to = (double)reader.GetValue(3), isPractice = (bool)reader.GetValue(2) });
                }
                cn.Close();
                return reservationData;
            }
        }

        public List<Classroom> getClassroom(int dummyClassID)
        {
            SqlConnection cn = new SqlConnection(env.db_con_str);
            cn.Open();
            string query = "SELECT * FROM class c WHERE c.id = " + dummyClassID;
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    this.classroomData.Add(new Classroom { id = (int)reader.GetValue(0), lectureCap = (int)reader.GetValue(1), name = (string)reader.GetValue(2), examCap = (int)reader.GetValue(3), isLab = (bool)reader.GetValue(4) });
                }
                cn.Close();
                return classroomData;
            }
        }

        public List<Course> getCourse(int dummyCourseID)
        {
            SqlConnection cn = new SqlConnection(env.db_con_str);
            cn.Open();
            string query = "SELECT * FROM course c WHERE c.id = " + dummyCourseID;
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()){
                    this.courseData.Add(new Course { id = (int)reader.GetValue(0), name = (string)reader.GetValue(1), creditHours = (int)reader.GetValue(2), lectureHours = (float)reader.GetValue(3), practiceHours = (double)reader.GetValue(4), labHours = (float)reader.GetValue(5), term = (int)reader.GetValue(6), courseNamedId = (string)reader.GetValue(7), isActive = (bool)reader.GetValue(8)});
                }
                cn.Close();
                return courseData;
            }
        }
    }
}
