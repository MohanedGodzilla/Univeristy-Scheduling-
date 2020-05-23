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
        public int courseNums = 1200;
        public static int max_days=6;
        public static int max_time=10;

        public void generateResource()
        {
            List<string> resName = new List<string> { "MATH",
              "PHYS",
              "COMP",
              "CHEM",
              "BIO",
              "GEOL",
              "GEOPHYS",
              "BIOTECH",
              "BOTANY",
              "ANIMAL",
              "STAT",
              "ZOO"
              };
            Resource resource = new Resource();

            for (int i = 0; i < resName.Count; i++)
            {
                resource.insertResource(resName[i]+" Lab");
            }
        }

        public void generateCourse()
        {
            Resource resource = new Resource();
            Model.Program program = new Model.Program();
            
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
              "STAT",
              "ZOO"
            };
            Random rnd = new Random();
            for (int i = 0; i < courseNums; i++)
            {
                Course course = new Course();
                int codeNameIndex = rnd.Next(0, 10);
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
                if ((code / 100) == 1)
                { //represent level 1
                    if ((code % 2) == 0)
                        term = 2;
                    else term = 1;
                }
                else if ((code / 100) == 2)
                {
                    if ((code % 2) == 0)
                        term = 4;
                    else term = 3;
                }
                else if ((code / 100) == 3)
                {
                    if ((code % 2) == 0)
                        term = 6;
                    else term = 5;
                }
                else if ((code / 100) == 4)
                {
                    if ((code % 2) == 0)
                        term = 8;
                    else term = 7;
                }              
                course.insertCourse(name, courseNamedID, creditHours, lectureHours, practiceHours, labHours, term, true);
                int courseId = course.getCurrentCourseId();
                Console.WriteLine("course id = "+courseId);
                if (labHours > 0)
                {
                    courseHasResource CourseRes = new courseHasResource();
                    // you can remove +1 if you move the if statment after calling of insert function
                    Resource res = Resource.getAll(courseNamedID.Substring(0, 3))[0];
                    CourseRes.insertResource(courseId, res.id);
                }

                ProgramCourses pc = new ProgramCourses();
                List<Model.Program> programs = Model.Program.getAll();
                int count = programs.Count / 2;
                int programsCount = rnd.Next(1, count);
                for (int j = rnd.Next(1,programsCount); j <= programsCount; j++)//j select random number from programsCount to insert differnt random programs
                {
                    int programId = programs[j].id;
                    pc.insertProgram(courseId, programId);

                }
                
            }
        }

        public void generateProgram()
        {
            List<string> progNames = new List<string> {
                "Petroleum Geophysics ",
                "Geophysics ",
                "Biophysics",
                "Biological" ,
                "Microbiology" ,
                "Biochemistry" ,
                "Medical Entomology" ,
                "Entomology" ,
                "Zoology" ,
                "Botany" ,
                "Mathematical Statistics" ,
                "Geology" ,
                "Biochemistry-Chemistry" ,
                "Botany-Chemistry" ,
                "Geology-Geophysics" ,
                "Geology-Chemistry" ,
                "Entomology-Chemistry" ,
                "Mathematical Statistics and Computer Science" ,
                "Pure Mathematics and Computer Science" ,
                "Mathematical Statistics and Pure Mathematics" ,
                "Microbiology-Chemistry" ,
                "Zoology-Chemistry" ,
                "Chemistry" ,
                "Applied Chemistry" ,
                "Computer Science" ,
                "Mathematics" ,
                "Physics" ,
                "Physcics and Computer Science" ,
                "Physics-Chemistry" ,
                "Applied Biotechnology" ,
                "Materials and Nanosciences" ,
                "NanoTechnology"
            };

            Model.Program program = new Model.Program();
            for (int i = 0; i < progNames.Count; i++)
            {
                program.insert(progNames[i]);
                int progId = program.getCurrentProgramId();
                generateTermData(progId);
            }
        }

        public void generateTermData(int progId)
        {
            for (int termInd = 1; termInd <= 8; termInd++)
            {
                Random rnd = new Random();
                int limit = rnd.Next(30, 120);
                TermData.insert(termInd, limit, progId);
            }
        }

        public void generateClassroom()
        {
            //CourseRes.insertResource(courseId, res.id);
             getRoomWithParams(0,5, 65, 65, 1);
             getRoomWithParams(5,5, 35, 35, 1);
            //CHEM
             getRoomWithParams(10,5, 65, 65, 1);
             getRoomWithParams(15,5, 35, 35, 1);
            //COMP

             getRoomWithParams(20,1, 70, 70, 1);
             getRoomWithParams(21, 1, 35, 35, 1);

            //LECT BIG
             getRoomWithParams(22, 1, 1000, 1000, 0);
             getRoomWithParams(23, 1, 500, 500, 0);

            //LECT MED
             getRoomWithParams(24, 10, 150, 150, 0);

             getRoomWithParams(34, 40, 60, 70, 0);
        }

        public void  getRoomWithParams(int idFrom, int count, int minCap, int maxCap, int isLab)
        {
            int countt = 0;
            for (int i = idFrom; i < idFrom+count; i++)
            {
                Classroom room = new Classroom();
                classHasResource chr = new classHasResource();
                Random rnd = new Random();
                string name = "room " + i;
                int lectureCap = rnd.Next(minCap, maxCap);
                int examCap = lectureCap / 2;
                room.insert(name, lectureCap, examCap, isLab);
                if (isLab == 1){
                    List<Resource> resourses = Resource.getAll();
                    int resId=1;
                    if (countt < resourses.Count)
                    {
                        resId = resourses[countt].id;
                        countt++;
                    }else{
                        countt = 0;
                    }
                    int classId = room.getCurrentClassId();
                    chr.insertResource(classId,resId);
                }
                Console.WriteLine("Class : " + i);
            }
        }



        public string generateString(int count)
        {
            string s = "";
            for (int i = 0; i < count; i++)
            {
                Random random = new Random();
                // random lowercase letter
                int a = random.Next(0, 26);
                char ch = (char)('a' + a);
                s += ch;
            }
            return s;
        }
    }
}


