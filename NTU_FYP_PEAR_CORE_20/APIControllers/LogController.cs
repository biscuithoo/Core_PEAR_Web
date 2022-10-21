using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NTU_FYP_PEAR_CORE_20.Data;
using NTU_FYP_PEAR_CORE_20.DTOs;
using NTU_FYP_PEAR_CORE_20.Models;
using NTU_FYP_PEAR_CORE_20.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NTU_FYP_PEAR_CORE_20.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private readonly OtherService otherService;
        private readonly UserService userService;
        private readonly ApproveRejectHandlerService arHandlerService;

        public LogController(OtherService os, UserService us, ApproveRejectHandlerService arhs)
        {
            otherService = os;
            userService = us;
            arHandlerService = arhs;
        }

        // api/log
        [HttpGet]
        public IActionResult GetLogs()
        {
            try
            {
                string token = Request.Headers["token"];
                ApplicationUser user = userService.getUserDetails(token, null);
                string userRole = userService.getUserType(user);
                if (!(userRole.Equals(Constants.Role.Administrator) || userRole.Equals(Constants.Role.Supervisor)))
                    return BadRequest(new { status = "error", message = "Unauthorised user" });

                List<LogDTO> logs = otherService.getLogs(null);
                return new OkObjectResult(new { status = "success", message = "", data = logs.ToList() });
            }
            catch (Exception e)
            {
                return BadRequest(new { status = "error", message = "Error: " + e.ToString() });
            }
        }

        // api/log/patients
        [HttpGet("patients")]
        public IActionResult GetPatientLogs()
        {
            try
            {
                string token = Request.Headers["token"];
                ApplicationUser user = userService.getUserDetails(token, null);
                string userRole = userService.getUserType(user);
                if (!(userRole.Equals(Constants.Role.Administrator) || userRole.Equals(Constants.Role.Supervisor)))
                    return BadRequest(new { status = "error", message = "Unauthorised user" });

                List<LogDTO> logs = otherService.getPatientLogs();
                return new OkObjectResult(new { status = "success", message = "", data = logs.ToList() });
            }
            catch (Exception e)
            {
                return BadRequest(new { status = "error", message = "Error: " + e.ToString() });
            }
        }

        // api/log/approvereject
        [HttpGet("approvereject")]
        public IActionResult GetLogApproveReject()
        {
            try
            {
                string token = Request.Headers["token"];
                ApplicationUser user = userService.getUserDetails(token, null);
                string userRole = userService.getUserType(user);
                if (!(userRole.Equals(Constants.Role.Administrator) || userRole.Equals(Constants.Role.Supervisor)))
                    return BadRequest(new { status = "error", message = "Unauthorised user" });

                List<LogApproveRejectDTO> logs = otherService.getARLogs(user.Id);
                return new OkObjectResult(new { status = "success", message = "", data = logs.ToList() });
            }
            catch (Exception e)
            {
                return BadRequest(new { status = "error", message = "Error: " + e.ToString() });
            }
        }

        // api/log/approvereject
        [HttpPut("approvereject")]
        public IActionResult LogApproveReject([FromBody] LogApprovalDTO dto)
        {
            try
            {
                string token = Request.Headers["token"];
                ApplicationUser user = userService.getUserDetails(token, null);
                string userRole = userService.getUserType(user);
                if (!(userRole.Equals(Constants.Role.Administrator) || userRole.Equals(Constants.Role.Supervisor)))
                    return BadRequest(new { status = "error", message = "Unauthorised user" });

                arHandlerService.approveRejectLog(dto.logId, dto.status, dto.rejectReason);
                return new OkObjectResult(new { status = "success", message = "" });
            }
            catch (Exception e)
            {
                return BadRequest(new { status = "error", message = "Error: " + e.ToString() });
            }
        }
    }
}
