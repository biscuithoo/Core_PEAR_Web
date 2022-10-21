using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace NTU_FYP_PEAR_CORE_20.Models
{
    public class Guardian : Base
    {
        [NotMapped]
        public static string TableName = "guardian";

        [Key]
        public int guardianID { get; set; }

        [Required]
        [StringLength(32)]
        public string guardianName { get; set; }

        [Required]
        [StringLength(16)]
        public string guardianContactNo { get; set; }

        [Required]
        [StringLength(9)]
        public string guardianNRIC { get; set; }

        [Required]
        [StringLength(256)]
        public string guardianEmail { get; set; }

        [Required]
        [ForeignKey("List_Relationship")]
        public int guardianRelationshipID { get; set; }

        //[JsonIgnore]
        public virtual List_Relationship List_Relationship { get; set; }

        public bool isActive { get; set; }
    }
}