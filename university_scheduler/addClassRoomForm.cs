using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace university_scheduler
{
    public partial class addClassRoomForm : Form
    {
        public string conString = env.db_con_str;
        public int classId;
        public List<int> selectedResourceList;
        public List<int> oldSelectedResourceList;
        public List<int> editedResourceList;
        public List<int> deletedResourceList;
        public List<int> addedResourceList;

        bool isEdit = false;
        private int current_id;

        viewClassroomForm classForm = (viewClassroomForm)Application.OpenForms["viewClassroomForm"];// it's an object that is used in function addClassRoomBTN_Click() to reopen the form when adding a new tuple in the database 

        public addClassRoomForm()
        {
            InitializeComponent();
            addClassBTN.Show();
            saveClassBTN.Hide();
        }
        public addClassRoomForm(int classId, int viewClassroom_disableSaveBTN)
        {
            InitializeComponent();
            this.classId = classId;
            show_EditForm(classId);
            addClassBTN.Hide();
            if (viewClassroom_disableSaveBTN == 0)
            {
                saveClassBTN.Show();
            }
            else if (viewClassroom_disableSaveBTN == 1)
            {
                saveClassBTN.Hide();
            }
            isEdit = true;           
        }

        private void addResourceForClass(int id)
        {
            for (int i = 0; i < this.selectedResourceList.Count; i++)
            {
                SqlConnection cn = new SqlConnection(conString);
                cn.Open();
                if (cn.State == System.Data.ConnectionState.Open)
                {
                    string query = "insert into class_has_resource (class_id,resource_id) values(" + id + " , " + this.selectedResourceList[i] + " )";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.ExecuteNonQuery();
                    //---//
                }
                cn.Close();
            }
        }

        private void bringIdsOfClassHasResource(int courseId)
        {
            SqlConnection cn = new SqlConnection(conString);
            cn.Open();
            string query = "SELECT resource_id FROM class_has_resource WHERE class_id = " + classId;
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                int count = 0;
                this.oldSelectedResourceList = new List<int>();
                while (reader.Read())
                {
                    int id = (int)reader.GetValue(0);
                    oldSelectedResourceList.Insert(count, id);
                    count++;
                }
                reader.Close();
                cn.Close();
            }
        }

        private void compareListsRes(List<int> oldSelected, List<int> newSelected)
        {
            for (int i = 0; i < oldSelected.Count; i++)
            {
                if (!newSelected.Contains(oldSelected[i]))
                {
                    this.deletedResourceList.Add(oldSelected[i]);
                }

            }
            for (int i = 0; i < newSelected.Count; i++)
            {
                if (!oldSelected.Contains(newSelected[i]))
                {
                    this.addedResourceList.Add(newSelected[i]);
                }
            }
        }

        private void editResourceForClass(int id)
        {
            try
            {
                this.deletedResourceList = new List<int>();
                this.addedResourceList = new List<int>();
                bringIdsOfClassHasResource(id);
                compareListsRes(this.oldSelectedResourceList, this.selectedResourceList);
                SqlConnection cn = new SqlConnection(conString);
                cn.Open();
                if (cn.State == System.Data.ConnectionState.Open)
                {
                    for (int j = 0; j < deletedResourceList.Count; j++)
                    {
                        string query = "DELETE FROM class_has_resource WHERE resource_id = " + deletedResourceList[j] + "AND class_id = " + id;
                        SqlCommand cmd = new SqlCommand(query, cn);
                        cmd.ExecuteNonQuery();
                    }
                    for (int j = 0; j < addedResourceList.Count; j++)
                    {
                        string query = "INSERT INTO class_has_resource(resource_id, class_id ) VALUES( '" + addedResourceList[j] + "' , '" + id + "')";
                        SqlCommand cmd = new SqlCommand(query, cn);
                        cmd.ExecuteNonQuery();
                    }
                }
                cn.Close();
            }
            catch (Exception e) { }
        }

        private int getTheMaxId()
        {
            SqlConnection cn = new SqlConnection(conString);
            cn.Open();
            string query = "SELECT MAX(id) from class";
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.ExecuteNonQuery();
            int val = (int)cmd.ExecuteScalar();
            cn.Close();
            return val;
        }

        private void addClassBTN_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(conString);
            cn.Open();
            if (cn.State == System.Data.ConnectionState.Open)
            {
                int valCheck;
                if (isLab.Checked)
                {
                    valCheck = 1;
                }
                else
                {
                    valCheck = 0;
                }

                string query = "insert into class(name, lecture_capacity, exam_capacity, isLab) values(N'" + className.Text.ToString() + "' ,'" + lecCounter.Value + "' ,'" + examCounter.Value + "','" + valCheck + "' )";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.ExecuteNonQuery();
                this.current_id = getTheMaxId();
                if (selectResource.Enabled == true)
                {
                    addResourceForClass(this.current_id);
                }
                cn.Close();
                MessageBox.Show("Adding class successfully..!");
                this.Close();
            }
        }

        private void saveClassBTN_Click(object sender, EventArgs e)
        {
            int selected_id = classId;
            SqlConnection cn = new SqlConnection(conString);
            cn.Open();
            if (cn.State == System.Data.ConnectionState.Open)
            {
                string query = "UPDATE class SET name = N'" + className.Text.ToString() + "', lecture_capacity = '" + lecCounter.Value + "',exam_capacity = '" + examCounter.Value + "' WHERE id = " + selected_id;
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.ExecuteNonQuery();
                if (selectResource.Enabled == true)
                {
                    editResourceForClass(selected_id);
                }
                MessageBox.Show("updateing class successfully..!");
                cn.Close();
                this.Close();
            }

        }

        private void show_EditForm(int classId)
        {
            //this function to show data in Edit form
            using (SqlConnection cn = new SqlConnection(conString))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM class WHERE id=" + classId, cn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        lecCounter.Value = (int)reader.GetValue(1);
                        className.Text = reader.GetValue(2).ToString();
                        examCounter.Value = (int)reader.GetValue(3);
                        int val = (int)reader.GetValue(4);
                        if (val == 1)
                        {
                            isLab.Checked = true;
                        }
                        else
                        {
                            isLab.Checked = false;
                        }
                    }
                    reader.Close();
                    cn.Close();
                }
            }
        }

        private void cancelClassBTN_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void selectResource_Click(object sender, EventArgs e)
        {
            selectResourceForm resForm;
            if (isEdit && selectedResourceList == null)
            {//is editing
                resForm = new selectResourceForm(this.classId, "class");
            }
            else
            {
                resForm = new selectResourceForm(selectedResourceList, "class");
            }
            DialogResult dialogresult = resForm.ShowDialog();
            this.selectedResourceList = resForm.checkedResource;
        }

        private void addClassRoomForm_Load(object sender, EventArgs e)
        {
            if (!isLab.Checked)
            {
                selectResource.Enabled = false;
            }
            isLab.CheckedChanged += new EventHandler(checkBox1_CheckedChanged);
        }

        void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (isLab.Checked)
            {
                selectResource.Enabled = true;
            }
            else
            {
                selectResource.Enabled = false;
            }
        }
    }
}
