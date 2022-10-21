using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NTU_FYP_PEAR_CORE_20.Models
{
    public class List_Prescription : BaseList
    {
        [NotMapped]
        public static string TableName = "list_prescription";

        [Key]
        public int list_prescriptionID { get; set; }
    }
}