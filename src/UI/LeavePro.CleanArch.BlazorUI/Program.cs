using System.Reflection;
using LeavePro.CleanArch.BlazorUI;
using LeavePro.CleanArch.BlazorUI.Contracts;
using LeavePro.CleanArch.BlazorUI.Services;
using LeavePro.CleanArch.BlazorUI.Services.Base;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => 
//    new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });


//Microsoft.Extensions.Http
builder.Services.AddHttpClient<IClient, Client>(client =>
    client.BaseAddress = new Uri("https://localhost:7214/"));

builder.Services.AddScoped<ILeaveAllocationService, LeaveAllocationService>();
builder.Services.AddScoped<ILeaveRequestService, LeaveRequestService>();
builder.Services.AddScoped<ILeaveTypeService, LeaveTypeService>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

await builder.Build().RunAsync();
