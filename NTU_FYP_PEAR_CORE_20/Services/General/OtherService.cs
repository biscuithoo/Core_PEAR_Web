using NTU_FYP_PEAR_CORE_20.Data;
using NTU_FYP_PEAR_CORE_20.DTOs;
using NTU_FYP_PEAR_CORE_20.Models;
using NTU_FYP_PEAR_CORE_20.Repository;
using NTU_FYP_PEAR_CORE_20.Repository.Others;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NTU_FYP_PEAR_CORE_20.Services
{
    /* 
     * For Centralise Methods such as Log
     * 
     * This Service is not allowed to call other Services
     * 
     * Log Scenarios (4)
     * 1. Normal Log: Logging for ALL Create, Update, Delete, UnMaskNRIC
     * 2. 1. + Requires approval (mainly CG, SA): Create LogApproveReject and Send Notification (to S)
     * 3. 1. + Needs Notify: Send Notification
     * 4. Requires double approval (new lists item): 2. related logs from + 1. 
     */
    public class OtherService
    {
        private readonly LogRepository logRepo;
        private readonly LogApproveRejectRepository logApproveRejectRepo;
        private readonly LogNotificationRepository logNotificationRepo;
        private readonly LogCategoryRepository logCatRepo;
        private readonly NotificationHandlerRepository notificationHandlerRepo;
        private readonly PatientAllocationRepository patientAllocationRepo;
        private readonly PatientRepository patientRepo;
        private readonly UserDeviceTokenRepository userDeviceTokenRepository;
        private readonly UserRepository userRepo;

        public OtherService(LogRepository lr, LogApproveRejectRepository lar, LogNotificationRepository lnr, LogCategoryRepository lcr, NotificationHandlerRepository nhr, PatientAllocationRepository par, PatientRepository pr, UserDeviceTokenRepository udtr, UserRepository ur)
        {
            this.logRepo = lr;
            this.logApproveRejectRepo = lar;
            this.logNotificationRepo = lnr;
            this.logCatRepo = lcr;
            this.notificationHandlerRepo = nhr;
            this.patientAllocationRepo = par;
            this.patientRepo = pr;
            this.userDeviceTokenRepository = udtr;
            this.userRepo = ur;
        }

        /* Reference PatientService/addLikeDislike
         * Normal Log:
         * Create(null, newLogData, 1, userInitID, tableAffected, ?)
         * 1. Call Create() in Repo for Model (this will return object with id = 0)
         * 2.1 No Approval required: Add to DB (id will be set), Serialise Object and createLog()
         * 2.2 Approval required: Just Serialise Object and createLog()
         * 
         * Update/Delete(oldLogData, newLogData, 2/3, userInitID, tableAffected, ?)
         * 1. Serialise Model before changes to oldLogData
         * 2. Make the changes
         * 3. Serialise Model to newLogData
         * 4.1 No Approval required: Update DB and createLog()
         * 4.2 Approval Required: Only createLog()
         */

        public Log createLog(string logCategory, string oldLogData, string newLogData, string userInitID, string tableAffected, int? relatedLogID, int? patientAID)
        {
            Log log = logRepo.CreateAdd(oldLogData, newLogData, logCatRepo.GetLogCatByName(logCategory), userInitID, tableAffected, relatedLogID, patientAID);
            logRepo.SaveChanges();
            return log;
        }
        public List<LogDTO> getLogs(List<Log> logList)
        {
            List<Log> logs = logList == null ? logRepo.getLogs() : logList;
            List<LogDTO> logsDTO = new List<LogDTO>();
            foreach (Log log in logs)
            {
                LogDTO logDTO = new LogDTO();
                logDTO.logId = log.logID;
                logDTO.logCatType = log.LogCategory.type;
                logDTO.logCatName = log.LogCategory.logCategoryName;
                logDTO.userInitRole = log.UserInit.Role.Name;
                logDTO.userInitName = log.UserInit.preferredName;
                logDTO.tableAffected = log.tableAffected;
                logDTO.createdDateTime = log.createdDateTime.ToString();
                logDTO.oldLogData = log.oldLogData;
                logDTO.newLogData = log.newLogData;
                logDTO.relatedLogId = log.relatedLogID;
                if (log.LogAproveReject != null)
                {
                    logDTO.status = log.LogAproveReject.Status;
                    logDTO.userResName = log.LogAproveReject.IntendedUser.preferredName;
                    logDTO.userResRole = log.LogAproveReject.IntendedUser.Role.Name;
                }
                logDTO.relatedLogs = log.RelatedLogs != null ? getLogs(log.RelatedLogs.ToList()) : null;
                logsDTO.Add(logDTO);
            }
            return logsDTO;
        }
        public List<LogDTO> getPatientLogs()
        {
            List<Log> logs = logRepo.getLogs();
            List<LogDTO> logsDTO = new List<LogDTO>();
            foreach (Log log in logs)
            {
                if (log.patientAllocationID == null) continue;
                LogDTO logDTO = new LogDTO();
                logDTO.logId = log.logID;
                logDTO.logCatType = log.LogCategory.type;
                logDTO.logCatName = log.LogCategory.logCategoryName;
                logDTO.userInitRole = log.UserInit.Role.Name;
                logDTO.userInitName = log.UserInit.preferredName;
                logDTO.tableAffected = log.tableAffected;
                logDTO.createdDateTime = log.createdDateTime.ToString();
                logDTO.oldLogData = log.oldLogData;
                logDTO.newLogData = log.newLogData;
                logDTO.relatedLogId = log.relatedLogID;
                if (log.LogAproveReject != null)
                {
                    logDTO.status = log.LogAproveReject.Status;
                    logDTO.userResName = log.LogAproveReject.IntendedUser.preferredName;
                    logDTO.userResRole = log.LogAproveReject.IntendedUser.Role.Name;
                }
                logDTO.patientID = log.PatientAllocation.patientID;
                logDTO.patientName = log.PatientAllocation.Patient.preferredName;
                logDTO.relatedLogs = log.RelatedLogs != null ? getLogs(log.RelatedLogs.ToList()) : null;
                logsDTO.Add(logDTO);
            }
            return logsDTO;
        }

        // For Logs that requires Approval, Create Approve Reject Log
        public LogApproveReject createLogAR(int logID, string intendedUserID)
        {
            LogApproveReject logApproveReject = logApproveRejectRepo.CreateAdd(logID, intendedUserID, null, 2);
            logApproveRejectRepo.SaveChanges();
            return logApproveReject;
        }
        public LogApproveReject createRelatedLogAR(int logID, string intendedUserID)
        {
            LogApproveReject logApproveReject = logApproveRejectRepo.CreateAdd(logID, intendedUserID, null, -1);
            logApproveRejectRepo.SaveChanges();
            return logApproveReject;
        }
        public List<LogApproveRejectDTO> getARLogs(string userID)
        {
            List<LogApproveRejectDTO> larsdto = new List<LogApproveRejectDTO>();
            List<LogApproveReject> lars = logApproveRejectRepo.GetByUser(userID);
            foreach (var lar in lars)
            {
                if (lar.status == -1) // Skip Hidden LogApproveReject
                    continue;
                larsdto.Add(new LogApproveRejectDTO
                {
                    logApproveRejectID = lar.logApproveRejectID,
                    intendedUserName = lar.IntendedUser.preferredName,
                    intendedUserType = lar.IntendedUser.Role.Name,
                    rejectReason = lar.rejectReason,
                    status = lar.Status,
                    createdDateTime = lar.createdDateTime.ToString(),
                    logId = lar.Log.logID,
                    tableAffected = lar.Log.tableAffected,
                    oldLogData = lar.Log.oldLogData,
                    newLogData = lar.Log.newLogData,
                    logCat = lar.Log.LogCategory.logCategoryName,
                    userInitName = lar.Log.UserInit.preferredName,
                    userInitRole = lar.Log.UserInit.Role.Name,
                    patientID = lar.Log.PatientAllocation.Patient.patientID,
                    patientName = lar.Log.PatientAllocation.Patient.preferredName
                });
            }
            return larsdto;
        }

        // For Logs that requires Notification, Create Notification Log
        public LogNotification createLogNotification(int logID, string intendedUserType, string intendedUserID, string step, string message)
        {
            LogNotification logNotification = logNotificationRepo.CreateAdd(logID, intendedUserType, intendedUserID, step, false, message);
            logNotificationRepo.SaveChanges();
            return logNotification;
        }

        // Get the count of unread notifications for the user
        public string getUnreadCount(string userID)
        {
            string count = logNotificationRepo.GetUnreadCount(userID);
            return count;
        }

        // Get all read or unread notifications intended for the user
        public List<LogNotification> getNotification(string userID, bool readStatus)
        {
            List<LogNotification> notifications;
            if (readStatus)
                notifications = logNotificationRepo.GetUnread(userID);
            else
                notifications = logNotificationRepo.GetRead(userID);
            return notifications;
        }

        // Read or unread the notification by updating the readStatus
        public LogNotification updateNotification(int logNotificationID, bool readStatus)
        {
            LogNotification logNotification = logNotificationRepo.UpdateNotification(logNotificationID, readStatus);
            return logNotification;
        }

        // Gets the next step based on response (Accept/Reject) and responseOption (Accept:2/Reject:3)
        public string getNextStep(string responseOption, string response)
        {
            string nextStep = null;
            string[] choices = responseOption.Split('/');
            foreach (string choice in choices)
            {
                if (choice.StartsWith(response))
                    nextStep = choice.Split(':').Last();
            }
            return nextStep;
        }

        // Gets the user in charge of patient by role based on patientAID
        public string getInCharge(string role, int patientAID)
        {
            ApplicationUser user = null;
            if (role.Equals(Constants.Role.Administrator) || role.Equals(Constants.Role.Supervisor))
                user = userRepo.GetUserByRole(role);
            else
            {
                PatientAllocation patientAllocation = patientAllocationRepo.GetById(patientAID);
                if (role.Equals(Constants.Role.Caregiver))
                    user = patientAllocation.Caregiver;
                else if (role.Equals(Constants.Role.Doctor))
                    user = patientAllocation.Doctor;
                else if (role.Equals(Constants.Role.GameTherapist))
                    user = patientAllocation.GameTherapist;
            }
            return user.Id;
        }

        // Gets the next step to be done in the notification chain and create logNotifications when necessary
        public void notificationHandler(int logID, int scenario, string response)
        {
            string prevStep = null;
            string step = null;
            Log log = logRepo.GetById(logID);
            int? patientAID = log.patientAllocationID;

            while (true)
            {
                LogNotification prevNotification = logNotificationRepo.FindByLog(logID);
                if (prevNotification != null)
                {
                    prevStep = prevNotification.step;
                    NotificationHandler prevNotiHandler = notificationHandlerRepo.FindByStep(scenario, prevStep);
                    if (prevNotiHandler.responseRequired == "no")
                        step = prevNotiHandler.nextStep;
                    else
                        step = getNextStep(prevNotiHandler.nextStep, response);
                }
                else step = "1";
                if (step == "end") break;

                NotificationHandler notiHandler = notificationHandlerRepo.FindByStep(scenario, step);
                string intendedUserType = notiHandler.intendedUserType;
                string intendedUserID = log.userInitID;
                if (patientAID != null)
                    intendedUserID = getInCharge(notiHandler.intendedUserType, Convert.ToInt32(patientAID));
                createNotification(log, intendedUserType, intendedUserID, scenario, step, prevStep, patientAID);

                string responseRequired = notiHandler.responseRequired;
                string nextStep = notiHandler.nextStep;

                if (responseRequired == "yes" || nextStep == "end")
                    break;
            }
        }

        // Formats notification message based on tableAffected then creates a logNotification and sends notification to android
        public void createNotification(Log log, string intendedUserType, string intendedUserID, int scenario, string step, string prevStep, int? patientAID)
        {
            LogApproveReject logApproveReject = log.LogAproveReject;
            int logID = log.logID;
            string rejectReason = logApproveReject.rejectReason;
            string logCat = log.LogCategory.logCategoryName;
            string tableAffected = log.tableAffected;
            string userInitID = log.userInitID;
            string patientName = null;

            ApplicationUser userInit = userRepo.GetUserByID(userInitID);
            if (prevStep != null)
            {
                LogNotification prevLogNotification = logNotificationRepo.FindByLog(logID);
                userInit = userRepo.GetUserByID(prevLogNotification.intendedUserID);
            }
            string userInitName = userInit.firstName + " " + userInit.lastName;
            string userInitType = userRepo.GetUserRole(userInit);

            if (patientAID != null)
            {
                PatientAllocation patientAllocation = patientAllocationRepo.GetById(Convert.ToInt32(patientAID));
                Patient patient = patientRepo.GetSelectedPatient(patientAllocation.patientID);
                if (patient != null)
                    patientName = patient.firstName + " " + patient.lastName;
            }

            NotificationHandler notiHandler = notificationHandlerRepo.FindByStep(scenario, step);
            string message = notiHandler.message;

            switch (tableAffected)
            {

                case "allergy":
                    {
                        Allergy allergy = JsonConvert.DeserializeObject<Allergy>(log.newLogData);
                        string allergyName = allergy.List_Allergy.value;

                        // add allergy
                        if (logCat.Equals(Constants.LogCategory.Patient.Create))
                            message = message.Replace("<Name>", userInitName).Replace("<value>", "Allergy: " + allergyName).Replace("<PName>", patientName).Replace("<rejectReason>", rejectReason).Replace("<add/update/delete>", "add");
                        // update allergy
                        else if (logCat.Equals(Constants.LogCategory.Patient.Update))
                        {
                            string difference = getDifference(log.oldLogData, log.newLogData);
                            message = message.Replace("<Name>", userInitName).Replace("<value>", "Allergy: " + difference).Replace("<PName>", patientName).Replace("<rejectReason>", rejectReason).Replace("<add/update/delete>", "update");
                        }
                        // delete allergy
                        else if (logCat.Equals(Constants.LogCategory.Patient.Delete))
                            message = message.Replace("<Name>", userInitName).Replace("<value>", "Allergy: " + allergyName).Replace("<PName>", patientName).Replace("<rejectReason>", rejectReason).Replace("<add/update/delete>", "delete");
                        break;
                    }
                default:
                    {
                        message = userInitType + " " + userInitName + " has requested to make changes to " + tableAffected + " for " + patientName;
                        break;
                    }
            }

            logNotificationRepo.CreateAdd(logID, intendedUserType, intendedUserID, step, false, message);
            logNotificationRepo.SaveChanges();

            int logNotificationID = logNotificationRepo.FindByLog(logID).logNotificationID;
            UserDeviceToken userDeviceToken = userDeviceTokenRepository.GetByUserID(intendedUserID);
            // pushNotificationToAndroid(userDeviceToken.deviceToken, logNotificationID, userInitName, logID);
        }

        // Gets the key of KeyValuePairs that had their value changed
        public string getDifference(string oldLogData, string newLogData)
        {
            string difference = null;
            JObject oldData = JsonConvert.DeserializeObject<JObject>(oldLogData);
            JObject newData = JsonConvert.DeserializeObject<JObject>(newLogData);

            if (!JToken.DeepEquals(oldData, newData))
            {
                foreach (KeyValuePair<string, JToken> item in newData)
                {
                    var oldValue = item.Value;
                    var newValue = oldData.Property(item.Key);
                    if (!JToken.DeepEquals(oldValue, newValue))
                        difference += item.Key + ", ";
                }
            }
            if (difference.EndsWith(", "))
                difference = difference.Remove(difference.Length - 2);
            return difference;
        }

        // Push notification to android based on and intendedUserID and userDeviceToken
        public String pushNotificationToAndroid(String userDeviceToken, int logNotificationID, string userInitName, int logID)
        {
            var result = "-1";
            var webAddr = "https://fcm.googleapis.com/fcm/send";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Headers.Add(HttpRequestHeader.Authorization, "key=AIzaSyBVAwB_Se6MqPVG4nvG3rlIPE6wFyBIQ-E");
            httpWebRequest.Method = "POST";

            JObject jobjNotification = new JObject();
            JObject jobjNotificationInfo = new JObject();
            JObject jobjNotificationData = new JObject();

            jobjNotification.Add("to", userDeviceToken);
            jobjNotification.Add("collapse_key", "type_a");

            string title = "New request";
            string msg = "New notification from " + userInitName;

            jobjNotificationInfo.Add("title", title);
            jobjNotificationInfo.Add("body", msg);
            jobjNotificationInfo.Add("icon", "pear_logo_transparent");
            jobjNotificationInfo.Add("click_action", "OPEN_NOTIFICATION");
            jobjNotificationInfo.Add("sound", "default");

            jobjNotificationData.Add("logid", logID);
            jobjNotificationData.Add("msg", msg);
            jobjNotificationData.Add("notificationId", logNotificationID);

            jobjNotification.Add("notification", jobjNotificationInfo);
            jobjNotification.Add("data", jobjNotificationData);

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string strNJson = jobjNotification.ToString();
                streamWriter.Write(strNJson);
                streamWriter.Flush();
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }
            return result;
        }
    }
}
