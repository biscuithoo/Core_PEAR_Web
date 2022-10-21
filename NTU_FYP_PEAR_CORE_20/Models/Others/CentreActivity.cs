using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace NTU_FYP_PEAR_CORE_20.Models
{
    public class CentreActivity
    {
        [NotMapped]
        public static string TableName = "centreActivity";

        [Key]
        public int centreActivityID { get; set; }

        [ForeignKey("Activities")]
        public int activityID { get; set; }

        [JsonIgnore]
        public virtual Activities Activities { get; set; }

        public bool isCompulsory { get; set; }
        public bool isFixed { get; set; }
        public bool isGroup { get; set; }
        public int minDuration { get; set; }
        public int maxDuration { get; set; }
        public int minPeopleReq { get; set; }
    }
}