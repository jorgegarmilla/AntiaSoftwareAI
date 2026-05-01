using Blazor.WhyDidYouRender.Configuration;
using Blazor.WhyDidYouRender.Extensions;
using BlazorBlueprint.Components;
using BlazorBlueprint.Primitives.Extensions;
using Blazored.Modal;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using System.Runtime.CompilerServices;
using WebApp.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
AddServices(builder);
await builder.Build().RunAsync();


static void AddServices(WebAssemblyHostBuilder builder)
{
    // identity
    builder.Services.AddAuthorizationCore().AddCascadingAuthenticationState().AddAuthenticationStateDeserialization();
    builder.Services.AddBlazorBlueprintComponents();

    // application services
    builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
    builder.Services.AddScoped<IDataService, DataService>();
    builder.Services.AddScoped<IApiProxy, ApiProxy>();
    builder.Services.AddSingleton<ResultState>();

    // infrastructure services
    builder.Services.AddBlazoredModal();
    builder.Services.AddValidation();

    if (builder.HostEnvironment.Environment == "Development")
        builder.Services.AddWhyDidYouRender(config => ReturnWhyDidYourRenderConfiguration(builder, true));
    
    else if (builder.HostEnvironment.Environment == "Testing")
        builder.Services.AddWhyDidYouRender(config => ReturnWhyDidYourRenderConfiguration(builder, false));
    
    else if (builder.HostEnvironment.Environment == "Production")
        builder.Services.AddWhyDidYouRender(config => { config.Enabled = false; });

    // cascading values
    builder.Services.AddCascadingValue(_ => DataService.ReturnPaises());
    builder.Services.AddCascadingValue<string>("EnvironmentName", _ => builder.HostEnvironment.Environment);

}

static WhyDidYouRenderConfig ReturnWhyDidYourRenderConfiguration(WebAssemblyHostBuilder builder, bool isDevelopment = false)
{
    WhyDidYouRenderConfig config = new WhyDidYouRenderConfig();

    if (isDevelopment)
    {
        config.Enabled = builder.HostEnvironment.IsDevelopment();
        config.Verbosity = TrackingVerbosity.Verbose;
        config.Output = TrackingOutput.BrowserConsole;
        config.TrackParameterChanges = true;
        config.EnableStateTracking = true;
    }
    else {

        //testing
        config.Enabled = true;
        config.Verbosity = TrackingVerbosity.Normal;
        config.Output = TrackingOutput.BrowserConsole;
        config.TrackParameterChanges = true;
        config.EnableStateTracking = true;
    }

    return config;
}