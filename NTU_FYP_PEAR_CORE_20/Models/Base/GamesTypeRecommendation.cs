using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace NTU_FYP_PEAR_CORE_20.Models
{
    public class GamesTypeRecommendation : Base
    {
        [NotMapped]
        public static string TableName = "gamesTypeRecommendation";

        [Key]
        public int gamesTypeRecommendationID { get; set; }

        [ForeignKey("PatientAllocation")]
        public int patientAllocationID { get; set; }

        [JsonIgnore]
        public virtual PatientAllocation PatientAllocation { get; set; }

        [ForeignKey("List_GameCategory")]
        public int gameCategoryListID { get; set; }

        //[JsonIgnore]
        public virtual List_GameCategory GameCategoryList { get; set; }

        [ForeignKey("Doctor")]
        public string doctorID { get; set; }
        public virtual ApplicationUser Doctor { get; set; }

        public string recommmendationReason { get; set; }
        public DateTime startDate { get; set; }
        public DateTime? endDate { get; set; }

        [ForeignKey("GameTherapist")]
        public string gameTherapistID { get; set; }
        public virtual ApplicationUser GameTherapist { get; set; }

        public bool? supervisorApproved { get; set; }
        public bool? gameTherapistApproved { get; set; }
        public string rejectionReason { get; set; }
    }
}