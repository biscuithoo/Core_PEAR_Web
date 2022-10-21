
using System.ComponentModel.DataAnnotations;

namespace NTU_FYP_PEAR_CORE_20.Models
{
    public class CreateRoleViewModel
    {

        [Required]
        public string RoleName { get; set; }

        public string From { get; set; }
    }
}