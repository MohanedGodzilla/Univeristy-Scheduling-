using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace university_scheduler.Model
{
    class Slot
    {

        public Slot(int id, int courseId,int creditHours, double hours, int term, bool isLab, bool isReq ,List<Resource> resources, List<Program> programs) {
            this.id = id;
            this.courseId = courseId;
            this.creditHours = creditHours ;
            this.hours = hours;
            this.term = term;
            this.isLab = isLab;
            this.isReq= isReq;
            this.resources = resources;
            this.programs = programs;
            if (programs!=null && programs.Count > 0) {
                studentCount = 0;
                programs.ForEach((Program program) => {
                    studentCount += program.getTermData(term).limit;
                });
            }
        }

        public int id { get; set; }
        public int courseId{ get; set; }
        public int creditHours { get; set; }
        public double hours { get; set; }
        public int term { get; set; }
        public bool isLab { get; set; }
        public bool isReq { get; set; }
        public int studentCount { get; set; }

        public List<Resource> resources = new List<Resource>();

        public List<Program> programs = new List<Program>();
    }
}
