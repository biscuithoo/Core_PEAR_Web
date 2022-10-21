using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace NTU_FYP_PEAR_CORE_20.Models
{
    public class GameCategoryAssignedDementia : Base
    {
        [NotMapped]
        public static string TableName = "gameCategoryAssignedDementia";

        [Key]
        public int gcadID { get; set; }

        [ForeignKey("List_DementiaType")]
        public int dementiaTypeListID { get; set; }

        //[JsonIgnore]
        public virtual List_DementiaType DementiaTypeList { get; set; }

        [ForeignKey("List_GameCategory")]
        public int gameCategoryListID { get; set; }

        [JsonIgnore]
        public virtual List_GameCategory GameCategoryList { get; set; }

        [ForeignKey("Doctor")]
        public string doctorID { get; set; }

        [JsonIgnore]
        public virtual ApplicationUser Doctor { get; set; }

        [ForeignKey("GameTherapist")]
        public string gameTherapistID { get; set; }

        [JsonIgnore]
        public virtual ApplicationUser GameTherapist { get; set; }

        public string recommmendationReason { get; set; }
        public string rejectionReason { get; set; }
    }
}