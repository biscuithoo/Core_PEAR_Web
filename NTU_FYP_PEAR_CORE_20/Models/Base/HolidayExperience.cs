using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace NTU_FYP_PEAR_CORE_20.Models
{
    public class HolidayExperience : Base
    {
        [NotMapped]
        public static string TableName = "holidayExperience";

        [Key]
        public int holidayExpID { get; set; }

        [ForeignKey("PatientAllocation")]
        public int patientAllocationID { get; set; }

        [JsonIgnore]
        public virtual PatientAllocation PatientAllocation { get; set; }

        [ForeignKey("List_Country")]
        public int countryListID { get; set; }

        //[JsonIgnore]
        public virtual List_Country List_Country { get; set; }

        [ForeignKey("AlbumPatient")]
        public int? albumPatientID { get; set; }

        [JsonIgnore]
        public virtual AlbumPatient AlbumPatient { get; set; }
        public DateTime? startDate { get; set; }
        public DateTime? endDate { get; set; }
    }
}