using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace NTU_FYP_PEAR_CORE_20.Models
{
    public class DoctorNote : Base
    {
        [NotMapped]
        public static string TableName = "doctorNote";

        [Key]
        public int doctorNoteID { get; set; }

        [ForeignKey("PatientAllocation")]
        public int patientAllocationID { get; set; }

        [JsonIgnore]
        public virtual PatientAllocation PatientAllocation { get; set; }

        [Required]
        [ForeignKey("Doctor")]
        public string doctorID { get; set; }

        [JsonIgnore]
        public virtual ApplicationUser Doctor { get; set; }

        public string doctorRemarks { get; set; }
    }
}