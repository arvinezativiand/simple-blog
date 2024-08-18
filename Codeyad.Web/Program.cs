using Codeyad.CoreLayer.Services.Categories;
using Codeyad.CoreLayer.Services.Comments;
using Codeyad.CoreLayer.Services.FileManager;
using Codeyad.CoreLayer.Services.MainPage;
using Codeyad.CoreLayer.Services.Posts;
using Codeyad.CoreLayer.Services.Users;
using Codeyad.DataLayer.Context;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IPostServices, PostServices>();
builder.Services.AddScoped<IFileManager, FileManager>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<IMainPageService, MainPageService>();

builder.Services.AddDbContext<BlogContext>(option =>
{
    option.UseSqlServer("Server =DESKTOP-OKQUJR3\\NEWSQLSERVER; Database = Codeyad; Encrypt=false; Integrated Security = true; MultipleActiveResultSets = true", b => b.MigrationsAssembly("Codeyad.Web"));
});


builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    option.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(option =>
{
    option.ExpireTimeSpan = TimeSpan.FromDays(30);
    option.LogoutPath = "/Auth/Logout";
    option.LoginPath = "/Auth/Login";
    option.AccessDeniedPath = "/";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/ErrorHandler/500");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/ErorrHandler/{0}");
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "Default",
    pattern: "{area:exists}/{controller=home}/{action=index}/{id?}"
    );
app.MapRazorPages();

app.Run();
