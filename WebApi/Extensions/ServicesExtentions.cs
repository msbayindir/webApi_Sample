using System;
using AspNetCoreRateLimit;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Presentation.ActionsFilters;
using Presentation.Controllers;
using Repositories.Contracts;
using Repositories.EfCore;
using Services;
using Services.Contract;

namespace WebApi.Extensions
{
	public static class ServicesExtentions
	{
		public static void ConfigurSqlContext(this IServiceCollection service,IConfiguration configur)
		{
			service.AddDbContext<RepositoryContext>(op =>
			{
				op.UseSqlServer(configur.GetConnectionString("sql"));

			});
		}


        public static void ConfigurRepositoryManager(this IServiceCollection service)
        {
			service.AddScoped<IRepositoryManager, RepositoryManager>();
        }
        public static void ConfigurProductRepository(this IServiceCollection service)
        {
            service.AddScoped<IProductRepository, ProductRepository>();
        }

        public static void ConfigurProductService(this IServiceCollection service)
        {
            service.AddScoped<IProductService, ProductManager>();
        }
        public static void ConfigurServiceManager(this IServiceCollection service)
        {
            service.AddScoped<IServiceManager, ServiceManager>();
        }
        public static void ConfigurLoggerService(this IServiceCollection service) =>
            service.AddSingleton<ILoggerService, LoggerManager>();

        public static void ConfigureActionFilter(this IServiceCollection service)
        {
	        service.AddScoped<ValidationFilterAttribute>();
	        service.AddSingleton<LogFilterAttribute>();

        }
        public static void ConfigureDataShapper(this IServiceCollection service)
        {
	        service.AddScoped<IDataShaper<ProductDto>,DataShaper<ProductDto>>();


        }
        public static void ConfigureVersioning(this IServiceCollection service)
        {
	        service.AddApiVersioning(avo =>
	        {
		        avo.ReportApiVersions = true;
		        avo.AssumeDefaultVersionWhenUnspecified = true;
		        avo.DefaultApiVersion = new ApiVersion(1, 0);
		        avo.ApiVersionReader = new HeaderApiVersionReader("api-version");
		        avo.Conventions.Controller<ProductController>().HasApiVersion(new ApiVersion(1,0));
		        avo.Conventions.Controller<ProductV2Controller>().HasDeprecatedApiVersion(new ApiVersion(2,0));

	        });
	        service.AddVersionedApiExplorer(opt =>
	        {
		        opt.GroupNameFormat = "'v'VVV";
	        });


        }
        public static void ConfigureRateLimit(this IServiceCollection service,ConfigurationManager Configuration)
        {

	        service.AddOptions();
	        service.Configure<IpRateLimitOptions>(Configuration.GetSection("IpRateLimiting"));

	        service.Configure<IpRateLimitPolicy>(Configuration.GetSection("IpRateLimitPolicies"));
	       
	        service.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
	        service.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
	        service.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
	        service.AddSingleton<IProcessingStrategy, AsyncKeyLockProcessingStrategy>();
	        


        }
    }
}

