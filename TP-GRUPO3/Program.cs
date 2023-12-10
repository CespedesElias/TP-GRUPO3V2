using Microsoft.EntityFrameworkCore;
using TP_GRUPO3.Context;
using TP_GRUPO3.Utils;

namespace TP_GRUPO3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<NegocioDatabaseContext>(options  => options.UseSqlServer(builder.Configuration["ConnectionString:NegocioDBConnection"]));


            // Add services to the container.
            builder.Services.AddControllersWithViews();

            

            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(1800);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            builder.Services.AddControllersWithViews(options =>
            {
                options.Filters.Add(typeof(UsuarioAction));
            });

            var app = builder.Build();
            app.UseSession();
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
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}