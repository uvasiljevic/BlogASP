using Blog.Application.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Search
{
    public class ArticlesSearch : PageSerach
    {
        public string Subject { get; set; }
    }
}
