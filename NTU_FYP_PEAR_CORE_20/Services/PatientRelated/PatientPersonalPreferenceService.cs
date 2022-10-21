using NTU_FYP_PEAR_CORE_20.Data;
using NTU_FYP_PEAR_CORE_20.DTOs;
using NTU_FYP_PEAR_CORE_20.Models;
using NTU_FYP_PEAR_CORE_20.Repository;
using NTU_FYP_PEAR_CORE_20.Repository.Base;
using System;
using System.Collections.Generic;

namespace NTU_FYP_PEAR_CORE_20.Services.PatientRelated
{
    /*
     * Patient's Likes, Dislikes, Habits, Hobbies
     */
    public class PatientPersonalPreferenceService
    {
        // Repository
        private readonly PatientRepository patientRepo;
        private readonly PatientAllocationRepository patientAllocationRepo;
        private readonly LikeDislikeRepository likeDislikeRepo;
        private readonly HabitRepository habitRepo;
        private readonly HobbyRepository hobbyRepo;
        private readonly IBaseListRepository<List_LikeDislike> list_LikeDislikeRepo;
        private readonly IBaseListRepository<List_Habit> list_HabitRepo;
        private readonly IBaseListRepository<List_Hobby> list_HobbyRepo;
        // Services
        private readonly UserService userService;
        private readonly OtherService otherService;

        public PatientPersonalPreferenceService(HabitRepository har, HobbyRepository hr, OtherService os, UserService us, IBaseListRepository<List_LikeDislike> lldr, IBaseListRepository<List_Habit> lhar, IBaseListRepository<List_Hobby> lhr, LikeDislikeRepository ldr, PatientRepository pr, GuardianRepository gr, PatientAllocationRepository par)
        {
            this.patientRepo = pr;
            this.patientAllocationRepo = par;
            this.likeDislikeRepo = ldr;
            this.habitRepo = har;
            this.hobbyRepo = hr;
            this.list_LikeDislikeRepo = lldr;
            this.list_HabitRepo = lhar;
            this.list_HobbyRepo = lhr;
            this.otherService = os;
            this.userService = us;
        }

