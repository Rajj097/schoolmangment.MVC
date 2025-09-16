using Microsoft.EntityFrameworkCore;
using schoolmangment.MVC.Database;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<SchoolMGTContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SchoolMGTContext") ?? throw new InvalidOperationException("Connection string 'SchoolMGTContext' not found.")));

// Add services to the container.
var conn = builder.Configuration.GetConnectionString("SchoolMGTConnection");

builder.Services.AddDbContext<SchoolMgtContext>(q => q.UseSqlServer(conn));

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
