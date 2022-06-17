using Microsoft.Extensions.DependencyInjection;


namespace Application.Extensions
{
    public static class ApplicationModule
    {
        public static void ConfigureApplication(this IServiceCollection services) {


            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


        }
        
    
    }
}
