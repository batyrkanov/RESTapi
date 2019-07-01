﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RESTapi.Common.Interfaces;
using RESTapi.Data;
using RESTapi.Data.Interfaces;
using RESTapi.Service.Interfaces;
using RESTapi.Service;

namespace RESTapi.Common
{
    public class PlatformInitializer : IPlatformInitializer
    {
        protected IConfiguration _configuration;

        public PlatformInitializer(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // configure database
            ConfigureDatabase(services);

            // add singletone instances
            services.AddSingleton(Mapping.Configuration.CreateDefaultMapper());

            // add scoped registrations
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IContractService, ContractService>();
        }

        protected virtual void ConfigureDatabase(IServiceCollection services)
        {
            services.AddDbContext<DbContext, Data.AppContext>(options =>
               options.UseSqlServer(
                   _configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
