using AM_DBTC.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:7167") 
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var baseUrl = builder.Configuration["ApiSettings:BaseUrl"]
    ?? throw new InvalidOperationException("ApiSettings:BaseUrl is not configured.");

builder.Services.AddHttpClient("ApiClient", client =>
{
    client.BaseAddress = new Uri(baseUrl);
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});

builder.Services.AddScoped<IAttendanceService, AttendanceService>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IFacultyService, FacultyService>();
builder.Services.AddScoped<ICourseService, CourseService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseCors("AllowFrontend");
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Attendance}/{action=AttendanceView}/{id?}");

app.Run();








//using Microsoft.AspNetCore.Cors.Infrastructure;
//using AM_DBTC.Services;

////var builder = WebApplication.CreateBuilder(args);

////// Add services to the container.
////builder.Services.AddControllersWithViews();

////var app = builder.Build();

////// Configure the HTTP request pipeline.
////if (!app.Environment.IsDevelopment())
////{
////    app.UseExceptionHandler("/Home/Error");
////    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
////    app.UseHsts();
////}

////app.UseHttpsRedirection();
////app.UseStaticFiles();

////app.UseRouting();

////app.UseAuthorization();

////app.MapControllerRoute(
////    name: "default",
////    pattern: "{controller=Login}/{action=Index}/{id?}");

////app.Run();









////using AM_DBTC.Services;

////var builder = WebApplication.CreateBuilder(args);

////builder.Services.AddControllersWithViews();

////var baseUrl = builder.Configuration["ApiSettings:BaseUrl"]
////    ?? throw new InvalidOperationException("ApiSettings:BaseUrl is not configured.");

////builder.Services.AddHttpClient("ApiClient", client =>
////{
////    client.BaseAddress = new Uri(baseUrl);
////    client.DefaultRequestHeaders.Add("Accept", "application/json");
////});

////builder.Services.AddScoped<IAttendanceService, AttendanceService>();
////builder.Services.AddScoped<IStudentService, StudentService>();
////builder.Services.AddScoped<IFacultyService, FacultyService>();
////builder.Services.AddScoped<ICourseService, CourseService>();

////var app = builder.Build();

////if (!app.Environment.IsDevelopment())
////{
////    app.UseExceptionHandler("/Home/Error");
////    app.UseHsts();
////}

////app.UseHttpsRedirection();
////app.UseStaticFiles();
////app.UseRouting();
////app.UseAuthorization();

////app.MapControllerRoute(
////    name: "default",
////    pattern: "{controller=Attendance}/{action=AttendanceView}/{id?}");

////app.Run();

// huhu ma'am