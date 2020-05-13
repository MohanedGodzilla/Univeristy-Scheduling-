using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using university_scheduler.Model;

namespace university_scheduler.Data
{
    class Generator
    {
        public string conString = env.db_con_str;
        
        public void generateResource() {
            List<string> resName = new List<string> { "PHYS LAB", "CHEM LAB", "BOTONY LAB", "BIO LAB", "CS LAB", "ZOO LAB" };
            Resource resource = new Resource();

            for (int i = 0; i< resName.Count; i++) { 
                resource.insertResource(resName[i]);
            }
        }

        public void generateCourse() {
            Resource resource = new Resource();
            courseHasResource CourseRes = new courseHasResource();
            List<string> codeName = new List<string> {
              "MATH",
              "PHYS",
              "COMP",
              "CHEM",
              "BIO",
              "GEOL",
              "GEOPHYS",
              "BIOTECH",
              "BOTANY",
              "ANIMAL",
              "STAT" };
            Random rnd = new Random();
            for (int i = 0; i < 500; i++) {
                Course course = new Course();
                int codeNameIndex = rnd.Next(0,10);
                int code = rnd.Next(100, 499);
                String courseNamedID = codeName[codeNameIndex] + code.ToString();
                String name = courseNamedID;

                int creditHours = rnd.Next(1, 4);
                double lectureHours = rnd.Next(1, creditHours);
                double extraHours = (creditHours - lectureHours) * 2;

                double practiceHours = rnd.Next(0, (int)extraHours);
                extraHours -= practiceHours;
                double labHours = extraHours;

                int term = 0;
                if ((code / 100) == 1){ //represent level 1
                    if ((code % 2) == 0)
                        term = 2;
                    else term = 1;
                }
                else if ((code / 100) == 2){
                    if ((code % 2) == 0)
                        term = 4;
                    else term = 3;
                }
                else if ((code / 100) == 3){
                    if ((code % 2) == 0)
                        term = 6;
                    else term = 5;
                }
                else if ((code / 100) == 4){
                    if ((code % 2) == 0)
                        term = 8;
                    else term = 7;
                }

                if (labHours > 0) {
                    int courseId = course.getCurrentCourseId() +1; // you can remove +1 if you move the if statment after calling of insert function
                    Resource res = resource.getAll(courseNamedID.Substring(0,3))[0];
                    CourseRes.insertResource(courseId, res.id);
                }
                course.insertCourse(name, courseNamedID, creditHours,lectureHours, practiceHours, labHours, term, true);
            }
        }

    }
}
