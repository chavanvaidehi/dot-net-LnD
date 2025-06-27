using Microsoft.EntityFrameworkCore;
using ShoppingSite.Data;
using ShoppingSite.Models;

var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllersWithViews()
    .AddSessionStateTempDataProvider(); // optional
builder.Services.AddSession();

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
