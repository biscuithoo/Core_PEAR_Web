using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace NTU_FYP_PEAR_CORE_20.Models
{
    public class Hobby : Base
    {
        [NotMapped]
        public static string TableName = "hobby";

        [Key]
        public int hobbyID { get; set; }

        [ForeignKey("PatientAllocation")]
        public int patientAllocationID { get; set; }

        [JsonIgnore]
        public virtual PatientAllocation PatientAllocation { get; set; }

        [ForeignKey("List_Hobby")]
        public int hobbyListID { get; set; }

        //[JsonIgnore]
        public virtual List_Hobby List_Hobby { get; set; }
    }
}