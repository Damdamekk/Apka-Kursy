using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Apka_Kursy.Exceptions;
using Apka_Kursy.Services;


namespace Apka_Kursy.Controllers
{
    public static class AuthorizationPolicies
    {
        public static readonly AuthorizationPolicy AdminPolicy = new AuthorizationPolicyBuilder().RequireRole(AuthorizationRoles.Admin).Build();
        public static readonly AuthorizationPolicy TeacherPolicy = new AuthorizationPolicyBuilder().RequireRole(AuthorizationRoles.Nauczyciel).Build();
    }
}
