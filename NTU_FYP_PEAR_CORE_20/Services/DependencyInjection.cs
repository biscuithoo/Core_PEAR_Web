using Microsoft.Extensions.DependencyInjection;
using NTU_FYP_PEAR_CORE_20.Services.PatientRelated;
using NTU_FYP_PEAR_CORE_20.Services.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NTU_FYP_PEAR_CORE_20.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddService(this IServiceCollection services)
        {
            // Registering the Services with the Dependency Injection System
            services.AddScoped<AdminService>();
            services.AddScoped<DeveloperService>();
            services.AddScoped<ActivityService>();
            services.AddScoped<GameService>();

            services.AddScoped<PatientService>();
            services.AddScoped<PatientPersonalPreferenceService>();

            services.AddScoped<ListService>();
            services.AddScoped<OtherService>();
            services.AddScoped<UserService>();
            services.AddScoped<ApproveRejectHandlerService>();

            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
