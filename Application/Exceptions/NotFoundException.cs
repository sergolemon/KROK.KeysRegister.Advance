using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {
        }

        public NotFoundException(object id) : base($"Source with id '{id}' was not found.")
        {
        }

        public NotFoundException() : base("Source was not found.")
        {

        }
    }
}
