using Microsoft.EntityFrameworkCore;
using NTU_FYP_PEAR_CORE_20.Data;
using NTU_FYP_PEAR_CORE_20.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NTU_FYP_PEAR_CORE_20.Repository
{
    public class LogApproveRejectRepository : Repository<LogApproveReject>
    {
        public LogApproveRejectRepository(ApplicationDbContext context) : base(context) { }

        public LogApproveReject Create(int logID, string intendedUserID, string rejectReason, int? status)
        {
            LogApproveReject entity = new LogApproveReject();
            entity.logID = logID;
            entity.intendedUserID = intendedUserID;
            entity.rejectReason = rejectReason == null ? entity.rejectReason : rejectReason;
            entity.status = status == null ? status : status;
            return entity;
        }
        public LogApproveReject CreateAdd(int logID, string intendedUserID, string rejectReason, int? status)
        {
            LogApproveReject entity = Create(logID, intendedUserID, rejectReason, status);
            Add(entity);
            return entity;
        }
        public List<LogApproveReject> GetByUser(string Id)
        {
            return GetAll().Where(i => i.intendedUserID == Id).Include(i => i.Log.UserInit.Role).Include(i => i.IntendedUser.Role).Include(i => i.Log.LogCategory).Include(i => i.Log.PatientAllocation.Patient).ToList();
        }
        public LogApproveReject FindByLog(int logID)
        {
            return DbSet.Where(x => x.logID == logID).SingleOrDefault();
        }
        public LogApproveReject UpdateAR(int logARID, int status, string rejectReason)
        {
            LogApproveReject entity = GetById(logARID);
            entity.status = status;
            entity.rejectReason = rejectReason == null ? entity.rejectReason : rejectReason;
            entity.updatedDateTime = DateTime.Now;
            Update(entity);
            return entity;
        }

    }
}
