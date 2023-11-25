using System;
using System.Security.Claims;
using AstroScreen_Cinema.Services;

namespace StackoveflowClone.Services
{
    public class UserHttpContextService : IUserHttpContextService
    {
        private IHttpContextAccessor _contextAccessor;

        public UserHttpContextService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public ClaimsPrincipal User => _contextAccessor.HttpContext?.User;

        public int? GetUserId
        {
            get
            {
                var userIdClaim = User?.FindFirst(u => u.Type == ClaimTypes.NameIdentifier);

                if (userIdClaim != null && int.TryParse(userIdClaim.Value, out var userId))
                {
                    return userId;
                }

                return null;
            }
        }
    }
}