        public PatientPresonalPrefsDTO getPatientPPP(int patientID)
        {
            // Check Patient valid
            var patient = patientRepo.GetSelectedPatient(patientID);
            if (patient == null) return null;
            int patientAllocationID = patient.PatientAllocation.patientAllocationID;

            PatientPresonalPrefsDTO pppdto = new PatientPresonalPrefsDTO();
            List<PPPLDHHDTO> likesdto = new List<PPPLDHHDTO>(), dislikesdto = new List<PPPLDHHDTO>(), likeDislikedto = new List<PPPLDHHDTO>();
            List<LikeDislike> likeDislikes = likeDislikeRepo.GetAllPatientLD(patientAllocationID);
            foreach (var ld in likeDislikes)
            {
                PPPLDHHDTO pppldhhdto = new PPPLDHHDTO { prefId = ld.likeDislikeID, listId = ld.likeDislikeListID, desc = ld.List_LikeDislike.value };
                if (ld.isLike) likesdto.Add(pppldhhdto);
                else dislikesdto.Add(pppldhhdto);
                likeDislikedto.Add(pppldhhdto);
            }
            List<PPPLDHHDTO> habitsdto = new List<PPPLDHHDTO>();
            List<Habit> habits = habitRepo.GetAllPatientH(patientAllocationID);
            foreach (var h in habits)
                habitsdto.Add(new PPPLDHHDTO { prefId = h.habitID, listId = h.habitListID, desc = h.List_Habit.value });

            List<PPPLDHHDTO> hobbiesdto = new List<PPPLDHHDTO>();
            List<Hobby> hobbies = hobbyRepo.GetAllPatientH(patientAllocationID);
            foreach (var h in hobbies)
                hobbiesdto.Add(new PPPLDHHDTO { prefId = h.hobbyID, listId = h.hobbyListID, desc = h.List_Hobby.value });

            pppdto.patientId = patientID;
            pppdto.name = patient.firstName + patient.lastName;
            pppdto.likes = likesdto;
            pppdto.dislikes = dislikesdto;
            //pppdto.likeDislikes = likeDislikedto;
            pppdto.habits = habitsdto;
            pppdto.hobbies = hobbiesdto;
            return pppdto;
        }
        /* 
         * Supervisor, Guardian
         * 1. Existing List: Create item -> Add to DB -> Create Log
         * 2. New List Item: Create list -> Create item -> Create Log & ApproveReject for item
         *                   -> Create Log & ApproveReject for list with relatedLogId to item log
         *                   -> LogNotification of list log to Admin
         * Caregiver
         * 1. Existing List: Create item -> Create Log & ApproveReject for item 
         *                   -> LogNotification to Supervisor
         * 2. New List Item: Create list -> Create item -> Create Log & ApproveReject for item
         *                   -> Create Log & ApproveReject for list with relatedLogId to item log
         *                   -> LogNotification of list log to Admin
         * Validations
         * 1. New list item not an Existing list item
         * 2. Item to add not already added or adding a Like which is already a Dislike
         */
        public Tuple<bool, string> addLikeDislike(string userIDInit, int patientID, int? listId, string desc, bool isLike, bool approvalRequired)
        {
            string logCategory = Constants.LogCategory.Patient.Create;
            string listLogCategory = Constants.LogCategory.List.Create;
            string tableAffected = LikeDislike.TableName;
            string tableAffectedList = List_LikeDislike.TableName;
            string oldLogData = null;

            // Check Patient valid
            var patientA = patientAllocationRepo.getByPatientID(patientID);
            if (patientA == null) return Tuple.Create(false, "Invalid Patient Id");
            int patientAllocationID = patientA.patientAllocationID;

            if (listId != null) // Existing item
            {
                // Check if list item is valid (exist & not deleted)
                List_LikeDislike lldExist = list_LikeDislikeRepo.GetOneNotDeleted((int)listId);
                if (lldExist == null) return Tuple.Create(false, "List item does not exist");

                // Check if already added
                LikeDislike ldExist = likeDislikeRepo.GetOnePatientLD(patientAllocationID, (int)listId);
                if (ldExist != null)
                    if (ldExist.isLike == isLike) return Tuple.Create(false, ldExist.IsLike + " for Patient is already added.");
                    else return Tuple.Create(false, "Cannot add " + (isLike ? "Like" : "Dislike") + " that already exist as a " + ldExist.IsLike);

                if (approvalRequired) // Caregiver
                {
                    // create object only
                    LikeDislike ld = likeDislikeRepo.Create(patientAllocationID, (int)listId, isLike);
                    // serialise object
                    string newLogData = likeDislikeRepo.Serialise(ld);
                    // add to log
                    Log log = otherService.createLog(logCategory, oldLogData, newLogData, userIDInit, tableAffected, null, patientAllocationID);
                    // create approve reject status
                    string intendedUserID = patientAllocationRepo.getSupervisorID(patientAllocationID);
                    otherService.createLogAR(log.logID, intendedUserID);
                    // notify supervisor
                    //otherService.notificationHandler(log.logID, 2, null);
                    return Tuple.Create(true, "Waiting for Supervisor's response");
                }
                else // Supervisor, Guardian
                {
                    // create and add to db
                    LikeDislike ld = likeDislikeRepo.CreateAdd(patientAllocationID, (int)listId, isLike);
                    likeDislikeRepo.SaveChanges();
                    // serialise object
                    string newLogData = likeDislikeRepo.Serialise(ld);
                    // add to log
                    Log log = otherService.createLog(logCategory, oldLogData, newLogData, userIDInit, tableAffected, null, patientAllocationID);
                    // notify guardian?
                    //otherService.notificationHandler(log.logID, 1, null);
                    return Tuple.Create(true, "Patient " + (isLike ? "likes" : "dislikes") + " added successfully.");
                }
            }
            else // New List Item
            {
                // Check if new item to add already exist
                if (list_LikeDislikeRepo.CheckExist(desc)) return Tuple.Create(false, "Item already exist");

                // Create List
                List_LikeDislike lld = list_LikeDislikeRepo.Create(new List_LikeDislike(), desc);
                // Create Item
                LikeDislike ld = likeDislikeRepo.Create(patientAllocationID, lld.list_likeDislikeID, isLike);
                // Create Log & Approve Reject for Item
                string newLogDataItem = likeDislikeRepo.Serialise(ld);
                Log logItem = otherService.createLog(logCategory, oldLogData, newLogDataItem, userIDInit, tableAffected, null, patientAllocationID);
                string adminID = userService.getAdministrator().Id;
                string intendedUserID = approvalRequired ? patientAllocationRepo.getSupervisorID(patientAllocationID) : userIDInit;
                otherService.createRelatedLogAR(logItem.logID, intendedUserID);
                // Create Log & Approve Reject for List
                string newLogDataList = list_LikeDislikeRepo.Serialise(lld);
                Log logList = otherService.createLog(listLogCategory, oldLogData, newLogDataList, userIDInit, tableAffectedList, logItem.logID, patientAllocationID);
                otherService.createLogAR(logList.logID, adminID);
                // notify admin (supervisor scenario 8, cg scenario 7)
                //otherService.notificationHandler(logList.logID, approvalRequired ? 8 : 7, null);
                return Tuple.Create(true, "Waiting for System Admininistrator " + (approvalRequired ? "and Supervisor " : "") + "response");
            }
        } // end of addLikeDislike
        public Tuple<bool, string> addHabit(string userIDInit, int patientID, int? listId, string desc, bool approvalRequired)
        {
            string logCategory = Constants.LogCategory.Patient.Create;
            string listLogCategory = Constants.LogCategory.List.Create;
            string tableAffected = Habit.TableName;
            string tableAffectedList = List_Habit.TableName;
            string oldLogData = null;

            // Check Patient valid
            var patientA = patientAllocationRepo.getByPatientID(patientID);
            if (patientA == null) return Tuple.Create(false, "Invalid Patient Id");
            int patientAllocationID = patientA.patientAllocationID;

            if (listId != null) // Existing item
            {
                // Check if list item is valid (exist & not deleted)
                List_Habit lhExist = list_HabitRepo.GetOneNotDeleted((int)listId);
                if (lhExist == null) return Tuple.Create(false, "List item does not exist");

                // Check if already added
                Habit hExist = habitRepo.GetOnePatientH(patientAllocationID, (int)listId);
                if (hExist != null)
                    return Tuple.Create(false, "Hobby for Patient is already added.");

                if (approvalRequired) // Caregiver
                {
                    // create object only
                    Habit h = habitRepo.Create(patientAllocationID, (int)listId);
                    // serialise object
                    string newLogData = habitRepo.Serialise(h);
                    // add to log
                    Log log = otherService.createLog(logCategory, oldLogData, newLogData, userIDInit, tableAffected, null, patientAllocationID);
                    // create approve reject status
                    string intendedUserID = patientAllocationRepo.getSupervisorID(patientAllocationID);
                    otherService.createLogAR(log.logID, intendedUserID);
                    // notify supervisor
                    //otherService.notificationHandler(log.logID, 2, null);
                    return Tuple.Create(true, "Waiting for Supervisor's response");
                }
                else // Supervisor, Guardian
                {
                    // create and add to db
                    Habit h = habitRepo.CreateAdd(patientAllocationID, (int)listId);
                    habitRepo.SaveChanges();
                    // serialise object
                    string newLogData = habitRepo.Serialise(h);
                    // add to log
                    Log log = otherService.createLog(logCategory, oldLogData, newLogData, userIDInit, tableAffected, null, patientAllocationID);
                    // notify guardian?
                    //otherService.notificationHandler(log.logID, 1, null);
                    return Tuple.Create(true, "Patient hobby added successfully.");
                }
            }
            else // New List Item
            {
                // Check if new item to add already exist
                if (list_HabitRepo.CheckExist(desc)) return Tuple.Create(false, "Item already exist");

                // Create List
                List_Habit lh = list_HabitRepo.Create(new List_Habit(), desc);
                // Create Item
                Habit h = habitRepo.Create(patientAllocationID, lh.list_habitID);
                // Create Log & Approve Reject for Item
                string newLogDataItem = habitRepo.Serialise(h);
                Log logItem = otherService.createLog(logCategory, oldLogData, newLogDataItem, userIDInit, tableAffected, null, patientAllocationID);
                string adminID = userService.getAdministrator().Id;
                string intendedUserID = approvalRequired ? patientAllocationRepo.getSupervisorID(patientAllocationID) : userIDInit;
                otherService.createRelatedLogAR(logItem.logID, intendedUserID);

                // Create Log & Approve Reject for List
                string newLogDataList = list_HabitRepo.Serialise(lh);
                Log logList = otherService.createLog(listLogCategory, oldLogData, newLogDataList, userIDInit, tableAffectedList, logItem.logID, patientAllocationID);
                otherService.createLogAR(logList.logID, adminID);
                // notify admin (supervisor scenario 8, cg scenario 7)
                //otherService.notificationHandler(logList.logID, approvalRequired ? 8 : 7, null);
                return Tuple.Create(true, "Waiting for System Admininistrator " + (approvalRequired ? "and Supervisor " : "") + "response");
            }
        } // end of addHabit
        public Tuple<bool, string> addHobby(string userIDInit, int patientID, int? listId, string desc, bool approvalRequired)
        {
            string logCategory = Constants.LogCategory.Patient.Create;
            string listLogCategory = Constants.LogCategory.List.Create;
            string tableAffected = Hobby.TableName;
            string tableAffectedList = List_Hobby.TableName;
            string oldLogData = null;

            // Check Patient valid
            var patientA = patientAllocationRepo.getByPatientID(patientID);
            if (patientA == null) return Tuple.Create(false, "Invalid Patient Id");
            int patientAllocationID = patientA.patientAllocationID;

            if (listId != null) // Existing item
            {
                // Check if list item is valid (exist & not deleted)
                List_Hobby lhExist = list_HobbyRepo.GetOneNotDeleted((int)listId);
                if (lhExist == null) return Tuple.Create(false, "List item does not exist");

                // Check if already added
                Hobby hExist = hobbyRepo.GetOnePatientH(patientAllocationID, (int)listId);
                if (hExist != null)
                    return Tuple.Create(false, "Hobby for Patient is already added.");

                if (approvalRequired) // Caregiver
                {
                    // create object only
                    Hobby h = hobbyRepo.Create(patientAllocationID, (int)listId);
                    // serialise object
                    string newLogData = hobbyRepo.Serialise(h);
                    // add to log
                    Log log = otherService.createLog(logCategory, oldLogData, newLogData, userIDInit, tableAffected, null, patientAllocationID);
                    // create approve reject status
                    string intendedUserID = patientAllocationRepo.getSupervisorID(patientAllocationID);
                    otherService.createLogAR(log.logID, intendedUserID);
                    // notify supervisor
                    //otherService.notificationHandler(log.logID, 2, null);
                    return Tuple.Create(true, "Waiting for Supervisor's response");
                }
                else // Supervisor, Guardian
                {
                    // create and add to db
                    Hobby h = hobbyRepo.CreateAdd(patientAllocationID, (int)listId);
                    hobbyRepo.SaveChanges();
                    // serialise object
                    string newLogData = hobbyRepo.Serialise(h);
                    // add to log
                    Log log = otherService.createLog(logCategory, oldLogData, newLogData, userIDInit, tableAffected, null, patientAllocationID);
                    // notify guardian?
                    //otherService.notificationHandler(log.logID, 1, null);
                    return Tuple.Create(true, "Patient hobby added successfully.");
                }
            }
            else // New List Item
            {
                // Check if new item to add already exist
                if (list_HobbyRepo.CheckExist(desc)) return Tuple.Create(false, "Item already exist");

                // Create List
                List_Hobby lh = list_HobbyRepo.Create(new List_Hobby(), desc);
                // Create Item
                Hobby h = hobbyRepo.Create(patientAllocationID, lh.list_hobbyID);
                // Create Log & Approve Reject for Item
                string newLogDataItem = hobbyRepo.Serialise(h);
                Log logItem = otherService.createLog(logCategory, oldLogData, newLogDataItem, userIDInit, tableAffected, null, patientAllocationID);
                string adminID = userService.getAdministrator().Id;
                string intendedUserID = approvalRequired ? patientAllocationRepo.getSupervisorID(patientAllocationID) : userIDInit;
                otherService.createRelatedLogAR(logItem.logID, intendedUserID);

                // Create Log & Approve Reject for List
                string newLogDataList = list_HobbyRepo.Serialise(lh);
                Log logList = otherService.createLog(listLogCategory, oldLogData, newLogDataList, userIDInit, tableAffectedList, logItem.logID, patientAllocationID);
                otherService.createLogAR(logList.logID, adminID);
                // notify admin (supervisor scenario 8, cg scenario 7)
                //otherService.notificationHandler(logList.logID, approvalRequired ? 8 : 7, null);
                return Tuple.Create(true, "Waiting for System Admininistrator " + (approvalRequired ? "and Supervisor " : "") + "response");
            }
        } // end of addHobby

