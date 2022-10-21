using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NTU_FYP_PEAR_CORE_20.Models
{
    public class PrivacySetting
    {
        [NotMapped]
        public static string TableName = "privacySetting";

        [Key]
        public int privacySettingID { get; set; }

        [Required]
        [StringLength(256)]
        public string socialHistoryItem { get; set; }

        public bool isSensitive { get; set; } = true;
        public DateTime createdDateTime { get; set; } = DateTime.Now;
        public DateTime updatedDateTime { get; set; } = DateTime.Now;
    }
}