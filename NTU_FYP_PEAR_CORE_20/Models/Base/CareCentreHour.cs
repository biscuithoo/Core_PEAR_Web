using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace NTU_FYP_PEAR_CORE_20.Models
{
    public class CareCentreHour : Base
    {
        [NotMapped]
        public static string TableName = "careCentreHour";

        [Key]
        public int centreHoursID { get; set; }

        [ForeignKey("CareCentre")]
        public int centreID { get; set; }

        [JsonIgnore]
        public virtual CareCentreAttribute CareCentre { get; set; }

        [StringLength(9)]
        public string centreWorkingDay { get; set; }
        public DateTime centreOpeningHours { get; set; }
        public DateTime centreClosingHours { get; set; }
    }
}