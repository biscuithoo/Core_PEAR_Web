using Microsoft.EntityFrameworkCore;
using NTU_FYP_PEAR_CORE_20.Data;
using NTU_FYP_PEAR_CORE_20.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NTU_FYP_PEAR_CORE_20.Repository.Base
{
    public class PatientAssignedDementiaRepository : BaseRepository<PatientAssignedDementia>
    {
        public PatientAssignedDementiaRepository(ApplicationDbContext context) : base(context) { }
        public PatientAssignedDementia Create(int patientAllocationID, int dementiaTypeListID)
        {
            PatientAssignedDementia entity = new PatientAssignedDementia();
            entity.patientAllocationID = patientAllocationID;
            entity.dementiaTypeListID = dementiaTypeListID;
            return entity;
        }
        public PatientAssignedDementia CreateAdd(int patientAllocationID, int dementiaTypeListID)
        {
            PatientAssignedDementia entity = Create(patientAllocationID, dementiaTypeListID);
            Add(entity);
            return entity;
        }
        public List<PatientAssignedDementia> GetAllPatientPAD(int patientAID)
        {
            return GetAll().Where(i => i.patientAllocationID == patientAID && i.isDeleted != true).Include(i => i.List_DementiaType).ToList();
        }
        public PatientAssignedDementia GetOnePatientPAD(int patientAID, int listID)
        {
            return GetAll().Include(i => i.List_DementiaType).FirstOrDefault(i => i.patientAllocationID == patientAID && i.dementiaTypeListID == listID && i.isDeleted != true);
        }
    }
}
