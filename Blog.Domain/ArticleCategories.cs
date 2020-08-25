using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Domain
{
    public class ArticleCategories : ManyToMany
    {
        public int ArticleId { get; set; }
        public int CategoryId { get; set; }

        public virtual Categories Category { get; set; }
        public virtual Articles Article { get; set; }
    }
}
