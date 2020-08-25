using Blog.Application.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Search
{
    public class UsersSearch : PageSerach
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
