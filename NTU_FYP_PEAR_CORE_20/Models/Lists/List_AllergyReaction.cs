using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NTU_FYP_PEAR_CORE_20.Models
{
    public class List_AllergyReaction : BaseList
    {
        [NotMapped]
        public static string TableName = "list_allergyReaction";

        [Key]
        public int list_allergyReactionID { get; set; }
    }
}
