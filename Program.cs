using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Biblioteca.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using DinkToPdf.Contracts;
using DinkToPdf;
using Biblioteca.Services;
using Microsoft.AspNetCore.Mvc.ViewEngines;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region Agregando servicios al contenedor

#region configuración de conexión de base de datos
var connectionString = builder.Configuration.GetConnectionString("WebApiDatabase") ?? "Data Source=BibliotecaDatabase.db";
builder.Services.AddSqlite<SqlDatabaseBibliotecaContext>(connectionString);
#endregion

#region configuración de autenticación 

builder.Services.AddAuthentication(options =>{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(options => {
    options.ExpireTimeSpan = TimeSpan.FromMinutes(40);
    options.SlidingExpiration = true;
    options.LoginPath = "/Account/Login";
    options.LogoutPath = "/Account/Logout";
});

#endregion

builder.Services.AddControllersWithViews();

#region configuración de los reportes

builder.Services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));
builder.Services.AddScoped<IPdfServices, PdfService>();
builder.Services.AddSingleton<ICompositeViewEngine, CompositeViewEngine>();

#endregion




#endregion

var app = builder.Build();

#region Agregando configuraciones 

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

// aplicando middleware de autenticacion
app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

#endregion

app.Run();
