using Microsoft.EntityFrameworkCore;
using NTU_FYP_PEAR_CORE_20.Data;
using NTU_FYP_PEAR_CORE_20.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NTU_FYP_PEAR_CORE_20.Repository.Base
{
    public class MobilityRepository : BaseRepository<Mobility>
    {
        public MobilityRepository(ApplicationDbContext context) : base(context) { }
        public Mobility Create(int patientAllocationID, int mobilityListID)
        {
            Mobility entity = new Mobility();
            entity.patientAllocationID = patientAllocationID;
            entity.mobilityListID = mobilityListID;
            return entity;
        }
        public Mobility CreateAdd(int patientAllocationID, int mobilityListID)
        {
            Mobility entity = Create(patientAllocationID, mobilityListID);
            Add(entity);
            return entity;
        }
        public List<Mobility> GetAllPatientM(int patientAID)
        {
            return GetAll().Where(i => i.patientAllocationID == patientAID && i.isDeleted != true).Include(i => i.List_Mobility).ToList();
        }
        public Mobility GetOnePatientM(int patientAID, int? listID)
        {
            if (listID != null)
            {
                return GetAll().Include(i => i.List_Mobility).FirstOrDefault(i => i.patientAllocationID == patientAID && i.mobilityListID == listID && i.isDeleted != true);
            }
            else
            {
                return GetAll().Include(i => i.List_Mobility).FirstOrDefault(i => i.patientAllocationID == patientAID && i.isDeleted != true);
            }

        }
    }
}
