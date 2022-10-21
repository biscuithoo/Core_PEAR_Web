using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NTU_FYP_PEAR_CORE_20.Models
{
	public class UserDeviceToken
    {
        [NotMapped]
        public static string TableName = "userDeviceToken";

        [Key]
        public int userDeviceTokenID { get; set; }

        [Required]
        [ForeignKey("ApplicationUser")]
        public string userID { get; set; }

        [JsonIgnore]
        public virtual ApplicationUser ApplicationUser { get; set; }

        [Required]
        [StringLength(256)]
        public string deviceToken { get; set; }
        public DateTime lastAccessedDate { get; set; } = DateTime.Now;
        public DateTime createdDateTime { get; set; } = DateTime.Now;
        public DateTime updatedDateTime { get; set; } = DateTime.Now;
    }
}