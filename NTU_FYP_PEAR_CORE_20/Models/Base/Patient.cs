using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace NTU_FYP_PEAR_CORE_20.Models
{
    public class Patient : Base
    {
        [NotMapped]
        public static string TableName = "patient";

        [Key]
        public int patientID { get; set; }

        [Required]
        [StringLength(256)]
        public string firstName { get; set; }

        [Required]
        [StringLength(256)]
        public string lastName { get; set; }

        [Required]
        [StringLength(9)]
        public string nric { get; set; }
        public string address { get; set; }
        public string tempAddress { get; set; }

        [StringLength(32)]
        public string homeNo { get; set; }

        [StringLength(32)]
        public string handphoneNo { get; set; }

        [Required]
        [StringLength(1)]
        public string gender { get; set; }
        public DateTime DOB { get; set; }

        [StringLength(256)]
        public string preferredName { get; set; }

        [ForeignKey("List_Language")]
        public int preferredLanguageListID { get; set; }

        //[JsonIgnore]
        public virtual List_Language PreferredLanguageList { get; set; }

        public bool privacyBit { get; set; } = false;
        public bool updateBit { get; set; } = true;
        public bool autoGame { get; set; } = false;
        public DateTime startDate { get; set; }
        public DateTime? endDate { get; set; }
        public string terminationReason { get; set; }
        public bool isActive { get; set; } = true;
        public string inactiveReason { get; set; }
        public DateTime? inactiveDate { get; set; }
        public bool isRespiteCare { get; set; }
        public string profilePicture { get; set; }

        [JsonIgnore]
        public virtual PatientAllocation PatientAllocation { get; set; }
    }
}