using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NTU_FYP_PEAR_CORE_20.Models
{
    public class AlbumPatient : Base
    {
        [NotMapped]
        public static string TableName = "albumPatient";

        [Key]
        public int albumPatientID { get; set; }
        public string albumPath { get; set; }

        [StringLength(256)]
        public string albumDetails { get; set; }

        [ForeignKey("List_AlbumCategory")]
        public int albumCategoryListID { get; set; }

        //[JsonIgnore]
        public virtual List_AlbumCategory AlbumCategoryList { get; set; }

        [ForeignKey("PatientAllocation")]
        public int patientAllocationID { get; set; }

        [JsonIgnore]
        public virtual PatientAllocation PatientAllocation { get; set; }


    }
}