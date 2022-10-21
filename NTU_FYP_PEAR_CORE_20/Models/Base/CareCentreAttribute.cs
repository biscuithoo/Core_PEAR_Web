using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace NTU_FYP_PEAR_CORE_20.Models
{
    public class CareCentreAttribute : Base
    {
        [NotMapped]
        public static string TableName = "careCentreAttribute";

        [Key]
        public int centreID { get; set; }

        [Required]
        [StringLength(256)]
        public string centreName { get; set; }

        [ForeignKey("Country")]
        public int countryListID { get; set; }

        //[JsonIgnore]
        public virtual List_Country Country { get; set; }

        [Required]
        public string centreAddress { get; set; }

        [Required]
        [StringLength(16)]
        public string centrePostalCode { get; set; }

        [Required]
        [StringLength(16)]
        public string centreContactNo { get; set; }

        [Required]
        [StringLength(256)]
        public string centreEmail { get; set; }
        public int devicesAvailable { get; set; }
    }
}