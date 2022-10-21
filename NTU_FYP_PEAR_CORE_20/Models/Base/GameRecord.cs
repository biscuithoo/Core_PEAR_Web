using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace NTU_FYP_PEAR_CORE_20.Models
{
    public class GameRecord : Base
    {
        [NotMapped]
        public static string TableName = "gameRecord";

        [Key]
        public int gameRecordID { get; set; }

        [ForeignKey("AssignedGame")]
        public int assignedGameID { get; set; }

        [JsonIgnore]
        public virtual AssignedGame AssignedGame { get; set; }

        public double? score { get; set; }
        public int? timeTaken { get; set; }
        public string performanceMetricsValues { get; set; }
    }
}