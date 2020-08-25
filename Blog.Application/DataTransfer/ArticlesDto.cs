using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace Blog.Application.DataTransfer
{
    public class ArticlesDto
    {
       
        public string Subject { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
    }

    public class ArtileCategoriesDto
    {
        public int ArticleId { get; set; }
        public int CategoryId { get; set; }
    }
}
