using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NTU_FYP_PEAR_CORE_20.DTOs
{
    public class LogDTO
    {
        public int logId;
        public string logCatType;
        public string logCatName;
        public string userInitRole;
        public string userInitName;
        public string tableAffected;
        public string createdDateTime;
        public string oldLogData;
        public string newLogData;
        public int? relatedLogId;

        public string status;
        public string userResRole;
        public string userResName;

        public int? patientID;
        public string patientName;

        public List<LogDTO> relatedLogs;

    }
}
