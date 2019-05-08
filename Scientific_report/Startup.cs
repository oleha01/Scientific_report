using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Scientific_report.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;

namespace Scientific_report
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            string connection = Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<AppReportContext>(options =>
                options.UseSqlServer(connection));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            
            services.AddIdentity<IdentityUser, IdentityRole>()
                        .AddEntityFrameworkStores<AppReportContext>()
                        .AddDefaultTokenProviders();

            //services.AddTransient<IUserProfileService, UserProfileService>();
            //services.AddTransient<IDepartmentService, DepartmentService>();
            //services.AddTransient<IScientificWorkService, ScientificWorkService>();
            //services.AddTransient<ITeacherReportService, TeacherReportService>();
            //services.AddTransient<IArticleService, ArticleService>();
            //services.AddTransient<IConferenceService, ConferenceService>();
            //services.AddTransient<IGrantService, GrantService>();
            //services.AddTransient<IMembershipService, MembershipService>();
            //services.AddTransient<IOppositionService, OppositionService>();
            //services.AddTransient<IPatentLicenseActivityService, PatentLicenseActivityService>();
            //services.AddTransient<IPostgraduateDissertationGuidanceService, PostgraduateDissertationGuidanceService>();
            //services.AddTransient<IPostgraduateGuidanceService, PostgraduateGuidanceService>();
            //services.AddTransient<IReportThesisService, ReportThesisService>();
            //services.AddTransient<IReviewService, ReviewService>();
            //services.AddTransient<IScientificConsultationService, ScientificConsultationService>();
            //services.AddTransient<IScientificInternshipService, ScientificInternshipService>();

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                // TODO: configure password setting properly for deploy
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 3;
                options.Password.RequiredUniqueChars = 0;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyz0123456789-._";
                options.User.RequireUniqueEmail = true;
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
            services.ConfigureApplicationCookie(options =>
                    {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                        options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
                        options.LoginPath = "/UserProfile/Login";
                        options.AccessDeniedPath = "/Home/AccessDenied";
                        options.SlidingExpiration = true;
                    });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }
// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            //app.UseIdentity();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    "default",
                    "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
