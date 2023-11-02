using KatmanliSinavProject.BLL.Services.AppUserService;
using KatmanliSinavProject.BLL.Services.KonuService;
using KatmanliSinavProject.BLL.Services.MakaleService;
using KatmanliSinavProject.Core.Entities.Concretes;
using KatmanliSinavProject.Core.Repositories;
using KatmanliSinavProject.DAL.Contexts;
using KatmanliSinavProject.DAL.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace KatmanliSinavProject.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            var conn = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(conn);

                options.UseLazyLoadingProxies();

            });
            builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                //Password
                options.Password.RequireDigit = false;//En az bir rakam
                options.Password.RequiredLength = 3;//Minimum uzunluk
                options.Password.RequireLowercase = false;//en az bir küçük harf
                options.Password.RequireUppercase = false;//en az bir büyük
                options.Password.RequireNonAlphanumeric = false;//en az bir sembol

                //User
                options.User.RequireUniqueEmail = true;//Eposta adresi benzersiz olmalý.
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";

                //SignIn
                options.SignIn.RequireConfirmedEmail = false;//Eposta onayý gerekli olsun mu
                options.SignIn.RequireConfirmedPhoneNumber = false;//Telefon onayý
                options.SignIn.RequireConfirmedAccount = false;
            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders().AddRoles<IdentityRole>();

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
          
            builder.Services.AddTransient<IMakaleRepository, MakaleRepository>();
            builder.Services.AddTransient<IKonuRepository, KonuRepository>();

            builder.Services.AddTransient<IMakaleService,MakaleService>();
            builder.Services.AddTransient<IKonuService, KonuService>();
            builder.Services.AddTransient<IUserService, UserService>();


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

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}