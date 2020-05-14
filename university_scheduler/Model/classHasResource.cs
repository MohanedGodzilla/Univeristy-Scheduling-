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
        public List<classHasResource> resourceList { get; set; }

        public string conString = env.db_con_str;

        public List<classHasResource> getAll()
        {
            SqlConnection cn = new SqlConnection(conString);
            cn.Open();
            string query = "SELECT * FROM class_has_resource";
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    this.resourceList.Add(new classHasResource { classId = (int)reader.GetValue(1), resourceId = (int)reader.GetValue(2) });
                    
                }
                return resourceList;
            }
        }

        public List<classHasResource> getAll(int classId)
        {
            SqlConnection cn = new SqlConnection(conString);
            cn.Open();
            string query = "SELECT * FROM class_has_resource WHERE class_id = '"+classId+"' ";
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    this.resourceList.Add(new classHasResource { classId = (int)reader.GetValue(1), resourceId = (int)reader.GetValue(2) });

                }
                return resourceList;
            }
        }
    }
}
