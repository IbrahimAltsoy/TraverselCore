using BusiinessLayer.Abstract;
using BusiinessLayer.Contcreate;
using DataAccessLayer;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concreate;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Identity;
using NToastNotify;
using Serilog;
using Serilog.Core;
using System;
using TraverselCore.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews()
    .AddNToastNotifyToastr(new ToastrOptions()
    {
        PositionClass = ToastPositions.TopRight,
        TimeOut = 3000

    });
// Buradan balýyor

Logger log = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("Logs/log.txt")
    .CreateLogger();
builder.Host.UseSerilog(log);

// burada bitiyor

builder.Services.AddDbContext<Context>();

builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddTransient(typeof(IService<>), typeof(Service<>));
builder.Services.AddTransient(typeof(ICommentService), typeof(CommentService));
builder.Services.AddTransient(typeof(IExcelService), typeof(ExcelService));//Excel servisi içðin ekledik
builder.Services.AddTransient(typeof(IPdfReportService), typeof(PdfReportService));// Pdf servisi için inþa ettik
builder.Services.AddTransient(typeof(IContactUsService), typeof(ContactUsService));//silinmeyen mesajlar için oluþturduðumuz servistir. 

//Identity yapýlandýrmasý 
builder.Services.AddIdentity<AppUser, AppRole>(option =>
{
	option.Password.RequireNonAlphanumeric = true;
	option.Password.RequireLowercase = true;
    option.Password.RequireUppercase = true;
})
	.AddRoleManager<RoleManager<AppRole>>().AddEntityFrameworkStores<Context>().AddDefaultTokenProviders().AddErrorDescriber<CustomIdentityValidator>();


var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    
    app.UseHsts();
}


app.UseStatusCodePagesWithReExecute("/ErrorPage/ErrorNumber", "?code={0}");// adres çubuðunda tanýmsýz adresler girildiðinde yönlendirileceði yeri belirtiyoruz. 
app.UseNToastNotify();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // Identity için eklenen alan 


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
// Area için eklenen alandýr. 
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});


app.Run();

