﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace App.Repositories.Extensions
{
    public static class RepositoryExtension
    {
        public static IServiceCollection AddRepository(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                var connectionString = configuration.GetSection(ConnectionStringOption.Key).Get<ConnectionStringOption>();
                options.UseSqlServer(connectionString!.SqlServer, sqlServerOptionsAction => sqlServerOptionsAction.MigrationsAssembly(typeof(RepositoryAssembly).Assembly.FullName));
            });
            return services;
        }
    }
}
