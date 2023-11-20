using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AstroScreen_Cinema.AuthorizationAuthentication;
using AstroScreen_Cinema.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;

namespace AstroScreen_Cinema.Services
{
	public class HomeService
	{
        private readonly AppDBContext _context;
        private readonly AuthenticationSettings _authenticationSettings;
        private readonly IAuthorizationService _authorizationServiece;
        private readonly IUserHttpContextService _userHttpContext;

        public HomeService(AppDBContext context, AuthenticationSettings authenticationSettings, IAuthorizationService authorizationServiece,
            IUserHttpContextService userHttpContext)
		{
			_context = context;
			_authenticationSettings = authenticationSettings;
            _authorizationServiece = authorizationServiece;
            _userHttpContext = userHttpContext;
        }

        public string IndexTokens()
        {

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Role, "NULL"),
                new Claim(ClaimTypes.NameIdentifier, "1"),
                new Claim(ClaimTypes.Name, "Default"),
                new Claim(ClaimTypes.MobilePhone, "xxx")
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
	}
}

