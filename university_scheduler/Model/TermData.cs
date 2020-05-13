using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace university_scheduler.Model
{
    class TermData
    {
        public int id { get; set; }
        public int term { get; set; }
        public int limit { get; set; }
        public double max_time { get; set; }
        public int max_days { get; set; }

        Dictionary<int, Dictionary<dynamic, int>> schedule = new Dictionary<int, Dictionary<dynamic, int>>();

    }
}
