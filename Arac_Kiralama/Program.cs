using Arac_Kiralama.Data;
using Arac_Kiralama.Models.Entity;
using Arac_Kiralama.Repository.Contexts;
using Arac_Kiralama.Repository.Repositories.Abstracts;
using Arac_Kiralama.Repository.Repositories.Concretes;
using Arac_Kiralama.Service.Abstracts;
using Arac_Kiralama.Service.Concretes;
using Arac_Kiralama.Service.Helpers.Cloudinary;
using Arac_Kiralama.Service.Mappers.Brands;
using Arac_Kiralama.Service.Mappers.Cars;
using Arac_Kiralama.Service.Mappers.Colors;
using Arac_Kiralama.Service.Mappers.Fuels;
using Arac_Kiralama.Service.Mappers.Profiles;
using Arac_Kiralama.Service.Mappers.Transmissions;
using Microsoft.AspNetCore.Identity;
using YetenekStore.Service.Helpers.Cloudinary;

namespace Arac_Kiralama
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<BaseDbContext>();

            // Identity servislerini ekleyin
            builder.Services.AddIdentity<User, IdentityRole>(options =>
            {
                // Þifre gereksinimleri
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequiredLength = 8;

                // Kullanýcý gereksinimleri
                options.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<BaseDbContext>()
            .AddDefaultTokenProviders();

            // Cookie ayarlarý
            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Account/Logout";
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.SlidingExpiration = true;
                options.ExpireTimeSpan = TimeSpan.FromDays(7);
            });

        
            builder.Services.AddScoped<IBrandService,BrandService>();
            builder.Services.AddScoped<IBrandRepository,BrandRepository>();
            builder.Services.AddScoped<IColorService, ColorService>();
            builder.Services.AddScoped<IColorRepository, ColorRepository>();
            builder.Services.AddScoped<ITransmissionRepository,TransmissionRepository> ();
            builder.Services.AddScoped<ITransmissionService, TansmissionService>();
            builder.Services.AddScoped<IFuelRepository, FuelRepository>();
            builder.Services.AddScoped<IFuelService, FuelService>();
            builder.Services.AddScoped<ICarRepository, CarRepository>();
            builder.Services.AddScoped<ICarService, CarService>();
            builder.Services.AddScoped<IBrandMapper,BrandAutoMapperConverter>();
            builder.Services.AddScoped<IColorMapper, ColorAutoMapperConverter>();
            builder.Services.AddScoped<ITransmissionMapper, TransmissionAutoMapperConverter>();
            builder.Services.AddScoped<IFuelMapper, FuelAutoMapperConverter>();
            builder.Services.AddScoped<ICarMapper, CarAutoMapperConverter>();
            builder.Services.AddAutoMapper(typeof(MappingProfiles));
            builder.Services.AddScoped<IFileService, FileService>();

            builder.Services.Configure<CloudinarySettings>(builder.Configuration.GetSection("Cloudinary"));

            var app = builder.Build();
            using (var scope = app.Services.CreateScope())
            {
                await RoleInitializer.InitializeAsync(scope.ServiceProvider);
            }

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
                pattern: "{controller=Cars}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
