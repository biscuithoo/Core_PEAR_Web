using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NTU_FYP_PEAR_CORE_20.Models
{
	public class AdHoc : Base
    {
        [NotMapped]
        public static string TableName = "adHoc";

        [Key]
        public int adhocID { get; set; }

        [ForeignKey("PatientAllocation")]
        public int patientAllocationID { get; set; }

        [JsonIgnore]
        public virtual PatientAllocation PatientAllocation { get; set; }

        [ForeignKey("OldActivity")]
        public int? oldActivityID { get; set; }

        [JsonIgnore]
        public virtual Activities OldActivity { get; set; }

        [ForeignKey("NewActivity")]
        public int newActivityID { get; set; }

        [JsonIgnore]
        public virtual Activities NewActivity { get; set; }

        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public bool isActive { get; set; }
    }
}