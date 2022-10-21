using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NTU_FYP_PEAR_CORE_20.Models
{
    public class AssignedGame : Base
    {
        [NotMapped]
        public static string TableName = "assignedGame";

        [Key]
        public int assignedGameID { get; set; }

        [ForeignKey("PatientAllocation")]
        public int patientAllocationID { get; set; }

        [JsonIgnore]
        public virtual PatientAllocation PatientAllocation { get; set; }

        [ForeignKey("Game")]
        public int gameID { get; set; }

        [JsonIgnore]
        public virtual Game Game { get; set; }

        public string assignRemarks { get; set; }
        public DateTime? endDate { get; set; }

        [ForeignKey("GameTherapist")]
        public string gameTherapistID { get; set; }

        [JsonIgnore]
        public virtual ApplicationUser GameTherapist { get; set; }

        public string recommmendationReason { get; set; }
        public string rejectionReason { get; set; }
    }
}