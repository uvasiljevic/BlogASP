using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Domain
{
    public class Articles : Entity
    {
        public string Subject { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }

        public virtual Users User { get; set; }
        public virtual ICollection<Comments> Comments { get; set; } = new HashSet<Comments>();
        public virtual ICollection<ArticlesRates> ArticlesRates { get; set; } = new HashSet<ArticlesRates>();
        public virtual ICollection<ArticleCategories> ArticleCategories { get; set; } = new HashSet<ArticleCategories>();
    }
}
