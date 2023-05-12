using Mobilestore.data;
using Mobilestore.Interface;
using System.Configuration;
using Microsoft.Extensions.Configuration;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<ImobileService, MobileDBContext>();

IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
// Duplicate here any configuration sources you use.
configurationBuilder.AddJsonFile("AppSettings.json");
IConfiguration configuration = configurationBuilder.Build();
builder.Services.Configure<Settings>(options =>
{
    options.ConnectionString = configuration.GetSection("MongoDB:ConnectionString").Value;
    options.Database = configuration.GetSection("MongoDB:Database").Value;
});
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
