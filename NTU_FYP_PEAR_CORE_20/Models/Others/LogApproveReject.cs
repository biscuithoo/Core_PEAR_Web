using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace NTU_FYP_PEAR_CORE_20.Models
{
    public class LogApproveReject
    {
        [NotMapped]
        public static string TableName = "logApproveReject";

        [Key]
        public int logApproveRejectID { get; set; }

        [ForeignKey("Log")]
        public int logID { get; set; }

        [JsonIgnore]
        public virtual Log Log { get; set; }

        [ForeignKey("IntendedUser")]
        public string intendedUserID { get; set; }

        [JsonIgnore]
        public virtual ApplicationUser IntendedUser { get; set; }

        [StringLength(256)]
        public string rejectReason { get; set; }

        public int? status { get; set; } = 2;

        [NotMapped]
        public string Status
        {
            get { if (status == 0) return "Rejected"; else if (status == 1) return "Approved"; else if (status == -1) return "Hidden"; else return "Pending"; }
            set { if (value == "Rejected") status = 0; else if (value == "Approved") status = 1; else if (value == "Hidden") status = -1; else status = 2; }
        }
        public DateTime createdDateTime { get; set; } = DateTime.Now;
        public DateTime updatedDateTime { get; set; } = DateTime.Now;
    }
}