using Cinema.Database;
using Cinema.WebApp.Services;
using Microsoft.EntityFrameworkCore;

namespace Cinema.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<CinemaDbContext>((services, options) =>
            {
                var configuration = services.GetRequiredService<IConfiguration>();
                options.UseSqlServer(configuration.GetConnectionString("Cinema"));
            });

            builder.Services.AddScoped<IMovieService, MovieService>();

            var app = builder.Build();

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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Movies}/{action=Index}");

            app.Run();
        }
    }
}