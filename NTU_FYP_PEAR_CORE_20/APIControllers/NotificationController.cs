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
    public class NotificationController : ControllerBase
    {
        private readonly UserService userService;
        private readonly OtherService otherService;
        public NotificationController(OtherService otherService, UserService userService)
        {
            this.userService = userService;
            this.otherService = otherService;
        }

        // api/notification/count/userID
        [HttpGet("count/{userID}")]
        public IActionResult GetNotificationCount(string userID)
        {
            try
            {
                string token = Request.Headers["token"];
                ApplicationUser user = userService.getUserDetails(token, userID);
                string userRole = userService.getUserType(user);
                if (userRole.Equals(Constants.Role.Guardian) || user == null)
                    return BadRequest(new { status = "error", message = "Unauthorised user" });

                string msg = otherService.getUnreadCount(userID);
                return new OkObjectResult(new { status = "success", message = msg });
            }
            catch (Exception e)
            {
                return BadRequest(new { status = "error", message = "Error: " + e.ToString() });
            }
        }

        // api/notification/userID/readStatus
        [HttpGet("{userID}/{readStatus:bool}")]
        public IActionResult GetNotification(string userID, bool readStatus)
        {
            try
            {
                string token = Request.Headers["token"];
                ApplicationUser user = userService.getUserDetails(token, userID);
                string userRole = userService.getUserType(user);
                if (userRole.Equals(Constants.Role.Guardian) || user == null)
                    return BadRequest(new { status = "error", message = "Unauthorised user" });

                List<LogNotification> notifications = otherService.getNotification(userID, readStatus);

                return new OkObjectResult(new { status = "success", message = "", data = notifications.ToList() });
            }
            catch (Exception e)
            {
                return BadRequest(new { status = "error", message = "Error: " + e.ToString() });
            }
        }

        // api/patient/update
        [HttpPut("update")]
        public IActionResult UpdateNotification([FromBody] string value)
        {
            try
            {
                string token = Request.Headers["token"];
                var updateInput = JsonConvert.DeserializeObject<dynamic>(value);
                string userID = updateInput["userID"];
                int logNotificationID = updateInput["logNotifcationID"];
                bool readStatus = updateInput["readStatus"];
                ApplicationUser user = userService.getUserDetails(token, userID);
                string userRole = userService.getUserType(user);
                if (userRole.Equals(Constants.Role.Guardian) || user == null)
                    return BadRequest(new { status = "error", message = "Unauthorised user" });

                LogNotification logNotification = otherService.updateNotification(logNotificationID, readStatus);

                return new OkObjectResult(new { status = "success", message = ""});
            }
            catch (Exception e)
            {
                return BadRequest(new { status = "error", message = "Error: " + e.ToString() });
            }
        }
    }
}
