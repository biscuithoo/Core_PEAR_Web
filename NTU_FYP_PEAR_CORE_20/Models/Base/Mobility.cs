using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using System.Linq;
using System.Web;

namespace NTU_FYP_PEAR_CORE_20.Models
{
    public class Mobility : Base
    {
        [NotMapped]
        public static string TableName = "mobility";

        [Key]
        public int mobilityID { get; set; }

        [ForeignKey("PatientAllocation")]
        public int patientAllocationID { get; set; }

        [JsonIgnore]
        public virtual PatientAllocation PatientAllocation { get; set; }

        [ForeignKey("List_Mobility")]
        public int mobilityListID { get; set; }

        //[JsonIgnore]
        public virtual List_Mobility List_Mobility { get; set; }
    }
}