using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using university_scheduler.Data;
using university_scheduler.Model;

namespace university_scheduler {

    class Scheduler {
        public delegate void OnNewReservation(int reserved, int total);
        private OnNewReservation onNewReservation;
        private const String REASON_CAP = "cap";
        private const String REASON_RES = "res";
        private const String REASON_PROG_TIME = "prog_time";
        private const String REASON_CLASS_TIME = "class_time";
        private const String REASON_DAYLIMIT = "day_limit";
        private const String REASON_CLASS_BLOCKED_HOURS = "class_blocked_hours";
        //LOGIC VARS
        private int slotID = 0;
        private List<Course> courses;
        private List<Classroom> classRooms;
        private HashSet<int> reservedSlotsIds = new HashSet<int>();
        private Dictionary<double, List<Slot>> weightDictionary = new Dictionary<double, List<Slot>>();
        private int programWF = 5;
        private int hourWF = 2;
        private int actualHourWF = 10;
        private int maxDaysO;
        private double maxTimeO;
        private int resInc = 0;
        private int maxRes = -1;
        private bool wantsToCancel = false;
        double maxResProgress = 0;
        public int total = 0;
        public int reserved = 0;

        Dictionary<int, Reservation> resDictionary;
        Dictionary<int, Reservation> bestResDictionary;

        Dictionary<String, int> confCount = new Dictionary<String, int>() {
            [REASON_CAP] = 0,
            [REASON_RES] = 0,
            [REASON_PROG_TIME] = 0,
            [REASON_CLASS_TIME] = 0,
            [REASON_DAYLIMIT] = 0,
            [REASON_CLASS_BLOCKED_HOURS] = 0
        };
        Dictionary<int, Dictionary<SessionType,Dictionary<String, int>>> courseConfDictonary = new Dictionary<int, Dictionary<SessionType, Dictionary<String, int>>>();
        Dictionary<double, List<int>> weightResDictionary = new Dictionary<double, List<int>>(); //Dictionary<weight,list of reservation ids>
        Dictionary<int, Dictionary<SessionType, List<Slot>>> courseSplitProgramSlotDictionary = new Dictionary<int, Dictionary<SessionType, List<Slot>>>();//course id, split count
        public Scheduler(List<Course> courses, List<Classroom> classrooms, double maxTime, int maxDays) {
            this.courses = courses;
            this.classRooms = classrooms;
            this.maxDaysO = maxDays;
            this.maxTimeO = maxTime;
        }

        public void addOnNewReservation(OnNewReservation onNewReservation) {
            this.onNewReservation = onNewReservation;
        }

        public void cancel() {
            this.wantsToCancel = true;
            Console.WriteLine("Stopping Schedular");
        }

