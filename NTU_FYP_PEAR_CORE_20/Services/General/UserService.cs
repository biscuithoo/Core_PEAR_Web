using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NTU_FYP_PEAR_CORE_20.Configuration;
using NTU_FYP_PEAR_CORE_20.Data;
using NTU_FYP_PEAR_CORE_20.Models;
using NTU_FYP_PEAR_CORE_20.Models.Others;
using NTU_FYP_PEAR_CORE_20.Repository.Others;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NTU_FYP_PEAR_CORE_20.Services
{
    /*
     * This Service is not allowed to call other Services
     */

    public interface IUserService
    {
        bool RevokeToken(string token);

    }

    public class UserService : IUserService
    {
        private readonly UserRepository userRepo;
        private readonly ApplicationDbContext _db;
        private readonly ILogger<UserService> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly JWT _jwt;

        public UserService(UserRepository userRepo, ILogger<UserService> logger, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IOptions<JWT> jwt, ApplicationDbContext db)
        {
            this.userRepo = userRepo;
            _logger = logger;
            _userManager = userManager;
            _roleManager = roleManager;
            _jwt = jwt.Value;
            _db = db;
        }
        

        public List<ApplicationUser> getListByRole(string role)
        {
            switch (role)
            {
                case "Caregiver":
                    return userRepo.GetListOfUserByRole(Constants.Role.Caregiver);
                case "Doctor":
                    return userRepo.GetListOfUserByRole(Constants.Role.Doctor);
                case "Supervisor":
                    return userRepo.GetListOfUserByRole(Constants.Role.Supervisor);
                case "Administrator":
                    return userRepo.GetListOfUserByRole(Constants.Role.Administrator);
                case "GameTherapist":
                    return userRepo.GetListOfUserByRole(Constants.Role.GameTherapist);
                case "Guardian":
                    return userRepo.GetListOfUserByRole(Constants.Role.Guardian);
            }

            return null;
        }

        public ApplicationUser getAdministrator()
        {
            return userRepo.GetUserByRole(Constants.Role.Administrator);
        }

        public ApplicationUser getUserDetails(string token, string userID)
        {
            ApplicationUser selectedUser = null;
            if (token == null && userID == null) return selectedUser;
            if (token == "1234")
                selectedUser = userRepo.GetUserByRole(Constants.Role.Supervisor);
            else if (token == "2341")
                selectedUser = userRepo.GetUserByRole(Constants.Role.Doctor);
            else if (token == "4321")
                selectedUser = userRepo.GetUserByRole(Constants.Role.Caregiver);
            else if (token == "3412")
                selectedUser = userRepo.GetUserByRole(Constants.Role.GameTherapist);
            else
            {
                if (userID == null)
                    selectedUser = userRepo.GetUserByToken(token);
                else 
                    selectedUser = userRepo.GetUserByIdToken(userID, token);
                // if (selectedUser != null) selectedUser = userRepo.GetUserByID(selectedUser.Id);
            }
            return selectedUser;
        }

        public string getUserType(ApplicationUser user)
        {
            if (user == null) return null;
            string userRole = userRepo.GetUserRole(user);
            if (userRole == null) return null;
            return userRole;
        }
       
        public bool RevokeToken(string token)
        {
            var user = _db.Users.SingleOrDefault(u => u.RefreshTokens.Any(t => t.Token == token));
            // return false if no user found with token
            if (user == null) return false;
            var refreshToken = user.RefreshTokens.Single(x => x.Token == token);
            // return false if token is not active
            if (!refreshToken.IsActive) return false;
            // revoke token and save
            refreshToken.Revoked = DateTime.UtcNow;
            _db.Update(user);
            _db.SaveChanges();
            return true;
        }

        public async Task<AuthenticationModel> GetTokenAsync(TokenRequestModel model)
        {
            var authenticationModel = new AuthenticationModel();
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user == null)
            {
                authenticationModel.IsAuthenticated = false;
                authenticationModel.Message = $"No Accounts Registered with {model.UserName}.";
                return authenticationModel;
            }
            if (await _userManager.CheckPasswordAsync(user, model.Password))
            {
                authenticationModel.IsAuthenticated = true;
                JwtSecurityToken jwtSecurityToken = await CreateJwtToken(user);
                authenticationModel.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
                authenticationModel.Email = user.Email;
                authenticationModel.UserName = user.UserName;
                var rolesList = await _userManager.GetRolesAsync(user).ConfigureAwait(false);
                authenticationModel.Roles = rolesList.ToList();

                if (user.RefreshTokens.Any(a => a.IsActive))
                {
                    var activeRefreshToken = user.RefreshTokens.Where(a => a.IsActive == true).FirstOrDefault();
                    authenticationModel.RefreshToken = activeRefreshToken.Token;
                    authenticationModel.RefreshTokenExpiration = activeRefreshToken.Expires;
                }
                else
                {
                    var refreshToken = CreateRefreshToken();
                    authenticationModel.RefreshToken = refreshToken.Token;
                    authenticationModel.RefreshTokenExpiration = refreshToken.Expires;
                    user.RefreshTokens.Add(refreshToken);
                    _db.Update(user);
                    _db.SaveChanges();
                }
                return authenticationModel;
            }
            authenticationModel.IsAuthenticated = false;
            authenticationModel.Message = $"Incorrect Credentials for user {user.Email}.";
            return authenticationModel;
        }

        public async Task<AuthenticationModel> RefreshTokenAsync(string token)
        {
            var authenticationModel = new AuthenticationModel();
            var user = _db.Users.SingleOrDefault(u => u.RefreshTokens.Any(t => t.Token == token));
            if (user == null)
            {
                authenticationModel.IsAuthenticated = false;
                authenticationModel.Message = $"Token did not match any users.";
                return authenticationModel;
            }
            var refreshToken = user.RefreshTokens.Single(x => x.Token == token);
            if (!refreshToken.IsActive)
            {
                authenticationModel.IsAuthenticated = false;
                authenticationModel.Message = $"Token Not Active.";
                return authenticationModel;
            }
            //Revoke Current Refresh Token
            refreshToken.Revoked = DateTime.UtcNow;
            //Generate new Refresh Token and save to Database
            var newRefreshToken = CreateRefreshToken();
            user.RefreshTokens.Add(newRefreshToken);
            _db.Update(user);
            _db.SaveChanges();
            //Generates new jwt
            authenticationModel.IsAuthenticated = true;
            JwtSecurityToken jwtSecurityToken = await CreateJwtToken(user);
            authenticationModel.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            authenticationModel.Email = user.Email;
            authenticationModel.UserName = user.UserName;
            var rolesList = await _userManager.GetRolesAsync(user).ConfigureAwait(false);
            authenticationModel.Roles = rolesList.ToList();
            authenticationModel.RefreshToken = newRefreshToken.Token;
            authenticationModel.RefreshTokenExpiration = newRefreshToken.Expires;
            return authenticationModel;
        }

        private RefreshToken CreateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var generator = new RNGCryptoServiceProvider())
            {
                generator.GetBytes(randomNumber);
                return new RefreshToken
                {
                    Token = Convert.ToBase64String(randomNumber),
                    Expires = DateTime.UtcNow.AddDays(10),
                    Created = DateTime.UtcNow
                };
            }
        }



        public ApplicationUser GetById(string id)
        {
            return _db.Users.Find(id);
        }

        private async Task<JwtSecurityToken> CreateJwtToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();
            for (int i = 0; i < roles.Count; i++)
            {
                roleClaims.Add(new Claim("roles", roles[i]));
            }
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwt.DurationInMinutes),
                signingCredentials: signingCredentials);
            return jwtSecurityToken;
        }       

        public static string HashInput(string input)
        {
            
            string stringHashed = input;

            // generate a 128-bit salt using a secure PRNG
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            Console.WriteLine($"Salt: {Convert.ToBase64String(salt)}");

            // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: stringHashed,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA1,
            iterationCount: 10000,
            numBytesRequested: 256 / 8));
            Console.WriteLine($"Hashed: {hashed}");
            return hashed;
        }

    }
}
