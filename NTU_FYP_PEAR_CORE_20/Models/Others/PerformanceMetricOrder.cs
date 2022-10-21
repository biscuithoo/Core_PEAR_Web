using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NTU_FYP_PEAR_CORE_20.Models
{
    public class PerformanceMetricOrder
    {
        [NotMapped]
        public static string TableName = "performanceMetricOrder";

        //[Key]
        public int metricOrder { get; set; }

        [Column(Order = 0)]
        //[ForeignKey("PerformanceMetricName")]
        public int pmnID { get; set; }

        [JsonIgnore]
        public virtual PerformanceMetricName PerformanceMetricName { get; set; }

        [Column(Order = 1)]
        //[ForeignKey("Game")]
        public int gameID { get; set; }

        [JsonIgnore]
        public virtual Game Game { get; set; }

        public DateTime createdDateTime { get; set; } = DateTime.Now;
        public DateTime updatedDateTime { get; set; } = DateTime.Now;
    }
}