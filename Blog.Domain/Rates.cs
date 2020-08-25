using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Domain
{
    public class Rates
    {
        public int Id { get; set; }
        public int Rate { get; set; }

        public virtual ICollection<ArticlesRates> ArticlesRates { get; set; } = new HashSet<ArticlesRates>();
    }
}
