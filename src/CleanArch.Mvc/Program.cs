using CleanArch.Infra.Data;
using CleanArch.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using CleanArch.Infra.IoC;
using CleanArch.Infra.IoC.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureContainer(builder.Configuration);
builder.Services.AddControllersWithViews();

var app = builder.Build();

if (app.Environment.IsProduction())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Migrate();

app.Run();
