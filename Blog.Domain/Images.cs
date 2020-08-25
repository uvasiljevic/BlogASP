using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Domain
{
    public class Images : Entity
    {
        public string Image { get; set; }

        public virtual ICollection<ArticlesImages> ArticlesImages { get; set; } = new HashSet<ArticlesImages>();



    }
}
