using Blog.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Api.Core
{
    public class AnonymousActor : IApplicationActor
    {
        public int Id => 0;

        public string Identity => "Anonymus user";

        public IEnumerable<int> AllowedUseCases => new List<int> { 30,31, 4,6 };
    }
}
