using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace NTU_FYP_PEAR_CORE_20.Models
{
    public class Habit : Base
    {
        [NotMapped]
        public static string TableName = "habit";

        [Key]
        public int habitID { get; set; }

        [ForeignKey("PatientAllocation")]
        public int patientAllocationID { get; set; }

        [JsonIgnore]
        public virtual PatientAllocation PatientAllocation { get; set; }

        [ForeignKey("List_Habit")]
        public int habitListID { get; set; }

        //[JsonIgnore]
        public virtual List_Habit List_Habit { get; set; }
    }
}