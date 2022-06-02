using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public static class DependencyInjectionExtension
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EFDbContext>(
                opts => opts.UseSqlServer(configuration.GetConnectionString("MSSQLConnStr"), 
                migr => migr.MigrationsAssembly(typeof(EFDbContext).Assembly.FullName))
            );
            services.AddScoped<IUnitOfWork, EFUnitOfWork>();
        }
    }
}
