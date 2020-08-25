using Blog.Application.DataTransfer;
using Blog.Application.Search;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Queries
{
    public interface IGetArticlesQuery : IQuery<ArticlesSearch, PagedResponse<GetArticlesDto>>
    {
    }
}