        // Methods for Add/Update to Database via Serialised Object
        /*
         * Approval
         * 1. Deserialise oldLogData/newLogData, add/update record into table
         * 2. Return Serialise record to update newLogData
         */
        public string addLikeDislikeLog(string newLogData)
        {
            // Add record into table
            LikeDislike ld = likeDislikeRepo.Deserialise(newLogData);
            likeDislikeRepo.Add(ld);
            likeDislikeRepo.SaveChanges();
            return likeDislikeRepo.Serialise(ld);
        }
        public string addHabitLog(string newLogData)
        {
            // Add record into table
            Habit h = habitRepo.Deserialise(newLogData);
            habitRepo.Add(h);
            habitRepo.SaveChanges();
            return habitRepo.Serialise(h);
        }
        public string addHobbyLog(string newLogData)
        {
            // Add record into table
            Hobby h = hobbyRepo.Deserialise(newLogData);
            hobbyRepo.Add(h);
            hobbyRepo.SaveChanges();
            return hobbyRepo.Serialise(h);
        }
        /*
         * Note: Cannot set virtual object List_LikeDislike in LikeDislike, only can set the ID
         */
        public string updateListLikeDislikeLog(string newLogData, List_LikeDislike lld)
        {
            LikeDislike ld = likeDislikeRepo.Deserialise(newLogData);
            ld.likeDislikeListID = lld.list_likeDislikeID;
            return likeDislikeRepo.Serialise(ld);
        }
        public string updateListHabitLog(string newLogData, List_Habit lh)
        {
            Habit h = habitRepo.Deserialise(newLogData);
            h.habitListID = lh.list_habitID;
            return habitRepo.Serialise(h);
        }
        public string updateListHobbyLog(string newLogData, List_Hobby lh)
        {
            Hobby h = hobbyRepo.Deserialise(newLogData);
            h.hobbyListID = lh.list_hobbyID;
            return hobbyRepo.Serialise(h);
        }
        /*
         * Approval
         * 1. Deserialise newLogData, add record into table
         * 2. Update relatedLog
         * 3. Return Serialise record to update newLogData
         */
        public string addLikeDislikeListLog(string newLogData, Log relatedLog)
        {
            // Add record into table
            List_LikeDislike ld = list_LikeDislikeRepo.Deserialise(newLogData);
            list_LikeDislikeRepo.Add(ld);
            list_LikeDislikeRepo.SaveChanges();
            // Update relatedLog
            relatedLog.newLogData = updateListLikeDislikeLog(relatedLog.newLogData, ld);
            relatedLog.LogAproveReject.status = 2; // Change from Hidden to Pending
            list_LikeDislikeRepo.SaveChanges();
            // Update object in log
            return list_LikeDislikeRepo.Serialise(ld);
        }
        public string addHabitListLog(string newLogData, Log relatedLog)
        {
            // Add record into table
            List_Habit h = list_HabitRepo.Deserialise(newLogData);
            list_HabitRepo.Add(h);
            list_HabitRepo.SaveChanges();
            // Update relatedLog
            relatedLog.newLogData = updateListHabitLog(relatedLog.newLogData, h);
            relatedLog.LogAproveReject.status = 2; // Change from Hidden to Pending
            list_HabitRepo.SaveChanges();
            // Update object in log
            return list_HabitRepo.Serialise(h);
        }
        public string addHobbyListLog(string newLogData, Log relatedLog)
        {
            // Add record into table
            List_Hobby h = list_HobbyRepo.Deserialise(newLogData);
            list_HobbyRepo.Add(h);
            list_HobbyRepo.SaveChanges();
            // Update relatedLog
            relatedLog.newLogData = updateListHobbyLog(relatedLog.newLogData, h);
            relatedLog.LogAproveReject.status = 2; // Change from Hidden to Pending
            list_HobbyRepo.SaveChanges();
            // Update object in log
            return list_HobbyRepo.Serialise(h);
        }
    }
}
