using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AstroScreen_Cinema.AuthorizationAuthentication;
using AstroScreen_Cinema.Models;
using AstroScreen_Cinema.Models.EntitiesDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
//using StackoveflowClone.Exceptions;

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

        public async Task<List<MovieDto>> GetMovies()
        {
            var movies = await _context.Movies.Where(m => m.PosterPath != null)
                .Select(m => new MovieDto
                {
                    Title = m.Title,
                    Desc = m.Description,
                    Duration = m.Duration,
                    imgPath = m.PosterPath

                }).ToListAsync();

            return movies;
        }
	}
}