using Microsoft.Extensions.DependencyInjection;
using NTU_FYP_PEAR_CORE_20.Repository.Base;
using NTU_FYP_PEAR_CORE_20.Repository.Others;

namespace NTU_FYP_PEAR_CORE_20.Repository
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            // Registering the Repository with the Dependency Injection System
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IBaseListRepository<>), typeof(BaseListRepository<>));

            // Base Repository
            services.AddScoped<GuardianRepository>();
            services.AddScoped<LikeDislikeRepository>();
            services.AddScoped<HobbyRepository>();
            services.AddScoped<HabitRepository>();
            services.AddScoped<PatientAllocationRepository>();
            services.AddScoped<PatientRepository>();
            services.AddScoped<MedicalHistoryRepository>();
            services.AddScoped<MobilityRepository>();
            services.AddScoped<PatientAssignedDementiaRepository>();
            services.AddScoped<RoutineRepository>();
            services.AddScoped<SocialHistoryRepository>();
            services.AddScoped<VitalRepository>();
            services.AddScoped<AllergyRepository>();

            // Others Repository
            services.AddScoped<LogApproveRejectRepository>();
            services.AddScoped<LogNotificationRepository>();
            services.AddScoped<LogRepository>();
            services.AddScoped<LogCategoryRepository>();
            services.AddScoped<NotificationHandlerRepository>();
            services.AddScoped<UserDeviceTokenRepository>();
            services.AddScoped<UserRepository>();

            return services;
        }
    }
}
