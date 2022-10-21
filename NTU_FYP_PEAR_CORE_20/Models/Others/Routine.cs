using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NTU_FYP_PEAR_CORE_20.Models
{
    public class Routine
    {
        [NotMapped]
        public static string TableName = "routine";

        [Key]
        public int routineID { get; set; }

        [ForeignKey("Activity")]
        public int activityID { get; set; }

        [JsonIgnore]
        public virtual Activities Activity { get; set; }

        [ForeignKey("PatientAllocation")]
        public int patientAllocationID { get; set; }

        [JsonIgnore]
        public virtual PatientAllocation PatientAllocation { get; set; }

        [Required]
        public string routineIssues { get; set; }
        public bool includeInSchedule { get; set; } = false;
    }
}