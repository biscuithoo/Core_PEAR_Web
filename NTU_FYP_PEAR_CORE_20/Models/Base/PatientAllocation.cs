using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NTU_FYP_PEAR_CORE_20.Models
{
    public class PatientAllocation : Base
    {
        [NotMapped]
        public static string TableName = "patientAllocation";

        [Key]
        public int patientAllocationID { get; set; }

        [ForeignKey("Patient")]
        public int patientID { get; set; }

        [JsonIgnore]
        public Patient Patient { get; set; }

        [Required]
        [ForeignKey("Doctor")]
        public string doctorID { get; set; }

        [JsonIgnore]
        public ApplicationUser Doctor { get; set; }

        [Required]
        [ForeignKey("Gametherapist")]
        public string gametherapistID { get; set; }

        [JsonIgnore]
        public ApplicationUser GameTherapist { get; set; }

        [Required]
        [ForeignKey("Supervisor")]
        public string supervisorID { get; set; }

        [JsonIgnore]
        public ApplicationUser Supervisor { get; set; }

        [Required]
        [ForeignKey("Caregiver")]
        public string caregiverID { get; set; }

        [JsonIgnore]
        public ApplicationUser Caregiver { get; set; }

        [Required]
        [ForeignKey("Guardian")]
        public int guardianID { get; set; }

        [JsonIgnore]
        public Guardian Guardian { get; set; }

        [ForeignKey("tempDoctor")]
        public string tempDoctorID { get; set; }

        [JsonIgnore]
        public ApplicationUser tempDoctor { get; set; }

        [ForeignKey("tempCaregiver")]
        public string tempCaregiverID { get; set; }

        [JsonIgnore]
        public ApplicationUser tempCaregiver { get; set; }

        [ForeignKey("Guardian2")]
        public int? guardian2ID { get; set; }

        [JsonIgnore]
        public Guardian Guardian2 { get; set; }

    }
}