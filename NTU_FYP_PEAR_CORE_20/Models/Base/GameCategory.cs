using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace NTU_FYP_PEAR_CORE_20.Models
{
    public class GameCategory : Base
    {
        [NotMapped]
        public static string TableName = "gameCategory";

        [Key]
        public int gameCategoryID { get; set; }

        [ForeignKey("List_GameCategory")]
        public int gameCategoryListID { get; set; }

        //[JsonIgnore]
        public virtual List_GameCategory GameCategoryList { get; set; }

        [ForeignKey("Game")]
        public int gameID { get; set; }

        [JsonIgnore]
        public virtual Game Game { get; set; }
    }
}