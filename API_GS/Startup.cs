using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using API_GS.Models;
using API_GS.Domain.EF;
using API_GS.Domain.Abstract;
using API_GS.Domain;

namespace API_GS
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  policy =>
                                  {
                                      policy.WithOrigins("http://localhost:3000",
                                                          "http://localhost:25864")
                                      .AllowAnyHeader()
                                      .AllowAnyMethod();
                                  });
            });


            services.AddControllers();
            services.AddDbContext<EFGsDBContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));           
            services.AddTransient<IShopItemRepository, EFShopItemRepository>();
            services.AddTransient<IContactRepository, EFContactRepository>();
            services.AddTransient<ITimeTableRepository, EFTimeTableRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
