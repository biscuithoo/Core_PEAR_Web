using Microsoft.EntityFrameworkCore;
using NTU_FYP_PEAR_CORE_20.Data;
using NTU_FYP_PEAR_CORE_20.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NTU_FYP_PEAR_CORE_20.Repository.Base
{
    public class MedicalHistoryRepository : BaseRepository<MedicalHistory>
    {
        public MedicalHistoryRepository(ApplicationDbContext context) : base(context) { }
        public MedicalHistory Create(int patientAllocationID, string medicalDetails, string informationSource, string medicalRemarks, DateTime medicalEstimatedDate)
        {
            MedicalHistory entity = new MedicalHistory();
            entity.patientAllocationID = patientAllocationID;
            entity.medicalDetails = medicalDetails;
            entity.informationSource = informationSource;
            entity.medicalRemarks = medicalRemarks;
            entity.medicalEstimatedDate = medicalEstimatedDate;
            return entity;
        }
        public MedicalHistory CreateAdd(int patientAllocationID, string medicalDetails, string informationSource, string medicalRemarks, DateTime medicalEstimatedDate)
        {
            MedicalHistory entity = Create(patientAllocationID, medicalDetails, informationSource, medicalRemarks, medicalEstimatedDate);
            Add(entity);
            return entity;
        }
        public List<MedicalHistory> GetAllPatientMH(int patientAID)
        {
            return GetAll().Where(i => i.patientAllocationID == patientAID && i.isDeleted != true).ToList();
        }
        public MedicalHistory GetOnePatientMH(int patientAID)
        {
            return GetAll().FirstOrDefault(i => i.patientAllocationID == patientAID && i.isDeleted != true);
        }
    }
}
