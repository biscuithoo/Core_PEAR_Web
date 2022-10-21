using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NTU_FYP_PEAR_CORE_20.Models
{
    public class Activities : Base
    {
        [NotMapped]
        public static string TableName = "activity";

        [Key]
        public int activityID { get; set; }

        [Required]
        [StringLength(16)]
        public string activityTitle { get; set; }

        [Required]
        public string activityDesc { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }

        [JsonIgnore]
        public virtual CentreActivity CentreActivity { get; set; }

        [JsonIgnore]
        public virtual Routine Routine { get; set; }
    }
}
 