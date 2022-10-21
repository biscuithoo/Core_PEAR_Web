using NTU_FYP_PEAR_CORE_20.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NTU_FYP_PEAR_CORE_20.DTOs
{
    public class PatientPersonalPrefDTO
    {
        [Required]
        public int patientId;
        [Required]
        public string type;
        public int? listId;
        public string desc;
        public int? prefId;
        public string newType;
    }

    public class PatientPresonalPrefsDTO
    {
        public int patientId;
        public string name;
        public List<PPPLDHHDTO> likes;
        public List<PPPLDHHDTO> dislikes;
        //public List<PPPLDHHDTO> likeDislikes;
        public List<PPPLDHHDTO> habits;
        public List<PPPLDHHDTO> hobbies;
    }

    public class PPPLDHHDTO
    {
        public int prefId;
        public int listId;
        public string desc;
    }
}
