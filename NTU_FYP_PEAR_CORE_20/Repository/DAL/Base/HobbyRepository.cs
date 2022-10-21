using Microsoft.EntityFrameworkCore;
using NTU_FYP_PEAR_CORE_20.Data;
using NTU_FYP_PEAR_CORE_20.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NTU_FYP_PEAR_CORE_20.Repository.Base
{
    public class HobbyRepository : BaseRepository<Hobby>
    {
        public HobbyRepository(ApplicationDbContext context) : base(context) { }
        public Hobby Create(int patientAllocationID, int hobbyListID)
        {
            Hobby entity = new Hobby();
            entity.patientAllocationID = patientAllocationID;
            entity.hobbyListID = hobbyListID;
            return entity;
        }
        public Hobby CreateAdd(int patientAllocationID, int hobbyListID)
        {
            Hobby entity = Create(patientAllocationID, hobbyListID);
            Add(entity);
            return entity;
        }
        public List<Hobby> GetAllPatientH(int patientAID)
        {
            return GetAll().Where(i => i.patientAllocationID == patientAID && i.isDeleted != true).Include(i => i.List_Hobby).ToList();
        }
        public Hobby GetOnePatientH(int patientAID, int listID)
        {
            return GetAll().Include(i => i.List_Hobby).FirstOrDefault(i => i.patientAllocationID == patientAID && i.hobbyListID == listID && i.isDeleted != true);
        }
    }
}
