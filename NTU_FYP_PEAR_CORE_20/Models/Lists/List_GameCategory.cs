using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NTU_FYP_PEAR_CORE_20.Models
{
    public class List_GameCategory : BaseList
    {
        [NotMapped]
        public static string TableName = "list_gameCategory";

        [Key]
        public int list_gameCategoryID { get; set; }
    }
}