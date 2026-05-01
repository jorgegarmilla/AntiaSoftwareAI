using Azure.Identity;
using BlazorBlueprint.Components;
using BlazorBlueprint.Primitives.Extensions;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApp.Client.Services;
using WebApp.Components;
using WebApp.Components.Account;
using WebApp.Controllers;
using WebApp.Data;
using WebApp.Data.Repositories;
using WebApp.Infrastructure.Identity;

var builder = WebApplication.CreateBuilder(args);
AddServices(builder);
var app = builder.Build();
ConfigureApp(app);
app.Run();


static void AddServices(WebApplicationBuilder builder)
{
    // razor components
    builder.Services.AddRazorComponents().AddInteractiveServerComponents().AddInteractiveWebAssemblyComponents().AddAuthenticationStateSerialization();
    builder.Services.AddBlazorBlueprintComponents();

    // database
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
    builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
    builder.Services.AddDatabaseDeveloperPageExceptionFilter();

    // identity
    builder.Services.AddCascadingAuthenticationState();
    builder.Services.AddScoped<IdentityUserAccessor>();
    builder.Services.AddScoped<IdentityRedirectManager>();
    builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();
    builder.Services.AddAuthentication(options => { options.DefaultScheme = IdentityConstants.ApplicationScheme; options.DefaultSignInScheme = IdentityConstants.ExternalScheme; }).AddIdentityCookies();
    builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<ApplicationDbContext>().AddSignInManager().AddDefaultTokenProviders();

    // application services
    builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();
    builder.Services.AddScoped<IJobsRepository, JobsRepository>();
    builder.Services.AddScoped<IDataService, DataService>();
    builder.Services.AddSingleton<ResultState>();
    builder.Services.AddApplicationInsightsTelemetry(builder.Configuration);  //https://learn.microsoft.com/en-us/dynamics365/business-central/dev-itpro/developer/devenv-instrument-application-for-telemetry-app-insights

    //builder.Services.AddBlazorDevTools();
}

static void ConfigureApp(WebApplication app)
{
    if (app.Environment.IsDevelopment())
    {
        app.UseWebAssemblyDebugging();
        app.UseMigrationsEndPoint();
    }
    else
    {
        app.UseExceptionHandler("/Error", createScopeForErrors: true);
        app.UseHsts(); // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    }

    app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
    app.UseHttpsRedirection();
    app.UseStaticFiles();
    app.UseAntiforgery();
    app.MapStaticAssets();
    app.MapRazorComponents<App>().AddInteractiveServerRenderMode().AddInteractiveWebAssemblyRenderMode().AddAdditionalAssemblies(typeof(WebApp.Client._Imports).Assembly);
    app.MapApiEndpoints();
    app.MapIdentityEndpoints();
}