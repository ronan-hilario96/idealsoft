using System;
using Edialsoft.Data.Context;
using Edialsoft.Data.Repositorios;
using Edialsoft.Domain._Base;
using Edialsoft.Domain.Person;
using Edialsoft.Domain.Person.actions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Edialsoft.IoC
{
    public static class StartupIoc
    {
        public static void Config(IServiceCollection services, IConfiguration configuration)
        {
            Console.WriteLine("String connection: {0}", configuration["ConnectionString"]);
            services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(configuration["ConnectionString"]));

            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

            services.AddScoped(typeof(IPersonRepository), typeof(PersonRepository));


            services.AddScoped<SavePerson>();
            services.AddScoped<DeletePerson>();
        }

        public static void Migrations(IServiceProvider services)
        {
            services.GetService<ApplicationDbContext>().Database.Migrate();
        }
    }
}
