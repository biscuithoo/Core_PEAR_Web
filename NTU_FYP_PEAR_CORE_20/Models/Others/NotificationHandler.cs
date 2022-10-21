using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NTU_FYP_PEAR_CORE_20.Models
{
    public class NotificationHandler
    {
        [NotMapped]
        public static string TableName = "notificationHandler";

        [Key]
        public int notificationHandlerID { get; set; }
        public int scenario { get; set; }
        public int maxNoOfSteps { get; set; }
        public string step { get; set; }
        public string senderTypeID { get; set; }
        public string intendedUserType { get; set; }
        public string responseRequired { get; set; }
        public string responseOptions { get; set; }
        public string nextStep { get; set; }
        public string message { get; set; }
    }
}
