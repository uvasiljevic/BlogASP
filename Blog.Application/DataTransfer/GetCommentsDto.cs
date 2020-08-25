using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.DataTransfer
{
    public class GetCommentsDto
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }
        public string User { get; set; }
    }
}
