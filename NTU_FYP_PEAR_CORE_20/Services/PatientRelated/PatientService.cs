using NTU_FYP_PEAR_CORE_20.Models;
using System;
using NTU_FYP_PEAR_CORE_20.Repository;
using System.Collections.Generic;
using NTU_FYP_PEAR_CORE_20.Data;
using NTU_FYP_PEAR_CORE_20.Repository.Base;
using NTU_FYP_PEAR_CORE_20.DTOs;

namespace NTU_FYP_PEAR_CORE_20.Services
{
    /*
     * Service classes perform business logic and reused by both Controllers and API Controllers. 
     * Service classes use Repository methods
     * 
     * Patient Related Business Logic
     * Seperate into another Service if Functionality is complicated/huge
     */
    public class PatientService
    {
        // Repository
        private readonly PatientRepository patientRepo;
        private readonly PatientAssignedDementiaRepository padRepo;
        private readonly MobilityRepository mobilityRepo;
        private readonly SocialHistoryRepository socialHistoryRepo;
        private readonly AllergyRepository allergyRepo;
        private readonly MedicalHistoryRepository medicalHistoryRepo;
        private readonly VitalRepository vitalRepo;
        private readonly LikeDislikeRepository likeDislikeRepository;
        private readonly RoutineRepository routineRepository;
        private readonly GuardianRepository guardianRepo;
        private readonly HabitRepository habitRepo;
        private readonly HobbyRepository hobbyRepo;
        private readonly PatientAllocationRepository patientAllocationRepo;

        // Services
        private readonly OtherService otherService;
        private readonly UserService userService;

        public PatientService(OtherService os, UserService us, PatientRepository pr, GuardianRepository gr, PatientAllocationRepository par, PatientAssignedDementiaRepository padr, MobilityRepository mr, SocialHistoryRepository shr, AllergyRepository ar, MedicalHistoryRepository mhr, VitalRepository vr, LikeDislikeRepository ldr, RoutineRepository rr, HabitRepository hr, HobbyRepository hbr)
        {
            this.otherService = os;
            this.userService = us;
            this.patientRepo = pr;
            this.guardianRepo = gr;
            this.patientAllocationRepo = par;
            this.padRepo = padr;
            this.mobilityRepo = mr;
            this.socialHistoryRepo = shr;
            this.allergyRepo = ar;
            this.medicalHistoryRepo = mhr;
            this.vitalRepo = vr;
            this.likeDislikeRepository = ldr;
            this.routineRepository = rr;
            this.habitRepo = hr;
            this.hobbyRepo = hbr;
        }

        // Get All Active Patients
        public List<PatientsDTO> GetPatientInfo(bool isActive)
        {

            List<PatientsDTO> pdtoList = new List<PatientsDTO>();

            if (isActive)
            {
                List<Patient> patients = patientRepo.GetActivePatients();

                foreach (var a in patients)
                {
                    PatientsDTO pdto = new PatientsDTO();
                    pdto.patientID = a.patientID;
                    var patient = patientRepo.GetSelectedPatient(a.patientID);
                    if (patient == null) return null;
                    int patientAllocationID = patient.PatientAllocation.patientAllocationID;

                    // Personal Information
                    if (patient.PatientAllocation.Caregiver != null)
                    {
                        pdto.caregiverName = patient.PatientAllocation.Caregiver.firstName + " " + patient.PatientAllocation.Caregiver.lastName;
                    }
                    else
                    {
                        pdto.caregiverName = "Adeline Tan"; //todo
                    }

                    pdto.nric = a.nric;
                    pdto.gender = a.gender;
                    pdto.firstName = a.firstName;
                    pdto.lastName = a.lastName;
                    pdto.preferredName = a.preferredName;
                    pdto.profilePicture = a.profilePicture;
                    pdto.dob = a.DOB;
                    pdto.startDate = a.startDate;
                    pdto.endDate = a.endDate;
                    pdto.preferredLanguage = patient.PreferredLanguageList.value;

                    // Contact Information
                    pdto.address = a.address;
                    pdto.tempAddress = a.tempAddress;
                    pdto.homeNo = a.homeNo;
                    pdto.handphoneNo = a.handphoneNo;

                    // Guardian Information
                    var guardian1 = guardianRepo.GetPatientGuardian(patient.PatientAllocation.guardianID);
                    if (guardian1 != null)
                    {
                        pdto.guardianList = new List<Guardian>();
                        pdto.guardianList.Add(guardian1);
                    }

                    if (patient.PatientAllocation.guardian2ID != null)
                    {
                        var guardian2 = guardianRepo.GetPatientGuardian((int)patient.PatientAllocation.guardian2ID);
                        pdto.guardianList.Add(guardian2);
                    }

                    // Dementia Condition
                    pdto.dementiaTypeList = padRepo.GetAllPatientPAD(patientAllocationID);

                    // General Information
                    pdto.mobility = mobilityRepo.GetOnePatientM(patientAllocationID, null);
                    pdto.socialHistory = socialHistoryRepo.GetOnePatientSH(patientAllocationID, null);

                    // Allergies
                    pdto.allergyList = allergyRepo.GetAllPatientA(patientAllocationID);

                    // Medical History
                    pdto.medicalHistoryList = medicalHistoryRepo.GetAllPatientMH(patientAllocationID);

                    // Vital
                    pdto.vitalList = vitalRepo.GetAllPatientV(patientAllocationID);

                    // Personal Preferences
                    pdto.likeList = likeDislikeRepository.GetPatientLD(patientAllocationID, true);
                    pdto.dislikeList = likeDislikeRepository.GetPatientLD(patientAllocationID, false);
                    pdto.habitList = habitRepo.GetAllPatientH(patientAllocationID);
                    pdto.hobbyList = hobbyRepo.GetAllPatientH(patientAllocationID);

                    // Routine
                    pdto.routineList = routineRepository.GetAllPatientR(patientAllocationID);

                    pdto.contentVisible = false;

                    pdtoList.Add(pdto);

                }
            }
            else
            {
                List<Patient> patients = patientRepo.GetInactivePatients();

                foreach (var a in patients)
                {
                    PatientsDTO pdto = new PatientsDTO();
                    pdto.patientID = a.patientID;
                    var patient = patientRepo.GetSelectedPatient(a.patientID);
                    if (patient == null) return null;
                    int patientAllocationID = patient.PatientAllocation.patientAllocationID;

                    // Personal Information
                    if (patient.PatientAllocation.Caregiver != null)
                    {
                        pdto.caregiverName = patient.PatientAllocation.Caregiver.firstName + " " + patient.PatientAllocation.Caregiver.lastName;
                    }
                    else
                    {
                        pdto.caregiverName = "Adeline Tan"; //todo
                    }

                    pdto.nric = a.nric;
                    pdto.gender = a.gender;
                    pdto.firstName = a.firstName;
                    pdto.lastName = a.lastName;
                    pdto.preferredName = a.preferredName;
                    pdto.startDate = a.startDate;
                    pdto.endDate = a.endDate;
                    pdto.inactiveReason = a.inactiveReason;
                    pdto.inactiveDate = a.inactiveDate;

                    pdtoList.Add(pdto);
                }
            }

            return pdtoList;
        }

