using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NTU_FYP_PEAR_CORE_20.Models
{
    public class List_SecretQuestion : BaseList
    {
        [NotMapped]
        public static string TableName = "list_secretQuestion";

        [Key]
        public int list_secretQuestionID { get; set; }

    }
}