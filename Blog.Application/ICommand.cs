using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application
{
    public interface ICommand<TRequest> : IUseCase
    {
        void Execute(TRequest request);
    }

    public interface IQuery<TSearch, TResult> : IUseCase
    {
        TResult Execute(TSearch search);
    }

    public interface ICommandUpdate<TRequest, TInt> : IUseCase
    {
        void Execute(TRequest request, TInt id);
    }

    public interface IUseCase
    {
        public int Id { get; }
        public string Name { get; }
    }
}
