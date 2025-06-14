using Microsoft.AspNetCore.Authentication.JwtBearer;
using RealEstate_Dapper_UI.Models;
using RealEstate_Dapper_UI.Services;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;

var builder = WebApplication.CreateBuilder(args);
JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Remove("sub");
// Add services to the container.

builder.Services.Configure<ApiSettings>(builder.Configuration.GetSection("ApiSettingsKey"));



builder.Services.AddTransient<ILoginService, LoginService>();

builder.Services.AddHttpClient();
builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddCookie(JwtBearerDefaults.AuthenticationScheme, options =>
{
    options.LoginPath = "/Login/Index";
    options.LogoutPath = "/Login/LogOut";
    options.AccessDeniedPath = "/Pages/AccessDenied";
    options.Cookie.Name = "RealEstateJwt";
    options.Cookie.HttpOnly = true;
    options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
    options.Cookie.SameSite = SameSiteMode.Strict;
   
});

builder.Services.AddHttpContextAccessor();
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

//app.MapControllerRoute(


//	name: "default",
//	pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
	endpoints.MapControllerRoute(
	name: "property",
	pattern: "property/{id}",
	defaults: new { controller = "Property", action = "PropertySingle" });

	endpoints.MapControllerRoute(
		name: "default",
		pattern: "{controller=Home}/{action=Index}/{id?}");

	endpoints.MapControllerRoute(
		name: "areas",
		pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

});

app.Run();
