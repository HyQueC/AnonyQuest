using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AnonyQuest.App.Data;
using AnonyQuest.App.Helpers;
using AnonyQuest.App.Areas.Identity;
using AnonyQuest.App.Repositories;
using AnonyQuest.Shared.Entities;
using AnonyQuest.Shared.Interfaces;

namespace AnonyQuest.App
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddScoped<QuestionnaireRepository>();
            services.AddScoped<QuestionRepository>();
            services.AddScoped<IQuestionnaireRepository>(x => x.GetRequiredService<QuestionnaireRepository>());
            services.AddScoped<IRepository<Questionnaire>>(x => x.GetRequiredService<QuestionnaireRepository>());
            services.AddScoped<IRepository<Question>>(x => x.GetRequiredService<QuestionRepository>());
            services.AddScoped<IAuthenticationStateService, AuthenticationStateService>();
            services.AddScoped<IDisplayMessage, DisplayMessage>();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
