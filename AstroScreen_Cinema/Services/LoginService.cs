using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
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
	public class LoginService
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

        public string GetLogin(string _login, string _pass)
		{
			var getUser = _appDBContext.Accounts.FirstOrDefault(a => a.Email.Equals(_login));

			if (getUser == null)
				throw new NotFoundException("Invalid email address");

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

            return tokenHandler.WriteToken(token);
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
	}
}

