using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NTU_FYP_PEAR_CORE_20.Data;
using NTU_FYP_PEAR_CORE_20.Models;
using NTU_FYP_PEAR_CORE_20.Services;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using System.IO;
using Newtonsoft.Json;
using System.Globalization;
using static System.String;
using Newtonsoft.Json.Linq;


namespace NTU_FYP_PEAR_CORE_20.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext _db;
        private const string folderName = "User";
        private readonly Cloudinary _cloudinary;
        public static string url = Constants.Image.URL;
        public int found = 0;

        public IndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<IndexModel> logger,
            ApplicationDbContext db,
            Cloudinary cloudinary)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _db = db;
            _cloudinary = cloudinary;
            SecretQnsList = db.ListSecretQuestions.ToList().Select(x => new SelectListItem
            {
                Text = x.value.ToString(),
                Value = x.list_secretQuestionID.ToString()
            }).OrderBy(x => x.Text);
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public IEnumerable<SelectListItem> SecretQnsList { get; set; }

        public string Preset { get; set; }

        public class InputModel
        {
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }

            [Display(Name = "Secret Question")]
            public int SecretQuestionID { get; set; }

            [Required]
            [Display(Name = "Secret Question Answer")]
            public string SecretQuestionAnswer { get; set; }

            [Display(Name = "Secret Question 2")]
            public int SecretQuestion2ID { get; set; }

            [Required]
            [Display(Name = "Secret Question 2 Answer")]
            public string SecretQuestion2Answer { get; set; }
        }


        private async Task LoadAsync(ApplicationUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            Username = userName;

            Input = new InputModel
            {
                PhoneNumber = phoneNumber
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {

            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            url = Constants.Image.URL;
            if (user.profilePicture != null)
            {
                url = Concat(url, user.profilePicture);
            }
            else
            {
                url = Concat(url, Constants.Image.placeholderURL);
            }
            return Page();
        }

        public async Task<IActionResult> OnPostUpload(IFormFile[] images)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var results = new List<Dictionary<string, string>>();

            if (images == null || images.Length == 0)
            {
                return RedirectToPage();
            }

            var rolename = await _userManager.GetRolesAsync(user);

            string role = rolename.FirstOrDefault();

            foreach (var image in images)
            {
                if (image.Length == 0) return RedirectToPage();

                var result = await _cloudinary.UploadAsync(

                new ImageUploadParams
                {
                    File = new FileDescription(
                        image.FileName,
                        image.OpenReadStream()),
                    Tags = role,
                    PublicId = user.UserName + "_profile_picture",
                    Folder = folderName
                }

                ).ConfigureAwait(false);

                var imageProperties = new Dictionary<string, string>();
                foreach (var token in result.JsonObj.Children())
                {
                    if (token is JProperty prop)
                    {
                        imageProperties.Add(prop.Name, prop.Value.ToString());
                    }
                }

                results.Add(imageProperties);
                String Data = result.Url.AbsoluteUri;
                found = Data.IndexOf("/upload/");
                user.profilePicture = Data.Substring(found);
            }

            try
            {
                await _db.UploadResults.AddAsync(new Data.UploadResult { UploadResultAsJson = JsonConvert.SerializeObject(results) }).ConfigureAwait(false);

                await _db.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetType());
                StatusMessage = "Unexpected error when trying to set picture";
                return RedirectToPage();
            }
            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile picture has been updated";
            return RedirectToPage();
        }


        public async Task<IActionResult> OnPostAsync()
        {

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }

            if (Input.SecretQuestionID.Equals(Input.SecretQuestion2ID))
            {
                StatusMessage = "Please select different secret questions";
                return RedirectToPage();
            }
            else
            {
                user.secretQuestionListID = Input.SecretQuestionID;
                //normalise before hashing
                user.secretAnswer = UserService.HashInput(Input.SecretQuestionAnswer.ToLower());
                user.secretQuestion2ListID = Input.SecretQuestion2ID;
                //normalise before hashing
                user.secretAnswer2 = UserService.HashInput(Input.SecretQuestion2Answer.ToLower());
                try
                {
                    Task.WaitAny(_db.SaveChangesAsync());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.GetType());
                    StatusMessage = "Unexpected error when trying to set secret questions";
                    return RedirectToPage();
                }
            }
            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }

    }
}
