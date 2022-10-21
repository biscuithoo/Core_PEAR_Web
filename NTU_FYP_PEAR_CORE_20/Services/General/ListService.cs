using NTU_FYP_PEAR_CORE_20.Models;
using System.Collections.Generic;
using NTU_FYP_PEAR_CORE_20.Repository;
using NTU_FYP_PEAR_CORE_20.Data;
using NTU_FYP_PEAR_CORE_20.DTOs;

namespace NTU_FYP_PEAR_CORE_20.Services
{
    /*
     * List_xxx
     * This Service is not allowed to call other Services
     */
    public class ListService
    {

        // Repository
        private readonly IBaseListRepository<List_AlbumCategory> list_AlbumCategoryRepo;
        private readonly IBaseListRepository<List_AllergyReaction> list_AllergyReactionRepo;
        private readonly IBaseListRepository<List_Allergy> list_AllergyRepo;
        private readonly IBaseListRepository<List_Country> list_CountryRepo;
        private readonly IBaseListRepository<List_DementiaType> list_DementiaTypeRepo;
        private readonly IBaseListRepository<List_Diet> list_DietRepo;
        private readonly IBaseListRepository<List_Education> list_EducationRepo;
        private readonly IBaseListRepository<List_GameCategory> list_GameCategoryRepo;
        private readonly IBaseListRepository<List_Habit> list_HabitRepo;
        private readonly IBaseListRepository<List_Hobby> list_HobbyRepo;
        private readonly IBaseListRepository<List_Language> list_LanguageRepo;
        private readonly IBaseListRepository<List_LikeDislike> list_LikeDislikeRepo;
        private readonly IBaseListRepository<List_LiveWith> list_LiveWithRepo;
        private readonly IBaseListRepository<List_Mobility> list_MobilityRepo;
        private readonly IBaseListRepository<List_Occupation> list_OccupationRepo;
        private readonly IBaseListRepository<List_Pet> list_PetRepo;
        private readonly IBaseListRepository<List_Prescription> list_PrescriptionRepo;
        private readonly IBaseListRepository<List_ProblemLog> list_ProblemLogRepo;
        private readonly IBaseListRepository<List_Relationship> list_RelationshipRepo;
        private readonly IBaseListRepository<List_Religion> list_ReligionRepo;
        private readonly IBaseListRepository<List_SecretQuestion> list_SecretQuestionRepo;

        public ListService(IBaseListRepository<List_AlbumCategory> lacr, IBaseListRepository<List_AllergyReaction> larr, IBaseListRepository<List_Allergy> lar, IBaseListRepository<List_Country> lcr, IBaseListRepository<List_DementiaType> ldtr, IBaseListRepository<List_Diet> ldr, IBaseListRepository<List_Education> ler, IBaseListRepository<List_GameCategory> lgcr, IBaseListRepository<List_Habit> lhr, IBaseListRepository<List_Hobby> lhor, IBaseListRepository<List_Language> llr, IBaseListRepository<List_LikeDislike> lldr, IBaseListRepository<List_LiveWith> llwr, IBaseListRepository<List_Mobility> lmr, IBaseListRepository<List_Occupation> lor, IBaseListRepository<List_Pet> lpr, IBaseListRepository<List_Prescription> lprr, IBaseListRepository<List_ProblemLog> lplr, IBaseListRepository<List_Relationship> lrr, IBaseListRepository<List_Religion> lrelir, IBaseListRepository<List_SecretQuestion> lsqr)
        {
            this.list_AlbumCategoryRepo = lacr;
            this.list_AllergyReactionRepo = larr;
            this.list_AllergyRepo = lar;
            this.list_CountryRepo = lcr;
            this.list_DementiaTypeRepo = ldtr;
            this.list_DietRepo = ldr;
            this.list_EducationRepo = ler;
            this.list_GameCategoryRepo = lgcr;
            this.list_HabitRepo = lhr;
            this.list_HobbyRepo = lhor;
            this.list_LanguageRepo = llr;
            this.list_LikeDislikeRepo = lldr;
            this.list_LiveWithRepo = llwr;
            this.list_MobilityRepo = lmr;
            this.list_OccupationRepo = lor;
            this.list_PetRepo = lpr;
            this.list_PrescriptionRepo = lprr;
            this.list_ProblemLogRepo = lplr;
            this.list_RelationshipRepo = lrr;
            this.list_ReligionRepo = lrelir;
            this.list_SecretQuestionRepo = lsqr;
        }

