using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NTU_FYP_PEAR_CORE_20.Controllers
{
    public class GuardianController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
