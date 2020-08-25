using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Commands
{
    public interface IDeleteArticleCommand : ICommand<int>
    {
    }
}
