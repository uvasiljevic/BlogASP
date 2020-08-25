using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Domain
{
    public class Users : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual ICollection<Comments> Comments { get; set; } = new HashSet<Comments>();
        public virtual ICollection<ArticlesRates> ArticlesRates { get; set; } = new HashSet<ArticlesRates>();
        public virtual ICollection<UserUseCases> UserUseCases { get; set; }

    }
}
