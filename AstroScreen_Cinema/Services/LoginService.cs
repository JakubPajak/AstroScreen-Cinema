using System;
using AstroScreen_Cinema.Models;
using AstroScreen_Cinema.Models.EntitiesDto;

namespace AstroScreen_Cinema.Services
{
	public class LoginService
	{
        private readonly AppDBContext _appDBContext;

        public LoginService(AppDBContext appDBContext)
		{
			_appDBContext = appDBContext;
		}

		public LoginDto GetLogin(string _login, string _pass)
		{
			var getUser = _appDBContext.Accounts.FirstOrDefault(a => a.Email.Equals(_login));

			if (getUser != null)
			{
				var userDto = new LoginDto()
				{
					Login = getUser.Email,
					Password = getUser.Password,
				};


				if (userDto.Password.Equals(_pass))
				{
					userDto.IsLogged = true;
					return userDto;
				}
				else
				{
					userDto.IsLogged = false;
					return userDto;
				}

			}
			else
			{
				return new LoginDto();
			}
		}
	}
}

