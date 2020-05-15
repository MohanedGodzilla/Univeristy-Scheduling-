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
        public string conString = env.db_con_str;
        public void insertResource(int dummyCourseId, int dummyResourceId)
        {
            SqlConnection cn = new SqlConnection(conString);
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
    }
}
