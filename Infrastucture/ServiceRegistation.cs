using Domain.Common;
using Domain.Entity;
using Domain.Entity.Model;
using Infrastucture.Common;
using Infrastucture.Context;
using Infrastucture.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Infrastucture
{
    public static class ServiceRegistation
    {
        public static void AddPersistenceRegistration(this IServiceCollection services)
        {
            services.AddDbContext<DataContext>(option => option.UseSqlServer("Data Source=.\\MSSQLSERVER01; Initial Catalog=Domain; Integrated Security=true"));
            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<DataContext>().AddDefaultTokenProviders();
            services.Configure<IdentityOptions>(option =>
            {
                option.Password.RequireDigit = false;
                option.Password.RequireLowercase = false;
                option.Password.RequireUppercase = false;

                option.Password.RequireNonAlphanumeric = false;
                option.Password.RequiredLength = 5;
            });
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
