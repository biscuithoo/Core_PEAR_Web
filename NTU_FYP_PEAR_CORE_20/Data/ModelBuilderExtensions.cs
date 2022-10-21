using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NTU_FYP_PEAR_CORE_20.Services;
using NTU_FYP_PEAR_CORE_20.Models;
using System;

namespace NTU_FYP_PEAR_CORE_20.Data
{
    public static class ModelBuilderExtensions
    {
        public static DateTime cuDT = Convert.ToDateTime("2021-01-01T00:00:00.0000000");

        public static void Seed(this ModelBuilder modelBuilder)
        {
            //----------------------- Data Seeding for Deployment -----------------------

            // ----------------------- List_xxx tables

            // List_AlbumCategory
            modelBuilder.Entity<List_AlbumCategory>().HasData(
                new List_AlbumCategory { list_albumCatID = 1, value = "Family", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_AlbumCategory { list_albumCatID = 2, value = "Friends", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_AlbumCategory { list_albumCatID = 3, value = "Holiday", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_AlbumCategory { list_albumCatID = 4, value = "Pet", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_AlbumCategory { list_albumCatID = 5, value = "Food", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_AlbumCategory { list_albumCatID = 6, value = "Activity", createdDateTime = cuDT, updatedDateTime = cuDT }
            );

            // List_Allergy
            modelBuilder.Entity<List_Allergy>().HasData(
                new List_Allergy { list_allergyID = 1, value = "To be updated", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Allergy { list_allergyID = 2, value = "None", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Allergy { list_allergyID = 3, value = "Corn", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Allergy { list_allergyID = 4, value = "Eggs", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Allergy { list_allergyID = 5, value = "Fish", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Allergy { list_allergyID = 6, value = "Meat", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Allergy { list_allergyID = 7, value = "Milk", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Allergy { list_allergyID = 8, value = "Peanuts", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Allergy { list_allergyID = 9, value = "Tree nuts", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Allergy { list_allergyID = 10, value = "Shellfish", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Allergy { list_allergyID = 11, value = "Soy", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Allergy { list_allergyID = 12, value = "Wheat", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Allergy { list_allergyID = 13, value = "Seafood", createdDateTime = cuDT, updatedDateTime = cuDT }
             );

            // List_AllergyReaction
            modelBuilder.Entity<List_AllergyReaction>().HasData(
                new List_AllergyReaction { list_allergyReactionID = 1, value = "Rashes", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_AllergyReaction { list_allergyReactionID = 2, value = "Sneezing", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_AllergyReaction { list_allergyReactionID = 3, value = "Vomiting", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_AllergyReaction { list_allergyReactionID = 4, value = "Nausea", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_AllergyReaction { list_allergyReactionID = 5, value = "Swelling", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_AllergyReaction { list_allergyReactionID = 6, value = "Difficulty Breathing", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_AllergyReaction { list_allergyReactionID = 7, value = "Diarrhea", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_AllergyReaction { list_allergyReactionID = 8, value = "Abdominal cramp or pain", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_AllergyReaction { list_allergyReactionID = 9, value = "Nasal Congestion", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_AllergyReaction { list_allergyReactionID = 10, value = "Itching", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_AllergyReaction { list_allergyReactionID = 11, value = "Hives", createdDateTime = cuDT, updatedDateTime = cuDT }
            );

            // List_Country
            modelBuilder.Entity<List_Country>().HasData(
                new List_Country { list_countryID = 1, value = "Afghanistan", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 2, value = "Antarctica", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 3, value = "Argentina", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 4, value = "Australia", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 5, value = "Austria", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 6, value = "Bangladesh", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 7, value = "Belgium", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 8, value = "Bermuda", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 9, value = "Bhutan", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 10, value = "Brazil", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 11, value = "Cambodia", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 12, value = "Cameroon", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 13, value = "Canada", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 14, value = "Central African Republic", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 15, value = "Chad", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 16, value = "Chile", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 17, value = "China", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 18, value = "Christmas Island", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 19, value = "Colombia", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 20, value = "Cook Islands", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 21, value = "Cote D\'Ivoire", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 22, value = "Croatia (Local Name: Hrvatska)", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 23, value = "Cuba", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 24, value = "Czech Republic", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 25, value = "Denmark", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 26, value = "Dominica", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 27, value = "Dominican Republic", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 28, value = "Ecuador", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 29, value = "Egypt", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 30, value = "Finland", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 31, value = "France", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 32, value = "Georgia", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 33, value = "Germany", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 34, value = "Greece", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 35, value = "Greenland", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 36, value = "Guinea", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 37, value = "Hong Kong", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 38, value = "Hungary", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 39, value = "India", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 40, value = "Indonesia", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 41, value = "Iran (Islamic Republic Of)", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 42, value = "Iraq", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 43, value = "Ireland", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 44, value = "Israel", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 45, value = "Italy", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 46, value = "Jamaica", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 47, value = "Japan", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 48, value = "Jordan", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 49, value = "Kenya", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 50, value = "Korea", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 51, value = "Kuwait", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 52, value = "Macau", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 53, value = "Macedonia", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 54, value = "Madagascar", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 55, value = "Malaysia", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 56, value = "Maldives", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 57, value = "Mexico", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 58, value = "Micronesia, Federated States", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 59, value = "Moldova, Republic Of", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 60, value = "Monaco", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 61, value = "Mongolia", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 62, value = "Myanmar", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 63, value = "Nepal", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 64, value = "Netherlands", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 65, value = "New Zealand", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 66, value = "Nigeria", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 67, value = "Norway", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 68, value = "Oman", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 69, value = "Pakistan", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 70, value = "Palau", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 71, value = "Papua New Guinea", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 72, value = "Peru", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 73, value = "Philippines", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 74, value = "Poland", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 75, value = "Portugal", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 76, value = "Qatar", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 77, value = "Reunion", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 78, value = "Romania", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 79, value = "Saudi Arabia", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 80, value = "Singapore", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 81, value = "South Africa", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 82, value = "Spain", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 83, value = "Sri Lanka", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 84, value = "Sudan", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 85, value = "Sweden", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 86, value = "Switzerland", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 87, value = "Taiwan", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 88, value = "Thailand", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 89, value = "Turkey", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 90, value = "United Arab Emirates", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 91, value = "United Kingdom", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 92, value = "United States", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 93, value = "United States Minor Is.", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 94, value = "Uruguay", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 95, value = "Viet Nam", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 96, value = "Virgin Islands (British)", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 97, value = "Virgin Islands (U.S.)", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Country { list_countryID = 98, value = "Yemen", createdDateTime = cuDT, updatedDateTime = cuDT }
            );

            // List_DementiaType
            modelBuilder.Entity<List_DementiaType>().HasData(
                new List_DementiaType { list_dementiaTypeID = 1, value = "Alzheimer disease early stage", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_DementiaType { list_dementiaTypeID = 2, value = "Alzheimer disease middle stage", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_DementiaType { list_dementiaTypeID = 3, value = "Alzheimer disease late stage", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_DementiaType { list_dementiaTypeID = 4, value = "Vascular dementia early stage", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_DementiaType { list_dementiaTypeID = 5, value = "Vascular dementia middle stage", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_DementiaType { list_dementiaTypeID = 6, value = "Vascular dementia late stage", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_DementiaType { list_dementiaTypeID = 7, value = "Lewy body dementia early stage", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_DementiaType { list_dementiaTypeID = 8, value = "Lewy body dementia middle stage", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_DementiaType { list_dementiaTypeID = 9, value = "Lewy body dementia late stage", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_DementiaType { list_dementiaTypeID = 10, value = "Parkinson disease dementia early stage", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_DementiaType { list_dementiaTypeID = 11, value = "Parkinson disease dementia middle stage", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_DementiaType { list_dementiaTypeID = 12, value = "Parkinson disease dementia late stage", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_DementiaType { list_dementiaTypeID = 13, value = "Fronto-temportal dementia early stage", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_DementiaType { list_dementiaTypeID = 14, value = "Fronto-temportal dementia middle stage", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_DementiaType { list_dementiaTypeID = 15, value = "Fronto-temportal dementia late stage", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_DementiaType { list_dementiaTypeID = 16, value = "Creutzfeldt-jakob disease early stage", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_DementiaType { list_dementiaTypeID = 17, value = "Creutzfeldt-jakob disease middle stage", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_DementiaType { list_dementiaTypeID = 18, value = "Creutzfeldt-jakob disease late stage", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_DementiaType { list_dementiaTypeID = 19, value = "Normal pressure hydrocephalus early stage", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_DementiaType { list_dementiaTypeID = 20, value = "Normal pressure hydrocephalus middle stage", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_DementiaType { list_dementiaTypeID = 21, value = "Normal pressure hydrocephalus late stage", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_DementiaType { list_dementiaTypeID = 22, value = "Huntington disease early stage", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_DementiaType { list_dementiaTypeID = 23, value = "Huntington disease middle stage", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_DementiaType { list_dementiaTypeID = 24, value = "Huntington disease late stage", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_DementiaType { list_dementiaTypeID = 25, value = "Wernicke-korsakoff syndrome early stage", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_DementiaType { list_dementiaTypeID = 26, value = "Wernicke-korsakoff syndrome middle stage", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_DementiaType { list_dementiaTypeID = 27, value = "Wernicke-korsakoff syndrome late stage", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_DementiaType { list_dementiaTypeID = 28, value = "Mixed dementia early stage", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_DementiaType { list_dementiaTypeID = 29, value = "Mixed dementia middle stage", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_DementiaType { list_dementiaTypeID = 30, value = "Mixed dementia late stage", createdDateTime = cuDT, updatedDateTime = cuDT }
            );

            // List_Diet
            modelBuilder.Entity<List_Diet>().HasData(
                new List_Diet { list_dietID = 1, value = "Diabetic", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Diet { list_dietID = 2, value = "Halal", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Diet { list_dietID = 3, value = "Vegan", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Diet { list_dietID = 4, value = "Vegetarian", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Diet { list_dietID = 5, value = "Gluten-free", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Diet { list_dietID = 6, value = "Soft food", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Diet { list_dietID = 7, value = "No Cheese", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Diet { list_dietID = 8, value = "No Peanuts", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Diet { list_dietID = 9, value = "No Seafood", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Diet { list_dietID = 10, value = "No Vegetables", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Diet { list_dietID = 11, value = "No Meat", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Diet { list_dietID = 12, value = "No Dairy", createdDateTime = cuDT, updatedDateTime = cuDT }
            );

            // List_Education
            modelBuilder.Entity<List_Education>().HasData(
                new List_Education { list_educationID = 1, value = "Primary or lower", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Education { list_educationID = 2, value = "Secondary", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Education { list_educationID = 3, value = "Diploma", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Education { list_educationID = 4, value = "Junior College", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Education { list_educationID = 5, value = "Degree", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Education { list_educationID = 6, value = "Master", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Education { list_educationID = 7, value = "Doctorate", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Education { list_educationID = 8, value = "Vocational", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Education { list_educationID = 9, value = "ITE", createdDateTime = cuDT, updatedDateTime = cuDT }
            );

            // List_GameCategory
            modelBuilder.Entity<List_GameCategory>().HasData(
                new List_GameCategory { list_gameCategoryID = 1, value = "Speed", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_GameCategory { list_gameCategoryID = 2, value = "Memory", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_GameCategory { list_gameCategoryID = 3, value = "Attention", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_GameCategory { list_gameCategoryID = 4, value = "Flexibility", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_GameCategory { list_gameCategoryID = 5, value = "Problem Solving", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_GameCategory { list_gameCategoryID = 6, value = "Hand-eye Coordination", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_GameCategory { list_gameCategoryID = 7, value = "Conversation Game", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_GameCategory { list_gameCategoryID = 8, value = "Card Game", createdDateTime = cuDT, updatedDateTime = cuDT }
            );

            // List_Habit
            modelBuilder.Entity<List_Habit>().HasData(
                new List_Habit { list_habitID = 1, value = "Biting Objects", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Habit { list_habitID = 2, value = "Licking Lips", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Habit { list_habitID = 3, value = "Crack Knuckles", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Habit { list_habitID = 4, value = "Daydreaming", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Habit { list_habitID = 5, value = "Fidget with Objects", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Habit { list_habitID = 6, value = "Frequent Toilet Visits", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Habit { list_habitID = 7, value = "Hair Fiddling", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Habit { list_habitID = 8, value = "Talking to oneself", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Habit { list_habitID = 9, value = "Pick nose", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Habit { list_habitID = 10, value = "Skip meals", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Habit { list_habitID = 11, value = "Snacking", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Habit { list_habitID = 12, value = "Thumb Sucking", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Habit { list_habitID = 13, value = "Abnormal Sleep Cycle", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Habit { list_habitID = 14, value = "Worrying", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Habit { list_habitID = 15, value = "Scratch People", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Habit { list_habitID = 16, value = "Sleep Walking", createdDateTime = cuDT, updatedDateTime = cuDT }
            );

            // List_Hobby
            modelBuilder.Entity<List_Hobby>().HasData(
                new List_Hobby { list_hobbyID = 1, value = "Reading", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Hobby { list_hobbyID = 2, value = "Travelling", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Hobby { list_hobbyID = 3, value = "Fishing", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Hobby { list_hobbyID = 4, value = "Crafting", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Hobby { list_hobbyID = 5, value = "Television", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Hobby { list_hobbyID = 6, value = "Bird Watching", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Hobby { list_hobbyID = 7, value = "Collecting", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Hobby { list_hobbyID = 8, value = "Music", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Hobby { list_hobbyID = 9, value = "Gardening", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Hobby { list_hobbyID = 10, value = "Video Games", createdDateTime = cuDT, updatedDateTime = cuDT }
            );

            // List_Language
            modelBuilder.Entity<List_Language>().HasData(
                new List_Language { list_languageID = 1, value = "Cantonese", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Language { list_languageID = 2, value = "English", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Language { list_languageID = 3, value = "Hainanese", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Language { list_languageID = 4, value = "Hakka", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Language { list_languageID = 5, value = "Hindi", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Language { list_languageID = 6, value = "Hokkien", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Language { list_languageID = 7, value = "Malay", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Language { list_languageID = 8, value = "Mandarin", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Language { list_languageID = 9, value = "Tamil", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Language { list_languageID = 10, value = "Teochew", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Language { list_languageID = 11, value = "Japanese", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Language { list_languageID = 12, value = "Spanish", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Language { list_languageID = 13, value = "Korean", createdDateTime = cuDT, updatedDateTime = cuDT }
            );

            // List_LikeDislike
            modelBuilder.Entity<List_LikeDislike>().HasData(
                new List_LikeDislike { list_likeDislikeID = 1, value = "Animals/Pets/Wildlife", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_LikeDislike { list_likeDislikeID = 2, value = "Consume alcohol", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_LikeDislike { list_likeDislikeID = 3, value = "Cooking/Food", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_LikeDislike { list_likeDislikeID = 4, value = "Dance", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_LikeDislike { list_likeDislikeID = 5, value = "Dirty environment", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_LikeDislike { list_likeDislikeID = 6, value = "Drama/Theatre", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_LikeDislike { list_likeDislikeID = 7, value = "Exercise/Sports", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_LikeDislike { list_likeDislikeID = 8, value = "Friends/Social activities", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_LikeDislike { list_likeDislikeID = 9, value = "Gambling", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_LikeDislike { list_likeDislikeID = 10, value = "Gardening/plants", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_LikeDislike { list_likeDislikeID = 11, value = "Movie/TV", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_LikeDislike { list_likeDislikeID = 12, value = "Music/Singing", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_LikeDislike { list_likeDislikeID = 13, value = "Natural Scenery", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_LikeDislike { list_likeDislikeID = 14, value = "Noisy environment", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_LikeDislike { list_likeDislikeID = 15, value = "Reading", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_LikeDislike { list_likeDislikeID = 16, value = "Religious activities", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_LikeDislike { list_likeDislikeID = 17, value = "Science/Technology", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_LikeDislike { list_likeDislikeID = 18, value = "Smoking", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_LikeDislike { list_likeDislikeID = 19, value = "Travelling/Sightseeing", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_LikeDislike { list_likeDislikeID = 20, value = "Mannequin/Dolls", createdDateTime = cuDT, updatedDateTime = cuDT }
            );

            // List_LiveWith
            modelBuilder.Entity<List_LiveWith>().HasData(
                new List_LiveWith { list_liveWithID = 1, value = "Alone", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_LiveWith { list_liveWithID = 2, value = "Children", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_LiveWith { list_liveWithID = 3, value = "Friend", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_LiveWith { list_liveWithID = 4, value = "Relative", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_LiveWith { list_liveWithID = 5, value = "Spouse", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_LiveWith { list_liveWithID = 6, value = "Family", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_LiveWith { list_liveWithID = 7, value = "Parents", createdDateTime = cuDT, updatedDateTime = cuDT }
            );

            // List_Mobility
            modelBuilder.Entity<List_Mobility>().HasData(
                new List_Mobility { list_mobilityID = 1, value = "Cane", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Mobility { list_mobilityID = 2, value = "Crutches", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Mobility { list_mobilityID = 3, value = "Walkers", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Mobility { list_mobilityID = 4, value = "Gait trainers", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Mobility { list_mobilityID = 5, value = "Scooter", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Mobility { list_mobilityID = 6, value = "Wheelchairs", createdDateTime = cuDT, updatedDateTime = cuDT }
            );

            // List_Occupation
            modelBuilder.Entity<List_Occupation>().HasData(
                new List_Occupation { list_occupationID = 1, value = "Accountant", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Occupation { list_occupationID = 2, value = "Business owner", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Occupation { list_occupationID = 3, value = "Chef/Cook", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Occupation { list_occupationID = 4, value = "Cleaner", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Occupation { list_occupationID = 5, value = "Clerk", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Occupation { list_occupationID = 6, value = "Dentist", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Occupation { list_occupationID = 7, value = "Doctor", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Occupation { list_occupationID = 8, value = "Driver", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Occupation { list_occupationID = 9, value = "Engineer", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Occupation { list_occupationID = 10, value = "Fireman", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Occupation { list_occupationID = 11, value = "Gardener", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Occupation { list_occupationID = 12, value = "Hawker", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Occupation { list_occupationID = 13, value = "Homemaker", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Occupation { list_occupationID = 14, value = "Housekeeper", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Occupation { list_occupationID = 15, value = "Labourer", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Occupation { list_occupationID = 16, value = "Lawyer", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Occupation { list_occupationID = 17, value = "Manager", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Occupation { list_occupationID = 18, value = "Mechanic", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Occupation { list_occupationID = 19, value = "Nurse", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Occupation { list_occupationID = 20, value = "Professional sportsperson", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Occupation { list_occupationID = 21, value = "Receptionist", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Occupation { list_occupationID = 22, value = "Sales person", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Occupation { list_occupationID = 23, value = "Secretary", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Occupation { list_occupationID = 24, value = "Security guard", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Occupation { list_occupationID = 25, value = "Teacher", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Occupation { list_occupationID = 26, value = "Trader", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Occupation { list_occupationID = 27, value = "Unemployed", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Occupation { list_occupationID = 28, value = "Vet", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Occupation { list_occupationID = 29, value = "Waiter", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Occupation { list_occupationID = 30, value = "Zoo keeper", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Occupation { list_occupationID = 31, value = "Artist", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Occupation { list_occupationID = 32, value = "Scientist", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Occupation { list_occupationID = 33, value = "Singer", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Occupation { list_occupationID = 34, value = "Policeman", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Occupation { list_occupationID = 35, value = "Actor", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Occupation { list_occupationID = 36, value = "Professor", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Occupation { list_occupationID = 37, value = "Florist", createdDateTime = cuDT, updatedDateTime = cuDT }
            );

            // List_Pet
            modelBuilder.Entity<List_Pet>().HasData(
                new List_Pet { list_petID = 1, value = "Bird", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Pet { list_petID = 2, value = "Cat", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Pet { list_petID = 3, value = "Dog", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Pet { list_petID = 4, value = "Fish", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Pet { list_petID = 5, value = "Hamster", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Pet { list_petID = 6, value = "Rabbit", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Pet { list_petID = 7, value = "Guinea Pig", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Pet { list_petID = 8, value = "Hedgehog", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Pet { list_petID = 9, value = "Tortoise", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Pet { list_petID = 10, value = "Spider", createdDateTime = cuDT, updatedDateTime = cuDT }
            );

            // List_Prescription
            modelBuilder.Entity<List_Prescription>().HasData(
                new List_Prescription { list_prescriptionID = 1, value = "Acetaminophen", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Prescription { list_prescriptionID = 2, value = "Diphenhydramine", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Prescription { list_prescriptionID = 3, value = "Donepezil", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Prescription { list_prescriptionID = 4, value = "Galantamine", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Prescription { list_prescriptionID = 5, value = "Guaifenesin", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Prescription { list_prescriptionID = 6, value = "Ibuprofen", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Prescription { list_prescriptionID = 7, value = "Memantine", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Prescription { list_prescriptionID = 8, value = "Olanzapine", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Prescription { list_prescriptionID = 9, value = "Paracetamol", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Prescription { list_prescriptionID = 10, value = "Rivastigmine", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Prescription { list_prescriptionID = 11, value = "Salbutamol", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Prescription { list_prescriptionID = 12, value = "Antihistamines", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Prescription { list_prescriptionID = 13, value = "Dextromethorphan ", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Prescription { list_prescriptionID = 14, value = "Antihistamines", createdDateTime = cuDT, updatedDateTime = cuDT }
            );

            // List_ProblemLog
            modelBuilder.Entity<List_ProblemLog>().HasData(
                new List_ProblemLog { list_problemLogID = 1, value = "Behavior", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_ProblemLog { list_problemLogID = 2, value = "Communication", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_ProblemLog { list_problemLogID = 3, value = "Delusion", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_ProblemLog { list_problemLogID = 4, value = "Emotion", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_ProblemLog { list_problemLogID = 5, value = "Health", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_ProblemLog { list_problemLogID = 6, value = "Memory", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_ProblemLog { list_problemLogID = 7, value = "Sleep", createdDateTime = cuDT, updatedDateTime = cuDT }
            );

            // List_Relationship
            modelBuilder.Entity<List_Relationship>().HasData(
                new List_Relationship { list_relationshipID = 1, value = "Husband", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Relationship { list_relationshipID = 2, value = "Wife", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Relationship { list_relationshipID = 3, value = "Child", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Relationship { list_relationshipID = 4, value = "Parent", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Relationship { list_relationshipID = 5, value = "Sibling", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Relationship { list_relationshipID = 6, value = "Grandchild", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Relationship { list_relationshipID = 7, value = "Friend", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Relationship { list_relationshipID = 8, value = "Nephew", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Relationship { list_relationshipID = 9, value = "Niece", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Relationship { list_relationshipID = 10, value = "Aunt", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Relationship { list_relationshipID = 11, value = "Uncle", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Relationship { list_relationshipID = 12, value = "Grandparent", createdDateTime = cuDT, updatedDateTime = cuDT }
            );

            // List_Religion
            modelBuilder.Entity<List_Religion>().HasData(
                new List_Religion { list_religionID = 1, value = "Atheist", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Religion { list_religionID = 2, value = "Buddhist", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Religion { list_religionID = 3, value = "Catholic", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Religion { list_religionID = 4, value = "Christian", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Religion { list_religionID = 5, value = "Free Thinker", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Religion { list_religionID = 6, value = "Hindu", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Religion { list_religionID = 7, value = "Islam", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Religion { list_religionID = 8, value = "Taoist", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Religion { list_religionID = 9, value = "Shintoist", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Religion { list_religionID = 10, value = "Sikhism", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Religion { list_religionID = 11, value = "Shinto", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Religion { list_religionID = 12, value = "Spiritism", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Religion { list_religionID = 13, value = "Judaism", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Religion { list_religionID = 14, value = "Confucianism", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_Religion { list_religionID = 15, value = "Protestantism", createdDateTime = cuDT, updatedDateTime = cuDT }
            );

            // List_SecretQuestion
            modelBuilder.Entity<List_SecretQuestion>().HasData(
                new List_SecretQuestion { list_secretQuestionID = 1, value = "What was your childhood nickname?", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_SecretQuestion { list_secretQuestionID = 2, value = "What is the name of your favorite childhood friend?", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_SecretQuestion { list_secretQuestionID = 3, value = "In what city or town did your mother and father meet?", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_SecretQuestion { list_secretQuestionID = 4, value = "What is the middle name of your oldest child?", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_SecretQuestion { list_secretQuestionID = 5, value = "What is your favorite team?", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_SecretQuestion { list_secretQuestionID = 6, value = "What is your favorite movie?", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_SecretQuestion { list_secretQuestionID = 7, value = "What was your favorite sport in high school?", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_SecretQuestion { list_secretQuestionID = 8, value = "What was your favorite food as a child?", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_SecretQuestion { list_secretQuestionID = 9, value = "What is the first name of the boy or girl that you first kissed?", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_SecretQuestion { list_secretQuestionID = 10, value = "What was the make and model of your first car?", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_SecretQuestion { list_secretQuestionID = 11, value = "What was the name of the hospital where you were born?", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_SecretQuestion { list_secretQuestionID = 12, value = "Who is your childhood sports hero?", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_SecretQuestion { list_secretQuestionID = 13, value = "What school did you attend for sixth grade?", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_SecretQuestion { list_secretQuestionID = 14, value = "What was the last name of your third grade teacher?", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_SecretQuestion { list_secretQuestionID = 15, value = "In what town was your first job?", createdDateTime = cuDT, updatedDateTime = cuDT },
                new List_SecretQuestion { list_secretQuestionID = 16, value = "What was the name of the company where you had your first job?", createdDateTime = cuDT, updatedDateTime = cuDT }
            );


            // ------------------------------------ Managed By Developers

            // LogCategory
            modelBuilder.Entity<LogCategory>().HasData(
                new LogCategory { logCategoryID = 1, logCategoryName = Constants.LogCategory.User.SignIn, type = "User" },
                new LogCategory { logCategoryID = 2, logCategoryName = Constants.LogCategory.User.SignOut, type = "User" },
                new LogCategory { logCategoryID = 3, logCategoryName = Constants.LogCategory.User.SignInFailure, type = "User" },
                new LogCategory { logCategoryID = 4, logCategoryName = Constants.LogCategory.User.LockedOut, type = "User" },
                new LogCategory { logCategoryID = 5, logCategoryName = Constants.LogCategory.User.ForgetPassword, type = "User" },
                new LogCategory { logCategoryID = 6, logCategoryName = Constants.LogCategory.User.ResetPassword, type = "User" },
                new LogCategory { logCategoryID = 7, logCategoryName = Constants.LogCategory.User.PasswordChange, type = "User" },
                new LogCategory { logCategoryID = 8, logCategoryName = Constants.LogCategory.User.NewAccount, type = "User" },
                new LogCategory { logCategoryID = 9, logCategoryName = Constants.LogCategory.User.UpdateAccount, type = "User" },
                new LogCategory { logCategoryID = 10, logCategoryName = Constants.LogCategory.User.DeleteAccount, type = "User" },
                new LogCategory { logCategoryID = 11, logCategoryName = Constants.LogCategory.User.NewUserType, type = "User" },
                new LogCategory { logCategoryID = 12, logCategoryName = Constants.LogCategory.User.InvalidSecretAnswer, type = "User" },
                new LogCategory { logCategoryID = 13, logCategoryName = Constants.LogCategory.CareCentre.NewCareCentre, type = "CareCentre" },
                new LogCategory { logCategoryID = 14, logCategoryName = Constants.LogCategory.CareCentre.UpdateCareCentre, type = "CareCentre" },
                new LogCategory { logCategoryID = 15, logCategoryName = Constants.LogCategory.Patient.Create, type = "Patient" },
                new LogCategory { logCategoryID = 16, logCategoryName = Constants.LogCategory.Patient.Update, type = "Patient" },
                new LogCategory { logCategoryID = 17, logCategoryName = Constants.LogCategory.Patient.Delete, type = "Patient" },
                new LogCategory { logCategoryID = 18, logCategoryName = Constants.LogCategory.Patient.ReadNRIC, type = "Patient" },
                new LogCategory { logCategoryID = 19, logCategoryName = Constants.LogCategory.Patient.GenerateScheduleWeekly, type = "Patient" },
                new LogCategory { logCategoryID = 20, logCategoryName = Constants.LogCategory.Patient.GenerateScheduleDaily, type = "Patient" },
                new LogCategory { logCategoryID = 21, logCategoryName = Constants.LogCategory.Patient.ExportSchedule, type = "Patient" },
                new LogCategory { logCategoryID = 22, logCategoryName = Constants.LogCategory.List.Create, type = "List" },
                new LogCategory { logCategoryID = 23, logCategoryName = Constants.LogCategory.List.Update, type = "List" },
                new LogCategory { logCategoryID = 24, logCategoryName = Constants.LogCategory.List.Delete, type = "List" }
            );

            // HighlightType
            modelBuilder.Entity<HighlightType>().HasData(
                new HighlightType { highlightTypeID = 1, highlightType = "newPrescription", createdDateTime = cuDT, updatedDateTime = cuDT },
                new HighlightType { highlightTypeID = 2, highlightType = "newAllergy", createdDateTime = cuDT, updatedDateTime = cuDT },
                new HighlightType { highlightTypeID = 3, highlightType = "newActivityExclusion", createdDateTime = cuDT, updatedDateTime = cuDT },
                new HighlightType { highlightTypeID = 4, highlightType = "abnormalVital", createdDateTime = cuDT, updatedDateTime = cuDT },
                new HighlightType { highlightTypeID = 5, highlightType = "problem", createdDateTime = cuDT, updatedDateTime = cuDT }
            );

            // ---------------------------------- Administrator Manageable

            // VitalThreshold
            modelBuilder.Entity<VitalThreshold>().HasData(
                new VitalThreshold { vitalThresholdID = 1, category = "temperature", minValue = 35, maxValue = 38, createdDateTime = cuDT, updatedDateTime = cuDT },
                new VitalThreshold { vitalThresholdID = 2, category = "systolicBP", minValue = 91, maxValue = 140, createdDateTime = cuDT, updatedDateTime = cuDT },
                new VitalThreshold { vitalThresholdID = 3, category = "diastolicBP", minValue = 61, maxValue = 90, createdDateTime = cuDT, updatedDateTime = cuDT },
                new VitalThreshold { vitalThresholdID = 4, category = "spO2", minValue = 95, maxValue = 100, createdDateTime = cuDT, updatedDateTime = cuDT },
                new VitalThreshold { vitalThresholdID = 5, category = "bslBeforeMeal", minValue = 6, maxValue = 10, createdDateTime = cuDT, updatedDateTime = cuDT },
                new VitalThreshold { vitalThresholdID = 6, category = "bslAfterMeal", minValue = 7, maxValue = 13, createdDateTime = cuDT, updatedDateTime = cuDT },
                new VitalThreshold { vitalThresholdID = 7, category = "heartRate", minValue = 60, maxValue = 80, createdDateTime = cuDT, updatedDateTime = cuDT }
            );


            // PrivacySetting
            modelBuilder.Entity<PrivacySetting>().HasData(
                new PrivacySetting { privacySettingID = 1, socialHistoryItem = "sexuallyActive", isSensitive = true, createdDateTime = cuDT, updatedDateTime = cuDT },
                new PrivacySetting { privacySettingID = 2, socialHistoryItem = "secondhandSmoker", isSensitive = true, createdDateTime = cuDT, updatedDateTime = cuDT },
                new PrivacySetting { privacySettingID = 3, socialHistoryItem = "alcoholUse", isSensitive = true, createdDateTime = cuDT, updatedDateTime = cuDT },
                new PrivacySetting { privacySettingID = 4, socialHistoryItem = "caffeineUse", isSensitive = false, createdDateTime = cuDT, updatedDateTime = cuDT },
                new PrivacySetting { privacySettingID = 5, socialHistoryItem = "tobaccoUse", isSensitive = true, createdDateTime = cuDT, updatedDateTime = cuDT },
                new PrivacySetting { privacySettingID = 6, socialHistoryItem = "drugUse", isSensitive = true, createdDateTime = cuDT, updatedDateTime = cuDT },
                new PrivacySetting { privacySettingID = 7, socialHistoryItem = "exercise", isSensitive = false, createdDateTime = cuDT, updatedDateTime = cuDT },
                new PrivacySetting { privacySettingID = 8, socialHistoryItem = "dietListID", isSensitive = false, createdDateTime = cuDT, updatedDateTime = cuDT },
                new PrivacySetting { privacySettingID = 9, socialHistoryItem = "religionListID", isSensitive = false, createdDateTime = cuDT, updatedDateTime = cuDT },
                new PrivacySetting { privacySettingID = 10, socialHistoryItem = "petListID", isSensitive = false, createdDateTime = cuDT, updatedDateTime = cuDT },
                new PrivacySetting { privacySettingID = 11, socialHistoryItem = "occupationListID", isSensitive = false, createdDateTime = cuDT, updatedDateTime = cuDT },
                new PrivacySetting { privacySettingID = 12, socialHistoryItem = "educationListID", isSensitive = false, createdDateTime = cuDT, updatedDateTime = cuDT },
                new PrivacySetting { privacySettingID = 13, socialHistoryItem = "liveWithListID", isSensitive = false, createdDateTime = cuDT, updatedDateTime = cuDT }
            );


            // NotificationHandlers
            modelBuilder.Entity<NotificationHandler>().HasData(
                // g -> s
                new NotificationHandler { notificationHandlerID = 1, scenario = 1, maxNoOfSteps = 1, step = "1", senderTypeID = Constants.Role.Guardian, intendedUserType = Constants.Role.Supervisor, responseRequired = "no", responseOptions = null, nextStep = "end", message = "FYI: Guardian <Name> has updated <value> for Patient <PName>" },
                // cg -> s -> a:cg / r:cg
                new NotificationHandler { notificationHandlerID = 2, scenario = 2, maxNoOfSteps = 3, step = "1", senderTypeID = Constants.Role.Caregiver, intendedUserType = Constants.Role.Supervisor, responseRequired = "yes", responseOptions = "Accept/Reject", nextStep = "Accept:2/Reject:3", message = "Caregiver <Name> has requested to <add/update/delete> <value> for Patient <PName>" },
                new NotificationHandler { notificationHandlerID = 3, scenario = 2, maxNoOfSteps = 3, step = "2", senderTypeID = Constants.Role.Supervisor, intendedUserType = Constants.Role.Caregiver, responseRequired = "no", responseOptions = null, nextStep = "end", message = "FYI: Your request to <add/update/delete> <value> for Patient <PName> has been accepted by Supervisor <Name>" },
                new NotificationHandler { notificationHandlerID = 4, scenario = 2, maxNoOfSteps = 3, step = "3", senderTypeID = Constants.Role.Supervisor, intendedUserType = Constants.Role.Caregiver, responseRequired = "no", responseOptions = null, nextStep = "end", message = "FYI: Your request to <add/update/delete> <value> for Patient <PName> has been rejected by Supervisor <Name> due to <rejectReason>" },
                // cg -> sa -> r:cg (if accept self switch to scenario 2)
                new NotificationHandler { notificationHandlerID = 21, scenario = 7, maxNoOfSteps = 2, step = "1", senderTypeID = Constants.Role.Caregiver, intendedUserType = Constants.Role.Administrator, responseRequired = "yes", responseOptions = "Accept/Reject", nextStep = "Accept:end/Reject:2", message = "Caregiver <Name> has requested to add <value>" },
                new NotificationHandler { notificationHandlerID = 22, scenario = 7, maxNoOfSteps = 2, step = "2", senderTypeID = Constants.Role.Administrator, intendedUserType = Constants.Role.Caregiver, responseRequired = "no", responseOptions = null, nextStep = "end", message = "FYI: Your request to add <value> for Patient <PName> is rejected by Administrator <Name> due to <rejectReason>" },
                // s -> sa -> a:s / r:s
                new NotificationHandler { notificationHandlerID = 23, scenario = 8, maxNoOfSteps = 3, step = "1", senderTypeID = Constants.Role.Supervisor, intendedUserType = Constants.Role.Administrator, responseRequired = "yes", responseOptions = "Accept/Reject", nextStep = "Accept:2/Reject:3", message = "Supervisor <Name> has requested to add <value>" },
                new NotificationHandler { notificationHandlerID = 24, scenario = 8, maxNoOfSteps = 3, step = "2", senderTypeID = Constants.Role.Administrator, intendedUserType = Constants.Role.Supervisor, responseRequired = "no", responseOptions = null, nextStep = "end", message = "FYI: Your request to add <value> has been accepted by Administrator <Name>" },
                new NotificationHandler { notificationHandlerID = 25, scenario = 8, maxNoOfSteps = 3, step = "3", senderTypeID = Constants.Role.Administrator, intendedUserType = Constants.Role.Supervisor, responseRequired = "no", responseOptions = null, nextStep = "end", message = "FYI: Your request to add <value> has been rejected by Administrator <Name> due to <rejectReason>" },
                // game
                new NotificationHandler { notificationHandlerID = 5, scenario = 3, maxNoOfSteps = 7, step = "1", senderTypeID = Constants.Role.Doctor, intendedUserType = Constants.Role.Supervisor, responseRequired = "yes", responseOptions = "Reject/Accept but GT cannot modify/Accept and GT may modify", nextStep = "Reject:2/Accept but GT cannot modify:4/Accept and GT may modify:6", message = "Doctor <Name> has recommended <value> for Patient <PName>" },
                new NotificationHandler { notificationHandlerID = 6, scenario = 3, maxNoOfSteps = 7, step = "2", senderTypeID = Constants.Role.Supervisor, intendedUserType = Constants.Role.Doctor, responseRequired = "no", responseOptions = null, nextStep = "3", message = "FYI: Your <value> recommendation for Patient <PName> is rejected by Supervisor <Name> due to <rejectReason>" },
                new NotificationHandler { notificationHandlerID = 7, scenario = 3, maxNoOfSteps = 7, step = "3", senderTypeID = Constants.Role.Supervisor, intendedUserType = Constants.Role.GameTherapist, responseRequired = "no", responseOptions = null, nextStep = "end", message = "FYI: Doctor’s <value> recommendation for Patient <PName> is rejected by Supervisor <Name> due to <rejectReason>" },
                new NotificationHandler { notificationHandlerID = 8, scenario = 3, maxNoOfSteps = 7, step = "4", senderTypeID = Constants.Role.Supervisor, intendedUserType = Constants.Role.Doctor, responseRequired = "no", responseOptions = null, nextStep = "5", message = "FYI: Your <value> recommendation for Patient <PName> is accepted by Supervisor <Name>" },
                new NotificationHandler { notificationHandlerID = 9, scenario = 3, maxNoOfSteps = 7, step = "5", senderTypeID = Constants.Role.Supervisor, intendedUserType = Constants.Role.GameTherapist, responseRequired = "no", responseOptions = null, nextStep = "end", message = "FYI: Doctor’s <value> recommendation for Patient <PName> is accepted by Supervisor <Name>" },
                new NotificationHandler { notificationHandlerID = 10, scenario = 3, maxNoOfSteps = 7, step = "6", senderTypeID = Constants.Role.Supervisor, intendedUserType = Constants.Role.Doctor, responseRequired = "no", responseOptions = null, nextStep = "7", message = "FYI: Your <value> recommendation for Patient <PName> is accepted by Supervisor <Name> and forwarded to Game Therapist" },
                new NotificationHandler { notificationHandlerID = 11, scenario = 3, maxNoOfSteps = 7, step = "7", senderTypeID = Constants.Role.Supervisor, intendedUserType = Constants.Role.GameTherapist, responseRequired = "no", responseOptions = null, nextStep = "end", message = "Doctor’s <value> recommendation for Patient <PName> is accepted by Supervisor <Name> for your endorsement" },
                new NotificationHandler { notificationHandlerID = 12, scenario = 4, maxNoOfSteps = 2, step = "1", senderTypeID = Constants.Role.GameTherapist, intendedUserType = Constants.Role.Supervisor, responseRequired = "no", responseOptions = null, nextStep = "2", message = "FYI: Doctor’s <value> recommendation for Patient <PName> is supported by Game Therapist <Name>" },
                new NotificationHandler { notificationHandlerID = 13, scenario = 4, maxNoOfSteps = 2, step = "2", senderTypeID = Constants.Role.GameTherapist, intendedUserType = Constants.Role.Doctor, responseRequired = "no", responseOptions = null, nextStep = "end", message = "FYI: Your <value> recommendation for Patient <PName> is supported by Game Therapist <Name>" },
                new NotificationHandler { notificationHandlerID = 14, scenario = 5, maxNoOfSteps = 2, step = "1", senderTypeID = Constants.Role.GameTherapist, intendedUserType = Constants.Role.Supervisor, responseRequired = "no", responseOptions = null, nextStep = "2", message = "FYI: Doctor’s <value> recommendation for Patient <PName> is objected by Game Therapist <Name>" },
                new NotificationHandler { notificationHandlerID = 15, scenario = 5, maxNoOfSteps = 2, step = "2", senderTypeID = Constants.Role.GameTherapist, intendedUserType = Constants.Role.Doctor, responseRequired = "no", responseOptions = null, nextStep = "end", message = "FYI: Your <value> recommendation for Patient <PName> is objected by Game Therapist <Name>" },
                new NotificationHandler { notificationHandlerID = 16, scenario = 6, maxNoOfSteps = 5, step = "1", senderTypeID = Constants.Role.GameTherapist, intendedUserType = Constants.Role.Supervisor, responseRequired = "yes", responseOptions = "Accept/Reject", nextStep = "Accept:2/Reject:4", message = "Game Therapist <Name> has modified Doctor’s recommendation to <value> for Patient <PName>" },
                new NotificationHandler { notificationHandlerID = 17, scenario = 6, maxNoOfSteps = 5, step = "2", senderTypeID = Constants.Role.Supervisor, intendedUserType = Constants.Role.GameTherapist, responseRequired = "no", responseOptions = null, nextStep = "3", message = "FYI: Your <value> modification for Patient <PName> is accepted by Supervisor <Name>" },
                new NotificationHandler { notificationHandlerID = 18, scenario = 6, maxNoOfSteps = 5, step = "3", senderTypeID = Constants.Role.Supervisor, intendedUserType = Constants.Role.Doctor, responseRequired = "no", responseOptions = null, nextStep = "end", message = "FYI: Game Therapist’s <value> modification for Patient <PName> is accepted by Supervisor <Name>" },
                new NotificationHandler { notificationHandlerID = 19, scenario = 6, maxNoOfSteps = 5, step = "4", senderTypeID = Constants.Role.Supervisor, intendedUserType = Constants.Role.GameTherapist, responseRequired = "no", responseOptions = null, nextStep = "5", message = "FYI: Your <value> modification for Patient <PName> is rejected by Supervisor <Name> due to <rejectReason>" },
                new NotificationHandler { notificationHandlerID = 20, scenario = 6, maxNoOfSteps = 5, step = "5", senderTypeID = Constants.Role.Supervisor, intendedUserType = Constants.Role.Doctor, responseRequired = "no", responseOptions = null, nextStep = "end", message = "FYI: Game Therapist’s <value> modification for Patient <PName> is rejected by Supervisor <Name> due to <rejectReason>" }
            );

            // ----------------------- Data Seeding for Testing -----------------------

            // CareCentreAttribute
            modelBuilder.Entity<CareCentreAttribute>().HasData(
                new CareCentreAttribute
                {
                    centreID = 1,
                    centreName = "PErson-centred-cARe",
                    centreAddress = "NTU, 50 Nanyang Avenue",
                    centrePostalCode = "639798",
                    centreEmail = "pear@pear.com",
                    centreContactNo = "91234567",
                    countryListID = 80, // Singapore
                    devicesAvailable = 2,
                    createdDateTime = cuDT,
                    updatedDateTime = cuDT,
                }
            );

            // CareCentreHour
            DateTime oH = DateTime.MinValue.Date.Add(new TimeSpan(9, 0, 0));
            DateTime cH = DateTime.MinValue.Date.Add(new TimeSpan(17, 0, 0));

            modelBuilder.Entity<CareCentreHour>().HasData(
                new CareCentreHour { centreHoursID = 1, centreID = 1, centreWorkingDay = "Monday", centreOpeningHours = oH, centreClosingHours = cH, createdDateTime = cuDT, updatedDateTime = cuDT },
                new CareCentreHour { centreHoursID = 2, centreID = 1, centreWorkingDay = "Tuesday", centreOpeningHours = oH, centreClosingHours = cH, createdDateTime = cuDT, updatedDateTime = cuDT },
                new CareCentreHour { centreHoursID = 3, centreID = 1, centreWorkingDay = "Wednesday", centreOpeningHours = oH, centreClosingHours = cH, createdDateTime = cuDT, updatedDateTime = cuDT },
                new CareCentreHour { centreHoursID = 4, centreID = 1, centreWorkingDay = "Thursday", centreOpeningHours = oH, centreClosingHours = cH, createdDateTime = cuDT, updatedDateTime = cuDT },
                new CareCentreHour { centreHoursID = 5, centreID = 1, centreWorkingDay = "Friday", centreOpeningHours = oH, centreClosingHours = cH, createdDateTime = cuDT, updatedDateTime = cuDT }
            );

            var imageUrl = $"/Images/profilePicture.jpg"; // this will create a string link.

            // Patient
            modelBuilder.Entity<Patient>().HasData(
                new Patient { patientID = 1, firstName = "Alice", lastName = "Lee", nric = "S1234567D", address = "71 KAMPONG BAHRU ROAD 169373, Singapore", tempAddress = null, homeNo = "6563252633", handphoneNo = "6563332633", gender = "F", DOB = new DateTime(1980, 1, 1), preferredName = "Alice", preferredLanguageListID = 1, privacyBit = false, updateBit = false, autoGame = false, startDate = new DateTime(2021, 1, 1), endDate = null, terminationReason = null, isActive = true, inactiveReason = null, inactiveDate = new DateTime(2021, 1, 1), isRespiteCare = false, profilePicture = imageUrl, isDeleted = false, createdDateTime = cuDT, updatedDateTime = cuDT },
                new Patient { patientID = 2, firstName = "Yan", lastName = "Yi", nric = "S5090148C", address = "10 Anson Road #30-08 INTERNATIONAL PLAZA, 079903, Singapore", tempAddress = null, homeNo = "62260712", handphoneNo = "62261758", gender = "F", DOB = new DateTime(1980, 2, 2), preferredName = "YY", preferredLanguageListID = 2, privacyBit = false, updateBit = false, autoGame = false, startDate = new DateTime(2021, 1, 1), endDate = null, terminationReason = null, isActive = true, inactiveReason = null, inactiveDate = new DateTime(2021, 1, 1), isRespiteCare = false, profilePicture = imageUrl, isDeleted = false, createdDateTime = cuDT, updatedDateTime = cuDT },
                new Patient { patientID = 3, firstName = "Jon", lastName = "Ong", nric = "S6421300H", address = "Blk 3007 Ubi Rd 1 05-412, 406701, Singapore", tempAddress = null, homeNo = "67485000", handphoneNo = "67489859", gender = "M", DOB = new DateTime(1980, 3, 3), preferredName = "Jon", preferredLanguageListID = 3, privacyBit = false, updateBit = false, autoGame = false, startDate = new DateTime(2021, 1, 1), endDate = null, terminationReason = null, isActive = true, inactiveReason = null, inactiveDate = new DateTime(2021, 1, 1), isRespiteCare = false, profilePicture = imageUrl, isDeleted = false, createdDateTime = cuDT, updatedDateTime = cuDT },
                new Patient { patientID = 4, firstName = "Bi", lastName = "Gong", nric = "S7866443F", address = "41 Sungei Kadut Loop S 729509, Singapore", tempAddress = "42 Sungei Kadut Loop S 729509, Singapore", homeNo = "98123120", handphoneNo = "98123133", gender = "M", DOB = new DateTime(1980, 4, 4), preferredName = "Bi", preferredLanguageListID = 4, privacyBit = false, updateBit = false, autoGame = false, startDate = new DateTime(2021, 1, 1), endDate = null, terminationReason = null, isActive = true, inactiveReason = null, inactiveDate = new DateTime(2021, 1, 1), isRespiteCare = false, profilePicture = imageUrl, isDeleted = false, createdDateTime = cuDT, updatedDateTime = cuDT },
                new Patient { patientID = 5, firstName = "Jeline", lastName = "Mao", nric = "S5862481J", address = "20 Cecil Street #16-04 EQUITY PLAZA, 049705, Singapore", tempAddress = null, homeNo = "92312811", handphoneNo = "92222811", gender = "F", DOB = new DateTime(1980, 5, 5), preferredName = "Jeline", preferredLanguageListID = 5, privacyBit = false, updateBit = false, autoGame = false, startDate = new DateTime(2021, 1, 1), endDate = null, terminationReason = null, isActive = true, inactiveReason = null, inactiveDate = new DateTime(2021, 1, 1), isRespiteCare = false, profilePicture = imageUrl, isDeleted = false, createdDateTime = cuDT, updatedDateTime = cuDT }
                );

            // Guardian
            modelBuilder.Entity<Guardian>().HasData(
                new Guardian { guardianID = 1, guardianName = "Tommy Lee", guardianContactNo = "97753383", guardianNRIC = "S7719748F", guardianEmail = "tommylee111@gmail.com", guardianRelationshipID = 1, isActive = true, isDeleted = false, createdDateTime = cuDT, updatedDateTime = cuDT },
                new Guardian { guardianID = 2, guardianName = "Ying Yi", guardianContactNo = "91234568", guardianNRIC = "S5157772H", guardianEmail = "yingyi222@gmail.com", guardianRelationshipID = 2, isActive = true, isDeleted = false, createdDateTime = cuDT, updatedDateTime = cuDT },
                new Guardian { guardianID = 3, guardianName = "Dawn Ong", guardianContactNo = "9812316", guardianNRIC = "S4910818D", guardianEmail = "dawnong333@gmail.com", guardianRelationshipID = 3, isActive = true, isDeleted = false, createdDateTime = cuDT, updatedDateTime = cuDT },
                new Guardian { guardianID = 4, guardianName = "Hilda Gong", guardianContactNo = "98123912", guardianNRIC = "S1295237F", guardianEmail = "hildagong444@gmail.com", guardianRelationshipID = 4, isActive = true, isDeleted = false, createdDateTime = cuDT, updatedDateTime = cuDT },
                new Guardian { guardianID = 5, guardianName = "Charissa Mao", guardianContactNo = "98231391", guardianNRIC = "S4201328E", guardianEmail = "charissamao555@gmail.com", guardianRelationshipID = 5, isActive = true, isDeleted = false, createdDateTime = cuDT, updatedDateTime = cuDT }
                );

            // Patient Allocation
            modelBuilder.Entity<PatientAllocation>().HasData(
                new PatientAllocation { patientAllocationID = 1, patientID = 1, doctorID = doctorUserId, gametherapistID = gameTherapistUserId, caregiverID = caregiverUserId, guardianID = 1, supervisorID = supervisorUserId, tempDoctorID = null, tempCaregiverID = null, guardian2ID = null, isDeleted = false, createdDateTime = cuDT, updatedDateTime = cuDT },
                new PatientAllocation { patientAllocationID = 2, patientID = 2, doctorID = doctorUserId, gametherapistID = gameTherapistUserId, caregiverID = caregiverUserId, guardianID = 2, supervisorID = supervisorUserId, tempDoctorID = null, tempCaregiverID = null, guardian2ID = null, isDeleted = false, createdDateTime = cuDT, updatedDateTime = cuDT },
                new PatientAllocation { patientAllocationID = 3, patientID = 3, doctorID = doctorUserId, gametherapistID = gameTherapistUserId, caregiverID = caregiverUserId, guardianID = 3, supervisorID = supervisorUserId, tempDoctorID = null, tempCaregiverID = null, guardian2ID = null, isDeleted = false, createdDateTime = cuDT, updatedDateTime = cuDT },
                new PatientAllocation { patientAllocationID = 4, patientID = 4, doctorID = doctorUserId, gametherapistID = gameTherapistUserId, caregiverID = caregiverUserId, guardianID = 4, supervisorID = supervisorUserId, tempDoctorID = null, tempCaregiverID = null, guardian2ID = null, isDeleted = false, createdDateTime = cuDT, updatedDateTime = cuDT },
                new PatientAllocation { patientAllocationID = 5, patientID = 5, doctorID = doctorUserId, gametherapistID = gameTherapistUserId, caregiverID = caregiverUserId, guardianID = 5, supervisorID = supervisorUserId, tempDoctorID = null, tempCaregiverID = null, guardian2ID = null, isDeleted = false, createdDateTime = cuDT, updatedDateTime = cuDT }
                );

            // Social History
            modelBuilder.Entity<SocialHistory>().HasData(
                new SocialHistory { socialHistoryID = 1, patientAllocationID = 1, sexuallyActive = false, secondhandSmoker = false, alcoholUse = false, caffeineUse = false, tobaccoUse = false, drugUse = false, exercise = false, dietListID = 1, religionListID = 1, petListID = 1, occupationListID = 1, educationListID = 1, liveWithListID = 1, isDeleted = false, createdDateTime = cuDT, updatedDateTime = cuDT },
                new SocialHistory { socialHistoryID = 2, patientAllocationID = 2, sexuallyActive = false, secondhandSmoker = false, alcoholUse = true, caffeineUse = false, tobaccoUse = false, drugUse = false, exercise = true, dietListID = 2, religionListID = 2, petListID = 1, occupationListID = 2, educationListID = 3, liveWithListID = 2, isDeleted = false, createdDateTime = cuDT, updatedDateTime = cuDT },
                new SocialHistory { socialHistoryID = 3, patientAllocationID = 3, sexuallyActive = true, secondhandSmoker = true, alcoholUse = false, caffeineUse = false, tobaccoUse = false, drugUse = false, exercise = false, dietListID = 3, religionListID = 3, petListID = 1, occupationListID = 2, educationListID = 2, liveWithListID = 2, isDeleted = false, createdDateTime = cuDT, updatedDateTime = cuDT },
                new SocialHistory { socialHistoryID = 4, patientAllocationID = 4, sexuallyActive = false, secondhandSmoker = false, alcoholUse = false, caffeineUse = false, tobaccoUse = false, drugUse = false, exercise = false, dietListID = 4, religionListID = 4, petListID = 1, occupationListID = 2, educationListID = 4, liveWithListID = 2, isDeleted = false, createdDateTime = cuDT, updatedDateTime = cuDT },
                new SocialHistory { socialHistoryID = 5, patientAllocationID = 5, sexuallyActive = false, secondhandSmoker = false, alcoholUse = false, caffeineUse = false, tobaccoUse = false, drugUse = true, exercise = true, dietListID = 5, religionListID = 5, petListID = 1, occupationListID = 2, educationListID = 5, liveWithListID = 2, isDeleted = false, createdDateTime = cuDT, updatedDateTime = cuDT }
                );

            // Patient Assigned Dementia
            modelBuilder.Entity<PatientAssignedDementia>().HasData(
               new PatientAssignedDementia { padID = 1, patientAllocationID = 1, dementiaTypeListID = 1, isDeleted = false, createdDateTime = cuDT, updatedDateTime = cuDT },
               new PatientAssignedDementia { padID = 2, patientAllocationID = 2, dementiaTypeListID = 2, isDeleted = false, createdDateTime = cuDT, updatedDateTime = cuDT },
               new PatientAssignedDementia { padID = 3, patientAllocationID = 3, dementiaTypeListID = 3, isDeleted = false, createdDateTime = cuDT, updatedDateTime = cuDT },
               new PatientAssignedDementia { padID = 4, patientAllocationID = 4, dementiaTypeListID = 4, isDeleted = false, createdDateTime = cuDT, updatedDateTime = cuDT },
               new PatientAssignedDementia { padID = 5, patientAllocationID = 5, dementiaTypeListID = 5, isDeleted = false, createdDateTime = cuDT, updatedDateTime = cuDT },
               new PatientAssignedDementia { padID = 6, patientAllocationID = 1, dementiaTypeListID = 17, isDeleted = false, createdDateTime = cuDT, updatedDateTime = cuDT }
               );

            // Mobility
            modelBuilder.Entity<Mobility>().HasData(
               new Mobility { mobilityID = 1, patientAllocationID = 1, mobilityListID = 1, isDeleted = false, createdDateTime = cuDT, updatedDateTime = cuDT },
               new Mobility { mobilityID = 2, patientAllocationID = 2, mobilityListID = 2, isDeleted = false, createdDateTime = cuDT, updatedDateTime = cuDT },
               new Mobility { mobilityID = 3, patientAllocationID = 3, mobilityListID = 3, isDeleted = false, createdDateTime = cuDT, updatedDateTime = cuDT },
               new Mobility { mobilityID = 4, patientAllocationID = 4, mobilityListID = 4, isDeleted = false, createdDateTime = cuDT, updatedDateTime = cuDT },
               new Mobility { mobilityID = 5, patientAllocationID = 5, mobilityListID = 5, isDeleted = false, createdDateTime = cuDT, updatedDateTime = cuDT }
               );

            // Allergy
            modelBuilder.Entity<Allergy>().HasData(
               new Allergy { allergyID = 1, patientAllocationID = 1, allergyListID = 1, allergyReactionListID = 1, allergyRemarks = "Not well", isDeleted = false, createdDateTime = cuDT, updatedDateTime = cuDT },
               new Allergy { allergyID = 2, patientAllocationID = 2, allergyListID = 2, allergyReactionListID = 2, allergyRemarks = "In serious condition", isDeleted = false, createdDateTime = cuDT, updatedDateTime = cuDT },
               new Allergy { allergyID = 3, patientAllocationID = 3, allergyListID = 3, allergyReactionListID = 3, allergyRemarks = "Ok", isDeleted = false, createdDateTime = cuDT, updatedDateTime = cuDT },
               new Allergy { allergyID = 4, patientAllocationID = 4, allergyListID = 4, allergyReactionListID = 4, allergyRemarks = "See doctor", isDeleted = false, createdDateTime = cuDT, updatedDateTime = cuDT },
               new Allergy { allergyID = 5, patientAllocationID = 5, allergyListID = 5, allergyReactionListID = 5, allergyRemarks = "Sick", isDeleted = false, createdDateTime = cuDT, updatedDateTime = cuDT }
               );

            // Medical History
            modelBuilder.Entity<MedicalHistory>().HasData(
               new MedicalHistory { medicalHistoryID = 1, patientAllocationID = 1, medicalDetails = "Covid", informationSource = "Doctor", medicalRemarks = "Not well", medicalEstimatedDate = cuDT, isDeleted = false, createdDateTime = cuDT, updatedDateTime = cuDT },
               new MedicalHistory { medicalHistoryID = 2, patientAllocationID = 2, medicalDetails = "Fever", informationSource = "Child", medicalRemarks = "", medicalEstimatedDate = cuDT, isDeleted = false, createdDateTime = cuDT, updatedDateTime = cuDT },
               new MedicalHistory { medicalHistoryID = 3, patientAllocationID = 3, medicalDetails = "Fever", informationSource = "Child", medicalRemarks = "", medicalEstimatedDate = cuDT, isDeleted = false, createdDateTime = cuDT, updatedDateTime = cuDT },
               new MedicalHistory { medicalHistoryID = 4, patientAllocationID = 4, medicalDetails = "Fever", informationSource = "Guardian", medicalRemarks = "Ok", medicalEstimatedDate = cuDT, isDeleted = false, createdDateTime = cuDT, updatedDateTime = cuDT },
               new MedicalHistory { medicalHistoryID = 5, patientAllocationID = 5, medicalDetails = "Breathless", informationSource = "Doctor", medicalRemarks = "Ok", medicalEstimatedDate = cuDT, isDeleted = false, createdDateTime = cuDT, updatedDateTime = cuDT }
               );

            // Vital
            modelBuilder.Entity<Vital>().HasData(
               new Vital { vitalID = 1, patientAllocationID = 1, afterMeal = 1, temperature = (decimal)37, systolicBP = (int)50, diastolicBP = (int)50, heartRate = (int)80, spO2 = (int)80, bloodSugarlevel = (int)20, height = (decimal)1.80, weight = (decimal)45.0, vitalRemarks = "Well", isDeleted = false, createdDateTime = cuDT, updatedDateTime = cuDT },
               new Vital { vitalID = 2, patientAllocationID = 2, afterMeal = 0, temperature = (decimal)42, systolicBP = (int)20, diastolicBP = (int)20, heartRate = (int)80, spO2 = (int)30, bloodSugarlevel = (int)21, height = (decimal)1.55, weight = (decimal)80.0, vitalRemarks = "Not well", isDeleted = false, createdDateTime = cuDT, updatedDateTime = cuDT },
               new Vital { vitalID = 3, patientAllocationID = 3, afterMeal = 0, temperature = (decimal)37, systolicBP = (int)30, diastolicBP = (int)30, heartRate = (int)80, spO2 = (int)90, bloodSugarlevel = (int)30, height = (decimal)1.85, weight = (decimal)70.0, vitalRemarks = "Well", isDeleted = false, createdDateTime = cuDT, updatedDateTime = cuDT },
               new Vital { vitalID = 4, patientAllocationID = 4, afterMeal = 1, temperature = (decimal)50, systolicBP = (int)50, diastolicBP = (int)50, heartRate = (int)110, spO2 = (int)50, bloodSugarlevel = (int)55, height = (decimal)1.67, weight = (decimal)52.0, vitalRemarks = "Not well", isDeleted = false, createdDateTime = cuDT, updatedDateTime = cuDT },
               new Vital { vitalID = 5, patientAllocationID = 5, afterMeal = 1, temperature = (decimal)30, systolicBP = (int)60, diastolicBP = (int)60, heartRate = (int)90, spO2 = (int)30, bloodSugarlevel = (int)30, height = (decimal)1.70, weight = (decimal)60.0, vitalRemarks = "Well", isDeleted = false, createdDateTime = cuDT, updatedDateTime = cuDT }
               );

            // LikeDislike
            modelBuilder.Entity<LikeDislike>().HasData(
               new LikeDislike { likeDislikeID = 1, patientAllocationID = 1, likeDislikeListID = 1, isLike = true, isDeleted = false, createdDateTime = cuDT, updatedDateTime = cuDT },
               new LikeDislike { likeDislikeID = 2, patientAllocationID = 1, likeDislikeListID = 2, isLike = false, isDeleted = false, createdDateTime = cuDT, updatedDateTime = cuDT },
               new LikeDislike { likeDislikeID = 3, patientAllocationID = 2, likeDislikeListID = 1, isLike = true, isDeleted = false, createdDateTime = cuDT, updatedDateTime = cuDT },
               new LikeDislike { likeDislikeID = 4, patientAllocationID = 2, likeDislikeListID = 3, isLike = false, isDeleted = false, createdDateTime = cuDT, updatedDateTime = cuDT },
               new LikeDislike { likeDislikeID = 5, patientAllocationID = 3, likeDislikeListID = 4, isLike = true, isDeleted = false, createdDateTime = cuDT, updatedDateTime = cuDT },
               new LikeDislike { likeDislikeID = 6, patientAllocationID = 3, likeDislikeListID = 5, isLike = false, isDeleted = false, createdDateTime = cuDT, updatedDateTime = cuDT },
               new LikeDislike { likeDislikeID = 7, patientAllocationID = 4, likeDislikeListID = 5, isLike = true, isDeleted = false, createdDateTime = cuDT, updatedDateTime = cuDT },
               new LikeDislike { likeDislikeID = 8, patientAllocationID = 5, likeDislikeListID = 2, isLike = false, isDeleted = false, createdDateTime = cuDT, updatedDateTime = cuDT }
               );

            // Habit
            modelBuilder.Entity<Habit>().HasData(
               new Habit { habitID = 1, patientAllocationID = 1, habitListID = 1, isDeleted = false, createdDateTime = cuDT, updatedDateTime = cuDT },
               new Habit { habitID = 2, patientAllocationID = 2, habitListID = 2, isDeleted = false, createdDateTime = cuDT, updatedDateTime = cuDT },
               new Habit { habitID = 3, patientAllocationID = 3, habitListID = 3, isDeleted = false, createdDateTime = cuDT, updatedDateTime = cuDT },
               new Habit { habitID = 4, patientAllocationID = 4, habitListID = 4, isDeleted = false, createdDateTime = cuDT, updatedDateTime = cuDT },
               new Habit { habitID = 5, patientAllocationID = 5, habitListID = 5, isDeleted = false, createdDateTime = cuDT, updatedDateTime = cuDT }
               );

            // Hobby
            modelBuilder.Entity<Hobby>().HasData(
               new Hobby { hobbyID = 1, patientAllocationID = 1, hobbyListID = 1, isDeleted = false, createdDateTime = cuDT, updatedDateTime = cuDT },
               new Hobby { hobbyID = 2, patientAllocationID = 2, hobbyListID = 2, isDeleted = false, createdDateTime = cuDT, updatedDateTime = cuDT },
               new Hobby { hobbyID = 3, patientAllocationID = 3, hobbyListID = 3, isDeleted = false, createdDateTime = cuDT, updatedDateTime = cuDT },
               new Hobby { hobbyID = 4, patientAllocationID = 4, hobbyListID = 4, isDeleted = false, createdDateTime = cuDT, updatedDateTime = cuDT },
               new Hobby { hobbyID = 5, patientAllocationID = 5, hobbyListID = 5, isDeleted = false, createdDateTime = cuDT, updatedDateTime = cuDT }
               );
        }

        private const string adminUserId = "B22698B8-42A2-4115-9631-1C2D1E2AC5F7";
        private const string adminRoleId = "2301D884-221A-4E7D-B509-0113DCC043E1";
        private const string doctorUserId = "B22698B8-42A2-4115-9631-1C2D1E2AC5F6";
        private const string doctorRoleId = "7D9B7113-A8F8-4035-99A7-A20DD400F6A3";
        private const string supervisorUserId = "B22698B8-42A2-4115-9631-1C2D1E2AC5F4";
        private const string supervisorRoleId = "01B168FE-810B-432D-9010-233BA0B380E9";
        private const string guardianUserId = "B22698B8-42A2-4115-9631-1C2D1E2AC5F5";
        private const string guardianRoleId = "78A7570F-3CE5-48BA-9461-80283ED1D94D";
        private const string gameTherapistUserId = "B22698B8-42A2-4115-9631-1C2D1E2AC5F3";
        private const string gameTherapistRoleId = "01B168FD-810B-432D-9010-233BA0B380E7";
        private const string caregiverUserId = "B22698B8-42A2-4115-9631-1C2D1E2AC5F2";
        private const string caregiverRoleId = "01B168FD-810B-432D-9010-233BA0B380E6";

        public static string PassGenerate(ApplicationUser user, string password)
        {
            return new PasswordHasher<ApplicationUser>().HashPassword(user, password);
        }

        // AspNetRoles
        public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
        {
            public void Configure(EntityTypeBuilder<IdentityRole> builder)
            {
                builder.HasData(
                    new IdentityRole { Id = adminRoleId, Name = Constants.Role.Administrator, NormalizedName = "ADMINISTRATOR" },
                    new IdentityRole { Id = doctorRoleId, Name = Constants.Role.Doctor, NormalizedName = "DOCTOR" },
                    new IdentityRole { Id = guardianRoleId, Name = Constants.Role.Guardian, NormalizedName = "GUARDIAN" },
                    new IdentityRole { Id = supervisorRoleId, Name = Constants.Role.Supervisor, NormalizedName = "SUPERVISOR" },
                    new IdentityRole { Id = gameTherapistRoleId, Name = Constants.Role.GameTherapist, NormalizedName = "GAME THERAPIST" },
                    new IdentityRole { Id = caregiverRoleId, Name = Constants.Role.Caregiver, NormalizedName = "CAREGIVER" }
                );
            }
        }

        // AspNetUsers
        public class AdminConfiguration : IEntityTypeConfiguration<ApplicationUser>
        {
            public void Configure(EntityTypeBuilder<ApplicationUser> builder)
            {
                string name = "janice";
                string email = name + "@gmail.com";
                var admin = new ApplicationUser
                {
                    Id = adminUserId,
                    UserName = name,
                    NormalizedUserName = name.ToUpper(),
                    firstName = "Janice",
                    lastName = "Yak",
                    preferredName = "Ms Janice",
                    nric = "S6908885F",
                    Email = email,
                    NormalizedEmail = email.ToUpper(),
                    address = "238 Thomson Road #13-07 NOVENA SQUARE - TOWER A, 307684, Singapore",
                    DOB = new DateTime(1980, 1, 1),
                    roleId = adminRoleId,
                    gender = "F",
                    secretQuestionListID = 1,
                    secretAnswer = UserService.HashInput("janny"),
                    secretQuestion2ListID = 2,
                    secretAnswer2 = UserService.HashInput("janny"),
                    secondContactNo = "67646678",
                    allowNotification = true,
                    profilePicture = Constants.Image.placeholderURL,
                    lastPasswordChanged = cuDT,
                    loginTimeStamp = cuDT,
                    isActive = true,
                    isDeleted = false,
                    token = "3214"
                };
                admin.PasswordHash = PassGenerate(admin, "Admin!23");
                builder.HasData(admin);
            }
        }

        public class SupervisorConfiguration : IEntityTypeConfiguration<ApplicationUser>
        {
            public void Configure(EntityTypeBuilder<ApplicationUser> builder)
            {
                string name = "jess";
                string email = name + "@gmail.com";
                var supervisor = new ApplicationUser
                {
                    Id = supervisorUserId,
                    UserName = name,
                    NormalizedUserName = name.ToUpper(),
                    firstName = "Jessica",
                    lastName = "Sim",
                    preferredName = "jess",
                    nric = "S8156781F",
                    Email = email,
                    NormalizedEmail = email.ToUpper(),
                    address = "521 Woodlands Dr14 #02-343, 730521 Singapore, Singapore",
                    DOB = new DateTime(1980, 1, 1),
                    roleId = supervisorRoleId,
                    gender = "F",
                    secretQuestionListID = 7,
                    secretAnswer = UserService.HashInput("janny"),
                    secretQuestion2ListID = 8,
                    secretAnswer2 = UserService.HashInput("janny"),
                    secondContactNo = "67646678",
                    allowNotification = true,
                    profilePicture = Constants.Image.placeholderURL,
                    lastPasswordChanged = cuDT,
                    loginTimeStamp = cuDT,
                    isActive = true,
                    isDeleted = false,
                    token = "1234"
                };
                supervisor.PasswordHash = PassGenerate(supervisor, "Supervisor!23");
                builder.HasData(supervisor);
            }
        }

        public class DoctorConfiguration : IEntityTypeConfiguration<ApplicationUser>
        {
            public void Configure(EntityTypeBuilder<ApplicationUser> builder)
            {
                string name = "daniel";
                string email = name + "@gmail.com";
                var doctor = new ApplicationUser
                {
                    Id = doctorUserId,
                    UserName = name,
                    NormalizedUserName = name.ToUpper(),
                    firstName = "Daniel",
                    lastName = "Lee",
                    preferredName = "Daniel",
                    nric = "S8601320G",
                    Email = email,
                    NormalizedEmail = email.ToUpper(),
                    address = "10 Biopolis Way #03-03/04 CHROMOS, BIOPOLIS, 138670, Singapore",
                    DOB = new DateTime(1980, 1, 1),
                    roleId = doctorRoleId,
                    gender = "M",
                    secretQuestionListID = 3,
                    secretAnswer = UserService.HashInput("janny"),
                    secretQuestion2ListID = 4,
                    secretAnswer2 = UserService.HashInput("janny"),
                    secondContactNo = "95554111",
                    allowNotification = true,
                    profilePicture = Constants.Image.placeholderURL,
                    lastPasswordChanged = cuDT,
                    loginTimeStamp = cuDT,
                    isActive = true,
                    isDeleted = false,
                    token = "2341"
                };
                doctor.PasswordHash = PassGenerate(doctor, "Doctor!23");
                builder.HasData(doctor);
            }
        }

        public class GuardianConfiguration : IEntityTypeConfiguration<ApplicationUser>
        {
            public void Configure(EntityTypeBuilder<ApplicationUser> builder)
            {
                string name = "tpg1";
                string email = name + "@gmail.com";
                var guardian = new ApplicationUser
                {
                    Id = guardianUserId,
                    UserName = name,
                    NormalizedUserName = name.ToUpper(),
                    firstName = "tpg1",
                    lastName = "tpg1",
                    preferredName = "tpg1",
                    nric = "S1295237F",
                    Email = email,
                    NormalizedEmail = email.ToUpper(),
                    address = "235 Thomson Road #13-07 NOVENA SQUARE - TOWER A, 307684, Singapore",
                    DOB = new DateTime(1980, 1, 1),
                    roleId = guardianRoleId,
                    gender = "F",
                    secretQuestionListID = 5,
                    secretAnswer = UserService.HashInput("janny"),
                    secretQuestion2ListID = 6,
                    secretAnswer2 = UserService.HashInput("janny"),
                    secondContactNo = "98123912",
                    allowNotification = true,
                    profilePicture = Constants.Image.placeholderURL,
                    lastPasswordChanged = DateTime.Parse("1989-2-12"),
                    loginTimeStamp = DateTime.Parse("1989-2-12"),
                    isActive = true,
                    isDeleted = false,
                    token = "3411"
                };
                guardian.PasswordHash = PassGenerate(guardian, "Guardian!23");
                builder.HasData(guardian);
            }
        }

        public class GameTherapistConfiguration : IEntityTypeConfiguration<ApplicationUser>
        {
            public void Configure(EntityTypeBuilder<ApplicationUser> builder)
            {
                string name = "alan";
                string email = name + "@gmail.com";
                var gameTherapist = new ApplicationUser
                {
                    Id = gameTherapistUserId,
                    UserName = name,
                    NormalizedUserName = name.ToUpper(),
                    firstName = "Alan",
                    lastName = "Tan",
                    preferredName = "Alan",
                    nric = "S7538013E",
                    Email = email,
                    NormalizedEmail = email.ToUpper(),
                    address = "Block 51 Ayer Rajah Crescent 02-15/16 Singapore 139948, Singapore",
                    DOB = new DateTime(1980, 1, 1),
                    roleId = gameTherapistRoleId,
                    gender = "M",
                    secretQuestionListID = 9,
                    secretAnswer = UserService.HashInput("janny"),
                    secretQuestion2ListID = 10,
                    secretAnswer2 = UserService.HashInput("janny"),
                    secondContactNo = "67646678",
                    allowNotification = true,
                    profilePicture = Constants.Image.placeholderURL,
                    lastPasswordChanged = DateTime.Parse("1989-2-12"),
                    loginTimeStamp = DateTime.Parse("1989-2-12"),
                    isActive = true,
                    isDeleted = false,
                    token = "3412"
                };
                gameTherapist.PasswordHash = PassGenerate(gameTherapist, "Game!23");
                builder.HasData(gameTherapist);
            }
        }

        public class CaregiverConfiguration : IEntityTypeConfiguration<ApplicationUser>
        {
            public void Configure(EntityTypeBuilder<ApplicationUser> builder)
            {
                string name = "adeline";
                string email = name + "@gmail.com";
                var caregiver = new ApplicationUser
                {
                    Id = caregiverUserId,
                    UserName = name,
                    NormalizedUserName = name.ToUpper(),
                    firstName = "Adeline",
                    lastName = "Tan",
                    preferredName = "Ade",
                    nric = "S9094515G",
                    Email = email,
                    NormalizedEmail = email.ToUpper(),
                    address = "1002 Jalan Bukit Merah #02-01/03, 159456, Singapore",
                    DOB = new DateTime(1990, 1, 1),
                    roleId = caregiverRoleId,
                    gender = "F",
                    secretQuestionListID = 9,
                    secretAnswer = UserService.HashInput("janny"),
                    secretQuestion2ListID = 10,
                    secretAnswer2 = UserService.HashInput("janny"),
                    secondContactNo = "62708850",
                    allowNotification = true,
                    profilePicture = Constants.Image.placeholderURL,
                    lastPasswordChanged = DateTime.Parse("1989-2-12"),
                    loginTimeStamp = DateTime.Parse("1989-2-12"),
                    isActive = true,
                    isDeleted = false,
                    token = "4321"
                };
                caregiver.PasswordHash = PassGenerate(caregiver, "Caregiver!23");
                builder.HasData(caregiver);
            }
        }

        // User Role Linking
        public class AdminWithRolesConfig : IEntityTypeConfiguration<IdentityUserRole<string>>
        {
            public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
            {
                builder.HasData(new IdentityUserRole<string> { RoleId = adminRoleId, UserId = adminUserId });
            }
        }

        public class DoctorWithRolesConfig : IEntityTypeConfiguration<IdentityUserRole<string>>
        {
            public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
            {
                builder.HasData(new IdentityUserRole<string> { RoleId = doctorRoleId, UserId = doctorUserId });
            }
        }

        public class SupervisorWithRolesConfig : IEntityTypeConfiguration<IdentityUserRole<string>>
        {
            public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
            {
                builder.HasData(new IdentityUserRole<string> { RoleId = supervisorRoleId, UserId = supervisorUserId });
            }
        }

        public class GuardianWithRolesConfig : IEntityTypeConfiguration<IdentityUserRole<string>>
        {
            public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
            {
                builder.HasData(new IdentityUserRole<string> { RoleId = guardianRoleId, UserId = guardianUserId });
            }
        }

        public class GameTherapistWithRolesConfig : IEntityTypeConfiguration<IdentityUserRole<string>>
        {
            public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
            {
                builder.HasData(new IdentityUserRole<string> { RoleId = gameTherapistRoleId, UserId = gameTherapistUserId });
            }
        }

        public class CareGiverWithRolesConfig : IEntityTypeConfiguration<IdentityUserRole<string>>
        {
            public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
            {
                builder.HasData(new IdentityUserRole<string> { RoleId = caregiverRoleId, UserId = caregiverUserId });
            }
        }

    }
}

//    new LogCategory { logCategoryName = "Encountered error", type = "Error" },
//    new LogCategory { logCategoryName = "Successful login", type = "User" },
//    new LogCategory { logCategoryName = "Invalid login", type = "User" },
//    new LogCategory { logCategoryName = "New user type", type = "User" },
//    new LogCategory { logCategoryName = "New user account", type = "User" },
//    new LogCategory { logCategoryName = "Update user account", type = "User" },
//    new LogCategory { logCategoryName = "Update user password", type = "User" },
//    new LogCategory { logCategoryName = "Invalid secret answer", type = "User" },
//    new LogCategory { logCategoryName = "Deny new user account creation", type = "User" },
//    new LogCategory { logCategoryName = "Delete user account", type = "User" },
//    new LogCategory { logCategoryName = "Request for full RIC", type = "User" },
//    new LogCategory { logCategoryName = "New care centre", type = "Centre" },
//    new LogCategory { logCategoryName = "Update care centre", type = "Centre" },
//    new LogCategory { logCategoryName = "Weekly schedule generation", type = "Patient" },
//    new LogCategory { logCategoryName = "Daily schedule generation", type = "Patient" },
//    new LogCategory { logCategoryName = "New item", type = "Patient" },
//    new LogCategory { logCategoryName = "Update item", type = "Patient" },
//    new LogCategory { logCategoryName = "Delete item", type = "Patient" },
//    new LogCategory { logCategoryName = "New list item", type = "Patient" },
//    new LogCategory { logCategoryName = "Update list item", type = "Patient" },
//    new LogCategory { logCategoryName = "Delete list item", type = "Patient" },
//    new LogCategory { logCategoryName = "Successful logout", type = "User" },
//    new LogCategory { logCategoryName = "Export schedule", type = "Patient" },
//    new LogCategory { logCategoryName = "Test schedule", type = "Patient" },
//    new LogCategory { logCategoryName = "Export Game", type = "Patient" },
//    new LogCategory { logCategoryName = "Reset user password", type = "User" },
//    new LogCategory { logCategoryName = "Update read status", type = "User" },
//    new LogCategory { logCategoryName = "To be updated", type = "Patient" },

