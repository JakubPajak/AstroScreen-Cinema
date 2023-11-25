using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AstroScreen_Cinema.AuthorizationAuthentication;
using AstroScreen_Cinema.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using StackoveflowClone.Exceptions;

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

        public string IndexAuthorize()
        {
            var user = _userHttpContext.GetUserId;
            //var user = _context.Accounts.FirstOrDefault(a => a.Account_ID == Id);

            var authorizatonResult = _authorizationServiece.AuthorizeAsync(_userHttpContext.User, user,
                new DataDisplayRequirement(ResourceOperation.MyAccount)).Result;

            if (authorizatonResult.Succeeded)
                return authorizatonResult.Succeeded.ToString();
            else
                return authorizatonResult.Failure.ToString();
        }
	}
}

