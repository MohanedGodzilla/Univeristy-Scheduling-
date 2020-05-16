using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace university_scheduler.Model
{
    class Slot
    {
        public int id { get; set; }
        public int courseId{ get; set; }
        public int creditHours { get; set; }
        public int hours { get; set; }
        public int term { get; set; }
        public int isLab { get; set; }
        public int isReq { get; set; }
        public int studentCount { get; set; }

        List<Resource> termresoursessData = new List<Resource>();

        List<Program> termprogramData = new List<Program>();
    }
}
