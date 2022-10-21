using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NTU_FYP_PEAR_CORE_20.DTOs
{
    public class LogApproveRejectDTO
    {
        public int logApproveRejectID;
        public string intendedUserName;
        public string intendedUserType;
        public string rejectReason;
        public string status;
        public string createdDateTime;

        public int logId;
        public string tableAffected;
        public string oldLogData;
        public string newLogData;
        public string logCat;
        public string userInitName;
        public string userInitRole;

        public int? patientID;
        public string patientName;

        public LogApproveRejectDTO() { }
        public LogApproveRejectDTO(int id, string iusername, string iusertype, string rr, string s, DateTime udt)
        {
            logApproveRejectID = id;
            intendedUserName = iusername;
            intendedUserType = iusertype;
            rejectReason = rr;
            status = s;
            createdDateTime = udt.ToString();
        }
    }

    public class LogApprovalDTO
    {
        public int logId;
        public string rejectReason;
        public string status;
    }
}
