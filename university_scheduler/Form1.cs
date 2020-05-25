﻿using System;
using System.Windows.Forms;
using university_scheduler.Data;

namespace university_scheduler
{
    public partial class NoScheduleHome : Form
    {
        Scheduler scheduler;
        public NoScheduleHome()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 5;
            courses_view();
            programs_view();
            classrooms_view();
            resourses_view();
        }
        
        private void NoScheduleHome_Load(object sender, EventArgs e)
        {
            stInput.ShowUpDown = true;
            etInput.ShowUpDown = true;
            
            /*Generator gen = new Generator();
             gen.generateResource();
             gen.generateProgram();
             gen.generateCourse();
             gen.generateClassroom();*/
            scheduler = new Scheduler();

        }

        private void courses_view() {
            viewCoursesForm frm = new viewCoursesForm() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.coursesView.Controls.Add(frm);
            frm.Show();
        }
        private void programs_view()
        {
            viewProgramForm frm = new viewProgramForm() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.programsView.Controls.Add(frm);
            frm.Show();
        }
        private void classrooms_view()
        {
            viewClassroomForm frm = new viewClassroomForm() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.classroomsView.Controls.Add(frm);
            frm.Show();
        }
        private void resourses_view()
        {
            viewResourcesForm frm = new viewResourcesForm() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.resourcesView.Controls.Add(frm);
            frm.Show();
        }

        private void stInput_ValueChanged(object sender, EventArgs e)
        {

        }

        private void coursesView_Click(object sender, EventArgs e)
        {

        }

        private void generateBTN_Click(object sender, EventArgs e) {
            string message = "By generating a new table the old reservations will be permenantly DELETED\nmake sure to keep a backup of your old table if you need it";
            string title = "Old reservations will be deleted";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (result != DialogResult.OK) {
                return;
            }
            scheduler.start();
            scheduler.saveReservations();
            HomeScreenWithTable addCoursePopup = new HomeScreenWithTable();
            DialogResult dialogResult = addCoursePopup.ShowDialog();
        }
    }
}
