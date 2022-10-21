using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NTU_FYP_PEAR_CORE_20.Data;
using NTU_FYP_PEAR_CORE_20.ViewModels;

namespace NTU_FYP_PEAR_CORE_20.Controllers
{
    public class SupervisorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ManagePatient()
        {
            return View("ManagePatient");
        }

        public IActionResult AddPatient()
        {
            return View("AddPatient");
        }

        [Authorize(Roles = Constants.Role.Supervisor)]
        public IActionResult ManagePatientPersonalPreference(int id)
        {
            return View();
        }
        [Authorize(Roles = Constants.Role.Supervisor)]
        public IActionResult AddPatientPersonalPreference(int id)
        {
            return View();
        }

        public IActionResult ManageActivities()
        {
            return View("ManageActivities");
        }

        public IActionResult ManageAttendance()
        {
            return View("ManageAttendance");
        }

        public IActionResult ManageAdhoc()
        {
            return View("ManageAdhoc");
        }

        public IActionResult ViewActivityLogs()
        {
            return View();
        }

        public IActionResult ViewApproveRejectLogs()
        {
            return View();
        }

        public IActionResult ExportSchedule()
        {
            return View("ExportSchedule");
        }
        public IActionResult GenerateSchedule()
        {
            return View("GenerateSchedule");
        }

        public IActionResult ViewMedicationSchedule()
        {
            return View("ViewMedicationSchedule");
        }

        public IActionResult ManagePatientPreference()
        {
            return View("ManagePatientPreference");
        }
    }
}
