using Microsoft.EntityFrameworkCore;
using NTU_FYP_PEAR_CORE_20.Data;
using NTU_FYP_PEAR_CORE_20.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NTU_FYP_PEAR_CORE_20.Repository
{
    public class LogRepository : Repository<Log>
    {
        public LogRepository(ApplicationDbContext context) : base(context) { }
        public Log Create(string oldLogData, string newLogData, int logCategoryID, string userInitID, string tableAffected, int? relatedLogID, int? patientAID)
        {
            Log entity = new Log();
            entity.oldLogData = oldLogData;
            entity.newLogData = newLogData;
            entity.logCategoryID = logCategoryID;
            entity.userInitID = userInitID;
            entity.tableAffected = tableAffected;
            entity.relatedLogID = relatedLogID == null ? entity.relatedLogID : relatedLogID;
            entity.patientAllocationID = patientAID == null ? entity.patientAllocationID : patientAID;
            return entity;
        }
        public Log CreateAdd(string oldLogData, string newLogData, int logCategoryID, string userInitID, string tableAffected, int? relatedLogID, int? patientAID)
        {
            Log entity = Create(oldLogData, newLogData, logCategoryID, userInitID, tableAffected, relatedLogID, patientAID);
            Add(entity);
            return entity;
        }

        public List<Log> getLogs()
        {
            return GetAll().Include(x => x.LogCategory).Include(x => x.RelatedLog).Include(x => x.LogNotification.IntendedUser.Role).Include(x => x.PatientAllocation.Patient)
                .Include(x => x.LogAproveReject.IntendedUser.Role).Include(x => x.UserInit.Role).ToList();
        }

        public Log GetLogById(int id)
        {
            return GetAll().Where(x => x.logID == id).Include(x => x.UserInit.Role)
                .Include(x => x.RelatedLog.LogAproveReject.IntendedUser.Role)
                .Include(x => x.LogAproveReject.IntendedUser.Role).Include(x => x.LogCategory)
                .Include(x => x.LogNotification.IntendedUser.Role).First();
        }

    }
}
