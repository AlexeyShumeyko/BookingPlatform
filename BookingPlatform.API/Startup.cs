using BookingPlatform.API.Configuration;
using BookingPlatform.Core.Contract;
using BookingPlatform.DAL;
using Microsoft.EntityFrameworkCore;
using Serilog;
using ILogger = Serilog.ILogger;
using BookingPlatform.Application.Interfaces;
using BookingPlatform.Application.Services;
using BookingPlatform.Application.Auth;

namespace BookingPlatform.API
{
    public static class Startup
    {
        internal static void AddServices(WebApplicationBuilder builder)
        {
            AddSerilog(builder);

            RegisterDAL(builder);

            RegisterService(builder.Services);
        }

        private static void RegisterDAL(WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("MSSQL");

            builder.Services.AddTransient(provider =>
            {
                var builder = new DbContextOptionsBuilder<BookingPlatformDbContext>();

                builder.UseSqlServer(connectionString);

                return builder.Options;
            });

            builder.Services.AddScoped<DbContext, BookingPlatformDbContext>();

            builder.Services.AddScoped<IUnitOfWork>(prov =>
            {
                var context = prov.GetRequiredService<DbContext>();

                return new UnitOfWork(context);
            });
        }

        private static void AddSerilog(WebApplicationBuilder builder)
        {
            var serilogConfig = builder.Configuration.GetSection(nameof(SerilogConfig)).Get<SerilogConfig>();

            var logFilePath = Path.Combine(serilogConfig?.LoggingDir ?? "./", "log.txt");

            var loggerConfig = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File(logFilePath, rollingInterval: RollingInterval.Month,
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}");

            if (builder.Environment.IsDevelopment())
            {
                loggerConfig = loggerConfig.MinimumLevel.Debug();
            }
            else
            {
                loggerConfig = loggerConfig.MinimumLevel.Warning();
            }

            var logger = loggerConfig.CreateLogger();

            builder.Services.AddSingleton<ILogger>(logger);
        }

        public static void RegisterService(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITourService, TourService>();

            services.AddScoped<IJwtProvider, JwtProvider>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();
        }
    }
}
