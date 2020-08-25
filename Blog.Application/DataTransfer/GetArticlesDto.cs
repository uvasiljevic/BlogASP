using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.DataTransfer
{
    public class GetArticlesDto
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public string User { get; set; } 

        public IEnumerable<GetArticlesCategoriesDto> ArticleCategories { get; set; } = new List<GetArticlesCategoriesDto>();
        public IEnumerable<GetArticleRatesDto> ArticleRates { get; set; } = new List<GetArticleRatesDto>();
        public IEnumerable<GetCommentsDto> Comments { get; set; } = new List<GetCommentsDto>();


    }
}


    


