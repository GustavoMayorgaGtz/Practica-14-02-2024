using Microsoft.EntityFrameworkCore;
using Practica_14_02_2024.Context;
using Practica_14_02_2024.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ProjectContext>((contextOptions) =>
{
    contextOptions.UseSqlServer(builder.Configuration.GetConnectionString("connection"));
});

builder.Services.Configure<AzureStorageConfig>(builder.Configuration.GetSection(("AzureStorage")));

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
