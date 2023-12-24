using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using AstroScreen_Cinema.AuthorizationAuthentication;
using AstroScreen_Cinema.Models;
using AstroScreen_Cinema.Models.EntitiesDto;
using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using StackoveflowClone.Exceptions;

namespace AstroScreen_Cinema.Services
{
    public class LoginService : ILoginService
    {
        private readonly AppDBContext _appDBContext;
        private readonly AuthenticationSettings _authenticationSettings;
        private readonly IAuthorizationService _authorizationServiece;
        private readonly IUserHttpContextService _userHttpContext;

        public LoginService(AppDBContext context, AuthenticationSettings authenticationSettings, IAuthorizationService authorizationServiece,
            IUserHttpContextService userHttpContext)
        {
            _appDBContext = context;
            _authenticationSettings = authenticationSettings;
            _authorizationServiece = authorizationServiece;
            _userHttpContext = userHttpContext;
        }



        public LoginDto GetLogin(string _login, string _pass, out string _token)
        {
            var getUser = _appDBContext.Accounts.FirstOrDefault(a => a.Email.Equals(_login));

            if (getUser == null)
                throw new NotFoundException("Invalid email address");

            //if (VerifyPassword(_pass, getUser.Password))
            //    throw new ForbiddenAccessException("Invalid email or Pass");

            if (getUser.Password != _pass)
                throw new ForbiddenAccessException("Invalid email or Pass");



            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Role, "Logged"),
                new Claim(ClaimTypes.NameIdentifier, getUser.Account_ID.ToString()),
                new Claim(ClaimTypes.Name, getUser.Name),
                new Claim(ClaimTypes.MobilePhone, getUser.PhoneNum.ToString())
            };


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(double.Parse(_authenticationSettings.JwtExpireDays));

            var token = new JwtSecurityToken(_authenticationSettings.JwtIssuer, _authenticationSettings.JwtIssuer
                , claims
                , expires: expires
                , signingCredentials: cred);


            var tokenHandler = new JwtSecurityTokenHandler();
            _token = tokenHandler.WriteToken(token);

            return new LoginDto() { Login = getUser.Email, Password = getUser.Password, IsLogged = "YES" };
        }



        public LoginDto UserLogOut(string _login)
        {
            var getUser = _appDBContext.Accounts.FirstOrDefault(a => a.Email.Equals(_login));

            if (getUser != null)
            {
                var userDto = new LoginDto()
                {
                    Login = getUser.Email,
                    Password = getUser.Password,
                };

                userDto.IsLogged = "FALSE";
                return userDto;

            }
            else
            {
                return new LoginDto();
            }
        }

        //The role of this method is quite straight forward
        //It privide logic for registration of the new user to database
        //We want to ensure each user is unique so second attempt to register
        //using the same email address will result in error
        public async Task RegisterUser(RegisterDto _user)
        {
            var newUser = new Account()
            {
                Name = _user.Name,
                Surname = _user.SecondName,
                Password = HashPassword(_user.Password),
                Email = _user.EmailAddress,
                PhoneNum = _user.PhoneNum,
                Birthdate = _user.BirthDate
            };

            await _appDBContext.AddAsync(newUser);
            try
            {
                await _appDBContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new BadRequestException(ex.ToString());
            }
        }

        //This private method provides the logic to make usage of the service
        //more secure and store user's passwords in a hashed version
        private string HashPassword(string _pass)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedPass = sha256.ComputeHash(Encoding.UTF8.GetBytes(_pass));
                return Convert.ToBase64String(hashedPass);
            }
        }

        //This private method serves a crucial role in authentication
        //Its role is to hash entered password during login and then check its similatiry
        //with the password corellated with user's login
        private bool VerifyPassword(string _enteredPass, string _hashedPass)
        {
            using(var sha256 = SHA256.Create())
            {
                var _hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(_enteredPass));
                var _enteredPassHash = Convert.ToBase64String(_hashedBytes);

                return string.Equals(_enteredPassHash, _hashedPass);
            }
        }
    }
}