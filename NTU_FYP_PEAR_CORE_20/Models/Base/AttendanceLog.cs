using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace NTU_FYP_PEAR_CORE_20.Models
{
    public class AttendanceLog : Base
    {
        [NotMapped]
        public static string TableName = "attendanceLog";

        [Key]
        public int attendanceLogID { get; set; }

        [ForeignKey("PatientAllocation")]
        public int patientAllocationID { get; set; }

        [JsonIgnore]
        public virtual PatientAllocation PatientAllocation { get; set; }
        public DateTime attendanceDate { get; set; }

        [StringLength(16)]
        public string day { get; set; }
        public DateTime? arrivalTime { get; set; }
        public DateTime? departureTime { get; set; }
    }
}