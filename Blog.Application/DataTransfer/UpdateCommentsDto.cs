using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.DataTransfer
{
    public class UpdateCommentsDto 
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }
        public int ArticleId { get; set; }
        public int UserId { get; set; }
    }
}
