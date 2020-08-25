using Blog.Application;
using Blog.Application.DataTransfer;
using Blog.Application.Queries;
using Blog.Application.Search;
using Blog.DataAccess;
using Blog.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Implementation.Queries
{
    public class EfGetArticlesQuery : IGetArticlesQuery
    {
        private readonly BlogContext _context;

        public EfGetArticlesQuery(BlogContext context)
        {
            _context = context;
        }

        public int Id => 30;

        public string Name => "Articles search";

        public PagedResponse<GetArticlesDto> Execute(ArticlesSearch search)
        {

            var query = _context.Articles.Include(x => x.ArticleCategories)
                                        .ThenInclude(x => x.Category)
                                        .Include(x => x.User)
                                        .AsQueryable();


            if (!string.IsNullOrEmpty(search.Subject) || !string.IsNullOrWhiteSpace(search.Subject))
            {
                query = query.Where(x => x.Subject.ToLower().Contains(search.Subject.ToLower()));
            }

            query = query.Where(x => x.IsActive == true);

            var skipCount = search.PerPage * (search.Page - 1);

            var response = new PagedResponse<GetArticlesDto>
            {
                TotalCount = query.Count(),
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                Items = query.Skip(skipCount)
                             .Take(search.PerPage)
                             .Select(a => new GetArticlesDto
                             {
                                 Id = a.Id,
                                 Subject = a.Subject,
                                 Text = a.Text,
                                 Description = a.Description,

                                 ArticleCategories = a.ArticleCategories.Select(ac => new GetArticlesCategoriesDto
                                 {
                                     Id = ac.CategoryId,
                                     Name = ac.Category.Name

                                 }),
                                 User = a.User.FirstName+' ' + a.User.FirstName

                             })
            };
            return response;
        }
    }
}
