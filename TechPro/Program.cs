using Microsoft.EntityFrameworkCore;
using TechPro.Models;
using TechPro.Models;
using SQLitePCL;

var builder = WebApplication.CreateBuilder(args);

// Initialize SQLite batteries
raw.SetProvider(new SQLite3Provider_e_sqlite3());
Batteries_V2.Init();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<Context>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
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
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();