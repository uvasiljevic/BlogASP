using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.DataTransfer
{
    public class CreateArticleDto
    {
        public string Subject { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public IEnumerable<CreateArticleCategoriesDto> ArticleCategories { get; set; } = new List<CreateArticleCategoriesDto>();

    }
    public class CreateArticleCategoriesDto
    {
        public int CategoryId { get; set; }
    }
}
