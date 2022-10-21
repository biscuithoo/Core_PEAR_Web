using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NTU_FYP_PEAR_CORE_20.Data
{
    public class Constants
    {

        public static class Role
        {
            public const string Administrator = "Administrator";
            public const string Doctor = "Doctor";
            public const string Supervisor = "Supervisor";
            public const string Guardian = "Guardian";
            public const string Caregiver = "Caregiver";
            public const string GameTherapist = "Game Therapist";
        }

        public static class LogCategory
        {
            public static class User
            {
                public const string SignIn = "Sign In";
                public const string SignOut = "Sign Out";
                public const string SignInFailure = "Sign In Failure";
                public const string LockedOut = "Locked Out";
                public const string ForgetPassword = "Forget Password";
                public const string ResetPassword = "Reset Password";
                public const string PasswordChange = "Password Change";
                public const string NewAccount = "New Account";
                public const string UpdateAccount = "Update Account";
                public const string DeleteAccount = "Delete Account";
                public const string NewUserType = "New User Type";
                public const string InvalidSecretAnswer = "Invalid Secret Answer";
            }
            public static class CareCentre
            {
                public const string NewCareCentre = "New Care Centre";
                public const string UpdateCareCentre = "Update Care Centre";
            }
            public static class Patient
            {
                public const string Create = "New Item";
                public const string Update = "Update Item";
                public const string Delete = "Delete Item";
                public const string ReadNRIC = "Read NRIC";
                public const string GenerateScheduleWeekly = "Weekly Schedule Generation";
                public const string GenerateScheduleDaily = "Daily Schedule Generation";
                public const string ExportSchedule = "Export Schedule";
                public const string ExportGame = "Export Game";
            }
            public static class List
            {
                public const string Create = "New List Item";
                public const string Update = "Update List Item";
                public const string Delete = "Delete List Item";
            }
        }

        public static class Image
        {
            public const string URL = "https://res.cloudinary.com/dbpearfyp/image";
            public const string placeholderURL = "/upload/v1616333385/ug4j3hrryerhyvjdj2ob.jpg";
        }
    }
}
