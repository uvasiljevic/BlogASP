using Blog.Application.DataTransfer;
using Blog.Application.Exceptions;
using Blog.Application.Queries;
using Blog.DataAccess;
using Blog.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Blog.Implementation.Queries
{
    public class EfGetOneArticleQuery : IGetOneArticleQuery
    {
		protected readonly BlogContext _context;

		public EfGetOneArticleQuery(BlogContext context)
		{
			_context = context;
		}

		public int Id => 31;

		public string Name => "Get one article";

		public GetArticlesDto Execute(int search)
		{
			var query = _context.Articles.Include(x => x.ArticleCategories)
										.ThenInclude(x => x.Category)
										.Include(x => x.User)
										.Include(x => x.ArticlesRates)
										.ThenInclude(x => x.Rate)
										.Include(x => x.ArticlesRates)
										.ThenInclude(x => x.User)
										.Include(x => x.Comments)
										.AsQueryable();

			var article = query.FirstOrDefault(a => a.Id == search);

			if (article == null)
			{
				throw new NotFoundEntityException(search, typeof(Articles));
			}

			var result = new GetArticlesDto
			{
				Id = article.Id,
				Subject = article.Subject,
				Text = article.Text,
				Description = article.Description,
				ArticleCategories = article.ArticleCategories.Select(ac => new GetArticlesCategoriesDto
				{
					Id = ac.CategoryId,
					Name = ac.Category.Name

				}),
				User = article.User.FirstName + ' ' + article.User.LastName,
				ArticleRates = article.ArticlesRates.Select(ar => new GetArticleRatesDto {
					Id = ar.RateId,
					User = ar.User.FirstName + ' ' + ar.User.LastName,
					Rate =ar.Rate.Rate
				}),
				Comments = article.Comments.Select(c => new GetCommentsDto { 
					Id = c.Id,
					Subject = c.Subject,
					Text = c.Text,
					User = c.User.FirstName + ' ' + c.User.LastName
				})
			};

			return result;
		}
	}
}
