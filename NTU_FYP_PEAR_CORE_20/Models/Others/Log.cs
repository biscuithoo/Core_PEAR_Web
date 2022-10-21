using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace NTU_FYP_PEAR_CORE_20.Models
{
    public class Log
    {
        [NotMapped]
        public static string TableName = "log";

        [Key]
        public int logID { get; set; }

        [ForeignKey("Log")]
        public int? relatedLogID { get; set; }
        public virtual Log RelatedLog { get; set; }

        [JsonIgnore]
        public virtual ICollection<Log> RelatedLogs { get; set; }

        public string oldLogData { get; set; }
        public string newLogData { get; set; }

        [ForeignKey("LogCategory")]
        public int logCategoryID { get; set; }

        public virtual LogCategory LogCategory { get; set; }

        [Required]
        [ForeignKey("UserInit")]
        public string userInitID { get; set; }

        [JsonIgnore]
        public virtual ApplicationUser UserInit { get; set; }

        [ForeignKey("PatientAllocation")]
        public int? patientAllocationID { get; set; }

        [JsonIgnore]
        public virtual PatientAllocation PatientAllocation { get; set; }

        [Required]
        [StringLength(256)]
        public string tableAffected { get; set; }
        public DateTime createdDateTime { get; set; } = DateTime.Now;

        [JsonIgnore]
        public virtual LogApproveReject LogAproveReject { get; set; }

        [JsonIgnore]
        public virtual LogNotification LogNotification { get; set; }

    }
}