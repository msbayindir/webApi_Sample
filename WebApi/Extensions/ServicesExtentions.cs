using System;
using Microsoft.EntityFrameworkCore;
using Presentation.ActionsFilters;
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

       
    }
}

