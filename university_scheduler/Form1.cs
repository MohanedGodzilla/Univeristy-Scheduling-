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
    public partial class NoScheduleHome : Form
    {
        public NoScheduleHome()
        {
            InitializeComponent();
            courses_view();
        }
        
        private void NoScheduleHome_Load(object sender, EventArgs e)
        {

        }

        private void courses_view() {
            viewCoursesForm frm = new viewCoursesForm() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.coursesView.Controls.Add(frm);
            frm.Show();
        }

    }
}
