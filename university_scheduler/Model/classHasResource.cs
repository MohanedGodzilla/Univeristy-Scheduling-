using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace university_scheduler.Model
{
    class classHasResource
    {
        public int classId { get; set; }
        public int resourceId { get; set; }



        public static List<classHasResource> getAll()
        {
            List<classHasResource> classHasResources = new List<classHasResource>();
            SqlConnection cn = new SqlConnection(env.db_con_str);
            cn.Open();
            string query = "SELECT * FROM class_has_resource";
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    classHasResources.Add(new classHasResource { classId = (int)reader.GetValue(1), resourceId = (int)reader.GetValue(2) });
                    
                }
                return classHasResources;
            }
        }

        public static List<classHasResource> getAll(int classId)
        {
            List<classHasResource> classHasResources = new List<classHasResource>();
            SqlConnection cn = new SqlConnection(env.db_con_str);
            cn.Open();
            string query = "SELECT * FROM class_has_resource WHERE class_id = '"+classId+"' ";
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    classHasResources.Add(new classHasResource { classId = (int)reader.GetValue(1), resourceId = (int)reader.GetValue(2) });

                }
                return classHasResources;
            }
        }
        public void insertResource(int dummyClassId, int dummyResourceId)
        {
            SqlConnection cn = new SqlConnection(env.db_con_str);
            cn.Open();
            if (cn.State == System.Data.ConnectionState.Open)
            {
                string query = "insert into class_has_resource(class_id,resource_id) values('" + dummyClassId + "' , '" + dummyResourceId + "')";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.ExecuteNonQuery();
                //---//
            }
            cn.Close();
        }

    }
}
