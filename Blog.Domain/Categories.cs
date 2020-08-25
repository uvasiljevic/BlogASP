using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Domain
{
    public class Categories : Entity
    {
        public string Name { get; set; }
        public virtual ICollection<ArticleCategories> ArticleCategories { get; set; } = new HashSet<ArticleCategories>();

    }
}
