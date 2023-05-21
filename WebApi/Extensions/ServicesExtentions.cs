using System;
using Microsoft.EntityFrameworkCore;
using Repositories.EfCore;

namespace WebApi.Extensions
{
	public static class ServicesExtentions
	{
		public static void ConfigurSqlContext(this IServiceCollection service,IConfiguration configur)
		{
			service.AddDbContext<RepositoryContext>(op =>
			{
				op.UseSqlServer(configur.GetConnectionString("sql"), b => b.MigrationsAssembly("WebApi"));
			});
		}
	}
}

