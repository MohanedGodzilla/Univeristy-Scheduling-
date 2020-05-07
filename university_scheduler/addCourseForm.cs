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
    public partial class addCourseForm : Form
    {
        
        public string conString =env.db_con_str ;
        public int courseId;
        public List<int> selectedResourceList ;
        public List<int> oldSelectedResourceList ;
        public List<int> editedResourceList;
        public List<int> deletedResourceList;
        public List<int> addedResourceList;
        public List<int> selectedProgramList;
        public List<int> oldSelectedProgramList ;
        public List<int> editedProgramList;
        public List<int> deletedProgramList;
        public List<int> addedProgramList;
        bool isEdit = false;
        private int current_id;

        public addCourseForm()
        {
            InitializeComponent();
            termCombo.SelectedIndex = 0;
            addCourseBTN.Show();
            saveBTN.Hide();
        }
        
        public addCourseForm(int courseId)
        {
            InitializeComponent();
            this.courseId = courseId;
            show_EditForm(courseId);
            addCourseBTN.Hide();
            saveBTN.Show();
            isEdit = true;
        }
        

        private void addCourseForm_Load(object sender, EventArgs e)
        {
            if (labHours.Value == 0)
            {
                selectResource.Enabled = false;
            }
            labHours.TextChanged += new EventHandler(numericUpDown1_TextChanged);
        }

        void numericUpDown1_TextChanged(object sender, EventArgs e)
        {
            if (labHours.Value != 0)
            {
                selectResource.Enabled = true;
            }
            else
            {
                selectResource.Enabled = false;
            }
        }

        private void addResourceForCourse(int id) {
            for (int i = 0; i < this.selectedResourceList.Count; i++){
                SqlConnection cn = new SqlConnection(conString);
                cn.Open();
                if (cn.State == System.Data.ConnectionState.Open)
                {
                    string query = "insert into course_has_resource (course_id,resource_id) values(" + id + " , " + this.selectedResourceList[i] + " )";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.ExecuteNonQuery();
                    //---//
                }
                cn.Close();
            }
        }
        private void addProgramForCourse(int id)
        {
            for (int i = 0; i < this.selectedProgramList.Count; i++)
            {
                SqlConnection cn = new SqlConnection(conString);
                cn.Open();
                if (cn.State == System.Data.ConnectionState.Open)
                {
                    string query = "insert into program_has_course(course_id,program_id) values(" + id + " , " + this.selectedProgramList[i] + " )";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.ExecuteNonQuery();
                    //---//
                }
                cn.Close();
            }
        }

        private void bringIdsOfCourseHasResource(int courseId) {
            SqlConnection cn = new SqlConnection(conString);
            cn.Open();
            string query = "SELECT resource_id FROM course_has_resource WHERE course_id = " + courseId;
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
            }
        }
        private void bringIdsOfCourseHasProgram(int courseId)
        {
            SqlConnection cn = new SqlConnection(conString);
            cn.Open();
            string query = "SELECT program_id FROM program_has_course WHERE course_id = " + courseId;
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                int count = 0;
                this.oldSelectedProgramList = new List<int>();
                while (reader.Read())
                {
                    int id = (int)reader.GetValue(0);
                    oldSelectedProgramList.Insert(count, id);
                    count++;
                }
                reader.Close();
            }
        }

        private void compareListsRes(List<int> oldSelected, List<int> newSelected){
            for (int i = 0; i < oldSelected.Count; i++){
                if (!newSelected.Contains(oldSelected[i])) {
                    this.deletedResourceList.Add(oldSelected[i]);
                }
            }
            for (int i = 0; i < newSelected.Count; i++) {
                if (!oldSelected.Contains(newSelected[i])){
                   this.addedResourceList.Add(newSelected[i]);
                }
            }
        }
        private void compareListsProg(List<int> oldSelected, List<int> newSelected)
        {
            for (int i = 0; i < oldSelected.Count; i++)
            {
                if (!newSelected.Contains(oldSelected[i]))
                {
                    this.deletedProgramList.Add(oldSelected[i]);
                }
            }
            for (int i = 0; i < newSelected.Count; i++)
            {
                if (!oldSelected.Contains(newSelected[i]))
                {
                    this.addedProgramList.Add(newSelected[i]);
                }
            }
        }

        private void editResourceForCourse(int id) {
            try
            {
                this.deletedResourceList = new List<int>();
                this.addedResourceList = new List<int>();
                bringIdsOfCourseHasResource(id);
                compareListsRes(this.oldSelectedResourceList, this.selectedResourceList);
                SqlConnection cn = new SqlConnection(conString);
                cn.Open();
                if (cn.State == System.Data.ConnectionState.Open)
                {
                    for (int j = 0; j < deletedResourceList.Count; j++)
                    {
                        string query = "DELETE FROM course_has_resource WHERE resource_id = " + deletedResourceList[j] + "AND course_id = " + id;
                        SqlCommand cmd = new SqlCommand(query, cn);
                        cmd.ExecuteNonQuery();
                    }
                    for (int j = 0; j < addedResourceList.Count; j++)
                    {
                        string query = "INSERT INTO course_has_resource(resource_id, course_id ) VALUES( '" + addedResourceList[j] + "' , '" + id + "')";
                        SqlCommand cmd = new SqlCommand(query, cn);
                        cmd.ExecuteNonQuery();
                    }
                }
                cn.Close();
            }catch(Exception e) { }
        }
        private void editProgramForCourse(int id)
        {
            try
            {
                this.deletedProgramList = new List<int>();
                this.addedProgramList = new List<int>();
                bringIdsOfCourseHasProgram(id);
                compareListsProg(this.oldSelectedProgramList, this.selectedProgramList);
                SqlConnection cn = new SqlConnection(conString);
                cn.Open();
                if (cn.State == System.Data.ConnectionState.Open)
                {
                    for (int j = 0; j < deletedProgramList.Count; j++)
                    {
                        string query = "DELETE FROM program_has_course WHERE program_id = " + deletedProgramList[j] + "AND course_id = " + id;
                        SqlCommand cmd = new SqlCommand(query, cn);
                        cmd.ExecuteNonQuery();
                    }
                    for (int j = 0; j < addedProgramList.Count; j++)
                    {
                        string query = "INSERT INTO program_has_course (program_id, course_id ) VALUES( '" + addedProgramList[j] + "' , '" + id + "')";
                        SqlCommand cmd = new SqlCommand(query, cn);
                        cmd.ExecuteNonQuery();
                    }
                }
                cn.Close();
            }catch(Exception e) { }
        }

        private int getTheMaxId() {
            SqlConnection cn = new SqlConnection(conString);
            cn.Open();
            string query = "SELECT MAX(id) from course";
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.ExecuteNonQuery();
            return (int)cmd.ExecuteScalar();
        }

        private void addCourseBTN_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(conString);
            cn.Open();
            if (cn.State == System.Data.ConnectionState.Open)
            {
                int val=0;
                if(isActive.Checked == true){
                    val = 1;
                }

                string query = "insert into course(name,credit_hours,lecture_hours,practice_hours,lab_hours,term,course_named_id,actived) values(" +"'" +courseName.Text.ToString() + "' , '" + creditHours.Text + "' , '" + lecHours.Text + "' , '" + practiceHours.Text + "' , '" + labHours.Text + "' , '" + (termCombo.SelectedIndex + 1) + "' , '" + courseCode.Text + "' , '" + val+"' )";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.ExecuteNonQuery();
                this.current_id = getTheMaxId();
                if (selectResource.Enabled == true) {
                    addResourceForCourse(this.current_id);
                }
                addProgramForCourse(this.current_id);
                MessageBox.Show("Adding course successfully..!");
                this.Close();
            }
        }

        private void saveBTN_Click(object sender, EventArgs e)
        {
            int selected_id = courseId;
            SqlConnection cn = new SqlConnection(conString);
            cn.Open();
            if (cn.State == System.Data.ConnectionState.Open)
            {
                int val = 0;
                if (isActive.Checked == true){
                    val = 1;
                }
                string query = "UPDATE course SET name = '"+courseName.Text + "' , credit_hours = '" + creditHours.Value + "' , lecture_hours = '" + lecHours.Value + "' , practice_hours = '" + practiceHours.Text + "' , lab_hours = '" + labHours.Text + "' , term = '" + (termCombo.SelectedIndex + 1) + "' , course_named_id =  '" + courseCode.Text + "' , actived = '" + val + "' WHERE id = " + selected_id;
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.ExecuteNonQuery();
                if (selectResource.Enabled == true){
                    editResourceForCourse(selected_id);
                }
                editProgramForCourse(selected_id);
                //---//
                MessageBox.Show("updateing course successfully...!");
                this.Close();
            }
        }

        private void show_EditForm(int courseId)
        { 
            //this function to show data in Edit form
            using (SqlConnection cn = new SqlConnection(conString))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM course WHERE id=" + courseId, cn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        courseName.Text = reader.GetValue(1).ToString();
                        creditHours.Value = (int)reader.GetValue(2);
                        lecHours.Value = new decimal((double)reader.GetValue(3));
                        practiceHours.Value = new decimal((double)reader.GetValue(4));
                        labHours.Value = new decimal((double)reader.GetValue(5));
                        termCombo.SelectedIndex = (int)reader.GetValue(6) - 1;
                        courseCode.Text = reader.GetValue(7).ToString();
                        if (reader.GetValue(8).ToString() == "1")
                        {
                            isActive.Checked = true;
                        }
                        else isActive.Checked = false;
                    }
                    reader.Close();

                }

            }
        }

        private void cancelBTN_Click(object sender, EventArgs e){
            this.Close();

        }
        
        private void selectResource_Click(object sender, EventArgs e)
        {
            selectResourceForm resForm = new selectResourceForm(this.courseId);
            DialogResult dialogresult = resForm.ShowDialog();
            this.selectedResourceList = resForm.checkedResource;
        }
        private void selectProgramBTN_Click(object sender, EventArgs e)
        {
            selectProgramForm progForm;
            if (isEdit && selectedProgramList==null) {//is editing
                progForm = new selectProgramForm(this.courseId);
            } else {
                progForm = new selectProgramForm(selectedProgramList);
            }
            DialogResult dialogresult = progForm.ShowDialog();
            this.selectedProgramList = progForm.checkedPrograms;
        }

        private void courseName_TextChanged(object sender, EventArgs e)
        {

        }

        private void courseCode_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
