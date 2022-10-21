using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NTU_FYP_PEAR_CORE_20.Data;
using NTU_FYP_PEAR_CORE_20.DTOs;
using NTU_FYP_PEAR_CORE_20.Models;
using NTU_FYP_PEAR_CORE_20.Services;
using NTU_FYP_PEAR_CORE_20.Services.PatientRelated;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NTU_FYP_PEAR_CORE_20.APIControllers
{
    /*
     * IActionResult return type preferably - BadRequestResult, NotFoundResult, OkObjectResult, etc 
     * Refer to: https://docs.microsoft.com/en-us/aspnet/core/web-api/action-return-types?view=aspnetcore-5.0
     * 
     * Return format in Json preferably - { status: "success/error", message: "", data: [] }
     * Work with corresponding frontend to make the necessary changes when porting over the API
     * status different from IActionResult
     * Sample: return new OkObjectResult(new { status = "success", message = "" });
     */

    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly PatientService patientService;
        private readonly PatientPersonalPreferenceService patientPPService;
        private readonly UserService userService;
        private readonly OtherService otherService;
        private readonly ListService listService;
        public PatientController(PatientPersonalPreferenceService ppps, PatientService ps, OtherService os, UserService us, ListService ls)
        {
            this.patientService = ps;
            this.patientPPService = ppps;
            this.userService = us;
            this.otherService = os;
            this.listService = ls;
        }


        // -------------------------------------------- Patient --------------------------------------------

        // api/patient?token=123&masked=0&isActive=1
        [HttpGet]
        public IActionResult Get(string token, int masked, int isActive)
        {
            try
            {
                List<PatientsDTO> patients;

                if (isActive == 1)
                    patients = patientService.GetPatientInfo(true) ;
                else
                    patients = patientService.GetPatientInfo(false);

                

                return new OkObjectResult(new { status = "success", message = "", data = patients.ToList() });
            }
            catch (Exception e)
            {
                return BadRequest(new { status = "error", message = "Error: " + e.ToString() });
            }
        }

        // api/patient/1?token=123&masked=0
        [HttpGet("{id}")]
        public IActionResult Get(int id, string token, int masked)
        {
            try
            {
                Patient patient = patientService.GetSelectedPatient(id);
                return new OkObjectResult(new { status = "success", message = "", data = patient });
            }
            catch (Exception e)
            {
                return BadRequest(new { status = "error", message = "Error: " + e.ToString() });
            }
        }

        // api/patient/add
        [HttpPut("add")]
        public IActionResult Add([FromBody] PatientDTO patient)
        {
            try
            {

                // Add Guardian
                // Add Guardian 2
                // Add patient
                // Add patient allocation
                // Add dementia condition/medical/mobility//socialhistory/privacy setting/allergy/default centreactivity

                string token = Request.Headers["token"];
                ApplicationUser user = userService.getUserDetails(token, null);
                string userRole = userService.getUserType(user);
                if (!(userRole.Equals(Constants.Role.Caregiver) || userRole.Equals(Constants.Role.Supervisor)))
                    return BadRequest(new { status = "error", message = "Unauthorised user" });

                string firstName = patient.firstName;
                string lastName = patient.lastName;
                string nric = patient.nric;
                string address = patient.address;
                string tempAddress = patient.tempAddress;
                string homeNo = patient.homeNo;
                string handphoneNo = patient.handphoneNo;
                string gender = patient.gender;
                DateTime DOB = (DateTime)patient.dob;
                string preferredName = patient.preferredName;
                int preferredLanguageListID = (int)patient.preferredLanguageListID;
                DateTime startDate = (DateTime)patient.startDate;
                DateTime endDate = (DateTime)patient.endDate;
                bool isRespiteCare = (bool)patient.isRespiteCare;
                string profilePicture = patient.profilePicture;

                // bool approvalRequired = userRole.Equals(Constants.Role.Supervisor) ? true : false;

                (bool result, string msg) = patientService.addPatient(firstName, lastName, nric, address, tempAddress, homeNo, handphoneNo, gender, DOB, preferredName, preferredLanguageListID, startDate, endDate, isRespiteCare, profilePicture);

                // Call Patient Service
                //(bool result, string msg) = patientService.addPatient(firstName, lastName, nric, address, tempAddress, homeNo, handphoneNo, gender, DOB, preferredName, preferredLanguageListID, startDate, endDate, isRespiteCare, profilePicture);

                //return new OkObjectResult(new { status = result ? "success" : "error", message = msg });
                return null;
            }
            catch (Exception e)
            {
                return BadRequest(new { status = "error", message = "Error: " + e.ToString() });
            }
        }

        // api/patient/update/1
        [HttpPut("update/{id}")]
        public IActionResult Update(int id, [FromBody] string value)
        {
            try
            {
                var patientInput = JsonConvert.DeserializeObject<dynamic>(value);
                var token = patientInput["token"];
                //int patientId = patientInput["patientId"];
                string firstName = patientInput["firstName"];
                string lastName = patientInput["lastName"];
                string nric = patientInput["nric"];
                string address = patientInput["address"];
                string tempAddress = patientInput["tempAddress"];
                int homeNo = patientInput["homeNo"];
                int handphoneNo = patientInput["handphoneNo"];
                string gender = patientInput["gender"];
                DateTime dob = patientInput["dob"];
                int patientGuardianID = patientInput["patientGuardianID"];
                string preferredName = patientInput["preferredName"];
                int preferredLanguageListID = patientInput["preferredLanguageListID"];
                int privacyBit = patientInput["privacyBit"];
                int updateBit = patientInput["updateBit"];
                int autoGame = patientInput["autoGame"];
                DateTime startDate = patientInput["startDate"];
                DateTime endDate = patientInput["endDate"];
                string terminationReason = patientInput["terminationReason"];
                int isActive = patientInput["isActive"];
                string inactiveReason = patientInput["inactiveReason"];
                DateTime inactiveDate = patientInput["inactiveDate"];
                int isRespiteCare = patientInput["isRespiteCare"];
                string profilePicture = patientInput["profilePicture"];
                int isDeleted = patientInput["isDeleted"];
                DateTime createdDateTime = patientInput["createdDateTime"];
                DateTime updatedDateTime = patientInput["updatedDateTime"];

                // Call Patient Service
                //(bool result, string msg) = patientService.AddPersonalPreference()

                //return new OkObjectResult(new { status = result ? "success" : "error", message = msg });
            }
            catch (Exception e)
            {
                return BadRequest(new { status = "error", message = "Error: " + e.ToString() });
            }
            return BadRequest(new { status = "error", message = "Not Implemented" });
        }

        // api/patient/delete/1
        [HttpPut("delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                // Call Patient Service
                bool result = patientService.DeletePatient(id);
                string msg = "";

                if (result)
                    msg = "Patient deleted successfully.";
                else
                    msg = "Patient deletion is unsuccessful.";

                return new OkObjectResult(new { status = result ? "success" : "error", message = msg });
            }
            catch (Exception e)
            {
                return BadRequest(new { status = "error", message = "Error: " + e.ToString() });
            }
        }

        // -------------------- Personal Preference (Likes, Dislikes, Habits, Hobbies) --------------------

        // api/patient/personalpreference/1?masked=0
        [HttpGet("personalpreference/{id}")]
        public IActionResult PersonalPreference(int id, int masked)
        {
            try
            {
                string token = Request.Headers["token"];
                ApplicationUser user = userService.getUserDetails(token, null);
                string userRole = userService.getUserType(user);
                if (userRole == null || !(userRole.Equals(Constants.Role.Caregiver) || userRole.Equals(Constants.Role.Supervisor) || userRole.Equals(Constants.Role.Guardian)))
                    return BadRequest(new { status = "error", message = "Unauthorised user" });

                PatientPresonalPrefsDTO pppDto = patientPPService.getPatientPPP(id);
                //List<ListDTO> likeDislike = listService.GetLikeDislikeDTO();
                //List<ListDTO> habits = listService.GetHabitDTO();
                //List<ListDTO> hobbies = listService.GetHobbyDTO();
                
                return new OkObjectResult(new { status = "success", message = "", data = pppDto });
            }
            catch (Exception e)
            {
                return BadRequest(new { status = "error", message = "Error: " + e.ToString() });
            }
            //return BadRequest(new { status = "error", message = "Not Implemented" });
        }

        /*
         * Others: { "patientId": 1, "type":"Hobbies", "listId": null, "desc": "test" }
         * Normal: { "patientId": 1, "type":"Hobbies", "listId": 3, "desc": null }
         */
        // api/patient/personalpreference/add
        [HttpPost("personalpreference/add")]
        public IActionResult AddPersonalPreference([FromBody] PatientPersonalPrefDTO dto)
        {
            try
            {
                string token = Request.Headers["token"];
                ApplicationUser user = userService.getUserDetails(token, null);
                string userRole = userService.getUserType(user);
                if (userRole == null || !(userRole.Equals(Constants.Role.Caregiver) || userRole.Equals(Constants.Role.Supervisor) || userRole.Equals(Constants.Role.Guardian)))
                    return BadRequest(new { status = "error", message = "Unauthorised user" });

                int patientId = dto.patientId;
                string type = dto.type; // Likes/Dislikes/Habit/Hobby
                int? listId = dto.listId;
                string desc = dto.desc; // For "Others" option
                bool approvalRequired = userRole.Equals(Constants.Role.Caregiver) ? true : false;

                // Call Patient Service
                bool result = false; string msg;
                switch (type)
                {
                    case "likes":
                    case "like":
                    case "Like":
                    case "Likes":
                        (result, msg) = patientPPService.addLikeDislike(user.Id, patientId, listId, desc, true, approvalRequired);
                        break;
                    case "dislike":
                    case "dislikes":
                    case "Dislike":
                    case "Dislikes":
                        (result, msg) = patientPPService.addLikeDislike(user.Id, patientId, listId, desc, false, approvalRequired);
                        break;
                    case "habit":
                    case "habits":
                    case "Habits":
                    case "Habit":
                        (result, msg) = patientPPService.addHabit(user.Id, patientId, listId, desc, approvalRequired);
                        break;
                    case "hobbies":
                    case "hobby":
                    case "Hobbies":
                    case "Hobby":
                        (result, msg) = patientPPService.addHobby(user.Id, patientId, listId, desc, approvalRequired);
                        break;
                    default:
                        msg = "Invalid type";
                        break;
                }
                return new OkObjectResult(new { status = result ? "success" : "error", message = msg });
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    status = "error",
                    message = "Error: " + e.ToString()
                });
            }
        }

        // api/patient/personalpreference/udpate/1
        [HttpPut("personalpreference/update/{id}")]
        public IActionResult UpdatePersonalPreference(int id, [FromBody] PatientPersonalPrefDTO dto)
        {
            try
            {
                string token = Request.Headers["token"];
                ApplicationUser user = userService.getUserDetails(token, null);
                string userRole = userService.getUserType(user);
                if (userRole == null || !(userRole.Equals(Constants.Role.Caregiver) || userRole.Equals(Constants.Role.Supervisor) || userRole.Equals(Constants.Role.Guardian)))
                    return BadRequest(new { status = "error", message = "Unauthorised user" });

            }
            catch (Exception e)
            {
                return BadRequest(new { status = "error", message = "Error: " + e.ToString() });
            }
            return BadRequest(new { status = "error", message = "Not Implemented" });
        }

        // api/patient/personalpreference/delete/1
        [HttpPut("personalpreference/delete/{id}")]
        public IActionResult DeletePersonalPreference(int id)
        {
            try
            {
                string token = Request.Headers["token"];
                ApplicationUser user = userService.getUserDetails(token, null);
                string userRole = userService.getUserType(user);
                if (userRole == null || !(userRole.Equals(Constants.Role.Caregiver) || userRole.Equals(Constants.Role.Supervisor) || userRole.Equals(Constants.Role.Guardian)))
                    return BadRequest(new { status = "error", message = "Unauthorised user" });

                // return new OkObjectResult(new { status = "success", message = "" });
            }
            catch (Exception e)
            {
                return BadRequest(new { status = "error", message = "Error: " + e.ToString() });
            }
            return BadRequest(new { status = "error", message = "Not Implemented" });
        }

        [HttpPut("test")]
        public IActionResult test()
        {
            try
            {
                string token = "1234";
                ApplicationUser user = userService.getUserDetails(token, null);
                string userRole = userService.getUserType(user);
                if (!(userRole.Equals(Constants.Role.Caregiver) || userRole.Equals(Constants.Role.Supervisor)))
                    return BadRequest(new { status = "error", message = "Unauthorised user" });

                // return new OkObjectResult(new { status = "success", message = "" });
            }
            catch (Exception e)
            {
                return BadRequest(new { status = "error", message = "Error: " + e.ToString() });
            }
            return BadRequest(new { status = "error", message = "Not Implemented" });
        }
    }
}