        public void start() {
            String validations = runPreReserveValidations();

            if (validations != "") {
                Console.WriteLine(validations);
                return;
            }

            Reservation.deleteAll();
            resDictionary = new Dictionary<int, Reservation>();
            weightResDictionary = new Dictionary<double, List<int>>();

            generateSlots();
            double totalLectureHours = 0;
            double practiceHours = 0;
            double labHours = 0;
            courses.ForEach(course => {
                totalLectureHours += course.lectureHours;
                practiceHours += course.practiceHours;
                labHours += course.practiceHours;
            });
            Console.WriteLine(programWF + hourWF + actualHourWF);
            Console.WriteLine($"LH:{totalLectureHours}\nPH:{practiceHours}\nLabH:{labHours}\n++++++++");

            List<double> sortedWeights = sortWeights();
            classRooms = sortingClassRooms(classRooms);


            for (int i = 0; i < sortedWeights.Count; i++) {
                if (wantsToCancel) {
                    return;
                }
                Dictionary<String, dynamic> conflict =
                    reserve(sortedWeights[i], weightDictionary[sortedWeights[i]]);

                if (resDictionary.Keys.Count > maxRes) {
                    maxRes = resDictionary.Keys.Count;
                    Console.WriteLine(
                        $"NEW COUNT {maxRes} \nTotals Res:{resInc}\n=======");
                    
                    Dictionary<String, int> resState = getReservedTotal();
                    double resProgress = resState["reserved"] / resState["total"];
                    if (resProgress > maxResProgress) {
                        maxResProgress = resProgress;
                        bestResDictionary = new Dictionary<int, Reservation>(resDictionary);
                    }
                    onNewReservation(resState["reserved"],resState["total"]);
                }
                if (conflict != null) {
                    Slot slotWithConflict = conflict["slot"];
                    String reason = conflict["reason"];
                    if (!courseConfDictonary.ContainsKey(slotWithConflict.courseId)) {
                        courseConfDictonary[slotWithConflict.courseId] = new Dictionary<SessionType, Dictionary<string, int>>();
                    }
                    if (!courseConfDictonary[slotWithConflict.courseId].ContainsKey(slotWithConflict.sessionType)) {
                        courseConfDictonary[slotWithConflict.courseId][slotWithConflict.sessionType] = new Dictionary<string, int>();
                    }
                    if (!courseConfDictonary[slotWithConflict.courseId][slotWithConflict.sessionType].ContainsKey(reason)) {
                        courseConfDictonary[slotWithConflict.courseId][slotWithConflict.sessionType][reason] = 0;
                    }
                    courseConfDictonary[slotWithConflict.courseId][slotWithConflict.sessionType][reason]++;
                    confCount[reason]++;
                    if (weightResDictionary.ContainsKey(sortedWeights[i]) && weightResDictionary[sortedWeights[i]] != null) {
                        foreach (int resId in weightResDictionary[sortedWeights[i]]) {
                            resDictionary.Remove(resId);
                        }
                    }

                    weightDictionary[sortedWeights[i]].Remove(slotWithConflict);

                    if (reason == REASON_CAP) {
                        if (slotWithConflict.programs.Count > 1) {
                            separatePrograms(slotWithConflict);
                        } else {
                            splitProgram(slotWithConflict, sortedWeights[i]);
                        }
                        sortedWeights = sortWeights();
                        i -= 1;
                    }/* else if (reason == REASON_PROG_TIME) {
                        if (slotWithConflict.programs.Count > 1) {
                            separatePrograms(slotWithConflict);
                        }
                        sortedWeights = sortWeights();
                        i -= 1;
                    }*/ else {
                        if (i == 0) {
                            double newWeight = sortedWeights[0] + 1;
                            sortedWeights.Insert(0, newWeight);
                            weightDictionary[newWeight] = new List<Slot>();
                            weightResDictionary[newWeight] = new List<int>();
                            i = 1;
                        }
                        if (weightResDictionary.ContainsKey(sortedWeights[i - 1]) && weightResDictionary[sortedWeights[i - 1]] != null) {
                            foreach (int resId in weightResDictionary[sortedWeights[i - 1]]) {
                                resDictionary.Remove(resId);
                            }
                            weightDictionary[sortedWeights[i - 1]].Insert(0, slotWithConflict);
                            i -= 2; //want to start from previous w el loop hatzawed 1 faaa ha!
                        }
                    }
                }
                //--------
                cleanResDictionary();
                printNonReserved();
                Console.WriteLine(
                    $"NEW COUNT {maxRes}\nTotals Res:{resInc}\n=======");
                Console.WriteLine(confCount);
            }
            
        }


        public void saveReservations() {
            List<Reservation> reservationsList;
            if (wantsToCancel) {
                if (bestResDictionary == null) return;
                reservationsList = bestResDictionary.Values.ToList();
            } else {
                if (resDictionary == null) return;
                reservationsList = resDictionary.Values.ToList();
            }
            reservationsList.ForEach((Reservation res) => {
                res.insertThis();
            });
        }

        void printNonReserved() {
            total = 0;
            reserved = 0;
            int nonRes = 0;
            weightDictionary.Keys.ToList().ForEach((double key) => {
                weightDictionary[key].ForEach((Slot slot) => {
                    total++;
                    if (!reservedSlotsIds.Contains(slot.id)) {
                        nonRes++;
                        Console.WriteLine($"!!!!!!!!!!! slot {slot.id} not reserved !!!!!!!!!!!");
                    } else {
                        reserved++;
                    }
                });
            });

            Console.WriteLine($"total:{total} reserved:{reserved} not:{nonRes}");
            onNewReservation(reserved, total);
        }

