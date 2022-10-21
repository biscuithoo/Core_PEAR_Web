using NTU_FYP_PEAR_CORE_20.Data;
using NTU_FYP_PEAR_CORE_20.Models;
using System;
using System.Linq;

namespace NTU_FYP_PEAR_CORE_20.Repository
{
    public class PatientAllocationRepository : BaseRepository<PatientAllocation>
    {
        public PatientAllocationRepository(ApplicationDbContext context) : base(context) { }

        public PatientAllocation Create(int patientID, string doctorID, string gametherapistID, string supervisorID, string caregiverID, int guardianID, string tempDoctorID, string tempCaregiverID, int? guardian2ID)
        {
            PatientAllocation entity = new PatientAllocation();
            entity.patientID = patientID;
            entity.doctorID = doctorID;
            entity.gametherapistID = gametherapistID;
            entity.supervisorID = supervisorID;
            entity.caregiverID = caregiverID;
            entity.guardianID = guardianID;
            entity.tempDoctorID = tempDoctorID;
            entity.tempCaregiverID = tempCaregiverID;
            entity.guardian2ID = guardian2ID;
            return entity;
        }

        public PatientAllocation CreateAdd(int patientID, string doctorID, string gametherapistID, string supervisorID, string caregiverID, int guardianID, string tempDoctorID, string tempCaregiverID, int? guardian2ID)
        {
            PatientAllocation entity = Create(patientID, doctorID, gametherapistID, supervisorID, caregiverID, guardianID, tempDoctorID, tempCaregiverID, guardian2ID);
            Add(entity);
            return entity;
        }

        public PatientAllocation getByPatientID(int patientID)
        {
            return GetAll().FirstOrDefault(x => x.patientID == patientID);
        }

        public string getSupervisorID(int patientAID)
        {
            return GetById(patientAID).supervisorID;
        }
    }
}
