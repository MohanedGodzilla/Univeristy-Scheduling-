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

        public string conString = env.db_con_str;
        List<Resource> resourceData = new List<Resource>();
        

        public override string ToString(){
            return "ID: " + id + "   Name: " + name;
        }

        public List<Resource> getAll() {
            SqlConnection cn = new SqlConnection(conString);
            cn.Open();
            string query = "SELECT * FROM resource ";
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    this.resourceData.Add(new Resource { name = reader.GetValue(1).ToString(), id = (int)reader.GetValue(0) });
                }

                return resourceData;
            }
            cn.Close();
        }

        public List<Resource> getAll(string dummyName)
        {
            SqlConnection cn = new SqlConnection(conString);
            cn.Open();
            string query = "SELECT * FROM resource where name LIKE '%" + dummyName + "%'";
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    this.resourceData.Add(new Resource { name = dummyName, id = (int)reader.GetValue(0) });
                }

                return resourceData;
            }
            cn.Close();
        }
    }
}
