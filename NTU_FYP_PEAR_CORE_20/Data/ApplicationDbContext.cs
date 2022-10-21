using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NTU_FYP_PEAR_CORE_20.Models;
using NTU_FYP_PEAR_CORE_20.Models.Others;
using System.Reflection;


namespace NTU_FYP_PEAR_CORE_20.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        /* DbSet properties for each database table */
        public DbSet<Activities> Activities { get; set; }
        public DbSet<ActivityAvailability> ActivityAvailabilities { get; set; }
        public DbSet<ActivityExclusion> ActivityExclusions { get; set; }
        public DbSet<CentreActivityPreference> CentreActivityPreferences { get; set; }
        public DbSet<CentreActivityRecommendation> CentreActivityRecommendations { get; set; }
        public DbSet<AdHoc> AdHocs { get; set; }
        public DbSet<AlbumPatient> AlbumPatients { get; set; }
        public DbSet<Allergy> Allergies { get; set; }
        public DbSet<AssignedGame> AssignedGames { get; set; }
        public DbSet<AttendanceLog> AttendanceLogs { get; set; }
        public DbSet<CareCentreAttribute> CareCentreAttributes { get; set; }
        public DbSet<CareCentreHour> CareCentreHours { get; set; }
        public DbSet<CentreActivity> CentreActivities { get; set; }
        public DbSet<DoctorNote> DoctorNotes { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GameCategoryAssignedDementia> GameCategoryAssignedDementias { get; set; }
        public DbSet<GameAssignedDementia> GameAssignedDementias { get; set; }
        public DbSet<GameCategory> GameCategories { get; set; }
        public DbSet<GameRecord> GameRecords { get; set; }
        public DbSet<GamesTypeRecommendation> GamesTypeRecommendations { get; set; }
        public DbSet<Habit> Habits { get; set; }
        public DbSet<Highlight> Highlights { get; set; }
        public DbSet<HighlightType> HighlightTypes { get; set; }
        public DbSet<VitalThreshold> VitalThresholds { get; set; }
        public DbSet<Hobby> Hobbies { get; set; }
        public DbSet<HolidayExperience> HolidayExperiences { get; set; }
        public DbSet<LikeDislike> LikeDislikes { get; set; }
        public DbSet<List_AlbumCategory> ListAlbumCategories { get; set; }
        public DbSet<List_Allergy> ListAllergies { get; set; }
        public DbSet<List_AllergyReaction> ListAllergyReactions { get; set; }
        public DbSet<List_Country> ListCountries { get; set; }
        public DbSet<List_DementiaType> ListDementiaTypes { get; set; }
        public DbSet<List_Diet> ListDiets { get; set; }
        public DbSet<List_Education> ListEducations { get; set; }
        public DbSet<List_GameCategory> ListGameCategories { get; set; }
        public DbSet<List_Habit> ListHabits { get; set; }
        public DbSet<List_Hobby> ListHobbies { get; set; }
        public DbSet<List_Language> ListLanguages { get; set; }
        public DbSet<List_LikeDislike> ListLikeDislikes { get; set; }
        public DbSet<List_LiveWith> ListLiveWiths { get; set; }
        public DbSet<List_Mobility> ListMobilities { get; set; }
        public DbSet<List_Occupation> ListOccupations { get; set; }
        public DbSet<List_Pet> ListPets { get; set; }
        public DbSet<List_Prescription> ListPrescriptions { get; set; }
        public DbSet<List_ProblemLog> ListProblemLogs { get; set; }
        public DbSet<List_Relationship> ListRelationships { get; set; }
        public DbSet<List_Religion> ListReligions { get; set; }
        public DbSet<List_SecretQuestion> ListSecretQuestions { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<LogAccount> LogAccounts { get; set; }
        public DbSet<LogApproveReject> LogApproveRejects { get; set; }
        public DbSet<LogCategory> LogCategories { get; set; }
        public DbSet<LogNotification> LogNotifications { get; set; }
        public DbSet<MedicalHistory> MedicalHistories { get; set; }
        public DbSet<MedicationLog> MedicationLogs { get; set; }
        public DbSet<Mobility> Mobilities { get; set; }
        public DbSet<NotificationHandler> NotificationHandlers { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Guardian> Guardians { get; set; }
        public DbSet<PatientAllocation> PatientAllocations { get; set; }
        public DbSet<PatientAssignedDementia> PatientAssignedDementias { get; set; }
        public DbSet<PerformanceMetricName> PerformanceMetricNames { get; set; }
        public DbSet<PerformanceMetricOrder> PerformanceMetricOrders { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<PrivacySetting> PrivacySettings { get; set; }
        public DbSet<ProblemLog> ProblemLogs { get; set; }
        public DbSet<Routine> Routines { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<SocialHistory> SocialHistories { get; set; }
        public DbSet<Vital> Vitals { get; set; }
        public DbSet<UploadResult> UploadResults { get; set; }

        public DbSet<UserDeviceToken> UserDeviceTokens { get; set; }


        /* 2. Constructor */
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }


        /* 3. */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Users & Roles
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // Activity
            modelBuilder.Entity<Activities>().ToTable(Models.Activities.TableName);
            modelBuilder.Entity<ActivityAvailability>().ToTable(ActivityAvailability.TableName);
            modelBuilder.Entity<ActivityExclusion>().ToTable(ActivityExclusion.TableName);
            modelBuilder.Entity<AdHoc>().ToTable(AdHoc.TableName);
            modelBuilder.Entity<CentreActivity>().ToTable(CentreActivity.TableName);
            modelBuilder.Entity<CentreActivityPreference>().ToTable(CentreActivityPreference.TableName);
            modelBuilder.Entity<CentreActivityRecommendation>().ToTable(CentreActivityRecommendation.TableName);
            modelBuilder.Entity<Routine>().ToTable(Routine.TableName);

            // Patient
            modelBuilder.Entity<Patient>().ToTable(Patient.TableName);

            modelBuilder.Entity<PatientAllocation>().ToTable(PatientAllocation.TableName);
            modelBuilder.Entity<PatientAllocation>().HasOne(x => x.Doctor).WithMany().OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<PatientAllocation>().HasOne(x => x.Caregiver).WithMany().OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<PatientAllocation>().HasOne(x => x.Supervisor).WithMany().OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<PatientAllocation>().HasOne(x => x.Guardian).WithMany().OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<PatientAllocation>().HasOne(x => x.GameTherapist).WithMany().OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PatientAssignedDementia>().ToTable(PatientAssignedDementia.TableName);
            modelBuilder.Entity<Allergy>().ToTable(Allergy.TableName);
            modelBuilder.Entity<LikeDislike>().ToTable(LikeDislike.TableName);
            modelBuilder.Entity<Habit>().ToTable(Habit.TableName);
            modelBuilder.Entity<Hobby>().ToTable(Hobby.TableName);
            modelBuilder.Entity<SocialHistory>().ToTable(SocialHistory.TableName);
            modelBuilder.Entity<Mobility>().ToTable(Mobility.TableName);
            modelBuilder.Entity<AlbumPatient>().ToTable(AlbumPatient.TableName);
            modelBuilder.Entity<HolidayExperience>().ToTable(HolidayExperience.TableName);
            modelBuilder.Entity<MedicalHistory>().ToTable(MedicalHistory.TableName);
            modelBuilder.Entity<MedicationLog>().ToTable(MedicationLog.TableName);
            modelBuilder.Entity<MedicationLog>().HasOne(x => x.Prescription).WithMany().OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Vital>().ToTable(Vital.TableName);
            modelBuilder.Entity<DoctorNote>().ToTable(DoctorNote.TableName);
            modelBuilder.Entity<ProblemLog>().ToTable(ProblemLog.TableName);
            modelBuilder.Entity<Prescription>().ToTable(Prescription.TableName);
            modelBuilder.Entity<AttendanceLog>().ToTable(AttendanceLog.TableName);

            // User
            modelBuilder.Entity<ApplicationUser>().HasOne(x => x.secretQuestion).WithMany().OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<UserDeviceToken>().ToTable(UserDeviceToken.TableName).HasIndex(x => x.deviceToken).IsUnique();
            modelBuilder.Entity<Guardian>().ToTable(Guardian.TableName);

            // Game
            modelBuilder.Entity<Game>().ToTable(Game.TableName);
            modelBuilder.Entity<AssignedGame>().ToTable(AssignedGame.TableName);
            modelBuilder.Entity<GameAssignedDementia>().ToTable(GameAssignedDementia.TableName);
            modelBuilder.Entity<GameCategory>().ToTable(GameCategory.TableName);
            modelBuilder.Entity<GameCategoryAssignedDementia>().ToTable(GameCategoryAssignedDementia.TableName);
            modelBuilder.Entity<GameRecord>().ToTable(GameRecord.TableName);
            modelBuilder.Entity<GamesTypeRecommendation>().ToTable(GamesTypeRecommendation.TableName);
            modelBuilder.Entity<PerformanceMetricName>().ToTable(PerformanceMetricName.TableName);
            modelBuilder.Entity<PerformanceMetricOrder>().ToTable(PerformanceMetricOrder.TableName);
            modelBuilder.Entity<PerformanceMetricOrder>().HasKey(o => new { o.pmnID, o.gameID });

            // List_xxx
            modelBuilder.Entity<List_AlbumCategory>().ToTable(List_AlbumCategory.TableName);
            modelBuilder.Entity<List_Allergy>().ToTable(List_Allergy.TableName);
            modelBuilder.Entity<List_AllergyReaction>().ToTable(List_AllergyReaction.TableName);
            modelBuilder.Entity<List_Country>().ToTable(List_Country.TableName);
            modelBuilder.Entity<List_DementiaType>().ToTable(List_DementiaType.TableName);
            modelBuilder.Entity<List_Diet>().ToTable(List_Diet.TableName);
            modelBuilder.Entity<List_Education>().ToTable(List_Education.TableName);
            modelBuilder.Entity<List_GameCategory>().ToTable(List_GameCategory.TableName);
            modelBuilder.Entity<List_Habit>().ToTable(List_Habit.TableName);
            modelBuilder.Entity<List_Hobby>().ToTable(List_Hobby.TableName);
            modelBuilder.Entity<List_Language>().ToTable(List_Language.TableName);
            modelBuilder.Entity<List_LikeDislike>().ToTable(List_LikeDislike.TableName);
            modelBuilder.Entity<List_LiveWith>().ToTable(List_LiveWith.TableName);
            modelBuilder.Entity<List_Mobility>().ToTable(List_Mobility.TableName);
            modelBuilder.Entity<List_Occupation>().ToTable(List_Occupation.TableName);
            modelBuilder.Entity<List_Pet>().ToTable(List_Pet.TableName);
            modelBuilder.Entity<List_Prescription>().ToTable(List_Prescription.TableName);
            modelBuilder.Entity<List_ProblemLog>().ToTable(List_ProblemLog.TableName);
            modelBuilder.Entity<List_Relationship>().ToTable(List_Relationship.TableName);
            modelBuilder.Entity<List_Religion>().ToTable(List_Religion.TableName);
            modelBuilder.Entity<List_SecretQuestion>().ToTable(List_SecretQuestion.TableName);

            // Others
            modelBuilder.Entity<NotificationHandler>().ToTable(NotificationHandler.TableName);
            modelBuilder.Entity<Log>().ToTable(Log.TableName);
            modelBuilder.Entity<LogAccount>().ToTable(LogAccount.TableName);
            modelBuilder.Entity<LogApproveReject>().ToTable(LogApproveReject.TableName);
            modelBuilder.Entity<LogNotification>().ToTable(LogNotification.TableName);
            modelBuilder.Entity<LogNotification>().HasOne(x => x.IdentityRole).WithMany().HasForeignKey(x => x.intendedUserType).HasPrincipalKey(x => x.Name);
            modelBuilder.Entity<LogCategory>().ToTable(LogCategory.TableName).HasIndex(x => x.logCategoryName).IsUnique();
            modelBuilder.Entity<PrivacySetting>().ToTable(PrivacySetting.TableName).HasIndex(x => x.socialHistoryItem).IsUnique();
            modelBuilder.Entity<Schedule>().ToTable(Schedule.TableName);
            modelBuilder.Entity<Highlight>().ToTable(Highlight.TableName);
            modelBuilder.Entity<HighlightType>().ToTable(HighlightType.TableName);
            modelBuilder.Entity<VitalThreshold>().ToTable(VitalThreshold.TableName);
            modelBuilder.Entity<CareCentreAttribute>().ToTable(CareCentreAttribute.TableName);
            modelBuilder.Entity<CareCentreHour>().ToTable(CareCentreHour.TableName);

            // Seed Data
            modelBuilder.Seed();
        }
    }
}
