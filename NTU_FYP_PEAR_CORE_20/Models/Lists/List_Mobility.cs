using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NTU_FYP_PEAR_CORE_20.Models
{
    public class List_Mobility : BaseList
    {
        [NotMapped]
        public static string TableName = "list_mobility";

        [Key]
        public int list_mobilityID { get; set; }
    }
}