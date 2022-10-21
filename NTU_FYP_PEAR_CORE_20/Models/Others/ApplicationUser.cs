using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using NTU_FYP_PEAR_CORE_20.Models.Others;

namespace NTU_FYP_PEAR_CORE_20.Models
{

    public class ApplicationUser : IdentityUser
    {
        [NotMapped]
        public static string TableName = "AspNetUsers";

        [Required]
        [StringLength(16)]
        public string firstName { get; set; }

        [Required]
        [StringLength(16)]
        public string lastName { get; set; }

        [Required]
        [StringLength(16)]
        public string preferredName { get; set; }

        [Required]
        [StringLength(9)]
        public string nric { get; set; }

        [Required]
        [StringLength(256)]
        public string address { get; set; }

        [Required]
        public DateTime DOB { get; set; }

        [Required]
        [StringLength(16)]
        public string gender { get; set; }

        [ForeignKey("secretQuestion")]
        public int secretQuestionListID { get; set; }

        [JsonIgnore]
        public virtual List_SecretQuestion secretQuestion { get; set; }

        [StringLength(256)]
        public string secretAnswer { get; set; }


        [ForeignKey("secretQuestion2")]
        public int secretQuestion2ListID { get; set; }

        [JsonIgnore]
        public virtual List_SecretQuestion secretQuestion2 { get; set; }
        [StringLength(256)]
        public string secretAnswer2 { get; set; }

        [StringLength(16)]
        public string secondContactNo { get; set; }

        public bool allowNotification { get; set; }

        [StringLength(256)]
        public string profilePicture { get; set; }

        [StringLength(256)]
        public string lockoutReason { get; set; }

        [StringLength(256)]
        public string token { get; set; }

        [Required]
        public DateTime lastPasswordChanged { get; set; }
        public DateTime loginTimeStamp { get; set; }
        public bool isActive { get; set; }
        public bool isDeleted { get; set; } = false;
        public DateTime createdDateTime { get; set; } = DateTime.Now;
        public DateTime updatedDateTime { get; set; } = DateTime.Now;

        public string roleId { get; set; }

        [JsonIgnore]
        public virtual IdentityRole Role { get; set; }

        public List<RefreshToken> RefreshTokens { get; set; }

    }
}