        Dictionary<String, int> getReservedTotal() {
            int total = 0;
            int reserved = 0;
            weightDictionary.Keys.ToList().ForEach((double key) => {
                weightDictionary[key].ForEach((Slot slot) => {
                    total++;
                    if (reservedSlotsIds.Contains(slot.id)) {
                        reserved++;
                    }
                });
            });

            return new Dictionary<string, int> { 
                ["total"]=total,
                ["reserved"]=reserved
            };
        }

        String runPreReserveValidations() {
            String validations = "";
            //softCheckResources();
            Dictionary<string, double> hoursMap =  softCheckTotalHours();
            double avH = hoursMap["totalAV"];
            double hours = hoursMap["total"];
            if (hours > avH) {
                validations += $"there is no enough time to place all the course REQ:{hours} FOUND: {avH}";
            }
            return validations;
        }

        List<Resource> softCheckResources() {
            List<Resource> notFoundRes = new List<Resource>();

            return notFoundRes;
        }

        Dictionary<string, double> softCheckTotalHours() {
            double lecHours=0;
            double labHours=0;
            double practiceHours = 0;
            double totalAvHours = maxDaysO * maxTimeO * classRooms.Count;
            double totalHours = 0;
            courses.ForEach((Course course)=>{
                lecHours += course.lectureHours;
                labHours += course.labHours;
                practiceHours += course.practiceHours;
            });

            totalHours = lecHours + practiceHours + labHours;
            return new Dictionary<string, double>() {
                ["lec"] = lecHours,
                ["lab"] = labHours,
                ["pract"] = practiceHours,
                ["totalAV"] = totalAvHours,
                ["total"] = totalHours
            };
        }

        Dictionary<String, dynamic> reserve(double weight, List<Slot> slots) {
            String reason = "";
            int day;
            List<int> resIDS = new List<int>();
            foreach (Slot slot in slots) {
                double maxTime = maxTimeO;
                bool isSlotRes = false;
                int dayIteration;
                for (dayIteration = 0; dayIteration < maxDaysO; dayIteration++) {
                    if (dayIteration % 2 == 0) {
                        day = dayIteration;
                    } else {
                        day = maxDaysO - dayIteration;
                    }
                    List<Classroom> typeClassRooms =
                        classRooms.Where((room) => (room.isLab == (slot.sessionType==SessionType.LAB))).ToList();


                    if (slot.sessionType == SessionType.LAB && typeClassRooms.Count>0) {
                        typeClassRooms = typeClassRooms.Where((room) => matchResources(room.resources,slot.resources)).ToList();
                    }

                    if (slot.sessionType == SessionType.LAB && typeClassRooms.Count == 0) {
                        reason = REASON_RES;
                        continue;
                    }
                    foreach (Classroom classRoom in typeClassRooms) {
                        int slotCap = slot.studentCount;
                        if (slotCap > classRoom.lectureCap) {
                            reason = REASON_CAP;
                            continue;
                        }

                        for (double time = 0; time < maxTime; time++) {
                            reason = REASON_CLASS_TIME;
                            double blockedHoursCheck = classRoom.isHourBlocked(
                                day, time, time + slot.hours); //return blockedTo
                            if (blockedHoursCheck != -1) {
                                reason = REASON_CLASS_BLOCKED_HOURS;
                                time = blockedHoursCheck;
                                continue;
                            }

                            if (!classRoom.reservations.ContainsKey(day) || !classRoom.reservations[day].ContainsKey(time) ||
                                !resDictionary.ContainsKey(classRoom.reservations[day][time])) {
                                //if classroom has an empty hour
                                bool isClassEmpty = true;

                                if (time + slot.hours > maxTime) {
                                    break;
                                }
                                for (double k = time + 1; k < time + slot.hours; k++) {
                                    //does it have enough slots for the course hours

                                    if (classRoom.reservations[day].ContainsKey(k) &&
                                        resDictionary.ContainsKey(classRoom.reservations[day][k])) {
                                        isClassEmpty = false;
                                        time = k; // el time aslan hayzeed 1 foooo2
                                        break;
                                    }
                                }
                                if (!isClassEmpty) {
                                    continue;
                                }
                                //if isClassEmpty
                                bool isProgramsAvailable = true;
                                foreach (Model.Program program in slot.programs) {
                                    TermData termData = program.getTermData(slot.term);
                                    reason = REASON_PROG_TIME;
                                    for (double k = time; k < time + slot.hours; k++) {
                                        if (termData.schedule[day].ContainsKey(k) &&
                                            resDictionary.ContainsKey(termData.schedule[day][k])) {
                                            isProgramsAvailable = false;
                                            time = k; //el time aslan hayzeed 1 foooo2
                                            break;
                                        }
                                    }
                                    if (!isProgramsAvailable) {
                                        break; //34an lw feh wa7da bazet ma akmel4 el ba2y
                                    }
                                }

                                if (isProgramsAvailable && isClassEmpty) {
                                    Reservation reservation = new Reservation(slot.courseId,
                                        classRoom.id, day, time, time + slot.hours, slot.sessionType == SessionType.LAB);
                                    reservation.programs = slot.programs;
                                    resDictionary[resInc] = reservation;
                                    reservedSlotsIds.Add(slot.id);

                                    if (!weightResDictionary.ContainsKey(weight)) {
                                        weightResDictionary[weight] = new List<int>();
                                    }
                                    weightResDictionary[weight].Add(resInc);
                                    foreach (Model.Program program in slot.programs) {
                                        for (double k = time; k < time + slot.hours; k++) {
                                            program.getTermData(slot.term).schedule[day][k] = resInc;
                                        }
                                    }
                                    for (double k = time; k < time + slot.hours; k++) {
                                        classRoom.reservations[day][k] = resInc;
                                    }
                                    isSlotRes = true;
                                    resInc++;
                                    break;
                                }
                            }
                        }
                        if (isSlotRes) break;
                    }
                    if (isSlotRes) {
                        break;
                    }
                }
                if (!isSlotRes) {
                    return new Dictionary<String, dynamic>() {
                        ["reason"] = reason,
                        ["slot"] = slot,
                    };
                }
            }
            return null;
        }

