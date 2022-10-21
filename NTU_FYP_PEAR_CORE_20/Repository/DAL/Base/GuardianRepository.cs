using NTU_FYP_PEAR_CORE_20.Data;
using NTU_FYP_PEAR_CORE_20.Models;
using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace NTU_FYP_PEAR_CORE_20.Repository
{
    public class GuardianRepository : BaseRepository<Guardian>
    {
        public GuardianRepository(ApplicationDbContext context) : base(context) { }

        public Guardian GetPatientGuardian(int guardianID)
        {
            return GetAll().Where(i => i.isDeleted != true && i.guardianID == guardianID).Include(i => i.List_Relationship).SingleOrDefault();
        }

        public bool CheckGuardianNRICExist(string guardianNRIC)
        {
            Guardian g = GetAll().Where(i => i.isDeleted != true && i.guardianNRIC == guardianNRIC).SingleOrDefault();

            if(g == null)
            {
                return false;
            }

            return true;
        }

        public Guardian Create(string guardianName, string guardianContactNo, string guardianNRIC, string guardianEmail, int guardianRelationshipID)
        {
            Guardian entity = new Guardian();
            return entity;
        }

        public Guardian CreateAdd(string guardianName, string guardianContactNo, string guardianNRIC, string guardianEmail, int guardianRelationshipID)
        {
            Guardian entity = Create(guardianName, guardianContactNo, guardianNRIC, guardianEmail, guardianRelationshipID);
            Add(entity);
            return entity;
        }

        

    }
}
