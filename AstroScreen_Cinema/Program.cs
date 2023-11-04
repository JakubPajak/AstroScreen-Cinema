using AstroScreen_Cinema;
using AstroScreen_Cinema.DataSeed;
using AstroScreen_Cinema.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


//builder.Services.AddDbContext<AppDBContext>();
builder.Services.AddDbContext<AppDBContext>(options =>
{
    //options.UseSqlServer(builder.Configuration.GetConnectionString("DataBaseMAC"));
    options.UseSqlServer(builder.Configuration.GetConnectionString("DataBaseWIN"));
});
builder.Services.AddScoped<DataSeeding>();
builder.Services.AddScoped<DataGenerator>();


var app = builder.Build();


using var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<DataGenerator>();

seeder.Seed();


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



//Lukasz ciezko kapuje temat
//Ale stara sie walczyc
//Chociaz roznie to wychodzi
