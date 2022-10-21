using NTU_FYP_PEAR_CORE_20.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NTU_FYP_PEAR_CORE_20.DTOs
{
    public class PatientDTO
    {
        [Required]
        public string nric;
        [Required]
        public string firstName;
        [Required]
        public string lastName;
        [Required]
        public string address;
        public string tempAddress;
        public string handphoneNo;
        public string preferredName;
        public string homeNo;
        public int preferredLanguageListID;
        [Required]
        public string gender;
        public string profilePicture;
        public bool? privacyBit;
        public bool? updateBit;
        public bool? autoGame;
        public bool? isActive;
        public bool? isRespiteCare;
        public string terminationReason;
        public string inactiveReason;
        public DateTime dob;
        public DateTime startDate;
        public DateTime? endDate;
        public DateTime? inactiveDate;

        // Guardian
        public string guardianName;
        public string guardianNRIC;
        public int guardianContactNo;
        public string guardianEmail;
        public string? guardianName2;
        public string? guardianNRIC2;
        public int? guardianContactNo2;
        public string? guardianEmail2;

        public int listOfAllergyID;
        public int listOfDementiaID;
        public string allergyRemarks;
        public string medDetails;
        public string medSourceDoc;
        public string medNotes;
        public DateTime medicalEstimatedDate;

        public int listOfMobilityID;
        public int listOfLiveWithID;
        public int listOfReligionID;
        public int listOfEducationID;
        public int listOfOccupationID;
        public int listOfPetID;
        public int listOfDietID;
        public int listOfAllergyReactionID;
        public int preferredLanguageID;
        public int guardianRelationshipID;
        public int guardian2RelationshipID;

        public bool isRetired;
        public bool isExercise;
        public bool caffeineUse;
        public bool tobaccoUse;
        public bool secondhandSmoker;
        public bool alcoholUse;
        public bool drugUse;
        public bool sexuallyActive;

        public int caregiverID;
        public int doctorID;
        public int gameTherapistID;
    }

    public class PatientsDTO
    {
        public string caregiverName;

        // Patient Information
        public int patientID;
        public string nric;
        public string firstName;
        public string lastName;
        public string preferredName;
        public int preferredLanguageListID;
        public string gender;
        public string profilePicture;
        public bool? isActive;
        public DateTime dob;
        public DateTime startDate;
        public DateTime? endDate;
        public string preferredLanguage;

        // Contact Information
        public string address;
        public string tempAddress;
        public string homeNo;
        public string handphoneNo;

        // Guardian Information
        public List<Guardian> guardianList;

        // Dementia Condition
        public List<PatientAssignedDementia> dementiaTypeList;

        // General Information
        public Mobility mobility;
        public SocialHistory socialHistory;

        // Allergies
        public List<Allergy> allergyList;

        // Medical History
        public List<MedicalHistory> medicalHistoryList;

        // Vital
        public List<Vital> vitalList;

        // Personal Preferences
        public List<LikeDislike> likeList;
        public List<LikeDislike> dislikeList;
        public List<Habit> habitList;
        public List<Hobby> hobbyList;

        // Routine
        public List<Routine> routineList;

        // For Manage Page
        public bool contentVisible;

        // For Inactive Patients
        public string inactiveReason;
        public DateTime? inactiveDate;
    }

    public class SocialHistoryDTO
    {
        [Required]
        public int patientAllocationID;

        public bool sexuallyActive;
        public bool secondhandSmoker;
        public bool alcoholUse;
        public bool caffeineUse;
        public bool tobaccoUse;
        public bool drugUse;
        public bool exercise;
    }

    public class GuardianDTO
    {
        [Required]
        public int guardianName;
        [Required]
        public string guardianNRIC;
        [Required]
        public int guardianRelationshipID;
        [Required]
        public string guardianEmail;
        [Required]
        public int guardianContactNo;
    }

    public class PatientAllocationDTO
    {
        [Required]
        public string doctorID;
        [Required]
        public string gameTherapistID;
        [Required]
        public int caregiverID;
        [Required]
        public string guardianID;
        [Required]
        public string supervisorID;
        public string? tempDoctorID;
        public int? guardian2ID;
        public string? tempCaregiverID;
    }

    public class PatientAssignedDementiaDTO
    {
        [Required]
        public int patientAllocationID;
        [Required]
        public int dementiaTypeListID;
    }
    public class AllergyDTO
    {
        [Required]
        public int patientAllocationID;
        [Required]
        public int allergyListID;
        [Required]
        public int allergyReactionListID;
        [Required]
        public string allergyRemarks;
    }
    public class DoctorNoteDTO
    {
        [Required]
        public int patientAllocationID;
        [Required]
        public string doctorID;
        [Required]
        public string doctorRemarks;
    }

}
