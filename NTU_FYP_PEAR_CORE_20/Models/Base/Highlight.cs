using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace NTU_FYP_PEAR_CORE_20.Models
{
    public class Highlight : Base
    {
        [NotMapped]
        public static string TableName = "highlight";

        [Key]
        public int highlightID { get; set; }

        [ForeignKey("PatientAllocation")]
        public int patientAllocationID { get; set; }

        [JsonIgnore]
        public virtual PatientAllocation PatientAllocation { get; set; }

        [ForeignKey("HighlightType")]
        public int highlightTypeID { get; set; }

        [JsonIgnore]
        public virtual HighlightType HighlightType { get; set; }

        [Required]
        [StringLength(256)]
        public string highlightJson { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
    }
}