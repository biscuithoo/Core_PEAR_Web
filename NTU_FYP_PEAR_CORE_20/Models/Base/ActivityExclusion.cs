using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NTU_FYP_PEAR_CORE_20.Models
{
    public class ActivityExclusion : Base
    {
        [NotMapped]
        public static string TableName = "activityExclusion";

        [Key]
        public int activityExclusionID { get; set; }

        [ForeignKey("PatientAllocation")]
        public int patientAllocationID { get; set; }

        [JsonIgnore]
        public virtual PatientAllocation PatientAllocation { get; set; }

        [ForeignKey("Activities")]
        public int activityID { get; set; }

        [JsonIgnore]
        public virtual Activities Activities { get; set; }

        [Required]
        public string exclusionRemarks { get; set; }

        public DateTime startDateTime { get; set; }
        public DateTime endDateTime { get; set; }
    }
}