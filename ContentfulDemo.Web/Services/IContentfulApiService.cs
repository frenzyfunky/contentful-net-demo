using Contentful.Core.Models;
using Contentful.Core.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContentfulDemo.Web.Services
{
    public interface IContentfulApiService
    {
        Task<ContentfulCollection<T>> FetchEntries<T>(QueryBuilder<T> queryBuilder);
        Task<T> FetchEntry<T>(string entryId, QueryBuilder<T> queryBuilder = null);
        Task CreateEntry(Entry<dynamic> entry, string contentTypeId);
    }
}
