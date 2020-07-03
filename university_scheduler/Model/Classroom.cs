using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace university_scheduler.Model {
    class Classroom {
        public int id;
        public string name;
        public int lectureCap;
        public int examCap;
        public bool isLab;

        public List<Resource> resources = new List<Resource>();


        public Dictionary<int, Dictionary<dynamic, int>> reservations = new Dictionary<int, Dictionary<dynamic, int>>();

        public Dictionary<int, List<List<dynamic>>> blockedHours = new Dictionary<int, List<List<dynamic>>>();

        public Classroom(int id, string name, int lecCap, int examCap, bool isLab) {
            this.id = id;
            this.name = name;
            this.lectureCap = lecCap;
            this.examCap = examCap;
            this.isLab = isLab;
            for (int i = 0; i < Data.SchedulerConfigs.maxDays; i++) {
                for (double j = 0; j < Data.SchedulerConfigs.maxTime; j++) {
                    reservations[i] = new Dictionary<dynamic, int>();
                }
            }
        }

        public static List<Classroom> getAll() {
            return getClassrooms("SELECT * FROM class");
        }

        public static List<Classroom> getAll(string dummyName) {
            return getClassrooms("SELECT * FROM class WHERE name LIKE '% " + dummyName + "%'");
        }

        private static List<Classroom> getClassrooms(string getQuery) {
            List<Classroom> classrooms = new List<Classroom>();
            SqlConnection cn = new SqlConnection(env.db_con_str);
            cn.Open();
            string query = getQuery;
            using (SqlCommand cmd = new SqlCommand(query, cn)) {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    classrooms.Add(new Classroom((int)reader.GetValue(0), (string)reader.GetValue(2), (int)reader.GetValue(1), (int)reader.GetValue(3), ((int)reader.GetValue(4) == 0 ? false : true)));
                }
                cn.Close();
                classrooms.ForEach((Classroom room) => {
                    room.resources = getClassResources(room.id);
                });
                return classrooms;
            }
        }

        public static List<Classroom> getClassroomById(int dummyId)
        {
            return getClassrooms("SELECT * FROM class WHERE id = " + dummyId);
        }

        public static void insert(string name, int lecCap, int examCap, int isLab) {

            SqlConnection cn = new SqlConnection(env.db_con_str);
            cn.Open();
            if (cn.State == System.Data.ConnectionState.Open) {
                string query = "insert into class(name, lecture_capacity, exam_capacity, isLab) values( '" + name + "' ,'" + lecCap + "' ,'" + examCap + "','" + isLab + "' )";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }

        public static int getCurrentClassId() {
            SqlConnection cn = new SqlConnection(env.db_con_str);
            cn.Open();
            string query = "SELECT MAX(id) from class";
            SqlCommand cmd = new SqlCommand(query, cn);
            // cmd.ExecuteNonQuery();
            int val = (int)cmd.ExecuteScalar();
            cn.Close();
            return val;
        }
        public static List<Resource> getClassResources(int classId) {
            List<Resource> classResources = new List<Resource>();
            List<int> resourcesIds = classHasResource.getResourcesIdsOfClass(classId);
            foreach (int resourceId in resourcesIds) {
                classResources.Add(Resource.getResourceById(resourceId));
            }
            return classResources;
        }

        /// if not blocked return -1
        /// if blocked return the end of the blocked Hours 
        public double isHourBlocked(int day, double from, double to) {
            if (this.blockedHours != null && this.blockedHours.ContainsKey(day) && this.blockedHours[day] != null) {
                for (int i = 0; i < this.blockedHours[day].Count; i++) {
                    double blockedFrom = this.blockedHours[day][i][0];
                    double blockedTo = this.blockedHours[day][i][1];
                    if (from >= blockedFrom && from <= blockedTo || to >= blockedFrom && to <= blockedTo) {
                        return blockedTo;
                    }
                }
            }
            return -1; //not blocked 
        }

        public static DataTable search(int flag)
        {
            //return getClassrooms();
            SqlConnection cn = new SqlConnection(env.db_con_str);
            cn.Open();
            string query="";
            if (flag==1)
                query = "SELECT id,name,lecture_capacity as 'lec cap' , exam_capacity as 'exam cap' FROM class";
            else if(flag==2)
                query = "SELECT name FROM class";
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                DataTable dt = new DataTable();
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
                return dt;
            }
        }

    }
}
