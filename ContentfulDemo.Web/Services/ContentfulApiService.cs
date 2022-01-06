using Contentful.Core;
using Contentful.Core.Models;
using Contentful.Core.Search;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContentfulDemo.Web.Services
{
    public class ContentfulApiService : IContentfulApiService
    {
        private readonly ILogger<ContentfulApiService> _logger;
        private readonly IContentfulClient _contentfulClient;
        private readonly IContentfulManagementClient _managementClient;

        public ContentfulApiService(ILogger<ContentfulApiService> logger, 
            IContentfulClient contentfulClient,
            IContentfulManagementClient managementClient)
        {
            _logger = logger;
            _contentfulClient = contentfulClient;
            _managementClient = managementClient;
        }

        public Task<ContentfulCollection<T>> FetchEntries<T>(QueryBuilder<T> queryBuilder)
        {
            return _contentfulClient.GetEntries(queryBuilder);
        }

        public Task<T> FetchEntry<T>(string entryId, QueryBuilder<T> queryBuilder = null)
        {
            throw new NotImplementedException();
        }

        public Task CreateEntry(Entry<dynamic> entry, string contentTypeId)
        {
            return _managementClient.CreateEntry(entry, contentTypeId);
        }
    }
}
