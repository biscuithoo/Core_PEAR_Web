using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace NTU_FYP_PEAR_CORE_20.Models
{
    public class CentreActivityRecommendation : Base
    {
        [NotMapped]
        public static string TableName = "centreActivityRecommendation";

        [Key]
        public int centreActivityRecommendationID { get; set; }

        [ForeignKey("PatientAllocation")]
        public int patientAllocationID { get; set; }

        [JsonIgnore]
        public virtual PatientAllocation PatientAllocation { get; set; }

        [ForeignKey("CentreActivity")]
        public int centreActivityID { get; set; }

        [JsonIgnore]
        public virtual CentreActivity CentreActivity { get; set; }

        [Required]
        [ForeignKey("ApplicationUser")]
        public string doctorID { get; set; }

        [JsonIgnore]
        public virtual ApplicationUser ApplicationUser { get; set; }

        [Required]
        public bool doctorRecommendation { get; set; } = false;

        [Required]
        public string doctorRemarks { get; set; }
    }
}