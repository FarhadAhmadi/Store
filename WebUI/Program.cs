using Application.Common.Interfaces;
using Application.Common.Interfaces.Facad;
using Application.Services.Category.FacadPattern;
using Application.Services.Roles.Queries.GetRoles;
using Application.Services.Users.Commands.AddUser;
using Application.Services.Users.Commands.DeleteUser;
using Application.Services.Users.FacadPattern;
using Application.Services.Users.Queries.GetUsers;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddAuthentication(options =>
{
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(options =>
{
    options.LoginPath = new PathString("/Authentication/Signin");
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5.0);
    options.AccessDeniedPath = new PathString("/Authentication/Signin");
});




// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IStoreDbContext, StoreDbContext>();
builder.Services.AddScoped<IGetRolesService, GetRolesService>();
builder.Services.AddScoped<IUserFacad,UserFacad>();

builder.Services.AddDbContext<StoreDbContext>(e => e.UseSqlServer("Data Source=. ;Initial Catalog=StoreDatabase;Integrated Security=True ; Encrypt=False ;"));

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{area=Admin}/{controller=User}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>

endpoints.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
        ));



app.Run();
