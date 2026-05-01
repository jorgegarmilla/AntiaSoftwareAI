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
             ClaimsPrincipal user,
             [FromServices] SignInManager<ApplicationUser> signInManager,
             [FromForm] string returnUrl) =>
            {
                await signInManager.SignOutAsync();
                return TypedResults.LocalRedirect($"~/{returnUrl}");
            }).DisableAntiforgery();

            return accountGroup;
        }
    }

}