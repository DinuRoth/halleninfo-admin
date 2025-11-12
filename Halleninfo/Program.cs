using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using MudBlazor.Services;
using MudExtensions.Services;
using System.Diagnostics;
using xTend;
using xTend.Service;
using static Stimulsoft.Report.StiOptions;


namespace Halleninfo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logFileName = "trace.log";
            var fileListener = new TextWriterTraceListener(logFileName);
            System.Diagnostics.Trace.Listeners.Add(fileListener);

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();


            builder.Logging.AddProvider(new FileLoggerProvider("Logs/log.txt"));

            builder.Services.AddHttpContextAccessor();
            builder.Services.AddxTend(builder);

            var app = builder.Build();

            app.UseMiddleware<ErrorHandlerMiddleware>(); // Should be always in the first place
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();
            app.UseMiddleware<IPBlockerService>();

            var assembl = typeof(xTend.DBO).Assembly;

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode()
                .AddAdditionalAssemblies(assembl);

            app.AddxTend ();
            app.Run();
        }
    }
}
