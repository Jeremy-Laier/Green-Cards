using GraphiQl;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using GREEN_CARD.Api.Helpers;
using GREEN_CARD.Api.Models;
using GREEN_CARD.Core.Data;
using GREEN_CARD.Data;
using GREEN_CARD.Data.Repositories;


namespace GREEN_CARD.Api
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
            services.AddMvc();
           
            services.AddHttpContextAccessor();
            services.AddSingleton<ContextServiceLocator>();
            services.AddDbContext<GREEN_CARDContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:GREEN_CARDDb"]));
            services.AddTransient<IPlayerRepository, PlayerRepository>();
            services.AddTransient<ISkaterStatisticRepository, SkaterStatisticRepository>();
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<GREEN_CARDQuery>();
            services.AddSingleton<GREEN_CARDMutation>();
            services.AddSingleton<PlayerType>();
            services.AddSingleton<PlayerInputType>();
            services.AddSingleton<SkaterStatisticType>();
            var sp = services.BuildServiceProvider();
            services.AddSingleton<ISchema>(new GREEN_CARDSchema(new FuncDependencyResolver(type => sp.GetService(type))));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, GREEN_CARDContext db)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseGraphiQl();
            app.UseMvc();
            db.EnsureSeedData();
        }
    }
}
