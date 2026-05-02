using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System.Security.Claims;
using WebApp.Client.ModelView;
using WebApp.Components.Account.Pages;
using WebApp.Components.Account.Pages.Manage;
using WebApp.Data;
using WebApp.Data.Repositories;

namespace WebApp.Controllers
{
    public static class ApiExtensions
    {
        public static IEndpointConventionBuilder MapApiEndpoints(this IEndpointRouteBuilder endpoints)
        {
            ArgumentNullException.ThrowIfNull(endpoints);

            var apiGroup = endpoints.MapGroup("/api");

            apiGroup.MapGet("/jobs", async (IJobsRepository repository) => await repository.GetAllJobsAsync());
            apiGroup.MapPost("/jobs", async (IJobsRepository repository, JobModelView job) => await repository.AddJobAsync(job)).RequireAuthorization();

            return apiGroup;

        }

        public static IEndpointConventionBuilder MapIdentityEndpoints(this IEndpointRouteBuilder endpoints)
        {
            ArgumentNullException.ThrowIfNull(endpoints);

            var accountGroup = endpoints.MapGroup("/Account");

            accountGroup.MapPost("/Logout", async (
             HttpContext httpContext,
             ClaimsPrincipal user,
             [FromServices] SignInManager<ApplicationUser> signInManager,
             [FromForm] string returnUrl) =>
            {
                await signInManager.SignOutAsync();

                // Delete the antiforgery cookie so the Login page always gets a fresh
                // token+cookie pair after logout, preventing stale-cookie 400 errors.
                foreach (var cookieName in httpContext.Request.Cookies.Keys
                    .Where(k => k.StartsWith(".AspNetCore.Antiforgery")))
                {
                    httpContext.Response.Cookies.Delete(cookieName);
                }

                return TypedResults.LocalRedirect($"~/{returnUrl}");
            }).DisableAntiforgery();

            return accountGroup;
        }
    }

}