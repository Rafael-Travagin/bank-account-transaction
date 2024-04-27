using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankAccount.Core;
using BankAccount.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace BankAccount.Api.Extesions
{
    public static class BuilderExtension
    {
        public static void AddConfiguration(this WebApplicationBuilder builder){
            
            Configuration.Database.ConnectionString =
                builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
        }
        
        public static void AddDatabase(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<AppDbContext>(x =>
                x.UseSqlServer(
                    Configuration.Database.ConnectionString,
                    b => b.MigrationsAssembly("BankAccount.Api")));
        }

        public static void AddMediator(this WebApplicationBuilder builder)
        {
            builder.Services.AddMediatR(x
                => x.RegisterServicesFromAssembly(typeof(Configuration).Assembly));
        }        
    }
}