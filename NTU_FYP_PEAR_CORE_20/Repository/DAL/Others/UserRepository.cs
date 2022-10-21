using Microsoft.AspNetCore.Identity;
using NTU_FYP_PEAR_CORE_20.Data;
using NTU_FYP_PEAR_CORE_20.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NTU_FYP_PEAR_CORE_20.Repository.Others
{
    public class UserRepository : Repository<ApplicationUser>
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;
        public UserRepository(ApplicationDbContext context, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager) : base(context)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public ApplicationUser GetUserByRole(string role)
        {
            ApplicationUser user = userManager.GetUsersInRoleAsync(role).Result.FirstOrDefault(x => x.isDeleted == false);
            return user;
        }
        public ApplicationUser GetUserByID(string userID)
        {
            ApplicationUser user = userManager.FindByIdAsync(userID).Result;
            if (user == null) return null;
            if (user.isDeleted == false) return user;
            else return null;
        }
        public ApplicationUser GetUserByToken(string token)
        {
            return GetAll().SingleOrDefault(x => x.token == token && x.isDeleted == false);
        }
        public ApplicationUser GetUserByIdToken(string userID, string token)
        {
            return GetAll().SingleOrDefault(x => x.token == token && x.Id == userID && x.isDeleted == false);
        }
        public string GetUserRole(ApplicationUser user)
        {
            return userManager.GetRolesAsync(user).Result.SingleOrDefault();
        }

        public List<ApplicationUser> GetListOfUserByRole(string role)
        {
            string roleId = "";

            switch (role)
            {
                case Constants.Role.Caregiver:
                    roleId = "01B168FD-810B-432D-9010-233BA0B380E6";
                    break;
                case Constants.Role.Doctor:
                    roleId = "7D9B7113-A8F8-4035-99A7-A20DD400F6A3";
                    break;
                case Constants.Role.Supervisor:
                    roleId = "01B168FE-810B-432D-9010-233BA0B380E9";
                    break;
                case Constants.Role.Administrator:
                    roleId = "2301D884-221A-4E7D-B509-0113DCC043E1";
                    break;
                case Constants.Role.GameTherapist:
                    roleId = "01B168FD-810B-432D-9010-233BA0B380E7";
                    break;
                case Constants.Role.Guardian:
                    roleId = "78A7570F-3CE5-48BA-9461-80283ED1D94D";
                    break;
            }

            return GetAll().Where(x => x.roleId == roleId && x.isDeleted == false).ToList();
        }
    }
}
