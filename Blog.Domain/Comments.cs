using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Domain
{
    public class Comments : Entity
    {
        public string Subject { get; set; }
        public string Text { get; set; }
        public int ArticleId { get; set; }
        public int UserId { get; set; }


        public Articles Article { get; set; }
        public Users User { get; set; }
    }
}
