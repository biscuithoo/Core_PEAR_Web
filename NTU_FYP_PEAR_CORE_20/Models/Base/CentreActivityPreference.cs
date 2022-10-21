using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace NTU_FYP_PEAR_CORE_20.Models
{
    public class CentreActivityPreference : Base
    {
        [NotMapped]
        public static string TableName = "centreActivityPreference";

        [Key]
        public int centreActivityPreferenceID { get; set; }

        [ForeignKey("PatientAllocation")]
        public int patientAllocationID { get; set; }

        [JsonIgnore]
        public virtual PatientAllocation PatientAllocation { get; set; }

        [ForeignKey("CentreActivity")]
        public int centreActivityID { get; set; }

        [JsonIgnore]
        public virtual CentreActivity CentreActivity { get; set; }

        public int isLike { get; set; } = 2;
    }
}