        #region HelperFunctions
        double calcWeight(Slot slot) {
            double weight = 0;
            if (slot.isReq) return 0;
            weight += slot.programs?.Count ?? 0 * programWF;
            weight += slot.creditHours * hourWF;
            weight += slot.hours * actualHourWF;
            weight += slot.studentCount / 20;
            return weight;
        }

        void addToWeightMap(Slot slot, double weight) {
            if (!weightDictionary.ContainsKey(weight)) {
                weightDictionary[weight] = new List<Slot>();
            }
            weightDictionary[weight].Add(slot);
        }

        void generateSlots() {
            foreach (Course course in courses) {
                List<Resource> resources = course.getCourseResources();
                List<Model.Program> programs = course.getCoursePrograms();
                if (course.lectureHours > 0) {

                    Slot slot = new Slot(
                        slotID,
                        course.id,
                        course.creditHours,
                        course.lectureHours,
                        course.term,
                        SessionType.LECTURE,
                        course.isReq,
                        new List<Resource>(),
                        programs);

                    double weight = calcWeight(slot);
                    addToWeightMap(slot, weight);

                    slotID++;
                }
                if (course.practiceHours > 0) {
                    Slot slot = new Slot(
                        slotID,
                        course.id,
                        course.creditHours,
                        course.practiceHours,
                        course.term,
                        SessionType.PRACTICE,
                        course.isReq,
                        new List<Resource>(),
                        programs);

                    double weight = calcWeight(slot);
                    addToWeightMap(slot, weight);
                    slotID++;
                }
                if (course.labHours > 0) {
                    Slot slot = new Slot(
                         slotID,
                        course.id,
                        course.creditHours,
                        course.labHours,
                        course.term,
                        SessionType.LAB,
                        course.isReq,
                        resources,
                        programs);

                    double weight = calcWeight(slot);
                    addToWeightMap(slot, weight);
                    slotID++;
                }
            }
        }

        void splitProgram(Slot slotWithConflict, double weight) {
            Slot slot1 = copySlot(slotWithConflict, slotWithConflict.programs);
            Slot slot2 = copySlot(slotWithConflict, slotWithConflict.programs);

            slot1.studentCount = (int)Math.Floor((double)(slotWithConflict.studentCount / 2));
            slot2.studentCount = (int)Math.Floor((double)(slotWithConflict.studentCount / 2));
            addToWeightMap(slot1, weight);
            addToWeightMap(slot2, weight);
        }

