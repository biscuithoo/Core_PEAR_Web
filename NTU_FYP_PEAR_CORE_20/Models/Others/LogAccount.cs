using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace NTU_FYP_PEAR_CORE_20.Models
{
    public class LogAccount
    {
        [NotMapped]
        public static string TableName = "logAccount";

        [Key]
        public int logAccountID { get; set; }

        [Required]
        [ForeignKey("UserInit")]
        public string userIDInit { get; set; }

        [JsonIgnore]
        public virtual ApplicationUser UserInit { get; set; }

        public string oldLogData { get; set; }

        [Required]
        public string newLogData { get; set; }

        [ForeignKey("LogCategory")]
        public int logCategoryID { get; set; }

        [JsonIgnore]
        public virtual LogCategory LogCategory { get; set; }

        public DateTime createdDateTime { get; set; } = DateTime.Now;
    }
}