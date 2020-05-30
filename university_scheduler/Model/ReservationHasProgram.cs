using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace university_scheduler.Model {
   
    class ReservationHasProgram {
        public int id;
        public int reservation_id;
        public int program_id;




        public static List<Program> getReservationPrograms(int reservationID) {
            SqlConnection cn = new SqlConnection(env.db_con_str);
            List<Program> programs = new List<Program>();
            cn.Open();
            string query = "SELECT program_id FROM reservation_has_program WHERE id = " + reservationID;
            using (SqlCommand cmd = new SqlCommand(query, cn)) {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    programs.Add(Program.getProgramById((int)reader.GetValue(0)));
                }
                cn.Close();
                return programs;
            }
        }

        public static List<Reservation> getProgramReservations(int programId) {
            SqlConnection cn = new SqlConnection(env.db_con_str);
            List<Reservation> reservations = new List<Reservation>();
            cn.Open();
            string query = $"SELECT reservation_id FROM reservation_has_program WHERE program_id =  {programId}";
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    reservations.Add(Reservation.getResById((int)reader.GetValue(0)));
                }
                cn.Close();
                return reservations;
            }
        }

        public static int insert(int reservation_id, int program_id) {
            SqlConnection cn = new SqlConnection(env.db_con_str);
            cn.Open();
            if (cn.State == System.Data.ConnectionState.Open) {
                string query = $"insert into reservation_has_program(reservation_id,program_id) OUTPUT INSERTED.ID values ({reservation_id},{program_id})";
                SqlCommand cmd = new SqlCommand(query, cn);
                int id = (int)cmd.ExecuteScalar();
                cn.Close();
                return id;

            }
            return -1;
        }
    }
}
