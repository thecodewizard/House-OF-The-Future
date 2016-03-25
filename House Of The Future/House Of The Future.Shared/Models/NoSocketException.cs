using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House_Of_The_Future.Shared.Models
{
    public class NoSocketException : Exception
    {
        public NoSocketException()
        {
        }

        public NoSocketException(string message)
            : base(message)
        {
        }

        public NoSocketException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
