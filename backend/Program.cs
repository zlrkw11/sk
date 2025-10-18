using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.Extensions.DependencyInjection;
using A2Template.Data;
using A2Template.Handler;
using A2Template.Helper;

namespace A2Template;

class Program
{
    static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers(options =>
        {
            options.OutputFormatters.Add(new CalendarOutputFormatter());
        });

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<A2DbContext>(options =>
            options.UseSqlite(builder.Configuration["P1DBConnection"]));

        builder.Services.AddScoped<IA2Repo, A2Repo>();

        builder.Services.AddAuthentication("BasicAuthentication")
            .AddScheme<AuthenticationSchemeOptions, A2AuthHandler>("BasicAuthentication", null);

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
