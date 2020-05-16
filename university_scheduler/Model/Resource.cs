using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace university_scheduler.Model
{
    class Resource
    {
        public int id { get; set; }
        public string name { get; set; }

        public static string conString = env.db_con_str;
        public override string ToString(){
            return "ID: " + id + "   Name: " + name;
        }


        public void insertResource(string dummyName) {
            SqlConnection cn = new SqlConnection(conString);
            cn.Open();
            if (cn.State == System.Data.ConnectionState.Open)
            {
                string query = "insert into resource(name) values('" + dummyName + "')";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.ExecuteNonQuery();
                //---//
            }
            cn.Close();
        }

        public static List<Resource> getAll() {
            List<Resource> resourceData = new List<Resource>();
            SqlConnection cn = new SqlConnection(conString);
            cn.Open();
            string query = "SELECT * FROM resource ";
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    resourceData.Add(new Resource { name = reader.GetValue(1).ToString(), id = (int)reader.GetValue(0) });
                }
                cn.Close();
                return resourceData;
            }
        }

        public static List<Resource> getAll(string dummyName)
        {
            List<Resource> resourceData = new List<Resource>();
            SqlConnection cn = new SqlConnection(conString);
            cn.Open();
            string query = "SELECT * FROM resource where name LIKE '%" + dummyName + "%'";
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    resourceData.Add(new Resource { name = dummyName, id = (int)reader.GetValue(0) });
                }
                cn.Close();
                return resourceData;
            }
        }

        public static Resource getResourceById(int dummyResourceID){
            List<Resource> resourceData = new List<Resource>();
            SqlConnection cn = new SqlConnection(conString);
            cn.Open();
            string query = "SELECT * FROM resource r WHERE r.id = " + dummyResourceID;
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                Resource res = new Resource { id = (int)reader.GetValue(0), name = (string)reader.GetValue(1) };
                cn.Close();
                return res;
            }
        }
    }
}
