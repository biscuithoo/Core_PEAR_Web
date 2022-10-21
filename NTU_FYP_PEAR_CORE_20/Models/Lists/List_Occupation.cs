using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NTU_FYP_PEAR_CORE_20.Models
{
    public class List_Occupation : BaseList
    {
        [NotMapped]
        public static string TableName = "list_occupation";

        [Key]
        public int list_occupationID { get; set; }
    }
}