        // Get All Album Categories
        public List<List_AlbumCategory> GetAlbumCategory()
        {
            return list_AlbumCategoryRepo.GetNotDeleted();
        }

        // Get All Allergy Reactions
        public List<List_AllergyReaction> GetAllergyReaction()
        {
            return list_AllergyReactionRepo.GetNotDeleted();
        }

        // Get All Allergy Reactions
        public List<List_Allergy> GetAllergy()
        {
            return list_AllergyRepo.GetNotDeleted();
        }

        // Get All Countries
        public List<List_Country> GetCountry()
        {
            return list_CountryRepo.GetNotDeleted();
        }

        // Get All Dementia Types
        public List<List_DementiaType> GetDementiaType()
        {
            return list_DementiaTypeRepo.GetNotDeleted();
        }

        // Get All Diets
        public List<List_Diet> GetDiet()
        {
            return list_DietRepo.GetNotDeleted();
        }

        // Get All Educations
        public List<List_Education> GetEducation()
        {
            return list_EducationRepo.GetNotDeleted();
        }

        // Get All Game Categories
        public List<List_GameCategory> GetGameCategory()
        {
            return list_GameCategoryRepo.GetNotDeleted();
        }

        // Get All Habits
        public List<List_Habit> GetHabit()
        {
            return list_HabitRepo.GetNotDeleted();
        }
        public List<ListDTO> GetHabitDTO()
        {
            List<List_Habit> lhs = GetHabit();
            List<ListDTO> habit = new List<ListDTO>();
            foreach (var lh in lhs)
                habit.Add(new ListDTO { listId = lh.list_habitID, value = lh.value });
            return habit;
        }

        // Get All Hobbies
        public List<List_Hobby> GetHobby()
        {
            return list_HobbyRepo.GetNotDeleted();
        }
        public List<ListDTO> GetHobbyDTO()
        {
            List<List_Hobby> lhs = GetHobby();
            List<ListDTO> hobby = new List<ListDTO>();
            foreach (var lh in lhs)
                hobby.Add(new ListDTO { listId = lh.list_hobbyID, value = lh.value });
            return hobby;
        }

        // Get All Languages
        public List<List_Language> GetLanguage()
        {
            return list_LanguageRepo.GetNotDeleted();
        }

        // Get All Like/Dislike
        public List<List_LikeDislike> GetLikeDislike()
        {
            return list_LikeDislikeRepo.GetNotDeleted();
        }
        public List<ListDTO> GetLikeDislikeDTO()
        {
            List<List_LikeDislike> ldds = GetLikeDislike();
            List<ListDTO> likeDislike = new List<ListDTO>();
            foreach (var ldd in ldds)
                likeDislike.Add(new ListDTO { listId = ldd.list_likeDislikeID, value = ldd.value });
            return likeDislike;
        }

        // Get All Live With
        public List<List_LiveWith> GetLiveWith()
        {
            return list_LiveWithRepo.GetNotDeleted();
        }

        // Get All Mobilities
        public List<List_Mobility> GetMobility()
        {
            return list_MobilityRepo.GetNotDeleted();
        }

        // Get All Occupations
        public List<List_Occupation> GetOccupation()
        {
            return list_OccupationRepo.GetNotDeleted();
        }

        // Get All Pets
        public List<List_Pet> GetPet()
        {
            return list_PetRepo.GetNotDeleted();
        }

        // Get All Prescriptions
        public List<List_Prescription> GetPrescription()
        {
            return list_PrescriptionRepo.GetNotDeleted();
        }

        // Get All Problem Logs
        public List<List_ProblemLog> GetProblemLog()
        {
            return list_ProblemLogRepo.GetNotDeleted();
        }

        // Get All Relationships
        public List<List_Relationship> GetRelationship()
        {
            return list_RelationshipRepo.GetNotDeleted();
        }

        // Get All Religions
        public List<List_Religion> GetReligion()
        {
            return list_ReligionRepo.GetNotDeleted();
        }

        // Get All Secret Questions
        public List<List_SecretQuestion> GetSecretQuestion()
        {
            return list_SecretQuestionRepo.GetNotDeleted();
        }
    }
}
