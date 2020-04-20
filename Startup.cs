using LindyCircleMVC.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace LindyCircleMVC
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services) {
            services.AddDbContext<UsersDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("LindyCircleDB")));
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddRoleManager<RoleManager<IdentityRole>>()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<UsersDbContext>();
            services.AddDbContext<LindyCircleDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("LindyCircleDB")));
            services.AddScoped<IMemberRepository, MemberRepository>();
            services.AddScoped<IAttendanceRepository, AttendanceRepository>();
            //If session use is required, uncomment the following two lines:
            //services.AddHttpContextAccessor();
            //services.AddSession();
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            //If session use is required, uncomment the following line:
            //app.UseSession();
            //UseSession must be called before UseRouting
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id:int?}");
            });
            //CreateUserRoles(userManager, roleManager).Wait();
        }

        private async Task CreateUserRoles(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager) {
            //Adding Addmin Role  
            var roleCheck = await roleManager.RoleExistsAsync("Admin");
            if (!roleCheck) {
                //create the roles and seed them to the database  
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }
            //Assign Admin role to the main User here we have given our newly loregistered login id for Admin management  
            IdentityUser user = await userManager.FindByNameAsync("mpipkin");
            await userManager.AddToRoleAsync(user, "Admin");
        }
    }
}
