using System.ComponentModel.DataAnnotations;

namespace NTU_FYP_PEAR_CORE_20.Data
{
    // handles data passed from profile page 
    public class UploadResult
    {
        [Key]
        public int Id { get; set; }
        public string UploadResultAsJson { get; set; }
    }
}
