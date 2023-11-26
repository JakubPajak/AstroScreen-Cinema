using System;
using System.Security.Claims;

namespace AstroScreen_Cinema.Services
{
    public interface IUserHttpContextService
    {
        ClaimsPrincipal User { get; }
        int? GetUserId { get; }
    }
}