using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Serilog;
using Serilog.Events;
using Serilog.Filters;
using System.Security.Cryptography.X509Certificates;

namespace Common.Common.Handlers
{
    public static class LoggingHandler
    {
        public static void AddLoggingConfiguration(this WebApplicationBuilder builder,string applicationName)
        {
            // 1.Ensure Log directory Exits
            var logPath = Path.Combine( 
                Directory.GetCurrentDirectory(),
                builder.Configuration["Logging:LogPath"] ?? "Logs");

            Directory.CreateDirectory(logPath);

            //2. Create and configure the logger
            var logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .MinimumLevel.Override("System", LogEventLevel.Warning)
                .Enrich.WithCorrelationId()
                .Enrich.WithProperty("ApplicationName", applicationName)
                .Enrich.FromLogContext()

                //System logs
                .WriteTo.Logger(x => x
                .Filter.ByIncludingOnly(Matching.WithProperty<string>(
                    "SourceContext", sc =>
                    sc?.StartsWith("Microsoft") == true ||
                    sc?.StartsWith("System") == true))

                .WriteTo.File(
                    Path.Combine(logPath, "SystemLog-.txt"),
                    rollingInterval: RollingInterval.Day,
                    retainedFileCountLimit: null,
                    outputTemplate: "{TimeStamp:yyyy-MM-dd HH:mm:ss} | {CorrelationId} | {Level:u3} | {ApplicationName} | {SourceContext} | {Message:lj}{NewLine}{Exception}"
                    )
                    )

                //Application logs
                .WriteTo.File(
                Path.Combine(logPath, "ApplicationLog-.txt"),
                rollingInterval: RollingInterval.Day,
                retainedFileCountLimit: null,
                outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} | {CorrelationId} | {Level:u3} | {ApplicationName} | {SourceContext} | {Message:lj}{NewLine}{Exception}"
                )

                //Console Output
                .WriteTo.Console(
                outputTemplate: "{TimeStamp:HH:mm:ss} [{Level:u3}] | {CorrelationId} | {ApplicationName} | {Message:lj}{NewLine}{Exception}"
                )
                .CreateLogger();

            //3. Assign logger to Serlog and ASP.NET logging
            Log.Logger = logger;
            builder.Logging.ClearProviders();
            builder.Logging.AddSerilog(logger);

            //4. Log Initialization confirmation
            Log.Information("Logging initialized. Logs will be written to {LogPath}", logPath);

           
        }
        public static void UseLoggingMiddleware(this IApplicationBuilder app)
        {
            app.UseSerilogRequestLogging(options =>
            {
                options.EnrichDiagnosticContext = (diagnosticContext, httpContext) =>
                {
                    diagnosticContext.Set("RequestHost", httpContext.Request.Host.Value);
                    diagnosticContext.Set("RequestScheme", httpContext.Request.Scheme);
                };
            });
        }
    }
}
