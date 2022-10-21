using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NTU_FYP_PEAR_CORE_20.Data;
using NTU_FYP_PEAR_CORE_20.Models;
using NTU_FYP_PEAR_CORE_20.Models.Others;
using NTU_FYP_PEAR_CORE_20.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;

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
    public class UserController : ControllerBase
    {
        private readonly UserService userService;

        public UserController(UserService userService)
        {
            this.userService = userService;
        }

        // -------------------------------------------- Users --------------------------------------------
        // api/user/role?token=123&masked=0&role=Doctor
        [HttpGet("role")]
        public IActionResult GetUserListByRole(string token, string role)
        {
            try
            {
                List<ApplicationUser> list = userService.getListByRole(role);


                return new OkObjectResult(new { status = "success", message = "", data = list.ToList() });
            }
            catch (Exception e)
            {
                return BadRequest(new { status = "error", message = "Error: " + e.ToString() });
            }
        }

        [HttpPost("token")]
        public async Task<IActionResult> GetTokenAsync(TokenRequestModel model)
        {
            var result = await userService.GetTokenAsync(model);
            SetRefreshTokenInCookie(result.RefreshToken);
            return Ok(result);
        }

        private void SetRefreshTokenInCookie(string refreshToken)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(10),
            };
            Response.Cookies.Append("refreshToken", refreshToken, cookieOptions);
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken()
        {
            var refreshToken = Request.Cookies["refreshToken"];
            var response = await userService.RefreshTokenAsync(refreshToken);
            if (!string.IsNullOrEmpty(response.RefreshToken))
                SetRefreshTokenInCookie(response.RefreshToken);
            return Ok(response);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("tokens/{id}")]
        public IActionResult GetRefreshTokens(string id)
        {
            var user = userService.GetById(id);
            return Ok(user.RefreshTokens);
        }

        [HttpPost("revoke-token")]
        public async Task<IActionResult> RevokeToken([FromBody] RevokeTokenRequest model)
        {
            // accept token from request body or cookie
            var token = model.Token ?? Request.Cookies["refreshToken"];
            if (string.IsNullOrEmpty(token))
                return BadRequest(new { message = "Token is required" });
            var response = userService.RevokeToken(token);
            if (!response)
                return NotFound(new { message = "Token not found" });
            return Ok(new { message = "Token revoked" });
        }





    }
}
