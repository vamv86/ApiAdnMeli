using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Exceptions
{
    public class InvalidColumnsException : Exception
    {
        public InvalidColumnsException(string message) : base(message) { }
    }
}
