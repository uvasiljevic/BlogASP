using Blog.Application.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Search
{
    public class LogSearch : PageSerach
    {
        public string Name { get; set; }
        public string Actor { get; set; }
        public DateTime? MinDate { get; set; }
        public DateTime? MaxDate { get; set; }
       
    }
}
