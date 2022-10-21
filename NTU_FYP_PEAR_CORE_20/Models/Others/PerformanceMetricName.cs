using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace NTU_FYP_PEAR_CORE_20.Models
{
    public class PerformanceMetricName
    {
        [NotMapped]
        public static string TableName = "performanceMetricName";

        [Key]
        public int pmnID { get; set; }
        public string performanceMetricName { get; set; }
        public string performanceMetricDetail { get; set; }

        [ForeignKey("Game")]
        public int gameID { get; set; }

        [JsonIgnore]
        public virtual Game Game { get; set; }

        public DateTime createdDateTime { get; set; } = DateTime.Now;
        public DateTime updatedDateTime { get; set; } = DateTime.Now;
    }
}