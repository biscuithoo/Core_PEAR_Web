using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NTU_FYP_PEAR_CORE_20.Models
{
    public class LikeDislike : Base
    {
        [NotMapped]
        public static string TableName = "likeDislike";

        [Key]
        public int likeDislikeID { get; set; }

        [ForeignKey("PatientAllocation")]
        public int patientAllocationID { get; set; }

        [JsonIgnore]
        public virtual PatientAllocation PatientAllocation { get; set; }

        [ForeignKey("List_LikeDislike")]
        public int likeDislikeListID { get; set; }

        //[JsonIgnore]
        public virtual List_LikeDislike List_LikeDislike { get; set; }
        public bool isLike { get; set; }

        [JsonIgnore]
        [NotMapped]
        public string IsLike
        {
            get { return isLike ? "Like" : "Dislike"; }
            set { isLike = (value == "Like") ? true : false; }
        }
    }
}