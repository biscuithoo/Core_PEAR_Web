using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace NTU_FYP_PEAR_CORE_20.Models
{
    public class HighlightType : Base
    {
        [NotMapped]
        public static string TableName = "highlightType";

        [Key]
        public int highlightTypeID { get; set; }

        [Required]
        [StringLength(32)]
        public string highlightType { get; set; }
    }
}