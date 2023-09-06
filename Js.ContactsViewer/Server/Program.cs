global using Js.ContactsViewer.Shared.Models;
using Js.ContactsViewer.Server.DataAccess;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();


//odczyt danych dla po³¹czenia z baz¹ SqlServer
var cs = builder.Configuration.GetConnectionString("DefaultConnection");
//rejestracja serwisu dla data access dla komunikacji EF z baz¹ danych
builder.Services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(cs));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
