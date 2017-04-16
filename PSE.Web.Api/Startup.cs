using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PSE.BLL.WCF.Contracts.Contracts;
using PSE.Web.Api.Configuration;
using PSE.Web.Api.Security;
using Microsoft.AspNetCore.Authorization;
using Autofac;
using System.ServiceModel;
using Autofac.Integration.Wcf;
using Autofac.Extensions.DependencyInjection;
using System.Diagnostics;
using System.IO;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.AspNetCore.Authentication.Cookies;
using PSE.Web.Api.Helpers;

namespace PSE.Web.Api
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IContainer ApplicationContainer { get; private set; }

        public static IConfigurationRoot Configuration { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {

            // Add framework services.
            ConfigureMvc(services);

            var builder = new ContainerBuilder();

            builder.RegisterInstance(Configuration).As<IConfiguration>();
            builder.RegisterType<CommonTracing>().As<ICommonTracing>().SingleInstance();

            builder
              .Register(c => new ChannelFactory<IImageUtilityService>( new BasicHttpBinding(), new EndpointAddress(Configuration["WcfService:Endpoints:ImageSvc"])))
              .SingleInstance();


            builder
              .Register(c => c.Resolve<ChannelFactory<IImageUtilityService>>().CreateChannel()).As<IImageUtilityService>().UseWcfSafeRelease();

            builder.Populate(services);

            this.ApplicationContainer = builder.Build();

            // Create the IServiceProvider based on the container.
            return new AutofacServiceProvider(this.ApplicationContainer);
        }

        private void ConfigureMvc(IServiceCollection services)
        {
            var policy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();
            services.AddMvc(options =>
            {
                options.Filters.Add(new PSEAuthorizeAttribute(policy));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IApplicationLifetime appLifetime)
        {

            if (env.IsDevelopment())
            {
                Trace.AutoFlush = true;
            }

            var testSwitch = new SourceSwitch("sourceSwitch")
            {
                Level = SourceLevels.All
            };
            loggerFactory.AddTraceSource(testSwitch,new TextWriterTraceListener("testLog.log"));

            // Add components (middleware) to pipeline here
            app.UseStaticFiles();

            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                AutomaticAuthenticate = true,
                AutomaticChallenge = true,
                ExpireTimeSpan = TimeSpan.FromDays(1)
            });

            app.UseOpenIdConnectAuthentication(new OpenIdConnectOptions
            {
                SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme,
                ClientId = Configuration["Authentication:Google:ClientId"],
                ClientSecret = Configuration["Authentication:Google:ClientSecret"],
                Authority = Configuration["Authentication:Google:Authority"],
                ResponseType = OpenIdConnectResponseType.Code,
                GetClaimsFromUserInfoEndpoint = true,
                SaveTokens = true,
                AutomaticChallenge = true
            });

            app.UseMvc(routes=>
            {
                routes.MapRoute(
                    name: "Default",
                    template: "{controller=Home}/{action=Index}"
                    );
            });

            appLifetime.ApplicationStopped.Register(() => this.ApplicationContainer.Dispose());
        }

    }
}
