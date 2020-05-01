using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace university_scheduler
{
    public partial class addCourseForm : Form
    {
        public string conString = "Data Source = localhost; Initial Catalog = course_scheduler; Integrated Security = True";

        viewCoursesForm resForm = (viewCoursesForm)Application.OpenForms["viewCoursesForm"];// it's an object that is used in function addResourceBTN_Click() to reopen the form when adding a new tuple in the database

        public addCourseForm()
        {
            addCourseBTN.Show();
            saveBTN.Hide();
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void addCourseForm_Load(object sender, EventArgs e)
        {
            termCombo.SelectedIndex = 0;
        }
        

        private void selectResource_Click(object sender, EventArgs e)
        {
            selectResourceForm resForm = new selectResourceForm();
            DialogResult dialogresult = resForm.ShowDialog();
        }

        private void courseName_TextChanged(object sender, EventArgs e)
        {

        }

        private void courseCode_TextChanged(object sender, EventArgs e)
        {

        }

        private void addCourseBTN_Load(object sender, EventArgs e)
        {

        }

        private void saveBTN_Click(object sender, EventArgs e)
        {

        }
    }
}
