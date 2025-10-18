using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.Extensions.DependencyInjection;
using DotNetEnv;

namespace Backend;

class Program
{
    static void Main(string[] args)
    {
        Env.Load();
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers(options =>
        {
            options.OutputFormatters.Add(new CalendarOutputFormatter());
        });

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<SKDbContext>(options =>
    options.UseNpgsql(Environment.GetEnvironmentVariable("P1DBConnection")));
        builder.Services.AddScoped<ISKRepo, SKRepo>();

        builder.Services.AddAuthentication("BasicAuthentication")
            .AddScheme<AuthenticationSchemeOptions, SKAuthHandler>("BasicAuthentication", null);

        builder.Services.AddAuthorization(options =>
        {
            options.AddPolicy("UserOnly", policy => policy.RequireClaim(ClaimTypes.Role, "User"));
            options.AddPolicy("StaffOnly", policy => policy.RequireClaim(ClaimTypes.Role, "Staff"));
        });

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
