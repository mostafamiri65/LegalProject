using Legal.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Legal.Data
{
    public static class RegisterContext
    {
        public static void RegisterDb(this IServiceCollection services,string? connectionString)
        {
            services.AddDbContext<LowDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
        }
    }
}
