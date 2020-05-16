using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace university_scheduler.Model
{
    class courseHasResource
    {
        
        public void insertResource(int dummyCourseId, int dummyResourceId)
        {
            SqlConnection cn = new SqlConnection(env.db_con_str);
            cn.Open();
            if (cn.State == System.Data.ConnectionState.Open)
            {
                string query = "insert into course_has_resource(course_id,resource_id) values('" + dummyCourseId + "' , '" + dummyResourceId + "')";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.ExecuteNonQuery();
                //---//
            }
            cn.Close();
        }

        public static List<int> getResourcesIdsOfCourse(int courseId) {
            List<int> resourcesIds = new List<int>();
            SqlConnection cn = new SqlConnection(conString);
            cn.Open();
            if (cn.State == System.Data.ConnectionState.Open)
            {
                string query = "select resource_id from course_has_resource where course_id = " + courseId;
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        resourcesIds.Add((int)reader.GetValue(0));
                    }
                }
                //---//
            }
            cn.Close();
            return resourcesIds;
        }
    }
}
