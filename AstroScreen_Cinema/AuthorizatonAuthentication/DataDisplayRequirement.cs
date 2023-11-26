using System;
using Microsoft.AspNetCore.Authorization;

namespace AstroScreen_Cinema.AuthorizationAuthentication
{
    public enum ResourceOperation
    {
        MyAccount,
        Reservation,
    }

    public class DataDisplayRequirement : IAuthorizationRequirement
    {
        public ResourceOperation ResourceOperation { get; set; }

        public DataDisplayRequirement(ResourceOperation resourceOperation)
        {
            ResourceOperation = resourceOperation;
        }
    }
}