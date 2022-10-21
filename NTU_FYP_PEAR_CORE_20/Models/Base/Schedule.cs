using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace NTU_FYP_PEAR_CORE_20.Models
{
    public class Schedule : Base
    {
        [NotMapped]
        public static string TableName = "schedule";

        [Key]
        public int scheduleID { get; set; }

        [ForeignKey("PatientAllocation")]
        public int patientAllocationID { get; set; }

        [JsonIgnore]
        public virtual PatientAllocation PatientAllocation { get; set; }

        [ForeignKey("Activity")]
        public int activityID { get; set; }

        [JsonIgnore]
        public virtual Activities Activity { get; set; }

        [StringLength(256)]
        public string scheduleDesc { get; set; }
        public DateTime startDateTime { get; set; }
        public DateTime endDateTime { get; set; }
        public bool isClash { get; set; } = false;
    }
}