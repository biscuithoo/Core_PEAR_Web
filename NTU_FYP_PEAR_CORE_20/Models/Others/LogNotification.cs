using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace NTU_FYP_PEAR_CORE_20.Models
{
    public class LogNotification
    {
        [NotMapped]
        public static string TableName = "logNotification";

        [Key]
        public int logNotificationID { get; set; }

        [ForeignKey("Log")]
        public int logID { get; set; }

        [JsonIgnore]
        public virtual Log Log { get; set; }

        [Required]
        [ForeignKey("IdentityRole")]
        public string intendedUserType { get; set; }

        [JsonIgnore]
        public virtual IdentityRole IdentityRole { get; set; }

        [ForeignKey("IntendedUser")]
        public string intendedUserID { get; set; }

        [JsonIgnore]
        public virtual ApplicationUser IntendedUser { get; set; }

        public string step { get; set; }
        public bool readStatus { get; set; }
        public string message { get; set; }
        public DateTime createdDateTime { get; set; } = DateTime.Now;
        public DateTime updatedDateTime { get; set; } = DateTime.Now;
    }
}