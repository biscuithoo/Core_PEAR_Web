using Microsoft.EntityFrameworkCore;
using NTU_FYP_PEAR_CORE_20.Data;
using NTU_FYP_PEAR_CORE_20.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NTU_FYP_PEAR_CORE_20.Repository.Base
{
    public class HabitRepository : BaseRepository<Habit>
    {
        public HabitRepository(ApplicationDbContext context) : base(context) { }
        public Habit Create(int patientAllocationID, int habitListID)
        {
            Habit entity = new Habit();
            entity.patientAllocationID = patientAllocationID;
            entity.habitListID = habitListID;
            return entity;
        }
        public Habit CreateAdd(int patientAllocationID, int habitListID)
        {
            Habit entity = Create(patientAllocationID, habitListID);
            Add(entity);
            return entity;
        }
        public List<Habit> GetAllPatientH(int patientAID)
        {
            return GetAll().Where(i => i.patientAllocationID == patientAID && i.isDeleted != true).Include(i => i.List_Habit).ToList();
        }
        public Habit GetOnePatientH(int patientAID, int listID)
        {
            return GetAll().Include(i => i.List_Habit).FirstOrDefault(i => i.patientAllocationID == patientAID && i.habitListID == listID && i.isDeleted != true);
        }
    }
}
