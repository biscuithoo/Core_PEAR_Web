using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NTU_FYP_PEAR_CORE_20.Models
{
    public class Allergy : Base
    {
        [NotMapped]
        public static string TableName = "allergy";

        [Key]
        public int allergyID { get; set; }

        [ForeignKey("PatientAllocation")]
        public int patientAllocationID { get; set; }

        [JsonIgnore]
        public virtual PatientAllocation PatientAllocation { get; set; }

        [ForeignKey("List_Allergy")]
        public int allergyListID { get; set; }

        //[JsonIgnore]
        public virtual List_Allergy List_Allergy { get; set; }

        [ForeignKey("List_AllergyReaction")]
        public int allergyReactionListID { get; set; }

        //[JsonIgnore]
        public virtual List_AllergyReaction List_AllergyReaction { get; set; }

        public string allergyRemarks { get; set; }
    }
}