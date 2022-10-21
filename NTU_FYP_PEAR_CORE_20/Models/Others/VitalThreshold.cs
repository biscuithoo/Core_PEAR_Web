using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NTU_FYP_PEAR_CORE_20.Models
{
    public class VitalThreshold : Base
    {
        [NotMapped]
        public static string TableName = "vitalThreshold";

        [Key]
        public int vitalThresholdID { get; set; }

        [Required]
        [StringLength(32)]
        public string category { get; set; }
        public int minValue { get; set; }
        public int maxValue { get; set; }
    }
}