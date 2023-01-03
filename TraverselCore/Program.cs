using BusiinessLayer.Abstract;
using BusiinessLayer.Contcreate;
using DataAccessLayer;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concreate;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Identity;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddDbContext<Context>();
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Context>();
builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddTransient(typeof(IService<>), typeof(Service<>));
//Identity yap�land�rmas� 
builder.Services.AddIdentity<AppUser, AppRole>(option =>
{
	option.Password.RequireNonAlphanumeric = false;
	option.Password.RequireLowercase = false;
    option.Password.RequireUppercase = false;
})
	.AddRoleManager<RoleManager<AppRole>>().AddEntityFrameworkStores<Context>().AddDefaultTokenProviders();
//builder.Services.ConfigureApplicationCookie(config =>
//{
//	config.LoginPath = new PathString("/Login/SignUp");
//	//config.LogoutPath = new PathString("/Login/SignUp");
//	//config.Cookie = new CookieBuilder
//	//{
//	//	Name = "MyBlog",
//	//	HttpOnly = true,
//	//	SameSite = SameSiteMode.Strict,
//	//	SecurePolicy = CookieSecurePolicy.SameAsRequest

//	//};
//	//config.SlidingExpiration = true;
//	//config.ExpireTimeSpan = TimeSpan.FromDays(7);
//	//config.AccessDeniedPath = new PathString("/Login/SignUp");
//});
//// burada bitiyor 

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

app.UseAuthentication(); // Identity i�in eklenen alan 


app.UseAuthorization();

//app.UseEndpoints(endpoints =>
//{
//	endpoints.MapControllerRoute(name: "Login", pattern: "{controller=Login}/{action=SignUp}/{id?}"
//		);
//	endpoints.MapDefaultControllerRoute();
//});

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Default}/{action=Index}/{id?}");

app.Run();

