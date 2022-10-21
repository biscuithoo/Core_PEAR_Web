using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NTU_FYP_PEAR_CORE_20.Models
{
    public class List_DementiaType : BaseList
    {
        [NotMapped]
        public static string TableName = "list_dementiaType";

        [Key]
        public int list_dementiaTypeID { get; set; }
    }
}