        void separatePrograms(Slot slotData) {
            int courseID = slotData.courseId;
            SessionType sessionType = slotData.sessionType;
            if (!courseSplitProgramSlotDictionary.ContainsKey(courseID)) {
                courseSplitProgramSlotDictionary[courseID] = new Dictionary<SessionType, List<Slot>>();
            }

            Dictionary<SessionType, List<Slot>> sMap = courseSplitProgramSlotDictionary[courseID];

            if (!sMap.ContainsKey(sessionType)) {
                sMap[sessionType] = new List<Slot>() {slotData};
            }

            List<Slot> pSlots = sMap[sessionType];
            List<Model.Program> pList = new List<Model.Program>();
            pSlots.ForEach((Slot slot)=> {
                pList.AddRange(slot.programs);
            });

            pList.Sort((Model.Program p1,Model.Program p2)=> (p1.getTermData(slotData.term).limit-p2.getTermData(slotData.term).limit));

            int progCount = pList.Count;//7
            int newSplitCount = pSlots.Count+1;//3
            courseSplitProgramSlotDictionary[courseID][sessionType] = new List<Slot>();
            while (progCount != 0) {
                int count = (int)Math.Ceiling((double)progCount / newSplitCount);
                progCount -= count;
                newSplitCount--;
                List<Model.Program> newSlotPrograms = new List<Model.Program>();
                List<Model.Program> addedPrograms = new List<Model.Program>();
                for (int i = 0; i < count; i++) {
                    int index= i % 2 == 0? i : count - i;

                    newSlotPrograms.Add(pList[index]);
                    addedPrograms.Add(pList[index]);
                }
                for (int i = 0; i < addedPrograms.Count; i++) {
                    pList.Remove(addedPrograms[i]);
                }

                Slot slot = copySlot(slotData, newSlotPrograms);
                courseSplitProgramSlotDictionary[courseID][sessionType].Add(slot);
                double weight = calcWeight(slot);
                addToWeightMap(slot, weight);
            }

        }

        List<Model.Program> pickAndSkip(List<Model.Program> programs, bool even) {
            List<Model.Program> subProgs = new List<Model.Program>();
            for (int i = 0, j = 1;
                i < programs.Count && j < programs.Count;
                i += 2, j += 2) {
                subProgs.Add(programs[even ? i : j]);
            }
            return subProgs;
        }

        Slot copySlot(Slot slot, List<Model.Program> programs) {
            Slot copySlot = new Slot(
                         slotID,
                        slot.courseId,
                        slot.creditHours,
                        slot.hours,
                        slot.term,
                        slot.sessionType,
                        slot.isReq,
                        slot.resources,
                        programs);
            slotID++;
            return copySlot;
        }

        List<double> sortWeights() {
            List<double> sortedW = weightDictionary.Keys.ToList();
            sortedW.Sort();
            sortedW.Reverse();
            return sortedW;
        }

        List<Classroom> sortingClassRooms(List<Classroom> classes) {
            classes.Sort((Classroom classA, Classroom classB) =>
                classA.lectureCap - classB.lectureCap);
            return classes;
        }

        bool matchResources(List<Resource> classRes, List<Resource> courseRes) {
            foreach (Resource courseyaRes in courseRes) {
                bool isMatched = false;
                foreach (Resource classyaRes in classRes) {
                    if (classyaRes.id == courseyaRes.id) {
                        isMatched = true;
                        break;
                    }
                }
                if (isMatched == false) {
                    return false;
                }
            }
            return true;
        }

        void cleanResDictionary() {
            for (int i = 0; i < maxDaysO; i++) {
                for (int j = 0; j < maxTimeO; j++) {
                    foreach (Classroom classaya in classRooms) {
                        if (classaya.reservations.ContainsKey(i) && classaya.reservations[i].ContainsKey(j) &&
                            !resDictionary.ContainsKey(classaya.reservations[i][j])) {
                            classaya.reservations[i].Remove(j);
                        }
                    }
                }
            }
        }

        void seedData() {
            courses = Course.getAll();
            classRooms = Classroom.getAll();
            Console.WriteLine("WOOOOW");
        }
    }
    #endregion
}
