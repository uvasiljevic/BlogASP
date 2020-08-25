using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Domain
{
    public class ArticlesImages : ManyToMany
    {
        public int ArticleId { get; set; }
        public int ImageId { get; set; }
        public Articles Article { get; set; }
        public Images Image { get; set; }
    }
}
