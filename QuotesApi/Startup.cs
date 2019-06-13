using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuotesApi.CustomConstraints;
using QuotesApi.Data;
using QuotesApi.Middlewares;
using static QuotesApi.Filters.ModelValidationFilterAttribute;

namespace QuotesApi
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
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(ApiValidationFilterAttribute));
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2).ConfigureApiBehaviorOptions(options =>
            {
                options.SuppressModelStateInvalidFilter = true; // by default with 2.2 and latest varsion valdatePeroblemFilter excuted with machine readable error format . we should suppress model state invalid filter to enable custom action filter execute.
            }).AddXmlSerializerFormatters();
            services.Configure<RouteOptions>(options => options.ConstraintMap.Add("allowedgods", typeof(OnlyGodsConstraint)));
            services.AddDbContext<QuotesDbContext>(options => options.UseSqlServer(@"Data Source = sachinkumar06; Initial Catalog = Quotes;Trusted_Connection=True"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, QuotesDbContext quotesDbContext)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //app.UseExceptionHandler("/api/errors/500");
            // Handles non - success status codes with empty body
            //app.UseStatusCodePagesWithReExecute("/api/errors/{0}"); // to handle http status code errors like 404 (not found) 500 (internal sever error)
            //quotesDbContext.Database.EnsureCreated();  //  use this when you are sure that once database created never changed.
            app.UseHttpsRedirection();
            app.ConfigureCustomExceptionMiddleware();
            app.UseMvc();
        }
    }
}
