using Funq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServiceStack;
using ServiceStack.OrmLite;
using ServiceStackWithDocker.ServiceInterface;
using ServiceStackWithDocker.ServiceModel;

namespace ServiceStackWithDocker
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) => Configuration = configuration;

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseServiceStack(new AppHost
            {
                AppSettings = new NetCoreAppSettings(Configuration)
            });
        }
    }

    public class AppHost : AppHostBase
    {
        public AppHost() : base("ServiceStackWithDocker", typeof(MyServices).Assembly) { }

        // Configure your AppHost with the necessary configuration and dependencies your App needs
        public override void Configure(Container container)
        {
            SetConfig(new HostConfig
            {
                DefaultRedirectPath = "index.html", //"/metadata",
                DebugMode = AppSettings.Get(nameof(HostConfig.DebugMode), false)
            });

            // inmemory data base created here
            container.Register<ServiceStack.Data.IDbConnectionFactory>(
                new OrmLiteConnectionFactory(":memory:", ServiceStack.OrmLite.SqliteDialect.Provider));

            using (var db = container.Resolve<ServiceStack.Data.IDbConnectionFactory>().OpenDbConnection())
            {
                db.CreateTableIfNotExists<Country>();
                db.InsertAll(CountriesService.SeedData);

                db.CreateTableIfNotExists<Sms>();
                db.InsertAll(SmsService.SeedData);
            }

            UseLogSmsSender(container);
            UseDbMccResolver(container);
        }

        private static void UseLogSmsSender(Container container)
        {
            container.RegisterAs<LogEmailSender, ISmsSender>().ReusedWithin(ReuseScope.Request);
        }

        private static void UseDbMccResolver(Container container)
        {
            container.RegisterAs<FromStringCountryCodeResolver, ICountryCodeResolver>();
        }
    }
}
