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
    public partial class viewCoursesForm : Form
    {
        public viewCoursesForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addCourseForm addCoursePopup = new addCourseForm();
            DialogResult dialogResult = addCoursePopup.ShowDialog();
        }
    }
}
