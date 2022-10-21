using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using CloudinaryDotNet;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NTU_FYP_PEAR_CORE_20.Data;
using NTU_FYP_PEAR_CORE_20.Models;
using static System.String;
using NTU_FYP_PEAR_CORE_20.Configuration;

namespace NTU_FYP_PEAR_CORE_20.Controllers
{
    public class AccountController : Controller
    {

        public IActionResult Login()
        {
            return View();
        }

       
    }
}
