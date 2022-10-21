using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NTU_FYP_PEAR_CORE_20.Models
{
    public class List_Hobby : BaseList
    {
        [NotMapped]
        public static string TableName = "list_hobby";

        [Key]
        public int list_hobbyID { get; set; }
    }
}