        public Tuple<bool, string> addPatient(string firstName, string lastName, string nric, string address, string tempAddress, string homeNo, string handphoneNo, string gender, DateTime dOB, string preferredName, int preferredLanguageListID, DateTime startDate, DateTime endDate, bool isRespiteCare, string profilePicture)
        {
            // Logic for setting and getting of data etc

            // ------ Add Part
            // Call DAO to Create the Model Object - will return the Model object with id = 0
            // Model newModel = ModelDAO.Create(parameters here);
            // If Supervisor/Guardian etc.
            // Call DAO to Add the Model into Database - will return the Model with the id set
            // newModel = ModelDAO.Add(newModel)



            // ------ Log Part - TBC
            // Serialise the object to to add into Log
            // string newLogData = new JavaScriptSerializer().Serialize(newModel);

            // Call the Log Method to add to Log 
            // int logId = .addLogToDB();

            // ----- Approval Reject & Notification Part - TBC !!!
            // Not yet settled where it will be placed

            

            Patient newPatient = patientRepo.CreateAdd(firstName, lastName, nric, address, tempAddress, homeNo, handphoneNo, gender, dOB, preferredName, preferredLanguageListID, startDate, endDate, isRespiteCare, profilePicture);

            return Tuple.Create(true, "New Patient Created Successfully.");

        }

        // Get Selected Patient with Patient ID
        public Models.Patient GetSelectedPatient(int patientID)
        {
            Models.Patient patient = patientRepo.GetSelectedPatient(patientID);
            return patient;
        }

        // Delete Selected Patient with Patient ID
        public bool DeletePatient(int patientID)
        {
            patientRepo.MarkDelete(patientID);
            return true;
        }

        public Tuple<bool, string> addGuardian(string userIDInit, string guardianName, string guardianContactNo, string guardianNRIC, string guardianEmail, int guardianRelationshipID)
        {
            string logCategory = Constants.LogCategory.Patient.Create;
            string tableAffected = Guardian.TableName;
            string tableAffectedList = Guardian.TableName;
            string oldLogData = null;

            // Check If guardian NRIC doesn't exist
            bool isExist = guardianRepo.CheckGuardianNRICExist(guardianNRIC);

            if (!isExist) // New Guardian
            {
                // create and add to db
                Guardian g = guardianRepo.CreateAdd(guardianName, guardianContactNo, guardianNRIC, guardianEmail, guardianRelationshipID);
                guardianRepo.SaveChanges();
                // serialise object
                string newLogData = guardianRepo.Serialise(g);
                // add to log
                Log log = otherService.createLog(logCategory, oldLogData, newLogData, userIDInit, tableAffected, null, null);
                // notify guardian?
                //otherService.notificationHandler(log.logID, 1, null);
                return Tuple.Create(true, "Guardian added successfully.");
            }

            return Tuple.Create(false, "Unable to add Guardian. Guardian's NRIC already exist.");
        } // end of addLikeDislike
    }

}