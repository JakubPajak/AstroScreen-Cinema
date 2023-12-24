﻿using AstroScreen_Cinema.Models.EntitiesDto;

namespace AstroScreen_Cinema.Services
{
    public interface ILoginService
    {
        LoginDto GetLogin(string _login, string _pass, out string _token);
        Task RegisterUser(RegisterDto _user);
        LoginDto UserLogOut(string _login);
    }
}