using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace NTU_FYP_PEAR_CORE_20.Models
{
    public class MedicationLog : Base
    {
        [NotMapped]
        public static string TableName = "medicationLog";

        [Key]
        public int medicationLogID { get; set; }

        [ForeignKey("PatientAllocation")]
        public int patientAllocationID { get; set; }

        [JsonIgnore]
        public virtual PatientAllocation PatientAllocation { get; set; }

        [ForeignKey("Prescription")]
        public int prescriptionID { get; set; }

        [JsonIgnore]
        public virtual Prescription Prescription { get; set; }

        public DateTime allocatedDateTime { get; set; }

        [ForeignKey("AspNetUsers")]
        public int? servedBy { get; set; }

        [JsonIgnore]
        public virtual ApplicationUser ServedBy { get; set; }

        public DateTime? takenDateTime { get; set; }
    }
}