global using Js.ContactsViewer.Client.Services;
global using Js.ContactsViewer.Client.Services.Interface;
global using Js.ContactsViewer.Shared.Models;
using Js.ContactsViewer.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

//rejestracja serwis�w
builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ISubCategoryService, SubCategoryService>();


await builder.Build().RunAsync();
