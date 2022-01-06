using Contentful.Core;
using Contentful.Core.Configuration;
using Contentful.Core.Models;
using ContentfulDemo.Web.Services;
using ContentfulDemo.Web.Usecases;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ContentfulDemo.Web.Extensions
{
    public static class StartupExtensions
    {
        public static IServiceCollection ConfigureContentfulClient(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ContentfulOptions>(options =>
            {
                options.SpaceId = configuration["Contentful:SpaceId"];
                options.DeliveryApiKey = configuration["Contentful:DeliveryApiKey"];
                options.PreviewApiKey = configuration["Contentful:PreviewApiKey"];
                options.ManagementApiKey = configuration["Contentful:ManagementToken"];
            });

            services.AddHttpClient();
            services.AddTransient<IContentfulClient, ContentfulClient>(x =>
            {
                return new ContentfulClient(x.GetRequiredService<IHttpClientFactory>().CreateClient(),
                    x.GetRequiredService<IOptions<ContentfulOptions>>().Value);
            });

            services.AddTransient<IContentfulManagementClient, ContentfulManagementClient>(x =>
            {
                return new ContentfulManagementClient(x.GetRequiredService<IHttpClientFactory>().CreateClient(),
                    x.GetRequiredService<IOptions<ContentfulOptions>>().Value);
            });

            return services;
        }

        public static IServiceCollection AddContentfulServices(this IServiceCollection services)
        {
            services.AddTransient<IContentfulApiService, ContentfulApiService>();
            services.AddTransient<IBlogUsecase, BlogUsecase>();
            services.AddSingleton<HtmlRenderer>();

            return services;
        }
    }
}
