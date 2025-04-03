using Microsoft.EntityFrameworkCore;
using MVC_Learning_ProjectApplication.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

//  ---------Register DbContext------------------------------------------------------------
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));
//-----------------------------------------------------------------------------------------


//  --------Register Repositories-----------------------------------------------------------
builder.Services.AddScoped<ExamsRepository>();
//------------------------------------------------------------------------------------------

var app = builder.Build();

//  ------------Middleware and routing------------------------------------------------------
app.UseStaticFiles();
app.UseRouting();
//------------------------------------------------------------------------------------------

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
