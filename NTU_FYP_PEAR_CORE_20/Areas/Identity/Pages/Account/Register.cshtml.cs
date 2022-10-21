using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using NTU_FYP_PEAR_CORE_20.Models;
using NTU_FYP_PEAR_CORE_20.Controllers;
using NTU_FYP_PEAR_CORE_20.Configuration;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using NTU_FYP_PEAR_CORE_20.Models.Others;
using NTU_FYP_PEAR_CORE_20.Data;
using System.Text.Json;
using NTU_FYP_PEAR_CORE_20.DTOs.Request;
using Microsoft.EntityFrameworkCore;


namespace NTU_FYP_PEAR_CORE_20.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly ApplicationDbContext _db;
        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            ApplicationDbContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _db = db;
            RolesList = _roleManager.Roles.ToList().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).OrderBy(x => x.Text);

            _logger = logger;
            _emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public IEnumerable<SelectListItem> RolesList { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }


        public class InputModel
        {
            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Prefered Name")]
            public string PreferedName { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Gender")]
            public string Gender { get; set; }

            [Required]
            [DataType(DataType.Date)]
            [Display(Name = "Date Of Birth")]
            public string DOB { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "NRIC")]
            public string NRIC { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Address")]
            public string Address { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Username")]
            public string Username { get; set; }

            [Required]
            [Display(Name = "Role")]
            public string RoleId { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }



        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async  Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { firstName = Input.FirstName, lastName = Input.LastName, preferredName = Input.PreferedName, gender = Input.Gender,
                                                    DOB = Convert.ToDateTime(Input.DOB), nric = Input.NRIC, address = Input.Address,
                                                    Email = Input.Email, UserName = Input.Username, secretQuestionListID = 1, secretQuestion2ListID = 1, allowNotification = true,
                                                    isActive = true
                                                };

                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    if (RolesList.Any()) 
                    {
                        var role = await _roleManager.FindByIdAsync(Input.RoleId);
                        IdentityResult addRoleResult = await _userManager.AddToRoleAsync(user, role.Name);

                        if(!addRoleResult.Succeeded)
                        {
                            foreach (var error in addRoleResult.Errors)
                            {
                                ModelState.AddModelError(string.Empty, error.Description);
                            }
                        }

                        var addedUser = await _userManager.FindByIdAsync(user.Id);
                        addedUser.roleId = role.Id;
                        await _userManager.UpdateAsync(addedUser);
                        

                    }
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                        
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl});
                    }
                    else
                    {
                        //await _signInManager.SignInAsync(user, isPersistent: false);
                         return LocalRedirect(returnUrl);
                    }
                    
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }

     
    }
