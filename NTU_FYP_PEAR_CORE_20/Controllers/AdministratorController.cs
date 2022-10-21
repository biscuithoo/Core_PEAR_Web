using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using NTU_FYP_PEAR_CORE_20.Models;
using NTU_FYP_PEAR_CORE_20.ViewModels;

namespace NTU_FYP_PEAR_CORE_20.Controllers
{
    [Authorize(Roles = "Administrator")]
    [Authorize]
    public class AdministratorController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;

        public AdministratorController(RoleManager<IdentityRole> roleManager,
                               UserManager<ApplicationUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        //[Authorize]
        //public IActionResult Index()
        //{
        //    return View();
        //}


        [HttpGet]
        public async Task<IActionResult> ListAccounts()
        {
            var users = userManager.Users.ToList();

            var model = new List<ListAccountRoleViewModel>();

            foreach (var user in users)
            {
                var role = await roleManager.FindByIdAsync(user.roleId);

                string roleName = "";
                if (role is not null)
                {
                    roleName = role.Name;
                }
                
                ListAccountRoleViewModel userRole = new ListAccountRoleViewModel
                {
                    appUser = user,
                    userRole = roleName
                };
                model.Add(userRole);
            }

            return View(model);
        }

        public async Task<IActionResult> DeleteAccount(string id)
        {
            var user = await userManager.FindByIdAsync(id);

            if(user == null)
            {
                ViewBag.ErrorMessage = $"User with ID = {id} cannot be found!";
                return View("NotFound");
            }
            else
            {
                //deactivate delete
                user.isDeleted = true;
                var result = await userManager.UpdateAsync(user);

                //perma delete
                //var result = await userManager.DeleteAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListAccounts");
                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View("ListAccounts");
            }
        }


        [HttpGet]
        public IActionResult CreateRole(string from)
        {
            //RoleModel model = null;
            CreateRoleViewModel roleModel = new CreateRoleViewModel
            {
                From = from
            };

            //var objTuple = new Tuple<RoleModel, string>(model, from);
            return View(roleModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model, string from)
        {
            if(ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole
                {
                    Name = model.RoleName
                };

                IdentityResult result = await roleManager.CreateAsync(identityRole);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListRoles", "Administrator", new { from = from });
                }
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            var objTuple = new Tuple<CreateRoleViewModel, string>(model, from);

            return View(objTuple);
        }

        [HttpGet]
        public IActionResult ListRoles(string from)
        {
            var roles = roleManager.Roles;
            //Sorting method
            var newroles = roles.OrderBy(x => x.Name).ToList();

            var objTuple = new Tuple<IEnumerable<IdentityRole>, string>(newroles, from);

            return View(objTuple);
        }

        [HttpGet]
        public async Task<IActionResult> EditRole(string id, string from, string error)
        {
            ViewBag.error = error;
            var role = await roleManager.FindByIdAsync(id);

            if(role == null)
            {
                ViewBag.ErrorMessage = $"Role with ID = {id} cannot be found!";
                return View("NotFound");
            }

            var model = new EditRoleViewModel
            {
                Id = role.Id,
                RoleName = role.Name,
                From = from
            };

            foreach(var user in userManager.Users.ToList()) 
            {
                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    if (!user.isDeleted)
                    {
                        model.Users.Add(user.preferredName);
                    }
                }

            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditRole(EditRoleViewModel model)
        {
            IdentityRole role = await roleManager.FindByIdAsync(model.Id);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with ID = {model.Id} cannot be found!";
                return View("NotFound");
            }
            else
            {
                role.Name = model.RoleName;
                var result = await roleManager.UpdateAsync(role);

                if (result.Succeeded)
                {

                    return RedirectToAction("ListRoles", "Administrator", new { from = model.From });
                }



                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(model);
            }
        }


        [HttpGet]
        public async Task<IActionResult> EditUsersInRole(string roleId, string from)
        {
            ViewBag.roleId = roleId;
            ViewBag.from = from;

            var role = await roleManager.FindByIdAsync(roleId);

            if(role == null)
            {
                ViewBag.ErrorMessage = $"Role with ID = {roleId} cannot be found!";
                return View("NotFound");
            }

            var model = new List<UserRoleViewModel>();

            foreach(var user in userManager.Users.ToList())
            {
                if (!user.isDeleted)
                {
                    var userRoleViewModel = new UserRoleViewModel
                    {
                        UserId = user.Id,
                        PreferredName = user.preferredName
                    };

                    if (await userManager.IsInRoleAsync(user, role.Name))
                    {
                        userRoleViewModel.IsSelected = true;
                    }
                    else
                    {
                        userRoleViewModel.IsSelected = false;
                    }

                    model.Add(userRoleViewModel);
                }
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditUsersInRole(List<UserRoleViewModel> model, string roleId, string from)
        {
            var role = await roleManager.FindByIdAsync(roleId);

            if(role == null)
            {
                ViewBag.ErrorMessage = $"Role with ID = {roleId} cannot be found!";
                return View("NotFound");
            }
            string error = "";

            for (int i = 0; i < model.Count; i++)
            {
                var user = await userManager.FindByIdAsync(model[i].UserId);
                IdentityResult result = null;


                if (model[i].IsSelected && !(await userManager.IsInRoleAsync(user, role.Name)))
                {
                    if (user.roleId != null)
                    {
                        error = "Error: " + user.preferredName + " is already assigned a role";
                        continue;
                    }
                    else
                    {
                        result = await userManager.AddToRoleAsync(user, role.Name);
                        user.roleId = role.Id;
                    }
                }
                else if (!model[i].IsSelected && await userManager.IsInRoleAsync(user, role.Name))
                {
                    result = await userManager.RemoveFromRoleAsync(user, role.Name);
                    user.roleId = null;
                }
                else
                {
                    continue;
                }

                await userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    if (i < (model.Count - 1))
                    {
                        continue;
                    }
                    else
                    {
                        return RedirectToAction("EditRole", new { Id = roleId, from = from, error});
                    }
                }
            }

            return RedirectToAction("EditRole", new { Id = roleId , from = from, error});
        }

        [HttpPost]
        public async Task<IActionResult> DeleteRole(string id, string from)
        {
            var role = await roleManager.FindByIdAsync(id);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {id} cannot be found";
                return View("NotFound");
            }
            else
            {
                var result = await roleManager.DeleteAsync(role);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListRoles", new { from = from });
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View("ListRoles", new { from = from });
            }
        }

        public IActionResult ApproveRejectLogs()
        {
            return View();
        }
    }


}
