using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NTU_FYP_PEAR_CORE_20.Models
{
    public class LogCategory
    {
        [NotMapped]
        public static string TableName = "logCategory";

        [Key]
        public int logCategoryID { get; set; }

        [Required]
        [StringLength(256)]
        public string logCategoryName { get; set; }

        [Required]
        [StringLength(256)]
        public string type { get; set; }
    }

}