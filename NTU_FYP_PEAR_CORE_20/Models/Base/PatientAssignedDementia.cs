using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace NTU_FYP_PEAR_CORE_20.Models
{
    public class PatientAssignedDementia : Base
    {
        [NotMapped]
        public static string TableName = "patientAssignedDementia";

        [Key]
        public int padID { get; set; }

        [ForeignKey("PatientAllocation")]
        public int patientAllocationID { get; set; }

        [JsonIgnore]
        public virtual PatientAllocation PatientAllocation { get; set; }

        [ForeignKey("List_DementiaType")]
        public int dementiaTypeListID { get; set; }

        //[JsonIgnore]
        public virtual List_DementiaType List_DementiaType { get; set; }
    }
}