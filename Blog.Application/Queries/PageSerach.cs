using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Queries
{
    public abstract class PageSerach
	{
		public int PerPage { get; set; } = 10;
		public int Page { get; set; }
	}
}
