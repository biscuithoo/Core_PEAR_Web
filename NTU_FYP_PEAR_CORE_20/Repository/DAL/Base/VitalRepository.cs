using Microsoft.EntityFrameworkCore;
using NTU_FYP_PEAR_CORE_20.Data;
using NTU_FYP_PEAR_CORE_20.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NTU_FYP_PEAR_CORE_20.Repository.Base
{
    public class VitalRepository : BaseRepository<Vital>
    {
        public VitalRepository(ApplicationDbContext context) : base(context) { }
        public Vital Create(int patientAllocationID, int afterMeal, decimal temperature, int systolicBP, int diastolicBP, int heartRate, int spO2, int bloodSugarlevel, int height, int weight, string vitalRemarks)
        {
            Vital entity = new Vital();
            entity.patientAllocationID = patientAllocationID;
            entity.afterMeal = afterMeal;
            entity.temperature = temperature;
            entity.systolicBP = systolicBP;
            entity.diastolicBP = diastolicBP;
            entity.heartRate = heartRate;
            entity.spO2 = spO2;
            entity.bloodSugarlevel = bloodSugarlevel;
            entity.height = height;
            entity.weight = weight;
            entity.vitalRemarks = vitalRemarks;
            return entity;
        }
        public Vital CreateAdd(int patientAllocationID, int afterMeal, decimal temperature, int systolicBP, int diastolicBP, int heartRate, int spO2, int bloodSugarlevel, int height, int weight, string vitalRemarks)
        {
            Vital entity = Create(patientAllocationID, afterMeal, temperature, systolicBP, diastolicBP, heartRate, spO2, bloodSugarlevel, height, weight, vitalRemarks);
            Add(entity);
            return entity;
        }
        public List<Vital> GetAllPatientV(int patientAID)
        {
            return GetAll().Where(i => i.patientAllocationID == patientAID && i.isDeleted != true).ToList();
        }
        public Vital GetOnePatientV(int patientAID)
        {
            return GetAll().FirstOrDefault(i => i.patientAllocationID == patientAID && i.isDeleted != true);
        }
    }
}
