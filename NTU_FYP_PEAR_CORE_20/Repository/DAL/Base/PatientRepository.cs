using Microsoft.EntityFrameworkCore;
using NTU_FYP_PEAR_CORE_20.Data;
using NTU_FYP_PEAR_CORE_20.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NTU_FYP_PEAR_CORE_20.Repository
{
    public class PatientRepository : BaseRepository<Patient>
    {
        public PatientRepository(ApplicationDbContext context) : base(context) { }

        public List<Patient> GetActivePatients()
        {
            return GetAll().Where(i => i.isDeleted != true && i.isActive == true).Include(i => i.PatientAllocation).Include(i => i.PreferredLanguageList).ToList();
        }

        public List<Patient> GetInactivePatients()
        {
            return GetAll().Where(i => i.isDeleted != true && i.isActive == false).Include(i => i.PatientAllocation).Include(i => i.PreferredLanguageList).ToList();
        }

        public Patient GetSelectedPatient(int patientID)
        {
            return GetAll().Where(i => i.isDeleted != true && i.patientID == patientID).Include(i => i.PatientAllocation).Include(i => i.PreferredLanguageList).SingleOrDefault();
        }

        public Patient Create(string firstName, string lastName, string nric, string address, string tempAddress, string homeNo, string handphoneNo, string gender, DateTime dob, string preferredName, int preferredLanguageListID, DateTime startDate, DateTime endDate, bool isRespiteCare, string profilePicture)
        {
            Patient newPatient = new Patient();
            newPatient.firstName = firstName;
            newPatient.lastName = lastName;
            newPatient.nric = nric;
            newPatient.address = address;
            newPatient.tempAddress = tempAddress;
            newPatient.homeNo = homeNo;
            newPatient.handphoneNo = handphoneNo;
            newPatient.gender = gender;
            newPatient.DOB = dob;
            newPatient.preferredName = preferredName;
            newPatient.preferredLanguageListID = preferredLanguageListID;
            newPatient.privacyBit = false;
            newPatient.updateBit = true;
            newPatient.autoGame = false;
            newPatient.startDate = startDate;
            newPatient.endDate = endDate;
            newPatient.terminationReason = null;
            newPatient.isActive = true;
            newPatient.inactiveReason = null;
            newPatient.inactiveDate = null;
            newPatient.isRespiteCare = isRespiteCare;
            newPatient.profilePicture = profilePicture;
            newPatient.isDeleted = false;
            newPatient.createdDateTime = DateTime.Now;
            newPatient.updatedDateTime = DateTime.Now;
            return newPatient;
        }

        public Patient CreateAdd(string firstName, string lastName, string nric, string address, string tempAddress, string homeNo, string handphoneNo, string gender, DateTime dob, string preferredName, int preferredLanguageListID, DateTime startDate, DateTime endDate, bool isRespiteCare, string profilePicture)
        {
            Patient newPatient = Create(firstName, lastName, nric, address, tempAddress, homeNo, handphoneNo, gender, dob, preferredName, preferredLanguageListID, startDate, endDate, isRespiteCare, profilePicture);
            Add(newPatient);
            return newPatient;
        }

    }
}
