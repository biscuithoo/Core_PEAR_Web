using System;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NTU_FYP_PEAR_CORE_20.Configuration;
using NTU_FYP_PEAR_CORE_20.Data;
using NTU_FYP_PEAR_CORE_20.Models;


namespace NTU_FYP_PEAR_CORE_20.Controllers
{
	public class HomeController : Controller
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger,
			UserManager<ApplicationUser> userManager
			)
		{
			_userManager = userManager;
			_logger = logger;
		}

		[Authorize]
		public IActionResult Index()
		{
			if (User.IsInRole("Administrator"))
			{
				return RedirectToAction("ListAccounts", "Administrator");
			}
			else if (User.IsInRole("Caregiver"))
			{
				return RedirectToAction("Index", "Caregiver");
			}
			else if (User.IsInRole("Doctor"))
			{
				return RedirectToAction("Index", "Doctor");
			}
			else if (User.IsInRole("Game Therapist"))
			{
				return RedirectToAction("Index", "GameTherapist");
			}
			else if (User.IsInRole("Guardian"))
			{
				return RedirectToAction("Index", "Guardian");
			}
			else if (User.IsInRole("Supervisor"))
			{
				return RedirectToAction("Index", "Supervisor");
			}
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
