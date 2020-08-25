using Blog.Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Commands
{
    public interface ICreateCommentCommand : ICommand<CommentsDto>
    {

    }
}
