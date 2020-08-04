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
        public int id;
        public int courseId;
        public int classId;
        public int day;
        public double from;
        public double to;
        public String sessionType;

        public List<Program> programs = new List<Program>();

        public Reservation() {
            this.courseId = 0;
            this.classId = 0;
            this.day = 0;
            this.from = 0;
            this.to = 0;
            this.sessionType = "lecture";
        }

        public Reservation(int dummyCourseId, int dummyClassId, int dummyDay, double dummyFrom, double dummyTo,string sessionType)
        {
            this.courseId = dummyCourseId;
            this.classId = dummyClassId;
            this.day = dummyDay;
            this.from = dummyFrom;
            this.to = dummyTo;
            this.sessionType = sessionType;
        }

        public void insertThis() {
            int term = Course.getCourseById(courseId).term;
            SqlConnection cn = new SqlConnection(env.db_con_str);
            cn.Open();
            if (cn.State == System.Data.ConnectionState.Open) {
                string query = $"insert into reservation(course_id,class_id,\"from\",\"to\",\"day\",session_type) OUTPUT INSERTED.ID values({courseId}, {classId}, {from}, {to}, {day}, '{sessionType}')";
                Console.WriteLine(query);
                SqlCommand cmd = new SqlCommand(query, cn);
                int id = (int)cmd.ExecuteScalar();
                cn.Close();
                programs.ForEach((Program program)=>{

                    ReservationHasProgram.insert(id, program.id,term);
                });
            }
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
                    Reservation res = new Reservation((int)reader.GetValue(1), (int)reader.GetValue(2), (int)reader.GetValue(5), (double)reader.GetValue(3), (double)reader.GetValue(4), (string)reader.GetValue(5));
                    res.id = (int)reader.GetValue(0);
                    res.programs = ReservationHasProgram.getReservationPrograms(res.id);
                    reservationData.Add(res);
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
            using (SqlCommand cmd = new SqlCommand($"SELECT * FROM reservation WHERE class_id = {classId} ORDER BY \"day\",\"from\" ", cn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    Reservation res = new Reservation((int)reader.GetValue(1), (int)reader.GetValue(2), (int)reader.GetValue(5), (double)reader.GetValue(3), (double)reader.GetValue(4), (string)reader.GetValue(6));
                    reservationData.Add(res);
                }
                cn.Close();
                return reservationData;
            }
        }


        public static Reservation getResById(int resId)
        {
            Reservation reservationData = new Reservation();
            SqlConnection cn = new SqlConnection(env.db_con_str);
            cn.Open();
            using (SqlCommand cmd = new SqlCommand($"SELECT * FROM reservation WHERE id = {resId} ", cn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Reservation res = new Reservation((int)reader.GetValue(1), (int)reader.GetValue(2), (int)reader.GetValue(5), (double)reader.GetValue(3), (double)reader.GetValue(4), (string)reader.GetValue(6));
                    reservationData= res;
                }
                cn.Close();
                return reservationData;
            }
        }

        public static void deleteAll() {
            string query = "DELETE FROM reservation;DBCC CHECKIDENT (reservation, RESEED, 0);DBCC CHECKIDENT (reservation_has_program, RESEED, 0);";
            SqlConnection cn = new SqlConnection(env.db_con_str);
            cn.Open();
            using (SqlCommand cmd = new SqlCommand(query, cn)) {
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }
    }
}
