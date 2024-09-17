using CompanyManagement.Infrasructure.EFCore;
using CompanyManagement.Infrastructure.Configuration;
using Framework.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using ServiceHost;
using Framework.Application.Sender.Sms;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddHttpClient();

builder.Services.AddDbContext<CompanyContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("VisitCompanyDb")
    ?? throw new InvalidOperationException("Connection string 'VisitCompanyDb' not found.")));

// Add authentication with cookies
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account"; // مسیر صفحه ورود
        options.AccessDeniedPath = "/AccessDenied"; // مسیر صفحه دسترسی غیرمجاز
        TimeSpan.FromMinutes(90);// مدتت زمان انقضای کوکی
        //options.ExpireTimeSpan = TimeSpan.FromDays(1);
        options.SlidingExpiration = true; // غیرفعال کردن تمدید خودکار
        options.Cookie.HttpOnly = true;  //این کار از حملات XSS (Cross-Site Scripting) جلوگیری می‌کند.
        options.Cookie.IsEssential = true;
        options.Cookie.SameSite = SameSiteMode.Strict; // این کار از حملات CSRF (Cross-Site Request Forgery) جلوگیری می‌کند.
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always; //با این کار، کوکی‌ها در برابر حملات مانند "man-in-the-middle" مقاوم‌تر می‌شوند،

    });

builder.Services.AddAuthorization(options =>
{
    // تعریف سیاست احراز هویت AdminArea
    options.AddPolicy("AdminArea", policy =>
    {
        policy.RequireAuthenticatedUser(); // نیاز به احراز هویت
        policy.RequireRole("مدیر سیستم"); // نیاز به نقش 'Admin'
    });
});

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(90); // این برای سشن است
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;

});

builder.Services.AddRazorPages()
    .AddMvcOptions(options => options.Filters.Add<SecurityPageFilter>())
    .AddRazorPagesOptions(options =>
    {
        // همه پوشه‌های مرتبط با مدیریت و دیگر صفحات حساس را محافظت کنید
        //options.Conventions.AuthorizeAreaFolder("Administration", "/Company", "Company");
        //options.Conventions.AuthorizeAreaFolder("Administration", "/CompanyCategories", "CompanyCategory");
        //options.Conventions.AuthorizeAreaFolder("Administration", "/checklist", "checklist");
       // options.Conventions.AuthorizeAreaFolder("Administration", "/", "AdminArea"); // اضافه کردن حفاظت برای کل ناحیه مدیریت
    });

builder.Services.AddHttpContextAccessor();

CompanyManagementBootsrapper.Configure(builder.Services, "VisitCompanyDb");

builder.Services.AddSingleton<IPasswordHasher, PasswordHasher>();
builder.Services.AddTransient<IAuthHelper, AuthHelper>();
builder.Services.AddTransient<ISmsSender, SmsSender>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// استفاده از Session و Authentication و Authorization به ترتیب صحیح
app.UseSession();
app.UseAuthentication(); // باید قبل از UseAuthorization فراخوانی شود
app.UseAuthorization();

app.MapRazorPages();

app.Run();
