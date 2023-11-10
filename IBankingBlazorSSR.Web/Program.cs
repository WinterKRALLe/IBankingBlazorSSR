using IBankingBlazorSSR.Application.Services;
using IBankingBlazorSSR.Domain.Entities;
using IBankingBlazorSSR.Infrastructure.Database;
using IBankingBlazorSSR.Web.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Default") ??
                       throw new NullReferenceException("No connection string");

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// builder.Services.AddDbContextFactory<dbContext>(options =>
    // options.UseSqlServer(connectionString));

builder.Services.AddScoped<AuthService>();

builder.Services.AddDbContext<MyIdentityDbContext>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();