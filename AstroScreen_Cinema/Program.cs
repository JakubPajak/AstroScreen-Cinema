using System.Text;
using AstroScreen_Cinema;
using AstroScreen_Cinema.AuthorizationAuthentication;
using AstroScreen_Cinema.DataSeed;
using AstroScreen_Cinema.Models;
using AstroScreen_Cinema.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using StackoveflowClone.Services;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);
var authenticationSettings = new AuthenticationSettings();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Configuration.GetSection("Authentication").Bind(authenticationSettings);

// Add services to the container.

builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = "Bearer";
    option.DefaultScheme = "Bearer";
    option.DefaultChallengeScheme = "Bearer";
}).AddJwtBearer(config =>
{
    config.RequireHttpsMetadata = false;
    config.SaveToken = true;
    config.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidIssuer = authenticationSettings.JwtIssuer,
        ValidAudience = authenticationSettings.JwtIssuer,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettings.JwtKey)),
    };
});

// Set up logger with enriched log events
Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .WriteTo.Logger(l => l
        .Filter.ByIncludingOnly(evt => evt.Properties.ContainsKey("LogType") && evt.Properties["LogType"].ToString() == "email")
        .WriteTo.File("email.txt", restrictedToMinimumLevel: LogEventLevel.Information, rollingInterval: RollingInterval.Month))
    .WriteTo.Logger(l => l
        .Filter.ByIncludingOnly(evt => evt.Properties.ContainsKey("LogType") && evt.Properties["LogType"].ToString() == "reservation")
        .WriteTo.File("reservation.txt", restrictedToMinimumLevel: LogEventLevel.Information, rollingInterval: RollingInterval.Day))
    .CreateLogger();



builder.Services.Configure<Microsoft.AspNetCore.Mvc.JsonOptions>(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
});


builder.Services.AddDbContext<AppDBContext>(options =>
{
    //options.UseSqlServer(builder.Configuration.GetConnectionString("DataBaseMAC"));
    options.UseSqlServer(builder.Configuration.GetConnectionString("DataBaseWIN"));
});

builder.Services.AddSession();
builder.Services.AddLogging();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton(authenticationSettings);

//Seeding Services
builder.Services.AddScoped<DataSeeding>();
builder.Services.AddScoped<MyHallGen>();
builder.Services.AddScoped<MyMovieGen>();
builder.Services.AddScoped<MyShowtimeGen>();
builder.Services.AddScoped<DataGenerator>();

//Controller services
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IHallReperuairService, HallReperuairService >();
builder.Services.AddScoped<IHomeService, HomeService>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IMyAccountService, MyAccountService>();
builder.Services.AddScoped<INowShowingService, NowShowingService>();
builder.Services.AddScoped<IReservationService, ReservationService>();
builder.Services.AddScoped<IUserHttpContextService, UserHttpContextService>();

var app = builder.Build();


using var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<DataGenerator>();

//await seeder.Seed();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/");

app.Run();