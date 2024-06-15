using _4._07._23_2_.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace _4._07._23_2_.Abstract
{
    public interface IUserService
    {
        Task<UserManagerResponse> RegisterUserAsync(RegisterViewModel model);
        Task<UserManagerResponse> LoginUserAsync(LoginViewModel model);
    }

    public class UserService : IUserService
    {
        public UserManager<IdentityUser> _userManager;
        public IConfiguration configuration;
        public UserService(UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            this.configuration = configuration;
        }
        public async Task<UserManagerResponse> RegisterUserAsync(RegisterViewModel model)
        {
            if (model == null) 
                throw new NullReferenceException("Register Model is null");

            if (model.Password != model.ConfirmPassword)
                return new UserManagerResponse
                {
                    Message = "Confirm password doesnt' match the password",
                    IsSuccess = false,
                };

            var identityUser = new IdentityUser
            {
                Email = model.Email,
                UserName = model.Email,
            };
            
            var result = await _userManager.CreateAsync(identityUser,model.Password);

            if(result.Succeeded)
            {
                return new UserManagerResponse
                {
                    Message = "User created succesfully!",
                    IsSuccess = true,
                };
            }

            return new UserManagerResponse
            {
                Message = "User did not create",
                IsSuccess = false,
                Errors = result.Errors.Select(e => e.Description)
            };

        }


        public async Task<UserManagerResponse> LoginUserAsync(LoginViewModel model)
        {
           var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null) {
                return new UserManagerResponse
                {
                    Message = "There is no user with that Email address",
                    IsSuccess = false,
                };
            } 
            var result = await _userManager.CheckPasswordAsync(user, model.Password);

            if (!result)
                return new UserManagerResponse
                {
                    Message = "Invalid password",
                    IsSuccess = false,
                };
            var claims = new[]
            {
                new Claim("Email",model.Email),
                new Claim(ClaimTypes.NameIdentifier,user.Id),
                new Claim(ClaimTypes.Role,"Kullanıcı")
            };

            string signingKey = "benim sifreleme algoritmam 215431534131 dfödçsöfdsö";
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: "www.wikipedi.com",
                audience: "BuBenimKullandığımAudienceDegeri",
                claims: claims,
                expires: DateTime.Now.AddMinutes(40),
                notBefore: DateTime.Now,
                signingCredentials: credentials
                );

            var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

            return new UserManagerResponse
            {
                Message = token,
                IsSuccess = true,
                ExpireDate = jwtSecurityToken.ValidTo
            };
        }   

        
    }
}
 