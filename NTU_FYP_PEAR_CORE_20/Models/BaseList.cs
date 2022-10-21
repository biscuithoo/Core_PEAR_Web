using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NTU_FYP_PEAR_CORE_20.Models
{
    /*
     * For List_xxx Models
     */
    public abstract class BaseList : Base
    {
        [Required]
        [StringLength(256)]
        public string value { get; set; }
    }
}
