using Microsoft.EntityFrameworkCore;
using NTU_FYP_PEAR_CORE_20.Data;
using NTU_FYP_PEAR_CORE_20.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NTU_FYP_PEAR_CORE_20.Repository.Base
{
    public class AllergyRepository : BaseRepository<Allergy>
    {
        public AllergyRepository(ApplicationDbContext context) : base(context) { }
        public Allergy Create(int patientAllocationID, int allergyListID, int allergyReactionListID, string allergyRemarks)
        {
            Allergy entity = new Allergy();
            entity.patientAllocationID = patientAllocationID;
            entity.allergyListID = allergyListID;
            entity.allergyReactionListID = allergyReactionListID;
            entity.allergyRemarks = allergyRemarks;
            return entity;
        }
        public Allergy CreateAdd(int patientAllocationID, int allergyListID, int allergyReactionListID, string allergyRemarks)
        {
            Allergy entity = Create(patientAllocationID, allergyListID, allergyReactionListID, allergyRemarks);
            Add(entity);
            return entity;
        }
        public List<Allergy> GetAllPatientA(int patientAID)
        {
            return GetAll().Where(i => i.patientAllocationID == patientAID && i.isDeleted != true).Include(i => i.List_Allergy).ToList();
        }
        public Allergy GetOnePatientA(int patientAID, int? listID)
        {
            if(listID != 0 || listID != null)
            {
                return GetAll().Include(i => i.List_Allergy).FirstOrDefault(i => i.patientAllocationID == patientAID && i.allergyListID == listID && i.isDeleted != true);
            }
            else
            {
                return GetAll().Include(i => i.List_Allergy).FirstOrDefault(i => i.patientAllocationID == patientAID && i.isDeleted != true);
            }
        }
    }
}
