using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NTU_FYP_PEAR_CORE_20.Models
{
    public class ActivityAvailability : Base
    {
        [NotMapped]
        public static string TableName = "activityAvailability";

        //[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Key]
        public int activityAvailabilityID { get; set; }

        [ForeignKey("Activities")]
        public int activityID { get; set; }

        [JsonIgnore]
        public virtual Activities Activities { get; set; }

        [Required]
        [StringLength(9)]
        public string day { get; set; }

        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
    }
}
 