using Application.Services;
using EMarket.Core.Application.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EMarket.Infrastructure.Persistence
{
    //Extension Method - Decorator
    public static class ServiceRegistration
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            #region Services
            services.AddTransient<IArticleService, ArticleService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IUserService, UserService>();
            #endregion
        }
    }
}
