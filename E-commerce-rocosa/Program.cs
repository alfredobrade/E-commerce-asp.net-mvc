using E_commerce_rocosa.Datos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApplicationDbContext>(options => 
                              options.UseSqlServer(
                                  builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddControllersWithViews();



var app = builder.Build();

// Configure the HTTP request pipeline.  --El pipeline especifica como la app responde a petisiones http
//--el pipeline esta conformado de middlewares. (el MVC esta considerado un middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); //--para usar los archivos estaticos de wwwroot - html, css, js, img, etc

app.UseRouting();

app.UseAuthorization();

//--middleware de enrutamiento
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); //--es el patron a seguir con MVC

app.Run();
