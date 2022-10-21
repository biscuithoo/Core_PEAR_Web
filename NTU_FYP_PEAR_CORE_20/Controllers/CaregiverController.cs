using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NTU_FYP_PEAR_CORE_20.Controllers
{
    public class CaregiverController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
