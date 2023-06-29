using Associates.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Associates.Services.Api.Configurations
{
    public static class DatabaseSetup
    {
        public static void AddDatabaseSetup(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddDbContext<AssociateContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("AssociatesDbConnection")));
        }
    }
}
