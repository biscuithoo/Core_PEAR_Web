using NTU_FYP_PEAR_CORE_20.Data;
using NTU_FYP_PEAR_CORE_20.Models;
using NTU_FYP_PEAR_CORE_20.Repository;
using NTU_FYP_PEAR_CORE_20.Repository.Others;
using NTU_FYP_PEAR_CORE_20.Services.PatientRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NTU_FYP_PEAR_CORE_20.Services
{
    /* 
     * This Service SHOULD NOT be called by ANY other service class
     * This Service calls all the other services to handle Add/Update to Database via Serialised Object
     */
    public class ApproveRejectHandlerService
    {
        private readonly LogRepository logRepo;
        private readonly LogApproveRejectRepository logApproveRejectRepo;
        private readonly LogNotificationRepository logNotificationRepo;
        private readonly LogCategoryRepository logCatRepo;

        private readonly PatientPersonalPreferenceService patientPPService;
        private readonly OtherService otherService;

        public ApproveRejectHandlerService(OtherService os, PatientPersonalPreferenceService ps, LogRepository lr, LogApproveRejectRepository lar, LogNotificationRepository lnr, LogCategoryRepository lcr)
        {
            this.logRepo = lr;
            this.logApproveRejectRepo = lar;
            this.logNotificationRepo = lnr;
            this.logCatRepo = lcr;
            this.patientPPService = ps;
            this.otherService = os;
        }

        /*
         * Approved
         * 1. Update LogApproveReject status
         * 2. Filter by tableAffected > logCategory
         * Method in relevant Service
         * 3. Deserialise oldLogData/newLogData, add/update record into table
         * 4. Serialise record > update newLogData
         * 5. !!!! Update Id of relatedLog !!!! 
         * - E.g After adding list item update listId in logData of relatedLog item
         * Return
         * 6. Trigger next step for relatedLog (if any) / Notify userInitID
         * 
         * Rejected
         * 1. Update LogApproveReject status, rejectReason (if any)
         * 2. Reject LogApproveReject of relatedLog (if any)
         * 3. Notify userInitID
         */
        public void approveRejectLog(int logID, string status, string rejectReason) // TODO: Testing
        {
            Log log = logRepo.GetLogById(logID);
            LogApproveReject lar = log.LogAproveReject;

            string tableAffected = log.tableAffected;
            string logCat = log.LogCategory.logCategoryName;

            if (status.Equals("Approved"))
            {
                lar.status = 1;

                // ---------- List_xxx (There are only Create Approvals for Lists)
                if (tableAffected.Equals(List_LikeDislike.TableName))
                {
                    if (logCat.Equals(Constants.LogCategory.List.Create))
                    {
                        log.newLogData = patientPPService.addLikeDislikeListLog(log.newLogData, log.RelatedLog);
                        logRepo.SaveChanges();
                        // Notify userInitID
                        if (log.UserInit.Role.Name.Equals(Constants.Role.Supervisor))
                        {
                            approveRejectLog(log.RelatedLog.logID, "Approved", rejectReason);
                            //    otherService.notificationHandler(log.logID, 8, "Accept");
                        }
                        if (log.UserInit.Role.Name.Equals(Constants.Role.Guardian))
                            approveRejectLog(log.RelatedLog.logID, "Approved", rejectReason);

                        //if (log.UserInit.Role.Name.Equals(Constants.Role.Caregiver))
                        //{ // notify supervisor
                        //    otherService.notificationHandler(log.logID, 7, "Accept");
                        //    otherService.notificationHandler(log.logID, 2, null);
                        //}
                    }
                }
                if (tableAffected.Equals(List_Habit.TableName))
                {
                    if (logCat.Equals(Constants.LogCategory.List.Create))
                    {
                        log.newLogData = patientPPService.addHabitListLog(log.newLogData, log.RelatedLog);
                        logRepo.SaveChanges();
                        // Notify userInitID
                        if (log.UserInit.Role.Name.Equals(Constants.Role.Supervisor))
                        {
                            approveRejectLog(log.RelatedLog.logID, "Approved", rejectReason);
                            //    otherService.notificationHandler(log.logID, 8, "Accept");
                        }
                        if (log.UserInit.Role.Name.Equals(Constants.Role.Guardian))
                            approveRejectLog(log.RelatedLog.logID, "Approved", rejectReason);
                        //if (log.UserInit.Role.Name.Equals(Constants.Role.Caregiver))
                        //{ // notify supervisor
                        //    otherService.notificationHandler(log.logID, 7, "Accept");
                        //    otherService.notificationHandler(log.logID, 2, null);
                        //}
                    }
                }
                if (tableAffected.Equals(List_Hobby.TableName))
                {
                    if (logCat.Equals(Constants.LogCategory.List.Create))
                    {
                        log.newLogData = patientPPService.addHobbyListLog(log.newLogData, log.RelatedLog);
                        logRepo.SaveChanges();
                        // Notify userInitID
                        if (log.UserInit.Role.Name.Equals(Constants.Role.Supervisor))
                        {
                            approveRejectLog(log.RelatedLog.logID, "Approved", rejectReason);
                            //    otherService.notificationHandler(log.logID, 8, "Accept");
                        }
                        if (log.UserInit.Role.Name.Equals(Constants.Role.Guardian))
                            approveRejectLog(log.RelatedLog.logID, "Approved", rejectReason);
                        //if (log.UserInit.Role.Name.Equals(Constants.Role.Caregiver))
                        //{ // notify supervisor
                        //    otherService.notificationHandler(log.logID, 7, "Accept");
                        //    otherService.notificationHandler(log.logID, 2, null);
                        //}
                    }
                }

                // ---------- Patient related
                if (tableAffected.Equals(LikeDislike.TableName))
                {
                    if (logCat.Equals(Constants.LogCategory.Patient.Create))
                    {
                        log.newLogData = patientPPService.addLikeDislikeLog(log.newLogData);
                        logRepo.SaveChanges();
                        // Notify userInitID
                        //otherService.notificationHandler(log.logID, 2, "Accept");
                    }
                }
                if (tableAffected.Equals(Habit.TableName))
                {
                    if (logCat.Equals(Constants.LogCategory.Patient.Create))
                    {
                        log.newLogData = patientPPService.addHabitLog(log.newLogData);
                        logRepo.SaveChanges();
                        // Notify userInitID
                        //otherService.notificationHandler(log.logID, 2, "Accept");
                    }
                }
                if (tableAffected.Equals(Hobby.TableName))
                {
                    if (logCat.Equals(Constants.LogCategory.Patient.Create))
                    {
                        log.newLogData = patientPPService.addHobbyLog(log.newLogData);
                        logRepo.SaveChanges();
                        // Notify userInitID
                        //otherService.notificationHandler(log.logID, 2, "Accept");
                    }
                }
            }
            else if (status.Equals("Rejected"))
            {
                // update logapprovereject status, rejectReason
                lar.status = 0;
                if (rejectReason != null) lar.rejectReason = rejectReason;

                // update relatedLog approvereject status (if any)
                Log relatedLog = log.RelatedLog;
                while (true)
                {
                    if (relatedLog != null)
                    {
                        relatedLog.LogAproveReject.status = 0;
                        if (rejectReason != null) relatedLog.LogAproveReject.rejectReason = rejectReason;
                        relatedLog = relatedLog.RelatedLog;
                    }
                    else
                        break;
                }

                // Notify userInitID
                // ---------- List_xxx (There are only Create Approvals for Lists)
                if (tableAffected.Equals(List_LikeDislike.TableName) || tableAffected.Equals(List_Habit.TableName) ||
                    tableAffected.Equals(List_Hobby.TableName))
                    if (logCat.Equals(Constants.LogCategory.Patient.Create))
                    {
                        //if (log.UserInit.Role.Name.Equals(Constants.Role.Supervisor))
                        //    otherService.notificationHandler(log.logID, 8, "Reject");
                        //if (log.UserInit.Role.Name.Equals(Constants.Role.Caregiver)) // notify supervisor
                        //    otherService.notificationHandler(log.logID, 7, "Reject");
                    }

                // ---------- Patient related
                if (tableAffected.Equals(LikeDislike.TableName) || tableAffected.Equals(Habit.TableName) ||
                    tableAffected.Equals(Hobby.TableName))
                    if (logCat.Equals(Constants.LogCategory.Patient.Create)) { }
                //otherService.notificationHandler(log.logID, 2, "Reject");
            }
            logRepo.SaveChanges();
        }
    }
}
