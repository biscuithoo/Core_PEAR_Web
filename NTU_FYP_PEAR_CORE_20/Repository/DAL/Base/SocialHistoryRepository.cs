using Microsoft.EntityFrameworkCore;
using NTU_FYP_PEAR_CORE_20.Data;
using NTU_FYP_PEAR_CORE_20.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NTU_FYP_PEAR_CORE_20.Repository.Base
{
    public class SocialHistoryRepository : BaseRepository<SocialHistory>
    {
        public SocialHistoryRepository(ApplicationDbContext context) : base(context) { }
        public SocialHistory Create(int patientAllocationID, bool sexuallyActive, bool secondhandSmoker, bool alcoholUse, bool caffeineUse, bool tobaccoUse, bool drugUse, bool exercise, int dietListID, int religionListID, int petListID, int occupationListID, int educationListID, int liveWithListID)
        {
            SocialHistory entity = new SocialHistory();
            entity.patientAllocationID = patientAllocationID;
            entity.sexuallyActive = sexuallyActive;
            entity.secondhandSmoker = secondhandSmoker;
            entity.alcoholUse = alcoholUse;
            entity.caffeineUse = caffeineUse;
            entity.tobaccoUse = tobaccoUse;
            entity.drugUse = drugUse;
            entity.exercise = exercise;
            entity.dietListID = dietListID;
            entity.religionListID = religionListID;
            entity.petListID = petListID;
            entity.occupationListID = occupationListID;
            entity.educationListID = educationListID;
            entity.liveWithListID = liveWithListID;
            return entity;
        }
        public SocialHistory CreateAdd(int patientAllocationID, bool sexuallyActive, bool secondhandSmoker, bool alcoholUse, bool caffeineUse, bool tobaccoUse, bool drugUse, bool exercise, int dietListID, int religionListID, int petListID, int occupationListID, int educationListID, int liveWithListID)
        {
            SocialHistory entity = Create(patientAllocationID, sexuallyActive, secondhandSmoker, alcoholUse, caffeineUse, tobaccoUse, drugUse, exercise, dietListID, religionListID, petListID, occupationListID, educationListID, liveWithListID);
            Add(entity);
            return entity;
        }
        public List<SocialHistory> GetAllPatientSH(int patientAID)
        {
            return GetAll().Where(i => i.patientAllocationID == patientAID && i.isDeleted != true).Include(i => i.List_Diet).Include(i => i.List_Religion).Include(i => i.List_Pet).Include(i => i.List_Occupation).Include(i => i.List_Education).Include(i => i.List_LiveWith).ToList();
        }
        public SocialHistory GetOnePatientSH(int patientAID, int? listID)
        {
            if(listID != null)
            {
                return GetAll().Include(i => i.List_Diet).Include(i => i.List_Religion).Include(i => i.List_Pet).Include(i => i.List_Occupation).Include(i => i.List_Education).Include(i => i.List_LiveWith).FirstOrDefault(i => i.patientAllocationID == patientAID && i.dietListID == listID && i.isDeleted != true);
            }
            else
            {
                return GetAll().Include(i => i.List_Diet).Include(i => i.List_Religion).Include(i => i.List_Pet).Include(i => i.List_Occupation).Include(i => i.List_Education).Include(i => i.List_LiveWith).FirstOrDefault(i => i.patientAllocationID == patientAID && i.isDeleted != true);
            }
        }
    }
}
