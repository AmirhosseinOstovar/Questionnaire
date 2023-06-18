using Domain_Service.Context;
using Domain_Service.Services.CategoryQuestion;
using Domain_Service.Services.Question;
using Domain_Service.Services.Response;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
var conection= builder.Configuration;
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ICategoryQuestion,CategoryQuestionService>();
builder.Services.AddScoped<IQuestion, QuestionService>();
builder.Services.AddScoped<IResponse, ResponseService>();

//var ss = builder.Configuration.GetSection("ConnectionString:sqlserver");
builder.Services.AddDbContext<DataContext>(ctx =>
ctx.UseSqlServer(builder.Configuration.GetSection("ConnectionString:sqlserver").Value));
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
