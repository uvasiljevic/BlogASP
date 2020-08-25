using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Domain
{
    public class ArticlesRates : ManyToMany 
    {
        public int ArticleId { get; set; }
        public int RateId { get; set; }
        public int UserId { get; set; }

        public virtual Rates Rate { get; set; }
        public virtual Users User { get; set; }
        public virtual Articles Article { get; set; }
    }
}
