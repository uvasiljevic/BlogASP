using Blog.Application;
using Blog.DataAccess;
using Blog.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Implementation.Logging
{
    public class UseCaseLogger : IUseCaseLogger
    {
        private readonly BlogContext _context;

        public UseCaseLogger(BlogContext context)
        {
            _context = context;
        }

        public void Log(IUseCase useCase, IApplicationActor actor, object useCaseData)
        {
            _context.UseCaseLogs.Add(new UseCaseLogs
            {
                Actor = actor.Identity,
                Date = DateTime.UtcNow,
                Data = JsonConvert.SerializeObject(useCaseData),
                Name = useCase.Name
            });

            _context.SaveChanges();
        }
    }
    
}
