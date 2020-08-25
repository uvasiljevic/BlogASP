using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Exceptions
{
    public class NotFoundEntityException : Exception
    {
        public NotFoundEntityException(int id, Type type)
            : base($"Entity of type {type.Name} with an id of {id} was not found.")
        {

        }
    }
}
