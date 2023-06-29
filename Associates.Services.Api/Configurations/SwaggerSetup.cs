using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models;

namespace Associates.Services.Api.Configurations
{
    public static class SwaggerSetup
    {
        public static void AddSwaggerSetup(this IServiceCollection services)
        {
            if (services is null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "API Associados",
                    Version = "v1",
                    Description = "API de Gerenciamento de Associados"
                });

                string applicationPath = PlatformServices.Default.Application.ApplicationBasePath;
                string xmlDocApplication = Path.Combine(applicationPath, "Associates.Application.xml");

                c.IncludeXmlComments(xmlDocApplication);
            });
        }
    }
}
