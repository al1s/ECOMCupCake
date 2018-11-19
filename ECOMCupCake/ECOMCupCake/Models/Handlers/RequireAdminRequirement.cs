using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECOMCupCake.Models.Handlers
{
    public class RequireAdminRequirement : IAuthorizationRequirement
    {
        public RequireAdminRequirement()
        {

        }
    }
}
