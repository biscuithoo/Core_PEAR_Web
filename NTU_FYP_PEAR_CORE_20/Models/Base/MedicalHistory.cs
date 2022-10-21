using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace NTU_FYP_PEAR_CORE_20.Models
{
    public class MedicalHistory : Base
    {
        [NotMapped]
        public static string TableName = "medicalHistory";

        [Key]
        public int medicalHistoryID { get; set; }

        [ForeignKey("PatientAllocation")]
        public int patientAllocationID { get; set; }

        [JsonIgnore]
        public virtual PatientAllocation PatientAllocation { get; set; }

        [Required]
        public string medicalDetails { get; set; }

        [Required]
        public string informationSource { get; set; }
        public string medicalRemarks { get; set; }
        public DateTime medicalEstimatedDate { get; set; }
    }
}