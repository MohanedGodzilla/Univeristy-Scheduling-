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
        public double programsRatio = 1; // 1 or 1.0/3.0 or Ay ratio
        public int classroomSize = 1; // 1:big data  and  0:small data 
        public static int max_days=6;
        public static int max_time=10;
        
        
        private int countt = 0;
        
        public static void generateALL(){
            Generator gen = new Generator();
            gen.generateResource();
            gen.generateProgram();
            gen.generateCourse();
            gen.generateClassroom();
        }

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
                int courseId = Course.insertCourse(name, courseNamedID, creditHours, lectureHours, practiceHours, labHours, term, true);
                if (courseId == -1) continue;
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
            for (int i = 0; i < progNames.Count * programsRatio; i++)
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
            if (classroomSize == 1)
            {
                // 54 room LAB
                getRoomWithParams(0, 25, 70, 70, 1);
                getRoomWithParams(25, 5, 45, 45, 1);
                getRoomWithParams(30, 15, 65, 65, 1);
                getRoomWithParams(45, 4, 45, 45, 1);
                getRoomWithParams(49, 3, 100, 100, 1);
                getRoomWithParams(52, 2, 60, 60, 1);

                /////////////// 26 room LECS
                //LECT BIG
                getRoomWithParams(54, 2, 700, 800, 0);
                getRoomWithParams(56, 2, 450, 450, 0);
                //LECT MED
                getRoomWithParams(58, 3, 150, 150, 0);
                getRoomWithParams(61, 2, 100, 100, 0);
                //LECT SMALL
                getRoomWithParams(63, 8, 70, 70, 0);
                getRoomWithParams(71, 7, 40, 40, 0);
                getRoomWithParams(78, 1, 55, 55, 0);
                getRoomWithParams(79, 1, 23, 23, 0);
            }
            else {
                getRoomWithParams(0, 5, 35, 35, 1);
                //CHEM
                getRoomWithParams(5, 5, 35, 35, 1);
                //COMP
                getRoomWithParams(10, 1, 70, 70, 1);

                //LECT BIG
                getRoomWithParams(11, 1, 500, 500, 0);

                //LECT MED
                getRoomWithParams(12, 2, 150, 150, 0);
            }
        }

        public void getRoomWithParams(int idFrom, int count, int minCap, int maxCap, int isLab) {
            for (int i = idFrom; i < idFrom + count; i++) {
                classHasResource chr = new classHasResource();
                Random rnd = new Random();
                string name = "room " + (i+1);
                int lectureCap = rnd.Next(minCap, maxCap);
                int examCap = lectureCap / 2;
                Classroom.insert(name, lectureCap, examCap, isLab);
                if (isLab == 1) {
                    List<Resource> resourses = Resource.getAll();
                    int resId = 1;
                    if (countt < resourses.Count) {
                        resId = resourses[countt].id;
                        countt++;
                    } else {
                        countt = 0;
                    }
                    int classId = Classroom.getCurrentClassId();
                    chr.insertResource(classId, resId);
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


