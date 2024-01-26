using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using user_management.Context;
using user_management.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<UserContext>(options =>
        options.UseSqlite("Data Source=app.db"));

builder.Services.AddIdentity<UserViewModel, IdentityRole>()
    .AddEntityFrameworkStores<UserContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    // Ќастройки Identity, например, требовани€ к парол€м и другие параметры
});

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "Account",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.MapControllerRoute(
    name: "Admin",
    pattern: "{controller=Admin}/{action=List}/{id?}");

app.MapControllerRoute(
    name: "User",
    pattern: "{controller=User}/{action=Home}/{id?}");

InitializeDatabaseAndAdminUser(app);

app.Run();


void InitializeDatabaseAndAdminUser(IApplicationBuilder app)
{
    using var scope = app.ApplicationServices.CreateScope();
    var serviceProvider = scope.ServiceProvider;
    var dbContext = serviceProvider.GetRequiredService<UserContext>();
    var userManager = serviceProvider.GetRequiredService<UserManager<UserViewModel>>();
    var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    // ѕрименение миграций
    dbContext.Database.Migrate();

    // ѕроверка существовани€ роли "Admin" и создание ее, если не существует
    var adminRoleExists = roleManager.RoleExistsAsync("Admin").Result;
    if (!adminRoleExists)
    {
        roleManager.CreateAsync(new IdentityRole("Admin")).Wait();
    }

    // ѕроверка существовани€ пользовател€ с ролью "Admin" и создание его, если не существует
    var adminUser = userManager.FindByNameAsync("admin").Result;
    if (adminUser == null)
    {
        adminUser = new UserViewModel
        {
            UserName = "admin",
            Email = "admin@example.com",
        };
        userManager.CreateAsync(adminUser, "AdminPassword123!").Wait();
        userManager.AddToRoleAsync(adminUser, "Admin").Wait();
    }
}