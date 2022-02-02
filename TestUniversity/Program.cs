using Microsoft.EntityFrameworkCore;
using System.Configuration;
using University.Data;
using University.Repo;
using University.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TestUniversityContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddMvc();

/* services.AddScoped(typeof (Repository), typeof (RepositoryCourses));
    services.AddScoped(typeof(Repository), typeof(RepositoryGroups));
    services.AddScoped(typeof(Repository), typeof(RepositoryStudents));*/


var DbContextOptionsBuilder = new DbContextOptionsBuilder<TestUniversityContext>();
DbContextOptionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));



builder.Services.AddTransient<IStudentService>(s => new StudentService(new TestUniversityContext(DbContextOptionsBuilder.Options)));
builder.Services.AddTransient<ICourseService>(c => new CourseService(new TestUniversityContext(DbContextOptionsBuilder.Options)));
builder.Services.AddTransient<IGroupService>(g => new GroupService(new TestUniversityContext(DbContextOptionsBuilder.Options)));
/*services.AddTransient<IGroupService, GroupService>();
services.AddTransient<ICourseService, CourseService>();*/


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
