using Domain.Entity;
using Infrastucture.Context;
using Infrastucture.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastucture
{
    public static class ServiceRegistation
    {
        public static void AddPersistenceRegistration(this IServiceCollection services)
        {
            services.AddDbContext<DataContext>(option => option.UseSqlServer("Data Source=.\\MSSQLSERVER01; Initial Catalog=Domain; Integrated Security=true"));
            services.AddScoped<IAdminService, AdminRepository>();
            services.AddScoped<IBookService, BookRepository>();
            services.AddScoped<ICategoryService, CategoryRepository>();
            services.AddScoped<IWritersService, WriterRepository>();
        }
    }
}
