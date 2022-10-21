using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NTU_FYP_PEAR_CORE_20.Models
{
    public class Prescription : Base
    {
        [NotMapped]
        public static string TableName = "prescription";

        [Key]
        public int prescriptionID { get; set; }

        [ForeignKey("PatientAllocation")]
        public int patientAllocationID { get; set; }

        [JsonIgnore]
        public virtual PatientAllocation PatientAllocation { get; set; }

        [ForeignKey("List_Prescription")]
        public int prescriptionListID { get; set; }

        //[JsonIgnore]
        public virtual List_Prescription List_Prescription { get; set; }

        [Required]
        [StringLength(256)]
        public string dosage { get; set; }
        public int frequencyPerDay { get; set; }

        [Required]
        [StringLength(256)]
        public string instruction { get; set; }
        public DateTime startDate { get; set; }
        public DateTime? endDate { get; set; }
        public bool afterMeal { get; set; }
        public string prescriptionRemarks { get; set; }
        public bool isChronic { get; set; }
    }
}