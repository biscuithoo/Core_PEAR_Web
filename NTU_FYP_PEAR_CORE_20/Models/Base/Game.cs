using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NTU_FYP_PEAR_CORE_20.Models
{
    public class Game : Base
    {
        [NotMapped]
        public static string TableName = "game";

        [Key]
        public int gameID { get; set; }

        [StringLength(256)]
        public string gameName { get; set; }

        [StringLength(256)]
        public string gameDesc { get; set; }

        [StringLength(256)]
        public string gameCreatedBy { get; set; }

        [StringLength(256)]
        public string manifest { get; set; }
        public int? duration { get; set; }
        public int? rating { get; set; }

        [StringLength(64)]
        public string difficulty { get; set; }
    }
}