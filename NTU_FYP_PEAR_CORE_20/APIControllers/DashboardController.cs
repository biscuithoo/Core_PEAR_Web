using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using NTU_FYP_PEAR_CORE_20.Data;
using NTU_FYP_PEAR_CORE_20.Models;
using NTU_FYP_PEAR_CORE_20.Services;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net;

namespace NTU_FYP_PEAR_CORE_20.APIControllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly UserService userService;

        public DashboardController(ApplicationDbContext db, UserService userService)
        {
            this.userService = userService;
            _db = db;
        }

        [HttpGet]
        [Route("displayActivities/{userId}")]
        public IActionResult DisplayActivities_JSONString(string userId)
        {
            try
            {
                string token = Request.Headers["token"];
                ApplicationUser user = userService.getUserDetails(token, userId);
                string userRole = userService.getUserType(user);
                if (userRole.Equals(Constants.Role.Guardian) || user == null)
                    return BadRequest(new { status = "error", message = "Unauthorised user" });

                JArray overallJArray = new JArray();

                var allActivies = (from act in _db.CentreActivities
                                   orderby act.Activities.activityTitle ascending
                                   select act.Activities.activityTitle).ToList();

                foreach (var curActivities in allActivies)
                {
                    overallJArray.Add(curActivities);
                }
                string msg = JsonConvert.SerializeObject(overallJArray);
                return new OkObjectResult(new { status = "success", message = msg });
            }
            catch (Exception e)
            {
                return BadRequest(new { status = "error", message = "Error: " + e.ToString() });
            }

        }


        [HttpGet]
        public IActionResult GetSecuredData()
        {
            return Ok("This Secured Data is available only for Authenticated Users.");
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public IActionResult PostSecuredData()
        {
            return Ok("This Secured Data is available only for Authenticated Admin Users.");
        }
    }
}
