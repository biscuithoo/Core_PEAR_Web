using Microsoft.AspNetCore.Identity;
using NTU_FYP_PEAR_CORE_20.Data;
using NTU_FYP_PEAR_CORE_20.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NTU_FYP_PEAR_CORE_20.Repository.Others
{
    public class UserDeviceTokenRepository : Repository<UserDeviceToken>
    {
        public UserDeviceTokenRepository(ApplicationDbContext context) : base(context) { }
        
        public UserDeviceToken GetByUserID(string userID)
        {
            UserDeviceToken userDeviceToken = GetAll().Where(x => x.userID == userID).SingleOrDefault();
            return userDeviceToken;
        }
    }
}
