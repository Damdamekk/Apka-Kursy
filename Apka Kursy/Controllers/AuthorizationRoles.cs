using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Apka_Kursy.Exceptions;
using Apka_Kursy.Services;


public static class AuthorizationRoles
{
    public const string Admin = "Admin";
    public const string Nauczyciel = "Nauczyciel";
}
