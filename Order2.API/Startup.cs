using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Order2.API.Controllers.Customers.Mapper;
using Order2.API.Controllers.Customers.Mapper.Addresses;
using Order2.API.Controllers.Items.Mapper;
using Order2.API.Controllers.Orders.Mapper.ItemGroups;
using Order2.API.Controllers.Orders.Mapper.Orders;
using Order2.API.Services.Items;
using Order2.Data;
using Order2.Services.Customers;
using Order2.Services.Items;
using Order2.Services.Orders;
using Swashbuckle.AspNetCore.Swagger;

namespace Order2.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public readonly ILoggerFactory efLoggerFactory
          = new LoggerFactory(new[] { new ConsoleLoggerProvider(
              (category, level) => category.Contains("Command") && level == LogLevel.Information, true) });

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Order2.API", Version = "v1" });
            });

            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICustomerMapper, CustomerMapper>();
            services.AddScoped<IAddressMapper, AddressMapper>();
            services.AddTransient<CustomerValidator>();

            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<IItemMapper, ItemMapper>();
            services.AddTransient<ItemValidator>();

            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderMapper, OrderMapper>();
            services.AddScoped<IItemGroupMapper, ItemGroupMapper>();
            services.AddTransient<OrderValidator>();

            services.AddDbContext<Order2DbContext>(options =>
                options
                .UseSqlServer("Data Source =.\\SQLExpress; Initial Catalog = Order2Db; Integrated Security = True; ")
                .UseLoggerFactory(efLoggerFactory));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseMvc();

            app.Run(async context =>
            {
                context.Response.Redirect("/swagger");
            });
        }
    }
}