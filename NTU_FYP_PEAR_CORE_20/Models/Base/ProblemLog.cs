using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace NTU_FYP_PEAR_CORE_20.Models
{
    public class ProblemLog : Base
    {
        [NotMapped]
        public static string TableName = "problemLog";

        [Key]
        public int problemLogID { get; set; }

        [Required]
        [ForeignKey("User")]
        public string userID { get; set; }

        [JsonIgnore]
        public virtual ApplicationUser User { get; set; }

        [ForeignKey("PatientAllocation")]
        public int patientAllocationID { get; set; }

        [JsonIgnore]
        public virtual PatientAllocation PatientAllocation { get; set; }

        //[ForeignKey("List_ProblemLog")]
        public int problemLogListID { get; set; }

        [JsonIgnore]
        public virtual List_ProblemLog List_ProblemLog { get; set; }

        public string problemLogRemarks { get; set; }
    }
}