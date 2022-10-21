using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace NTU_FYP_PEAR_CORE_20.Models
{
    public class GameAssignedDementia : Base
    {
        [NotMapped]
        public static string TableName = "gameAssignedDementia";

        [Key]
        public int gadID { get; set; }

        [ForeignKey("List_DementiaType")]
        public int dementiaTypeListID { get; set; }

        //[JsonIgnore]
        public virtual List_DementiaType DementiaTypeList { get; set; }

        [ForeignKey("Game")]
        public int gameID { get; set; }

        [JsonIgnore]
        public virtual Game Game { get; set; }

        [ForeignKey("GameTherapist")]
        public string gameTherapistID { get; set; }

        [JsonIgnore]
        public virtual ApplicationUser GameTherapist { get; set; }

        public string recommmendationReason { get; set; }
        public string rejectionReason { get; set; }
    }
}