using ProductlineApp.WebUI.Services.Products;

namespace ProductlineApp.WebUI
{
    public static class Extensions
    {
        public static IServiceCollection AddWebUI(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();

            return services;
        }
    }
}
