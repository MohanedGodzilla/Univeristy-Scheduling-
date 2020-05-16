using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace university_scheduler.Model
{
    class Classroom
    {
        public int id { get; set; }
        public string name { get; set; }
        public int lectureCap { get; set; }
        public int examCap { get; set; }
        public int isLab { get; set; }
        public double max_time { get; set; }
        public int max_days { get; set; }

        public string conString = env.db_con_str;

        List<Resource> classResourses = new List<Resource>();

        List<Classroom> classData = new List<Classroom>();

        Dictionary<int, Dictionary<dynamic, int>> reservations = new Dictionary<int, Dictionary<dynamic, int>>();

        Dictionary<int, List<List<dynamic>>> blockedHours = new Dictionary<int, List<List<dynamic>>>();

        public List<Classroom> getAll()
        {
            SqlConnection cn = new SqlConnection(conString);
            cn.Open();
            string query = "SELECT * FROM class";
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    this.classData.Add(new Classroom { id = (int)reader.GetValue(0), lectureCap = (int)reader.GetValue(1), name = (string)reader.GetValue(2), examCap = (int)reader.GetValue(3), isLab = (int)reader.GetValue(4) });
                }
                return classData;
            }
        }

        public List<Classroom> getAll(string dummyName)
        {
            SqlConnection cn = new SqlConnection(conString);
            cn.Open();
            string query = "SELECT * FROM class WHERE name LIKE '% " + dummyName + "%'";
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    this.classData.Add(new Classroom { id = (int)reader.GetValue(0), lectureCap = (int)reader.GetValue(1), name = (string)reader.GetValue(2), examCap = (int)reader.GetValue(3), isLab = (int)reader.GetValue(4) });
                }
                return classData;
            }
        }

        public void insert(string name, int lecCap, int examCap, int isLab)
        {
           
            SqlConnection cn = new SqlConnection(conString);
            cn.Open();
            if (cn.State == System.Data.ConnectionState.Open)
            {
                string query = "insert into class(name, lecture_capacity, exam_capacity, isLab) values( '" + name + "' ,'" + lecCap + "' ,'" + examCap + "','" + isLab + "' )";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.ExecuteNonQuery();

            }
            cn.Close();
        }

        public int getCurrentClassId()
        {
            SqlConnection cn = new SqlConnection(conString);
            cn.Open();
            string query = "SELECT MAX(id) from class";
            SqlCommand cmd = new SqlCommand(query, cn);
           // cmd.ExecuteNonQuery();
            return (int)cmd.ExecuteScalar();
        }
        public List<Resource> getClassResources(int classId)
        {
            List<Resource> classResources = new List<Resource>();
            List<int> resourcesIds = classHasResource.getResourcesIdsOfClass(classId);
            foreach (int resourceId in resourcesIds)
            {
                classResources.Add(Resource.getResourceById(resourceId));
            }
            return classResources;
        }
        
        public bool isHourBlocked(List<List<dynamic>> hoursToChecke)
        {
            return blockedHours.ContainsValue(hoursToChecke);
        }
    }
}
