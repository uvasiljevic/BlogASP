using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.DataTransfer
{
    public class GetArticleRatesDto
    {
        public int Id { get; set; }
        public string User { get; set; }
        public int Rate { get; set; }
    }
}
