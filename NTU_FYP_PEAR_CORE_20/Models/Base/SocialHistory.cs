using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace NTU_FYP_PEAR_CORE_20.Models
{
    public class SocialHistory : Base
    {
        [NotMapped]
        public static string TableName = "socialHistory";

        [Key]
		public int socialHistoryID { get; set; }

        [ForeignKey("PatientAllocation")]
        public int patientAllocationID { get; set; }

        [JsonIgnore]
        public virtual PatientAllocation PatientAllocation { get; set; }

        public bool? sexuallyActive { get; set; }
        public bool? secondhandSmoker { get; set; }
        public bool? alcoholUse { get; set; }
        public bool? caffeineUse { get; set; }
        public bool? tobaccoUse { get; set; }
        public bool? drugUse { get; set; }
        public bool? exercise { get; set; }

        [ForeignKey("List_Diet")]
        public int? dietListID { get; set; }

        //[JsonIgnore]
        public virtual List_Diet List_Diet { get; set; }

        [ForeignKey("List_Religion")]
        public int? religionListID { get; set; }

        //[JsonIgnore]
        public virtual List_Religion List_Religion { get; set; }

        [ForeignKey("List_Pet")]
        public int? petListID { get; set; }

        //[JsonIgnore]
        public virtual List_Pet List_Pet { get; set; }

        [ForeignKey("List_Occupation")]
        public int? occupationListID { get; set; }

        //[JsonIgnore]
        public virtual List_Occupation List_Occupation { get; set; }

        [ForeignKey("List_Education")]
        public int? educationListID { get; set; }

        //[JsonIgnore]
        public virtual List_Education List_Education { get; set; }

        [ForeignKey("List_LiveWith")]
        public int? liveWithListID { get; set; }

        //[JsonIgnore]
        public virtual List_LiveWith List_LiveWith { get; set; }

    }
}