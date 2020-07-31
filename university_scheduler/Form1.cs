using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using university_scheduler.Data;
using university_scheduler.Model;
using Excel = Microsoft.Office.Interop.Excel;

namespace university_scheduler
{
    public partial class NoScheduleHome : Form
    {

        public NoScheduleHome()
        {
            InitializeComponent();
            sDay.SelectedIndex = 0;
            eDay.SelectedIndex = 5;
            semesterCombo.SelectedIndex = 0;
            startTime = stInput.Value.Hour;
            endTime = etInput.Value.Hour;
            startDay = sDay.SelectedIndex;
            endDay = eDay.SelectedIndex;
            int notComeFromHomeScreenWithTable = 0;
            courses_view(notComeFromHomeScreenWithTable);
            programs_view(notComeFromHomeScreenWithTable);
            classrooms_view(notComeFromHomeScreenWithTable);
            resourses_view(notComeFromHomeScreenWithTable);
            //Generator.generateALL();
        }

        public static int startTime;
        public static int endTime;
        public static int startDay;
        public static int endDay;

        //disableBTNS = add,delete,edit buttons 
        public NoScheduleHome(int existTable_disableBTNs)
        {
            InitializeComponent();
            sDay.SelectedIndex = 0;
            eDay.SelectedIndex = 5;
            semesterCombo.SelectedIndex = 0;
            courses_view(existTable_disableBTNs);
            programs_view(existTable_disableBTNs);
            classrooms_view(existTable_disableBTNs);
            resourses_view(existTable_disableBTNs);

            startTime = stInput.Value.Hour;
            endTime = etInput.Value.Hour;
            startDay = sDay.SelectedIndex;
            endDay = eDay.SelectedIndex;
        }

        private void NoScheduleHome_Load(object sender, EventArgs e)
        {
            stInput.ShowUpDown = true;
            etInput.ShowUpDown = true;
        }


        private void courses_view(int flag) {
            if (flag != 1)
            {
                viewCoursesForm frm = new viewCoursesForm() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                this.coursesView.Controls.Add(frm);
                frm.Show();
            }
            else {
                viewCoursesForm frm = new viewCoursesForm(flag) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                this.coursesView.Controls.Add(frm);
                frm.Show();
            }
        }
        private void programs_view(int flag)
        {
            if (flag != 1){
                viewProgramForm frm = new viewProgramForm() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                this.programsView.Controls.Add(frm);
                frm.Show();
            }
            else {
                viewProgramForm frm = new viewProgramForm(flag) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                this.programsView.Controls.Add(frm);
                frm.Show();
            }
        }
        private void classrooms_view(int flag)
        {
            if (flag != 1)
            {
                viewClassroomForm frm = new viewClassroomForm() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                this.classroomsView.Controls.Add(frm);
                frm.Show();
            }
            else {
                viewClassroomForm frm = new viewClassroomForm(flag) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                this.classroomsView.Controls.Add(frm);
                frm.Show();
            }
        }
        private void resourses_view(int flag)
        {
            if (flag != 1)
            {
                viewResourcesForm frm = new viewResourcesForm() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                this.resourcesView.Controls.Add(frm);
                frm.Show();
            }
            else {
                viewResourcesForm frm = new viewResourcesForm(flag) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                this.resourcesView.Controls.Add(frm);
                frm.Show();
            }
        }

        private void generateBTN_Click(object sender, EventArgs e) {
            //EnableTab(false);
            EnableTab(this.coursesView, false);
            EnableTab(this.programsView, false);
            EnableTab(this.classroomsView, false);
            EnableTab(this.resourcesView, false);
            this.generateBTN.Enabled = false;
            Load_view();
            resLabel.Text = viewLoadForm.res;

            HomeScreenWithTable Popup = new HomeScreenWithTable();
            Popup.MdiParent = this.ParentForm;
            this.Hide();
            Popup.ShowDialog();
            this.Close();
        }

        private void Load_view()
        {
            SchedulerConfigs.maxTime = Math.Abs(endTime - startTime) + 1;
            SchedulerConfigs.maxDays = Math.Abs(endDay - startDay) + 1;
            SchedulerConfigs.selectedTerm = semesterCombo.SelectedIndex + 1;

            viewLoadForm frm = new viewLoadForm();
            frm.startBrogress();
            frm.ShowDialog();
        }
        public void EnableTab(TabPage page, bool enable)
        {
            page.Controls.Clear();
           
        }

        private void stInput_ValueChanged(object sender, EventArgs e) {

        }
 
    }
}