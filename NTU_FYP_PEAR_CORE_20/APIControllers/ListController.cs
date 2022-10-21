using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NTU_FYP_PEAR_CORE_20.Data;
using NTU_FYP_PEAR_CORE_20.Models;
using NTU_FYP_PEAR_CORE_20.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

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
    public class ListController : ControllerBase
    {
        private readonly ListService listService;

        public ListController(ListService listService)
        {
            this.listService = listService;
        }

        public IActionResult Get(string token, string type)
        {
            try
            {
                switch (type)
                {
                    // Note: string type is case sensitive 

                    case "AlbumCategory":
                        List<List_AlbumCategory> albumCatList = listService.GetAlbumCategory();
                        return new OkObjectResult(new { status = "success", message = "", data = albumCatList.ToList() });
                    case "AllergyReaction":
                        List<List_AllergyReaction> allergyReactionList = listService.GetAllergyReaction();
                        return new OkObjectResult(new { status = "success", message = "", data = allergyReactionList.ToList() });
                    case "Allergy":
                        List<List_Allergy> allergyList = listService.GetAllergy();
                        return new OkObjectResult(new { status = "success", message = "", data = allergyList.ToList() });
                    case "Country":
                        List<List_Country> countryList = listService.GetCountry();
                        return new OkObjectResult(new { status = "success", message = "", data = countryList.ToList() });
                    case "DementiaType":
                        List<List_DementiaType> dementiaTypeList = listService.GetDementiaType();
                        return new OkObjectResult(new { status = "success", message = "", data = dementiaTypeList.ToList() });
                    case "Diet":
                        List<List_Diet> dietList = listService.GetDiet();
                        return new OkObjectResult(new { status = "success", message = "", data = dietList.ToList() });
                    case "Education":
                        List<List_Education> educationList = listService.GetEducation();
                        return new OkObjectResult(new { status = "success", message = "", data = educationList.ToList() });
                    case "GameCategory":
                        List<List_GameCategory> gameCategoryList = listService.GetGameCategory();
                        return new OkObjectResult(new { status = "success", message = "", data = gameCategoryList.ToList() });
                    case "Habit":
                        List<List_Habit> habitList = listService.GetHabit();
                        return new OkObjectResult(new { status = "success", message = "", data = habitList.ToList() });
                    case "Hobby":
                        List<List_Hobby> hobbyList = listService.GetHobby();
                        return new OkObjectResult(new { status = "success", message = "", data = hobbyList.ToList() });
                    case "Language":
                        List<List_Language> languageList = listService.GetLanguage();
                        return new OkObjectResult(new { status = "success", message = "", data = languageList.ToList() });
                    case "LikeDislike":
                        List<List_LikeDislike> likeDislikeList = listService.GetLikeDislike();
                        return new OkObjectResult(new { status = "success", message = "", data = likeDislikeList.ToList() });
                    case "LiveWith":
                        List<List_LiveWith> liveWithList = listService.GetLiveWith();
                        return new OkObjectResult(new { status = "success", message = "", data = liveWithList.ToList() });
                    case "Mobility":
                        List<List_Mobility> mobilityList = listService.GetMobility();
                        return new OkObjectResult(new { status = "success", message = "", data = mobilityList.ToList() });
                    case "Occupation":
                        List<List_Occupation> occupationList = listService.GetOccupation();
                        return new OkObjectResult(new { status = "success", message = "", data = occupationList.ToList() });
                    case "Pet":
                        List<List_Pet> petList = listService.GetPet();
                        return new OkObjectResult(new { status = "success", message = "", data = petList.ToList() });
                    case "Prescription":
                        List<List_Prescription> prescriptionList = listService.GetPrescription();
                        return new OkObjectResult(new { status = "success", message = "", data = prescriptionList.ToList() });
                    case "ProblemLog":
                        List<List_ProblemLog> problemLogList = listService.GetProblemLog();
                        return new OkObjectResult(new { status = "success", message = "", data = problemLogList.ToList() });
                    case "Relationship":
                        List<List_Relationship> relationshipList = listService.GetRelationship();
                        return new OkObjectResult(new { status = "success", message = "", data = relationshipList.ToList() });
                    case "Religion":
                        List<List_Religion> religionList = listService.GetReligion();
                        return new OkObjectResult(new { status = "success", message = "", data = religionList.ToList() });
                    case "SecretQuestion":
                        List<List_SecretQuestion> secretQuestionList = listService.GetSecretQuestion();
                        return new OkObjectResult(new { status = "success", message = "", data = secretQuestionList.ToList() });

                    default:
                        return BadRequest(new { status = "error", message = "Please enter a valid type of list" });
                }
                

                
            }
            catch (Exception e)
            {
                return BadRequest(new { status = "error", message = "Error: " + e.ToString() });
            }
        }
    }
}
