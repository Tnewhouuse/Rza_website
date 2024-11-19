using Rza_website.Models;
using Microsoft.EntityFrameworkCore;
using Rza_website.Utilties;
using Rza_website.Components;
using Rza_website.Services;

namespace Rza_website
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            builder.Services.AddDbContext<TlS2302280RzaContext>(options => 
            options.UseMySql(builder.Configuration.GetConnectionString("MySqlConnection"), 
            new MySqlServerVersion(new Version(8, 0, 29))));

            builder.Services.AddScoped<CustomerService>();
            builder.Services.AddScoped<AttractionService>();
            builder.Services.AddScoped<UserSession>();
            //builder.Services.AddSingleton<UserSession>();
            builder.Services.AddScoped<TicketService>();
            builder.Services.AddScoped<TicketBookingService>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
