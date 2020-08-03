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

        public string conString = env.db_con_str;
        public int courseId;
        viewCoursesForm courseForm = (viewCoursesForm)Application.OpenForms["viewCoursesForm"];// it's an object that is used in function addCourseBTN_Click() to reopen the form when adding a new tuple in the database
        public List<int> selectedResourceList;
        public List<int> oldSelectedResourceList;
        public List<int> editedResourceList;
        public List<int> deletedResourceList;
        public List<int> addedResourceList;
        public List<int> selectedProgramList;
        public List<int> oldSelectedProgramList;
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
            lecHours.Enabled = false;
            practiceHours.Enabled = false;
            labHours.Enabled = false;
        }

        public addCourseForm(int courseId, int viewCourse_disableSaveBTN)
        {
            InitializeComponent();
            this.courseId = courseId;
            show_EditForm(courseId);
            addCourseBTN.Hide();
            if (viewCourse_disableSaveBTN == 0)
            {
                saveBTN.Show();

            }
            else if (viewCourse_disableSaveBTN == 1)
            {
                saveBTN.Hide();
            }
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

        private void addResourceForCourse(int id)
        {
            for (int i = 0; i < this.selectedResourceList.Count; i++)
            {
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
            if (selectedProgramList != null)
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

        }

        private void bringIdsOfCourseHasResource(int courseId)
        {
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
                cn.Close();
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
            if (newSelected != null)
            {
                for (int i = 0; i < newSelected.Count; i++)
                {
                    if (!oldSelected.Contains(newSelected[i]))
                    {
                        this.addedResourceList.Add(newSelected[i]);
                    }
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
            if (newSelected != null)

                for (int i = 0; i < newSelected.Count; i++)
                {
                    if (!oldSelected.Contains(newSelected[i]))
                    {
                        this.addedProgramList.Add(newSelected[i]);
                    }
                }
        }

        private void editResourceForCourse(int id)
        {
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
            }
            catch (Exception e) { }
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
            }
            catch (Exception e) { }
        }

        private int getTheMaxId()
        {
            SqlConnection cn = new SqlConnection(conString);
            cn.Open();
            string query = "SELECT MAX(id) from course";
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.ExecuteNonQuery();
            int val = (int)cmd.ExecuteScalar();
            cn.Close();
            return val;
        }

        private void addCourseBTN_Click(object sender, EventArgs e)
        {
            try
            {
                if (labHours.Value != 0 && this.selectedResourceList.Count == 0 )
                {
                    MessageBox.Show("you have to select the resource type for this course.\n PLEASE, check it again ");
                    return;
                }
            }
            catch (Exception ex) {
                MessageBox.Show("you have to select the resource type for this course.\n PLEASE, check it again ");
                return;
            }
            if ((((lecHours.Value + practiceHours.Value + labHours.Value) - 1) != creditHours.Value))
            {
                MessageBox.Show("The sum of lecture, practice and lab hours is not equal to credit hours \n PLEASE, check it again ");
            }
            if ((String.IsNullOrEmpty(courseCode.Text) && String.IsNullOrEmpty(courseName.Text)))
            {
                MessageBox.Show("May be there are some empty fields.\n PLEASE, check it again ");
            }
            
            else
            {
                SqlConnection cn = new SqlConnection(conString);
                cn.Open();
                if (cn.State == System.Data.ConnectionState.Open)
                {
                    int val = 0;
                    if (isActive.Checked == true)
                    {
                        val = 1;
                    }

                    string query = "insert into course(name,credit_hours,lecture_hours,practice_hours,lab_hours,term,course_named_id,actived) values(" + "N'" + courseName.Text.ToString() + "' , '" + creditHours.Text + "' , '" + lecHours.Text + "' , '" + practiceHours.Text + "' , '" + labHours.Text + "' , '" + (termCombo.SelectedIndex + 1) + "' , N'" + courseCode.Text + "' , '" + val + "' )";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (System.Data.SqlClient.SqlException ex) {
                        int SQL_UNIQUE_KEY_VIOLATION = -2146232060;
                        if (ex.ErrorCode == SQL_UNIQUE_KEY_VIOLATION)
                        {
                            MessageBox.Show("Course Code already exists!");
                            return;
                        }
                    }
                    this.current_id = getTheMaxId();
                    if (selectResource.Enabled == true)
                    {
                        addResourceForCourse(this.current_id);
                    }
                    addProgramForCourse(this.current_id);
                    this.Close();
                    courseForm.loaddata();
                    courseForm.courseData.Update();
                    courseForm.courseData.Refresh();
                }
                cn.Close();
            }
        }

        private void saveBTN_Click(object sender, EventArgs e)
        {
            if ((((lecHours.Value + practiceHours.Value + labHours.Value) - 1) != creditHours.Value))
            {
                MessageBox.Show("The sum of lecture, practice and lab hours is not equal to credit hours \n PLEASE, check it again ");
            }
            if ((String.IsNullOrEmpty(courseCode.Text) && String.IsNullOrEmpty(courseName.Text)))
            {
                MessageBox.Show("May be there are some empty fields.\n PLEASE, check it again ");
            }
            else
            {
                int selected_id = courseId;
                SqlConnection cn = new SqlConnection(conString);
                cn.Open();
                if (cn.State == System.Data.ConnectionState.Open)
                {
                    int val = 0;
                    if (isActive.Checked == true)
                    {
                        val = 1;
                    }
                    string query = "UPDATE course SET name = N'" + courseName.Text + "' , credit_hours = '" + creditHours.Value + "' , lecture_hours = '" + lecHours.Value + "' , practice_hours = '" + practiceHours.Text + "' , lab_hours = '" + labHours.Text + "' , term = '" + (termCombo.SelectedIndex + 1) + "' , course_named_id =  N'" + courseCode.Text + "' , actived = '" + val + "' WHERE id = " + selected_id;
                    SqlCommand cmd = new SqlCommand(query, cn);
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        int SQL_UNIQUE_KEY_VIOLATION = -2146232060;
                        if (ex.ErrorCode == SQL_UNIQUE_KEY_VIOLATION)  {
                            MessageBox.Show("Course Code already exists!");
                            return;
                        }
                    }
                    if (selectResource.Enabled == true){
                            editResourceForCourse(selected_id);
                    }
                    editProgramForCourse(selected_id);
                    //---//
                    MessageBox.Show("updateing course successfully...!");
                    cn.Close();
                    this.Close();
                    courseForm.loaddata();
                    courseForm.courseData.Update();
                    courseForm.courseData.Refresh();
                  }
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
                cn.Close();

            }
        }

        private void cancelBTN_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void selectResource_Click(object sender, EventArgs e)
        {
            /*selectResourceForm resForm = new selectResourceForm(this.courseId, "course");
            DialogResult dialogresult = resForm.ShowDialog();
            this.selectedResourceList = resForm.checkedResource;*/

            selectResourceForm resForm;
            if (isEdit && selectedResourceList == null)
            {//is editing
                resForm = new selectResourceForm(this.courseId, "course");
            }
            else
            {
                resForm = new selectResourceForm(selectedResourceList, "course");
            }
            DialogResult dialogresult = resForm.ShowDialog();
            this.selectedResourceList = resForm.checkedResource;
        }
        private void selectProgramBTN_Click(object sender, EventArgs e)
        {
            selectProgramForm progForm;
            if (isEdit && selectedProgramList == null)
            {//is editing
                progForm = new selectProgramForm(this.courseId);
            }
            else
            {
                progForm = new selectProgramForm(selectedProgramList);
            }
            DialogResult dialogresult = progForm.ShowDialog();
            this.selectedProgramList = progForm.checkedPrograms;
        }

        private void creditHours_ValueChanged(object sender, EventArgs e)
        {
            lecHours.Enabled = true;
            practiceHours.Enabled = true;
            labHours.Enabled = true;
            if (creditHours.Value > 0) {
                lecHours.Maximum = creditHours.Value;
                practiceHours.Maximum = creditHours.Value +1;
                labHours.Maximum = creditHours.Value + 1;
            }
        }

        private void lecHours_ValueChanged(object sender, EventArgs e)
        {
            labHours.Enabled = true;
            practiceHours.Enabled = true;
            if (lecHours.Value == creditHours.Value)
            {
                labHours.Maximum = 1;
                practiceHours.Maximum = 1;
            }
            else if (lecHours.Value + 1 == creditHours.Value)
            {
                labHours.Maximum = 2;
                practiceHours.Maximum = 2;
            }
            else if ((lecHours.Value < creditHours.Value) && (lecHours.Value + 1 != creditHours.Value)) {
                labHours.Maximum = (creditHours.Value - labHours.Value) +1;
                practiceHours.Maximum = (creditHours.Value - labHours.Value) + 1;
            }
        }

        private void practiceHours_ValueChanged(object sender, EventArgs e)
        {
            lecHours.Enabled = true;
            if ((labHours.Value + practiceHours.Value) - 1 == creditHours.Value)
            {
                lecHours.Value = 0;
                lecHours.Enabled = false;
            }
            if ((practiceHours.Value - 1) == creditHours.Value && lecHours.Value == 0)
            {
                labHours.Value = 0;
                lecHours.Value = 0;
                labHours.Enabled = false;
                lecHours.Enabled = false;
            }
            else if (((practiceHours.Value - 1) + lecHours.Value) == creditHours.Value)
            {
                labHours.Value = 0;
                labHours.Enabled = false;
                practiceHours.Maximum = (creditHours.Value - lecHours.Value) + 1;
            }
            
            else if (((practiceHours.Value - 1) + lecHours.Value) < creditHours.Value) {
                labHours.Maximum = (creditHours.Value - (lecHours.Value + (practiceHours.Value - 1))) + 1;
            }

            if (practiceHours.Value <= creditHours.Value && ((practiceHours.Value - 1) + lecHours.Value) < creditHours.Value) {
                labHours.Enabled = true;
                practiceHours.Maximum = (creditHours.Value - lecHours.Value - labHours.Value) + 1;
            }
        }

        private void labHours_ValueChanged(object sender, EventArgs e)
        {
            lecHours.Enabled = true;
            if ((labHours.Value + practiceHours.Value) - 1 == creditHours.Value)
            {
                lecHours.Value = 0;
                lecHours.Enabled = false;
            }
            if ((labHours.Value - 1) == creditHours.Value && lecHours.Value == 0)
            {
                practiceHours.Value = 0;
                lecHours.Value = 0;
                lecHours.Enabled = false;
                practiceHours.Enabled = false;
            }
            else if (((labHours.Value - 1) + lecHours.Value) == creditHours.Value)
            {
                practiceHours.Value = 0;
                practiceHours.Enabled = false;
                labHours.Maximum = (creditHours.Value - lecHours.Value) + 1;
            }
            
            else if (((labHours.Value - 1) + lecHours.Value) < creditHours.Value)
            {
                practiceHours.Maximum = (creditHours.Value - (lecHours.Value + (labHours.Value - 1))) + 1;
            }

            if (labHours.Value <= creditHours.Value && ((labHours.Value - 1) + lecHours.Value) < creditHours.Value)
            {
                practiceHours.Enabled = true;
                labHours.Maximum = (creditHours.Value - lecHours.Value - practiceHours.Value) + 1;
            }
        }
    }
}
