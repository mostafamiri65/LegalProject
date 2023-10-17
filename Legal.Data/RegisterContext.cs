using Legal.Data.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Legal.Data
{
    public static class RegisterContext
    {
        public static void RegisterDb(this IServiceCollection services)
        {
            services.AddDbContext<LowDbContext>();
        }
    }
}
