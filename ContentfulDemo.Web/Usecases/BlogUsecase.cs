using Contentful.Core.Models;
using Contentful.Core.Search;
using ContentfulDemo.Web.Models;
using ContentfulDemo.Web.Models.FormModels;
using ContentfulDemo.Web.Models.ViewModels;
using ContentfulDemo.Web.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace ContentfulDemo.Web.Usecases
{
    public class BlogUsecase : IBlogUsecase
    {
        private readonly IContentfulApiService _contentfulApiService;

        public BlogUsecase(IContentfulApiService contentfulApiService)
        {
            _contentfulApiService = contentfulApiService;
        }

        public async Task CreateContactMessage(ContactMessage message)
        {
            var entry = new Entry<dynamic>();
            var fieldDict = new Dictionary<string, object>();

            var eo = new ExpandoObject();
            var eoColl = (ICollection<KeyValuePair<string, object>>)eo;

            foreach (var property in message.GetType().GetProperties())
            {
                fieldDict.Add(property.Name.ToLower(), new Dictionary<string, string> { { "en-US", property.GetValue(message).ToString() } });
            }

            foreach (var kvp in fieldDict)
            {
                eoColl.Add(kvp);
            }

            dynamic eoDynamic = eo;
            entry.Fields = eoDynamic;

            await _contentfulApiService.CreateEntry(entry, "contactMessage");
        }

        public async Task<HomepageViewModel> GetAboutPageData()
        {
            var queryBuilderHero = QueryBuilder<HomepageHero>.New.ContentTypeIs("homepageHero");
            var homepageHero = (await _contentfulApiService.FetchEntries(queryBuilderHero)).FirstOrDefault();

            var result = new HomepageViewModel
            {
                HomepageHero = homepageHero
            };

            return result;
        }

        public async Task<ContactViewModel> GetContactPageData()
        {
            var queryBuilderHero = QueryBuilder<Contact>.New.ContentTypeIs("contact");
            var contact = (await _contentfulApiService.FetchEntries(queryBuilderHero)).FirstOrDefault();

            return JsonConvert.DeserializeObject<ContactViewModel>(JsonConvert.SerializeObject(contact));
        }

        public async Task<HomepageViewModel> GetHomepageData()
        {
            var queryBuilderHero = QueryBuilder<HomepageHero>.New.ContentTypeIs("homepageHero");
            var homepageHero = (await _contentfulApiService.FetchEntries(queryBuilderHero)).FirstOrDefault();

            var queryBuilderPosts = QueryBuilder<Post>.New.ContentTypeIs("blogPost").Limit(12);
            var posts = await _contentfulApiService.FetchEntries(queryBuilderPosts);

            var result = new HomepageViewModel
            {
                HomepageHero = homepageHero,
                Posts = posts.ToList()
            };

            return result;
        }

        public async Task<Post> GetPostDetail(string slug)
        {
            var queryBuilder = QueryBuilder<Post>.New.ContentTypeIs("blogPost").FieldEquals(f => f.Slug, slug);
            var post = (await _contentfulApiService.FetchEntries(queryBuilder)).FirstOrDefault();

            return post;
        }

        public async Task<BlogViewModel> GetPosts(int? pageNumber)
        {
            var queryBuilderHero = QueryBuilder<BlogpageHero>.New.ContentTypeIs("blogpageHero");
            var hero = await _contentfulApiService.FetchEntries(queryBuilderHero);

            var queryBuilder = QueryBuilder<Post>.New
                .ContentTypeIs("blogPost")
                .OrderBy("-sys.createdAt")
                .Limit(10)
                .Skip((pageNumber.GetValueOrDefault(1) - 1) * 10);

            var posts = await _contentfulApiService.FetchEntries(queryBuilder);

            var result = new BlogViewModel
            {
                BlogpageHero = hero.FirstOrDefault(),
                Posts = posts.ToList(),
                CurrentPage = pageNumber.GetValueOrDefault(1),
                TotalPage = (int)Math.Ceiling((double)posts.Total / 10)
            };

            return result;
        }

        public async Task<CategoryViewModel> GetPostsByCategory(string category, string categoryId = null, int? pageNumber = null)
        {
            if (categoryId == null)
            {
                var categoryQuery = QueryBuilder<Category>.New.ContentTypeIs("category");
                var categories = await _contentfulApiService.FetchEntries(categoryQuery);

                categoryId = categories.FirstOrDefault(x => x.Name == category).Sys.Id;
            }

            var queryBuilder = QueryBuilder<Post>.New
                .ContentTypeIs("blogPost")
                .FieldEquals("fields.categories.sys.id", categoryId)
                .OrderBy("-sys.createdAt")
                .Limit(10)
                .Skip((pageNumber.GetValueOrDefault(1) - 1) * 10);

            var posts = await _contentfulApiService.FetchEntries(queryBuilder);

            var result = new CategoryViewModel
            {
                Category = posts.FirstOrDefault().Categories.FirstOrDefault(x => x.Name == category),
                Posts = posts.ToList(),
                CurrentPage = pageNumber.GetValueOrDefault(1),
                TotalPage = (int)Math.Ceiling((double)posts.Total / 10)
            };

            return result;
        }

        public async Task<SidebarViewModel> GetSidebarData()
        {
            var queryBuilder = QueryBuilder<Post>.New.ContentTypeIs("blogPost").OrderBy("sys.createdAt");
            var posts = await _contentfulApiService.FetchEntries(queryBuilder);

            var sidebarCategories = posts
                    .GroupBy(p => new { Category = p.Categories[0] })
                    .Select(x => new SidebarViewModel.Category
                    {
                        Name = x.Key.Category.Name,
                        Slug = x.Key.Category.Slug,
                        Count = x.Count(),
                        Id = x.Key.Category.Sys.Id
                    }).ToList();


            var result = new SidebarViewModel
            {
                Tags = posts.SelectMany(x => x.Tags.Select(y => y.Name)).Distinct().Select(x => new Tag { Name = x }).ToList(),
                Categories = sidebarCategories,
                PopularArticles = posts.OrderBy(p => p.Sys.CreatedAt).Take(5).ToList()
            };

            return result;
        }
    }
}
