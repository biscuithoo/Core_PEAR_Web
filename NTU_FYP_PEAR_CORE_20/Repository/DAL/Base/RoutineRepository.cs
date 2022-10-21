using Microsoft.EntityFrameworkCore;
using NTU_FYP_PEAR_CORE_20.Data;
using NTU_FYP_PEAR_CORE_20.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NTU_FYP_PEAR_CORE_20.Repository.Base
{
    public class RoutineRepository : Repository<Routine>
    {
        public RoutineRepository(ApplicationDbContext context) : base(context) { }
        public Routine Create(int patientAllocationID, int activityID, string routineIssues, bool includeInSchedule)
        {
            Routine entity = new Routine();
            entity.patientAllocationID = patientAllocationID;
            entity.activityID = activityID;
            entity.routineIssues = routineIssues;
            entity.includeInSchedule = includeInSchedule;
            return entity;
        }
        public Routine CreateAdd(int patientAllocationID, int activityID, string routineIssues, bool includeInSchedule)
        {
            Routine entity = Create(patientAllocationID, activityID, routineIssues, includeInSchedule);
            Add(entity);
            return entity;
        }
        public List<Routine> GetAllPatientR(int patientAID)
        {
            return GetAll().Where(i => i.patientAllocationID == patientAID).ToList();
        }
        public Routine GetOnePatientR(int patientAID, int listID)
        {
            return GetAll().FirstOrDefault(i => i.patientAllocationID == patientAID);
        }
    }
}
