using _4___E_CODING_DAL;
using E_CODING_MVC_NET6_0;
using E_CODING_MVC_NET6_0.InfraStructure.ApiClient;
using E_CODING_MVC_NET6_0.InfraStructure.Project;
using E_CODING_MVC_NET6_0.InfraStructure.TemplateFonctionnel;
using E_CODING_Service_Abstraction;
using E_CODING_Service_Abstraction.ApiClient;
using E_CODING_Service_Abstraction.Project;
using E_CODING_Services.Project;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;


namespace E_CODING_MVC_NET6_0
{
    public static class ServiceExtensions
    {
        
        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {
            });
        }

        public static void ConfigureSqlServerContext(this IServiceCollection services)
        {
            services.AddDbContext<TemplateProjectDbContext>(
                    item => item.UseSqlServer("Server=DESKTOP-2TG0VPH\\SQLEXPRESS; Database=ECODING; Integrated Security=SSPI; "));
        }

        public static void ConfigureApiClient(this IServiceCollection services)
        {
            services.AddScoped<IApiClientService, ApiClientService>();
            services.AddScoped<ITemplateProjectApiClient, TemplateProjectApiClient>();
            services.AddScoped<ITemplateTechniqueApiClient, TemplateTechniqueApiClient>();
            services.AddScoped<ITemplateFonctionnelApiClient, TemplateFonctionnelApiClient>();
            services.AddScoped<ITemplateResultApiClient, TemplateResultApiClient>();
        }


    }

}
